using System;
using System.Collections.Generic;
using System.Reflection;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001C6 RID: 454
	public class SBSettingsThemes : ViewModelBase
	{
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x00047B77 File Offset: 0x00045D77
		// (set) Token: 0x06000DA6 RID: 3494 RVA: 0x00047B7F File Offset: 0x00045D7F
		public string BackgroundMain
		{
			get
			{
				return this.backgroundMain;
			}
			set
			{
				this.backgroundMain = value;
				this.OnPropertyChanged("BackgroundMain");
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x00047B93 File Offset: 0x00045D93
		// (set) Token: 0x06000DA8 RID: 3496 RVA: 0x00047B9B File Offset: 0x00045D9B
		public string BackgroundSecondary
		{
			get
			{
				return this.backgroundSecondary;
			}
			set
			{
				this.backgroundSecondary = value;
				this.OnPropertyChanged("BackgroundSecondary");
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x00047BAF File Offset: 0x00045DAF
		// (set) Token: 0x06000DAA RID: 3498 RVA: 0x00047BB7 File Offset: 0x00045DB7
		public string ForegroundMain
		{
			get
			{
				return this.foregroundMain;
			}
			set
			{
				this.foregroundMain = value;
				this.OnPropertyChanged("ForegroundMain");
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000DAB RID: 3499 RVA: 0x00047BCB File Offset: 0x00045DCB
		// (set) Token: 0x06000DAC RID: 3500 RVA: 0x00047BD3 File Offset: 0x00045DD3
		public string ForegroundGood
		{
			get
			{
				return this.foregroundGood;
			}
			set
			{
				this.foregroundGood = value;
				this.OnPropertyChanged("ForegroundGood");
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000DAD RID: 3501 RVA: 0x00047BE7 File Offset: 0x00045DE7
		// (set) Token: 0x06000DAE RID: 3502 RVA: 0x00047BEF File Offset: 0x00045DEF
		public string ForegroundBad
		{
			get
			{
				return this.foregroundBad;
			}
			set
			{
				this.foregroundBad = value;
				this.OnPropertyChanged("ForegroundBad");
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x00047C03 File Offset: 0x00045E03
		// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x00047C0B File Offset: 0x00045E0B
		public string ForegroundCustom
		{
			get
			{
				return this.foregroundFree;
			}
			set
			{
				this.foregroundFree = value;
				this.OnPropertyChanged("ForegroundCustom");
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x00047C1F File Offset: 0x00045E1F
		// (set) Token: 0x06000DB2 RID: 3506 RVA: 0x00047C27 File Offset: 0x00045E27
		public string ForegroundRetry
		{
			get
			{
				return this.foregroundRetry;
			}
			set
			{
				this.foregroundRetry = value;
				this.OnPropertyChanged("ForegroundRetry");
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000DB3 RID: 3507 RVA: 0x00047C3B File Offset: 0x00045E3B
		// (set) Token: 0x06000DB4 RID: 3508 RVA: 0x00047C43 File Offset: 0x00045E43
		public string ForegroundToCheck
		{
			get
			{
				return this.foregroundToCheck;
			}
			set
			{
				this.foregroundToCheck = value;
				this.OnPropertyChanged("ForegroundToCheck");
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x00047C57 File Offset: 0x00045E57
		// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x00047C5F File Offset: 0x00045E5F
		public string ForegroundMenuSelected
		{
			get
			{
				return this.foregroundMenuSelected;
			}
			set
			{
				this.foregroundMenuSelected = value;
				this.OnPropertyChanged("ForegroundMenuSelected");
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x00047C73 File Offset: 0x00045E73
		// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x00047C7B File Offset: 0x00045E7B
		public string ForegroundMainTabCtrlSelectedItem
		{
			get
			{
				return this.foregroundMainTabCtrlSelectedItem;
			}
			set
			{
				this.foregroundMainTabCtrlSelectedItem = value;
				this.OnPropertyChanged("ForegroundMainTabCtrlSelectedItem");
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000DB9 RID: 3513 RVA: 0x00047C8F File Offset: 0x00045E8F
		// (set) Token: 0x06000DBA RID: 3514 RVA: 0x00047C97 File Offset: 0x00045E97
		public string PrimaryBrush
		{
			get
			{
				return this.primaryBrush;
			}
			set
			{
				this.primaryBrush = value;
				this.OnPropertyChanged("PrimaryBrush");
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000DBB RID: 3515 RVA: 0x00047CAB File Offset: 0x00045EAB
		// (set) Token: 0x06000DBC RID: 3516 RVA: 0x00047CB3 File Offset: 0x00045EB3
		public string PrimaryTextBrush
		{
			get
			{
				return this.primaryTextBrush;
			}
			set
			{
				this.primaryTextBrush = value;
				this.OnPropertyChanged("PrimaryTextBrush");
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000DBD RID: 3517 RVA: 0x00047CC7 File Offset: 0x00045EC7
		// (set) Token: 0x06000DBE RID: 3518 RVA: 0x00047CCF File Offset: 0x00045ECF
		public string BorderBrush
		{
			get
			{
				return this.borderBrush;
			}
			set
			{
				this.borderBrush = value;
				this.OnPropertyChanged("BorderBrush");
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x00047CE3 File Offset: 0x00045EE3
		// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x00047CEB File Offset: 0x00045EEB
		public string MainBar
		{
			get
			{
				return this.mainBar;
			}
			set
			{
				this.mainBar = value;
				this.OnPropertyChanged("MainBar");
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x00047CFF File Offset: 0x00045EFF
		// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x00047D07 File Offset: 0x00045F07
		public bool UseImage
		{
			get
			{
				return this.useImage;
			}
			set
			{
				this.useImage = value;
				this.OnPropertyChanged("UseImage");
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x00047D1B File Offset: 0x00045F1B
		// (set) Token: 0x06000DC4 RID: 3524 RVA: 0x00047D23 File Offset: 0x00045F23
		public string BackgroundImage
		{
			get
			{
				return this.backgroundImage;
			}
			set
			{
				this.backgroundImage = value;
				this.OnPropertyChanged("BackgroundImage");
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00047D37 File Offset: 0x00045F37
		// (set) Token: 0x06000DC6 RID: 3526 RVA: 0x00047D3F File Offset: 0x00045F3F
		public int BackgroundImageOpacity
		{
			get
			{
				return this.backgroundImageOpacity;
			}
			set
			{
				this.backgroundImageOpacity = value;
				this.OnPropertyChanged("BackgroundImageOpacity");
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00047D53 File Offset: 0x00045F53
		// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x00047D5B File Offset: 0x00045F5B
		public string BackgroundLogo
		{
			get
			{
				return this.backgroundLogo;
			}
			set
			{
				this.backgroundLogo = value;
				this.OnPropertyChanged("BackgroundLogo");
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x00047D6F File Offset: 0x00045F6F
		// (set) Token: 0x06000DCA RID: 3530 RVA: 0x00047D77 File Offset: 0x00045F77
		public bool EnableSnow
		{
			get
			{
				return this.enableSnow;
			}
			set
			{
				this.enableSnow = value;
				this.OnPropertyChanged("EnableSnow");
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00047D8B File Offset: 0x00045F8B
		// (set) Token: 0x06000DCC RID: 3532 RVA: 0x00047D93 File Offset: 0x00045F93
		public int SnowAmount
		{
			get
			{
				return this.snowAmount;
			}
			set
			{
				this.snowAmount = value;
				this.OnPropertyChanged("SnowAmount");
			}
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00047DA8 File Offset: 0x00045FA8
		public void Reset()
		{
			SBSettingsThemes obj = new SBSettingsThemes();
			foreach (PropertyInfo propertyInfo in ((IEnumerable<PropertyInfo>)new List<PropertyInfo>(typeof(SBSettingsThemes).GetProperties())))
			{
				propertyInfo.SetValue(this, propertyInfo.GetValue(obj, null));
			}
		}

		// Token: 0x040006AA RID: 1706
		private string backgroundMain = "#222";

		// Token: 0x040006AB RID: 1707
		private string backgroundSecondary = "#111";

		// Token: 0x040006AC RID: 1708
		private string foregroundMain = "#dcdcdc";

		// Token: 0x040006AD RID: 1709
		private string foregroundGood = "#adff2f";

		// Token: 0x040006AE RID: 1710
		private string foregroundBad = "#ff6347";

		// Token: 0x040006AF RID: 1711
		private string foregroundFree = "#ff8c00";

		// Token: 0x040006B0 RID: 1712
		private string foregroundRetry = "#ffff00";

		// Token: 0x040006B1 RID: 1713
		private string foregroundToCheck = "#7fffd4";

		// Token: 0x040006B2 RID: 1714
		private string foregroundMenuSelected = "#1e90ff";

		// Token: 0x040006B3 RID: 1715
		private string foregroundMainTabCtrlSelectedItem = "#ffffff";

		// Token: 0x040006B4 RID: 1716
		private string primaryBrush = "#326cf3";

		// Token: 0x040006B5 RID: 1717
		private string primaryTextBrush = "#ffffff";

		// Token: 0x040006B6 RID: 1718
		private string borderBrush = "#3f3f46";

		// Token: 0x040006B7 RID: 1719
		private string mainBar = "#ffffff";

		// Token: 0x040006B8 RID: 1720
		private bool useImage;

		// Token: 0x040006B9 RID: 1721
		private string backgroundImage = "";

		// Token: 0x040006BA RID: 1722
		private int backgroundImageOpacity = 100;

		// Token: 0x040006BB RID: 1723
		private string backgroundLogo = "";

		// Token: 0x040006BC RID: 1724
		private bool enableSnow;

		// Token: 0x040006BD RID: 1725
		private int snowAmount = 1;
	}
}
