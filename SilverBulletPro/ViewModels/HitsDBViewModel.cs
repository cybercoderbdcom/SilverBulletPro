using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Repositories;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B7 RID: 439
	public class HitsDBViewModel : ViewModelBase, IHitsDB
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x000451E7 File Offset: 0x000433E7
		// (set) Token: 0x06000C86 RID: 3206 RVA: 0x000451EF File Offset: 0x000433EF
		public ObservableCollection<Hit> HitsCollection
		{
			get
			{
				return this.hitsCollection;
			}
			private set
			{
				this.hitsCollection = value;
				this.OnPropertyChanged("HitsCollection");
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x00045203 File Offset: 0x00043403
		public int Total
		{
			get
			{
				return this.HitsCollection.Count;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000C88 RID: 3208 RVA: 0x00045210 File Offset: 0x00043410
		public IEnumerable<Hit> Hits
		{
			get
			{
				return this.HitsCollection;
			}
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x00045218 File Offset: 0x00043418
		public HitsDBViewModel()
		{
			this._repo = new LiteDBRepository<Hit>(Constants.DataBaseFile, "hits");
			this.HitsCollection = new ObservableCollection<Hit>();
			this.HookFilters();
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000C8A RID: 3210 RVA: 0x00045272 File Offset: 0x00043472
		public List<string> ConfigsList
		{
			get
			{
				return (from x in this.HitsCollection
				select x.ConfigName).Distinct<string>().ToList<string>();
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x000452A8 File Offset: 0x000434A8
		// (set) Token: 0x06000C8C RID: 3212 RVA: 0x000452B0 File Offset: 0x000434B0
		public string SearchString
		{
			get
			{
				return this.searchString;
			}
			set
			{
				this.searchString = value;
				this.OnPropertyChanged("SearchString");
				CollectionViewSource.GetDefaultView(this.HitsCollection).Refresh();
				this.OnPropertyChanged("Filtered");
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x000452DF File Offset: 0x000434DF
		// (set) Token: 0x06000C8E RID: 3214 RVA: 0x000452E7 File Offset: 0x000434E7
		public string TypeFilter
		{
			get
			{
				return this.typeFilter;
			}
			set
			{
				this.typeFilter = value;
				this.OnPropertyChanged("TypeFilter");
				CollectionViewSource.GetDefaultView(this.HitsCollection).Refresh();
				this.OnPropertyChanged("Filtered");
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000C8F RID: 3215 RVA: 0x00045316 File Offset: 0x00043516
		// (set) Token: 0x06000C90 RID: 3216 RVA: 0x0004531E File Offset: 0x0004351E
		public string ConfigFilter
		{
			get
			{
				return this.configFilter;
			}
			set
			{
				this.configFilter = value;
				this.OnPropertyChanged("ConfigFilter");
				CollectionViewSource.GetDefaultView(this.HitsCollection).Refresh();
				this.OnPropertyChanged("Filtered");
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x0004534D File Offset: 0x0004354D
		public int Filtered
		{
			get
			{
				return this.HitsCollection.Count((Hit h) => this.HitsFilter(h));
			}
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x00045366 File Offset: 0x00043566
		public void HookFilters()
		{
			((CollectionView)CollectionViewSource.GetDefaultView(this.HitsCollection)).Filter = new Predicate<object>(this.HitsFilter);
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x0004538C File Offset: 0x0004358C
		private bool HitsFilter(object item)
		{
			return !((item as Hit).Type != this.TypeFilter) && (!(this.ConfigFilter != HitsDBViewModel.DefaultFilter) || !((item as Hit).ConfigName != this.ConfigFilter)) && (string.IsNullOrEmpty(this.SearchString) || (item as Hit).CapturedData.ToCaptureString().ToLower().Contains(this.SearchString.ToLower()));
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x00045413 File Offset: 0x00043613
		public void Add(Hit hit)
		{
			this.HitsCollection.Add(hit);
			this._repo.Add(hit);
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x0004542D File Offset: 0x0004362D
		public void RefreshList()
		{
			this.HitsCollection = new ObservableCollection<Hit>(this._repo.Get());
			this.HookFilters();
			this.OnPropertyChanged("Total");
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x00045456 File Offset: 0x00043656
		public void Update(Hit hit)
		{
			this._repo.Update(hit);
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x00045464 File Offset: 0x00043664
		public void Remove(Hit hit)
		{
			this.HitsCollection.Remove(hit);
			this._repo.Remove(hit);
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x00045480 File Offset: 0x00043680
		public void Remove(IEnumerable<Hit> hits)
		{
			Hit[] array = hits.ToArray<Hit>();
			foreach (Hit item in array)
			{
				this.HitsCollection.Remove(item);
			}
			if (this.HitsCollection.Count == 0)
			{
				this.OnPropertyChanged("HitsCollection");
				this.OnPropertyChanged("Filtered");
			}
			this._repo.Remove(array);
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x000454E4 File Offset: 0x000436E4
		public void RemoveAll()
		{
			this.HitsCollection.Clear();
			this.OnPropertyChanged("HitsCollection");
			this.OnPropertyChanged("Filtered");
			this._repo.RemoveAll();
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x00045514 File Offset: 0x00043714
		public void DeleteDuplicates()
		{
			List<Hit> hits = (from h in this.HitsCollection
			group h by h.GetHashCode(GlobalData.SBSettings.General.IgnoreWordlistOnHitDedupe) into g
			where g.Count<Hit>() > 1
			select g).SelectMany((IGrouping<int, Hit> g) => (from h in g
			orderby h.Date
			select h).Reverse<Hit>().Skip(1)).ToList<Hit>();
			this.OnPropertyChanged("HitsCollection");
			this.OnPropertyChanged("Filtered");
			this.Remove(hits);
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x000455B8 File Offset: 0x000437B8
		public void DeleteFiltered()
		{
			List<Hit> hits = (from h in this.HitsCollection
			where (string.IsNullOrEmpty(this.SearchString) || h.CapturedString.ToLower().Contains(this.SearchString.ToLower())) && (this.ConfigFilter == "All" || h.ConfigName == this.ConfigFilter) && h.Type == this.TypeFilter
			select h).ToList<Hit>();
			this.OnPropertyChanged("HitsCollection");
			this.OnPropertyChanged("Filtered");
			this.Remove(hits);
		}

		// Token: 0x04000647 RID: 1607
		public LiteDBRepository<Hit> _repo;

		// Token: 0x04000648 RID: 1608
		private ObservableCollection<Hit> hitsCollection;

		// Token: 0x04000649 RID: 1609
		public static readonly string DefaultFilter = "All";

		// Token: 0x0400064A RID: 1610
		private string searchString = "";

		// Token: 0x0400064B RID: 1611
		private string typeFilter = "SUCCESS";

		// Token: 0x0400064C RID: 1612
		private string configFilter = HitsDBViewModel.DefaultFilter;
	}
}
