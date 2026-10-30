using System;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Crypto;

namespace SilverBulletPro.Models
{
	// Token: 0x020001E7 RID: 487
	internal class HashFuncModel
	{
		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000F64 RID: 3940 RVA: 0x0004D19C File Offset: 0x0004B39C
		// (set) Token: 0x06000F65 RID: 3941 RVA: 0x0004D1A4 File Offset: 0x0004B3A4
		public HashFunc HashFunc { get; set; }

		// Token: 0x06000F66 RID: 3942 RVA: 0x0004D1AD File Offset: 0x0004B3AD
		public override string ToString()
		{
			return EnumExtension.GetDescription(this.HashFunc);
		}
	}
}
