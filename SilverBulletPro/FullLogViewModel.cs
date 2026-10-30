using System;
using System.Collections.Generic;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro
{
	// Token: 0x0200002B RID: 43
	public class FullLogViewModel : ViewModelBase
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600018E RID: 398 RVA: 0x0000CD37 File Offset: 0x0000AF37
		// (set) Token: 0x0600018F RID: 399 RVA: 0x0000CD3F File Offset: 0x0000AF3F
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
				this.OnPropertyChanged("SearchProgress");
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000CD5E File Offset: 0x0000AF5E
		// (set) Token: 0x06000191 RID: 401 RVA: 0x0000CD66 File Offset: 0x0000AF66
		public List<int> Indexes
		{
			get
			{
				return this.indexes;
			}
			set
			{
				this.indexes = value;
				this.OnPropertyChanged("TotalSearchMatches");
				this.OnPropertyChanged("CurrentSearchMatch");
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000192 RID: 402 RVA: 0x0000CD85 File Offset: 0x0000AF85
		public int TotalSearchMatches
		{
			get
			{
				return this.Indexes.Count;
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000CD92 File Offset: 0x0000AF92
		public void UpdateTotalSearchMatches()
		{
			this.OnPropertyChanged("TotalSearchMatches");
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000194 RID: 404 RVA: 0x0000CD9F File Offset: 0x0000AF9F
		// (set) Token: 0x06000195 RID: 405 RVA: 0x0000CDA7 File Offset: 0x0000AFA7
		public int CurrentSearchMatch
		{
			get
			{
				return this.currentSearchMatch;
			}
			set
			{
				this.currentSearchMatch = value;
				this.OnPropertyChanged("CurrentSearchMatch");
			}
		}

		// Token: 0x040000D1 RID: 209
		private string searchString = "";

		// Token: 0x040000D2 RID: 210
		private List<int> indexes = new List<int>();

		// Token: 0x040000D3 RID: 211
		private int currentSearchMatch;
	}
}
