using System;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B1 RID: 433
	[Flags]
	public enum ConfigFilterType : ushort
	{
		// Token: 0x0400062C RID: 1580
		Name = 1,
		// Token: 0x0400062D RID: 1581
		Author = 2,
		// Token: 0x0400062E RID: 1582
		Category = 4,
		// Token: 0x0400062F RID: 1583
		NeedsProxies = 8,
		// Token: 0x04000630 RID: 1584
		CaptchasNeeded = 16,
		// Token: 0x04000631 RID: 1585
		PuppeteerPresent = 32,
		// Token: 0x04000632 RID: 1586
		SeleniumPresent = 64,
		// Token: 0x04000633 RID: 1587
		OcrNeeded = 128,
		// Token: 0x04000634 RID: 1588
		HasCFBypass = 256,
		// Token: 0x04000635 RID: 1589
		LastModified = 512
	}
}
