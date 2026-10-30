using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Repositories;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001CF RID: 463
	public class WordlistManagerViewModel : ViewModelBase, IWordlistManager
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x0004AB21 File Offset: 0x00048D21
		// (set) Token: 0x06000E81 RID: 3713 RVA: 0x0004AB29 File Offset: 0x00048D29
		public ObservableCollection<Wordlist> WordlistsCollection
		{
			get
			{
				return this.wordlistsCollection;
			}
			private set
			{
				this.wordlistsCollection = value;
				this.OnPropertyChanged("WordlistsCollection");
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x0004AB3D File Offset: 0x00048D3D
		public int Total
		{
			get
			{
				return this.WordlistsCollection.Count;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000E83 RID: 3715 RVA: 0x0004AB4A File Offset: 0x00048D4A
		public IEnumerable<Wordlist> Wordlists
		{
			get
			{
				return this.WordlistsCollection;
			}
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x0004AB52 File Offset: 0x00048D52
		public WordlistManagerViewModel()
		{
			this._repo = new LiteDBRepository<Wordlist>(Constants.DataBaseFile, "wordlists");
			this.WordlistsCollection = new ObservableCollection<Wordlist>();
			this.RefreshList();
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x0004AB8B File Offset: 0x00048D8B
		// (set) Token: 0x06000E86 RID: 3718 RVA: 0x0004AB93 File Offset: 0x00048D93
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
				CollectionViewSource.GetDefaultView(this.WordlistsCollection).Refresh();
				this.OnPropertyChanged("Total");
			}
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x0004ABC2 File Offset: 0x00048DC2
		public void HookFilters()
		{
			((CollectionView)CollectionViewSource.GetDefaultView(this.WordlistsCollection)).Filter = new Predicate<object>(this.WordlistsFilter);
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x0004ABE5 File Offset: 0x00048DE5
		private bool WordlistsFilter(object item)
		{
			return (item as Wordlist).Name.ToLower().Contains(this.searchString.ToLower());
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x0004AC08 File Offset: 0x00048E08
		public Wordlist GetWordlistByName(string name)
		{
			return (from x in this.WordlistsCollection
			where x.Name == name
			select x).First<Wordlist>();
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x0004AC40 File Offset: 0x00048E40
		public static Wordlist FileToWordlist(string path, bool countLines = true)
		{
			Wordlist wordlist = new Wordlist(Path.GetFileNameWithoutExtension(path), path, GlobalData.Settings.Environment.WordlistTypes.First<WordlistType>().Name, "", countLines, false, false);
			wordlist.Type = GlobalData.Settings.Environment.RecognizeWordlistType(wordlist.FirstLine);
			return wordlist;
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x0004AC98 File Offset: 0x00048E98
		public static Wordlist CreateNumberList(long start, long count)
		{
			string randomFileName = Path.GetRandomFileName();
			string empty = string.Empty;
			string name = GlobalData.Settings.Environment.WordlistTypes.First<WordlistType>().Name;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendFormatted<long>(start);
			defaultInterpolatedStringHandler.AppendLiteral("...");
			defaultInterpolatedStringHandler.AppendFormatted<long>(count);
			Wordlist wordlist = new Wordlist(randomFileName, empty, name, defaultInterpolatedStringHandler.ToStringAndClear(), true, false, false);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendFormatted<long>(start);
			defaultInterpolatedStringHandler.AppendLiteral("...");
			defaultInterpolatedStringHandler.AppendFormatted<long>(count);
			wordlist.Purpose = defaultInterpolatedStringHandler.ToStringAndClear();
			return wordlist;
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x0004AD30 File Offset: 0x00048F30
		public void Add(Wordlist wordlist)
		{
			if (this.WordlistsCollection.Any((Wordlist w) => w.Path == wordlist.Path && !w.Purpose.Contains("...")))
			{
				throw new Exception("Wordlist already present: " + wordlist.Path);
			}
			this.WordlistsCollection.Add(wordlist);
			this._repo.Add(wordlist);
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x0004ADA0 File Offset: 0x00048FA0
		public void RefreshList()
		{
			this.WordlistsCollection = new ObservableCollection<Wordlist>(this._repo.Get());
			this._repo.Disconnect(true);
			this.HookFilters();
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x0004ADCA File Offset: 0x00048FCA
		public void Update(Wordlist wordlist)
		{
			this._repo.Update(wordlist);
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x0004ADD8 File Offset: 0x00048FD8
		public void Remove(Wordlist wordlist)
		{
			this.WordlistsCollection.Remove(wordlist);
			this._repo.Remove(wordlist);
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x0004ADF3 File Offset: 0x00048FF3
		public void RemoveAll()
		{
			this.WordlistsCollection.Clear();
			this._repo.RemoveAll();
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x0004AE0C File Offset: 0x0004900C
		public void DeleteNotFound()
		{
			for (int i = 0; i < this.WordlistsCollection.Count; i++)
			{
				Wordlist wordlist = this.WordlistsCollection[i];
				if (!File.Exists(wordlist.Path))
				{
					this.Remove(wordlist);
					i--;
				}
			}
		}

		// Token: 0x040006EF RID: 1775
		private LiteDBRepository<Wordlist> _repo;

		// Token: 0x040006F0 RID: 1776
		private ObservableCollection<Wordlist> wordlistsCollection;

		// Token: 0x040006F1 RID: 1777
		private string searchString = "";
	}
}
