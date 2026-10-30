using System;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro
{
	// Token: 0x0200000E RID: 14
	public class GlobalSettings : ISettings
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002D3D File Offset: 0x00000F3D
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002D45 File Offset: 0x00000F45
		public EnvironmentSettings Environment { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002D4E File Offset: 0x00000F4E
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002D56 File Offset: 0x00000F56
		public CoreSettingsViewModel CoreSettings { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002D5F File Offset: 0x00000F5F
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00002D67 File Offset: 0x00000F67
		public ProxyManagerSettings ProxyManagerSettings { get; set; }
	}
}
