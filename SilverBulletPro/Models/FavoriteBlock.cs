using System;
using Newtonsoft.Json;

namespace SilverBulletPro.Models
{
	// Token: 0x020001E6 RID: 486
	[JsonObject(Title = "Favorites")]
	internal class FavoriteBlock
	{
		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000F60 RID: 3936 RVA: 0x0004D17B File Offset: 0x0004B37B
		// (set) Token: 0x06000F61 RID: 3937 RVA: 0x0004D183 File Offset: 0x0004B383
		public string Name { get; set; }

		// Token: 0x06000F62 RID: 3938 RVA: 0x0004D18C File Offset: 0x0004B38C
		public override string ToString()
		{
			return this.Name;
		}
	}
}
