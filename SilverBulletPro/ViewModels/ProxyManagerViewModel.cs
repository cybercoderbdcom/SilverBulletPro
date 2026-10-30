using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Data;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Repositories;
using SilverBulletPro.Requests;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001BD RID: 445
	public class ProxyManagerViewModel : ViewModelBase, IProxyManager
	{
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x00046591 File Offset: 0x00044791
		public ProxyCheckerViewModel ProxyChecker
		{
			get
			{
				return GlobalData.ProxyChecker;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000D07 RID: 3335 RVA: 0x00046598 File Offset: 0x00044798
		// (set) Token: 0x06000D08 RID: 3336 RVA: 0x000465A0 File Offset: 0x000447A0
		public ObservableCollection<Proxylist> ProxylistsCollection
		{
			get
			{
				return this.proxylistsCollection;
			}
			private set
			{
				this.proxylistsCollection = value;
				this.OnPropertyChanged("ProxylistsCollection");
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000D09 RID: 3337 RVA: 0x000465B4 File Offset: 0x000447B4
		public int Total
		{
			get
			{
				return this.ProxylistsCollection.Count;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x000465C1 File Offset: 0x000447C1
		public IEnumerable<Proxylist> Proxylists
		{
			get
			{
				return this.ProxylistsCollection;
			}
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x000465C9 File Offset: 0x000447C9
		public ProxyManagerViewModel()
		{
			this._repo = new LiteDBRepository<Proxylist>(Constants.DataBaseFile, "proxylists");
			this.ProxylistsCollection = new ObservableCollection<Proxylist>();
			this.RefreshList();
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x00046604 File Offset: 0x00044804
		public Proxylist GetProxylistByName(string name)
		{
			return (from x in this.ProxylistsCollection
			where x.Name == name
			select x).First<Proxylist>();
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0004663A File Offset: 0x0004483A
		public static Proxylist FileToProxylist(string path, ProxyType proxyType)
		{
			return new Proxylist(System.IO.Path.GetFileNameWithoutExtension(path), proxyType.ToString(), path, 2, DateTime.Now, true, false);
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0004665D File Offset: 0x0004485D
		public static Proxylist RefreshProxylist(Proxylist proxylist)
		{
			return new Proxylist(System.IO.Path.GetFileNameWithoutExtension(proxylist.Path), proxylist.Type, proxylist.Path, proxylist.Working, proxylist.LastChecked, true, false)
			{
				Proxies = proxylist.Proxies
			};
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x00046695 File Offset: 0x00044895
		public static Proxylist ArrayToProxylist(IList<CProxy> proxies, string name, ProxyType proxyType)
		{
			return new Proxylist(name, proxyType.ToString(), proxies, 2, DateTime.Now, true, false);
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x000466B4 File Offset: 0x000448B4
		public List<CProxy> GetProxies(Proxylist proxylist, ProxyType defaultType = 0, string defaultUsername = "", string defaultPassword = "")
		{
			if (!(proxylist.Path == "-") && !string.IsNullOrWhiteSpace(proxylist.Path))
			{
				IEnumerable<string> source = File.ReadLines(proxylist.Path);
				List<CProxy> list = new List<CProxy>();
				foreach (string text in (from p in source
				where !string.IsNullOrEmpty(p)
				select p).Distinct<string>().ToList<string>())
				{
					try
					{
						CProxy cproxy = new CProxy().Parse(text, defaultType, defaultUsername, defaultPassword);
						if (!cproxy.IsNumeric || cproxy.IsValidNumeric)
						{
							list.Add(cproxy);
						}
					}
					catch
					{
					}
				}
				return list;
			}
			IList<CProxy> proxies = proxylist.Proxies;
			if (proxies == null)
			{
				return null;
			}
			return proxies.ToList<CProxy>();
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000D11 RID: 3345 RVA: 0x000467A4 File Offset: 0x000449A4
		// (set) Token: 0x06000D12 RID: 3346 RVA: 0x000467AC File Offset: 0x000449AC
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
				CollectionViewSource.GetDefaultView(this.ProxylistsCollection).Refresh();
			}
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x000467D0 File Offset: 0x000449D0
		public void HookFilters()
		{
			((CollectionView)CollectionViewSource.GetDefaultView(this.ProxylistsCollection)).Filter = new Predicate<object>(this.ProxylistsFilter);
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x000467F3 File Offset: 0x000449F3
		private bool ProxylistsFilter(object item)
		{
			return (item as Proxylist).Name.ToLower().Contains(this.searchString.ToLower());
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000D15 RID: 3349 RVA: 0x00046815 File Offset: 0x00044A15
		// (set) Token: 0x06000D16 RID: 3350 RVA: 0x0004681D File Offset: 0x00044A1D
		public string Type
		{
			get
			{
				return this.type;
			}
			private set
			{
				this.type = value;
				this.OnPropertyChanged("Type");
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000D17 RID: 3351 RVA: 0x00046831 File Offset: 0x00044A31
		// (set) Token: 0x06000D18 RID: 3352 RVA: 0x00046839 File Offset: 0x00044A39
		public string Name
		{
			get
			{
				return this.name;
			}
			private set
			{
				this.name = value;
				this.OnPropertyChanged("Name");
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000D19 RID: 3353 RVA: 0x0004684D File Offset: 0x00044A4D
		// (set) Token: 0x06000D1A RID: 3354 RVA: 0x00046855 File Offset: 0x00044A55
		public string Path
		{
			get
			{
				return this.path;
			}
			private set
			{
				this.path = value;
				this.OnPropertyChanged("Path");
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x00046869 File Offset: 0x00044A69
		// (set) Token: 0x06000D1C RID: 3356 RVA: 0x00046871 File Offset: 0x00044A71
		public string Working
		{
			get
			{
				return this.working;
			}
			private set
			{
				this.working = value;
				this.OnPropertyChanged("Working");
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x00046885 File Offset: 0x00044A85
		// (set) Token: 0x06000D1E RID: 3358 RVA: 0x0004688D File Offset: 0x00044A8D
		public string LastChecked
		{
			get
			{
				return this.lastChecked;
			}
			private set
			{
				this.lastChecked = value;
				this.OnPropertyChanged("LastChecked");
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000D1F RID: 3359 RVA: 0x000468A4 File Offset: 0x00044AA4
		public ProxyManagerStats Stats
		{
			get
			{
				return default(ProxyManagerStats);
			}
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x000468BA File Offset: 0x00044ABA
		public void Add(Proxylist proxy)
		{
			this.ProxylistsCollection.Add(proxy);
			this._repo.Add(proxy);
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x000468D4 File Offset: 0x00044AD4
		public void AddRange(IEnumerable<Proxylist> proxies)
		{
			foreach (Proxylist item in proxies)
			{
				this.ProxylistsCollection.Add(item);
			}
			this._repo.Add(proxies);
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x00046930 File Offset: 0x00044B30
		public void RefreshList()
		{
			this.ProxylistsCollection = new ObservableCollection<Proxylist>(this._repo.Get());
			this.HookFilters();
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x0004694E File Offset: 0x00044B4E
		public void Update(Proxylist proxy)
		{
			this._repo.Update(proxy);
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x0004695C File Offset: 0x00044B5C
		public void Remove(Proxylist proxy)
		{
			this.ProxylistsCollection.Remove(proxy);
			this._repo.Remove(proxy);
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x00046978 File Offset: 0x00044B78
		public void Remove(IEnumerable<Proxylist> proxies)
		{
			Proxylist[] array = proxies.ToArray<Proxylist>();
			foreach (Proxylist item in array)
			{
				this.ProxylistsCollection.Remove(item);
			}
			this._repo.Remove(array);
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x000469B9 File Offset: 0x00044BB9
		public void RemoveAll()
		{
			this.ProxylistsCollection.Clear();
			this._repo.RemoveAll();
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x000469D1 File Offset: 0x00044BD1
		public void RemoveNotWorking()
		{
			this.Remove(from p in this.Proxylists
			where p.Working == 1
			select p);
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x00046A04 File Offset: 0x00044C04
		public void RemoveDuplicates()
		{
			IEnumerable<Proxylist> proxies = (from p in this.Proxylists
			group p by p.Path into g
			where g.Count<Proxylist>() > 1
			select g).SelectMany((IGrouping<string, Proxylist> g) => (from p in g
			orderby p.Path
			select p).Reverse<Proxylist>().Skip(1));
			this.Remove(proxies);
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x00046A8C File Offset: 0x00044C8C
		public void DeleteNotFound()
		{
			for (int i = 0; i < this.ProxylistsCollection.Count; i++)
			{
				Proxylist proxylist = this.ProxylistsCollection[i];
				if (proxylist.IsFile && !File.Exists(proxylist.Path))
				{
					this.Remove(proxylist);
					i--;
				}
			}
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x00046ADC File Offset: 0x00044CDC
		public void RemoveUntested()
		{
			this.Remove(from p in this.Proxylists
			where p.Working == 2
			select p);
		}

		// Token: 0x0400066D RID: 1645
		private LiteDBRepository<Proxylist> _repo;

		// Token: 0x0400066E RID: 1646
		private ObservableCollection<Proxylist> proxylistsCollection;

		// Token: 0x0400066F RID: 1647
		private string searchString = "";

		// Token: 0x04000670 RID: 1648
		private string type;

		// Token: 0x04000671 RID: 1649
		private string name;

		// Token: 0x04000672 RID: 1650
		private string path;

		// Token: 0x04000673 RID: 1651
		private string working;

		// Token: 0x04000674 RID: 1652
		private string lastChecked;
	}
}
