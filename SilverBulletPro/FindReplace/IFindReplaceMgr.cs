using System;
using System.Collections;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001DE RID: 478
	internal interface IFindReplaceMgr
	{
		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000F19 RID: 3865
		// (set) Token: 0x06000F1A RID: 3866
		bool CaseSensitive { get; set; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000F1B RID: 3867
		// (set) Token: 0x06000F1C RID: 3868
		object CurrentEditor { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000F1D RID: 3869
		// (set) Token: 0x06000F1E RID: 3870
		IEnumerable Editors { get; set; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000F1F RID: 3871
		// (set) Token: 0x06000F20 RID: 3872
		string ReplacementText { get; set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000F21 RID: 3873
		// (set) Token: 0x06000F22 RID: 3874
		FindReplaceMgr.SearchScope SearchIn { get; set; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000F23 RID: 3875
		// (set) Token: 0x06000F24 RID: 3876
		bool SearchUp { get; set; }

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000F25 RID: 3877
		// (set) Token: 0x06000F26 RID: 3878
		string TextToFind { get; set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000F27 RID: 3879
		// (set) Token: 0x06000F28 RID: 3880
		bool UseRegEx { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000F29 RID: 3881
		// (set) Token: 0x06000F2A RID: 3882
		bool UseWildcards { get; set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000F2B RID: 3883
		// (set) Token: 0x06000F2C RID: 3884
		bool WholeWord { get; set; }

		// Token: 0x06000F2D RID: 3885
		IEditor ConvertEditor(object o);
	}
}
