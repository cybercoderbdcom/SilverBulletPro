using System;
using System.Collections.Generic;
using System.Reflection;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001C4 RID: 452
	public class SBSettingsSounds : ViewModelBase
	{
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x000479A4 File Offset: 0x00045BA4
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x000479AC File Offset: 0x00045BAC
		public bool EnableSounds
		{
			get
			{
				return this.enableSounds;
			}
			set
			{
				this.enableSounds = value;
				this.OnPropertyChanged("EnableSounds");
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x000479C0 File Offset: 0x00045BC0
		// (set) Token: 0x06000D98 RID: 3480 RVA: 0x000479C8 File Offset: 0x00045BC8
		public string OnHitSound
		{
			get
			{
				return this.onHitSound;
			}
			set
			{
				this.onHitSound = value;
				this.OnPropertyChanged("OnHitSound");
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x000479DC File Offset: 0x00045BDC
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x000479E4 File Offset: 0x00045BE4
		public string OnReloadSound
		{
			get
			{
				return this.onReloadSound;
			}
			set
			{
				this.onReloadSound = value;
				this.OnPropertyChanged("OnReloadSound");
			}
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x000479F8 File Offset: 0x00045BF8
		public void Reset()
		{
			SBSettingsSounds obj = new SBSettingsSounds();
			foreach (PropertyInfo propertyInfo in ((IEnumerable<PropertyInfo>)new List<PropertyInfo>(typeof(SBSettingsSounds).GetProperties())))
			{
				propertyInfo.SetValue(this, propertyInfo.GetValue(obj, null));
			}
		}

		// Token: 0x040006A5 RID: 1701
		private bool enableSounds;

		// Token: 0x040006A6 RID: 1702
		private string onHitSound = "rifle_hit.wav";

		// Token: 0x040006A7 RID: 1703
		private string onReloadSound = "rifle_reload.wav";
	}
}
