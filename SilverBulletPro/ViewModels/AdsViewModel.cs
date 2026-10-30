using System;
using System.Collections.ObjectModel;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Models;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001C8 RID: 456
	public class AdsViewModel : ViewModelBase
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x00047F42 File Offset: 0x00046142
		// (set) Token: 0x06000DD7 RID: 3543 RVA: 0x00047F4A File Offset: 0x0004614A
		public ObservableCollection<AdModel> AdsDataList
		{
			get
			{
				return this.adsDataList;
			}
			set
			{
				this.SetProperty<ObservableCollection<AdModel>>(ref this.adsDataList, value, "AdsDataList");
			}
		}

		// Token: 0x040006C1 RID: 1729
		private ObservableCollection<AdModel> adsDataList = new ObservableCollection<AdModel>();
	}
}
