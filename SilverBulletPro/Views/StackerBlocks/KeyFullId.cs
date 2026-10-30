using System;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000049 RID: 73
	public class KeyFullId
	{
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000366 RID: 870 RVA: 0x00014F63 File Offset: 0x00013163
		// (set) Token: 0x06000367 RID: 871 RVA: 0x00014F6B File Offset: 0x0001316B
		public int KeyId { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000368 RID: 872 RVA: 0x00014F74 File Offset: 0x00013174
		// (set) Token: 0x06000369 RID: 873 RVA: 0x00014F7C File Offset: 0x0001317C
		public int ParentId { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00014F85 File Offset: 0x00013185
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00014F8D File Offset: 0x0001318D
		public bool LeftTermInitialized { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00014F96 File Offset: 0x00013196
		// (set) Token: 0x0600036D RID: 877 RVA: 0x00014F9E File Offset: 0x0001319E
		public bool ConditionInitialized { get; set; }

		// Token: 0x0600036E RID: 878 RVA: 0x00014FA7 File Offset: 0x000131A7
		public KeyFullId()
		{
			this.KeyId = 0;
			this.ParentId = 0;
			this.LeftTermInitialized = false;
			this.ConditionInitialized = false;
		}
	}
}
