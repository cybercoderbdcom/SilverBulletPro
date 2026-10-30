using System;
using System.Collections.ObjectModel;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Models;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001CA RID: 458
	public class VerifiedMarketViewModel : ViewModelBase
	{
		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000DDC RID: 3548 RVA: 0x00047FA2 File Offset: 0x000461A2
		// (set) Token: 0x06000DDD RID: 3549 RVA: 0x00047FAA File Offset: 0x000461AA
		public ObservableCollection<MarketModel> MarketDataList
		{
			get
			{
				return this.marketDataList;
			}
			set
			{
				this.SetProperty<ObservableCollection<MarketModel>>(ref this.marketDataList, value, "MarketDataList");
			}
		}

		// Token: 0x040006C3 RID: 1731
		private ObservableCollection<MarketModel> marketDataList = new ObservableCollection<MarketModel>();
	}
}
