using System;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001C7 RID: 455
	public class SilverZoneViewModel : ViewModelBase
	{
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x00047EE6 File Offset: 0x000460E6
		// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x00047EEE File Offset: 0x000460EE
		public int AdsBadge
		{
			get
			{
				return this.adsBadge;
			}
			set
			{
				this.adsBadge = value;
				this.OnPropertyChanged("AdsBadge");
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00047F02 File Offset: 0x00046102
		// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x00047F0A File Offset: 0x0004610A
		public int VerifiedMarketBadge
		{
			get
			{
				return this.verifiedMarketBadge;
			}
			set
			{
				this.verifiedMarketBadge = value;
				this.OnPropertyChanged("VerifiedMarketBadge");
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x00047F1E File Offset: 0x0004611E
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x00047F26 File Offset: 0x00046126
		public int NotifBadge
		{
			get
			{
				return this.notifBadge;
			}
			set
			{
				this.notifBadge = value;
				this.OnPropertyChanged("NotifBadge");
			}
		}

		// Token: 0x040006BE RID: 1726
		private int adsBadge;

		// Token: 0x040006BF RID: 1727
		private int verifiedMarketBadge;

		// Token: 0x040006C0 RID: 1728
		private int notifBadge;
	}
}
