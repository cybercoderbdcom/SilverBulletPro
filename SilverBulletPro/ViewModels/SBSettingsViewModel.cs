using System;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001C0 RID: 448
	public class SBSettingsViewModel
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000D42 RID: 3394 RVA: 0x0004743F File Offset: 0x0004563F
		// (set) Token: 0x06000D43 RID: 3395 RVA: 0x00047447 File Offset: 0x00045647
		public SBSettingsGeneral General { get; set; } = new SBSettingsGeneral();

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000D44 RID: 3396 RVA: 0x00047450 File Offset: 0x00045650
		// (set) Token: 0x06000D45 RID: 3397 RVA: 0x00047458 File Offset: 0x00045658
		public SBSettingsSounds Sounds { get; set; } = new SBSettingsSounds();

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000D46 RID: 3398 RVA: 0x00047461 File Offset: 0x00045661
		// (set) Token: 0x06000D47 RID: 3399 RVA: 0x00047469 File Offset: 0x00045669
		public SBSettingsSources Sources { get; set; } = new SBSettingsSources();

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x00047472 File Offset: 0x00045672
		// (set) Token: 0x06000D49 RID: 3401 RVA: 0x0004747A File Offset: 0x0004567A
		public SBSettingsThemes Themes { get; set; } = new SBSettingsThemes();

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000D4A RID: 3402 RVA: 0x00047483 File Offset: 0x00045683
		// (set) Token: 0x06000D4B RID: 3403 RVA: 0x0004748B File Offset: 0x0004568B
		public SBSettingsLanguage Language { get; set; } = new SBSettingsLanguage();

		// Token: 0x06000D4C RID: 3404 RVA: 0x00047494 File Offset: 0x00045694
		public void Reset()
		{
			this.General.Reset();
			this.Sounds.Reset();
			this.Sources.Reset();
			this.Themes.Reset();
		}
	}
}
