using System;
using System.Text;

namespace SilverBulletPro.Models
{
	// Token: 0x020001E5 RID: 485
	public class EncodeModel
	{
		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000F58 RID: 3928 RVA: 0x0004D138 File Offset: 0x0004B338
		// (set) Token: 0x06000F59 RID: 3929 RVA: 0x0004D140 File Offset: 0x0004B340
		public EncodingInfo Info { get; set; }

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0004D149 File Offset: 0x0004B349
		// (set) Token: 0x06000F5B RID: 3931 RVA: 0x0004D151 File Offset: 0x0004B351
		public string Name { get; set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000F5C RID: 3932 RVA: 0x0004D15A File Offset: 0x0004B35A
		// (set) Token: 0x06000F5D RID: 3933 RVA: 0x0004D162 File Offset: 0x0004B362
		public string DisplayName { get; set; }

		// Token: 0x06000F5E RID: 3934 RVA: 0x0004D16B File Offset: 0x0004B36B
		public override string ToString()
		{
			return this.DisplayName;
		}
	}
}
