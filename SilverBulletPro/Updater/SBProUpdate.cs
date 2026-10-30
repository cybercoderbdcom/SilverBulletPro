using System;
using System.Collections.Generic;

namespace SilverBulletPro.Updater
{
	// Token: 0x020001D1 RID: 465
	public class SBProUpdate
	{
		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000E93 RID: 3731 RVA: 0x0004AEE8 File Offset: 0x000490E8
		// (set) Token: 0x06000E94 RID: 3732 RVA: 0x0004AEF0 File Offset: 0x000490F0
		public string Version { get; set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x0004AEF9 File Offset: 0x000490F9
		// (set) Token: 0x06000E96 RID: 3734 RVA: 0x0004AF01 File Offset: 0x00049101
		public bool Available { get; set; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000E97 RID: 3735 RVA: 0x0004AF0A File Offset: 0x0004910A
		// (set) Token: 0x06000E98 RID: 3736 RVA: 0x0004AF12 File Offset: 0x00049112
		public string Message { get; set; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000E99 RID: 3737 RVA: 0x0004AF1B File Offset: 0x0004911B
		// (set) Token: 0x06000E9A RID: 3738 RVA: 0x0004AF23 File Offset: 0x00049123
		public string DownloadUrl { get; set; }

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000E9B RID: 3739 RVA: 0x0004AF2C File Offset: 0x0004912C
		// (set) Token: 0x06000E9C RID: 3740 RVA: 0x0004AF34 File Offset: 0x00049134
		public List<ReleaseNotes> ReleaseNotes { get; set; } = new List<ReleaseNotes>();
	}
}
