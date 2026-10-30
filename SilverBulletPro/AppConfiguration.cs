using System;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Configuration;

namespace SilverBulletPro
{
	// Token: 0x0200000C RID: 12
	public struct AppConfiguration : IApplication
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002A90 File Offset: 0x00000C90
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002A98 File Offset: 0x00000C98
		public IRunnerManager RunnerManager { readonly get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002AA1 File Offset: 0x00000CA1
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002AA9 File Offset: 0x00000CA9
		public IProxyManager ProxyManager { readonly get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002AB2 File Offset: 0x00000CB2
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002ABA File Offset: 0x00000CBA
		public IProxyChecker ProxyChecker { readonly get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002AC3 File Offset: 0x00000CC3
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002ACB File Offset: 0x00000CCB
		public IWordlistManager WordlistManager { readonly get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002AD4 File Offset: 0x00000CD4
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002ADC File Offset: 0x00000CDC
		public IConfigManager ConfigManager { readonly get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002AE5 File Offset: 0x00000CE5
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002AED File Offset: 0x00000CED
		public IHitsDB HitsDB { readonly get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002AF6 File Offset: 0x00000CF6
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002AFE File Offset: 0x00000CFE
		public IAlerter Alerter { readonly get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002B07 File Offset: 0x00000D07
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002B0F File Offset: 0x00000D0F
		public ILogger Logger { readonly get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002B18 File Offset: 0x00000D18
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002B20 File Offset: 0x00000D20
		public ISettings Settings { readonly get; set; }
	}
}
