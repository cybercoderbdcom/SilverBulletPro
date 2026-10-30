using System;
using System.Text.RegularExpressions;

namespace SilverBulletPro.Updater
{
	// Token: 0x020001D3 RID: 467
	public class LatestRelease
	{
		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000EA1 RID: 3745 RVA: 0x0004AF69 File Offset: 0x00049169
		// (set) Token: 0x06000EA2 RID: 3746 RVA: 0x0004AF71 File Offset: 0x00049171
		public string Name { get; set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x0004AF7A File Offset: 0x0004917A
		// (set) Token: 0x06000EA4 RID: 3748 RVA: 0x0004AF82 File Offset: 0x00049182
		public Assets[] Assets { get; set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x0004AF8B File Offset: 0x0004918B
		// (set) Token: 0x06000EA6 RID: 3750 RVA: 0x0004AF93 File Offset: 0x00049193
		public string Body { get; set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x0004AF9C File Offset: 0x0004919C
		public Version Ver
		{
			get
			{
				return Version.Parse(Regex.Match(this.Name, "\\d+(\\.\\d+)+").Value);
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x0004AFB8 File Offset: 0x000491B8
		public bool Available
		{
			get
			{
				return this.Ver > Version.Parse(Regex.Match(GlobalData.AppVersion, "\\d+(\\.\\d+)+").Value);
			}
		}
	}
}
