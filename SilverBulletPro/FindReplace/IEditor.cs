using System;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001DD RID: 477
	public interface IEditor
	{
		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000F12 RID: 3858
		string Text { get; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000F13 RID: 3859
		int SelectionStart { get; }

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000F14 RID: 3860
		int SelectionLength { get; }

		// Token: 0x06000F15 RID: 3861
		void Select(int start, int length);

		// Token: 0x06000F16 RID: 3862
		void Replace(int start, int length, string ReplaceWith);

		// Token: 0x06000F17 RID: 3863
		void BeginChange();

		// Token: 0x06000F18 RID: 3864
		void EndChange();
	}
}
