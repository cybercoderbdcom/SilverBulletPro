using System;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001BB RID: 443
	public class MainWindowViewModel : ViewModelBase
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x00045DF5 File Offset: 0x00043FF5
		// (set) Token: 0x06000CD6 RID: 3286 RVA: 0x00045DFD File Offset: 0x00043FFD
		public int SilverZoneBadge
		{
			get
			{
				return this.silverZoneBadge;
			}
			set
			{
				this.SetProperty<int>(ref this.silverZoneBadge, value, "SilverZoneBadge");
			}
		}

		// Token: 0x0400065C RID: 1628
		private int silverZoneBadge;
	}
}
