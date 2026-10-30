using System;
using System.Windows.Media;
using MahApps.Metro.IconPacks;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B4 RID: 436
	public class ResultViewModel : ViewModelBase
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000C71 RID: 3185 RVA: 0x00044EFA File Offset: 0x000430FA
		// (set) Token: 0x06000C72 RID: 3186 RVA: 0x00044F02 File Offset: 0x00043102
		public bool Passed { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000C73 RID: 3187 RVA: 0x00044F0B File Offset: 0x0004310B
		// (set) Token: 0x06000C74 RID: 3188 RVA: 0x00044F13 File Offset: 0x00043113
		public string Text { get; set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000C75 RID: 3189 RVA: 0x00044F1C File Offset: 0x0004311C
		public SolidColorBrush Color
		{
			get
			{
				if (!this.Passed)
				{
					return Brushes.Tomato;
				}
				return Brushes.YellowGreen;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000C76 RID: 3190 RVA: 0x00044F31 File Offset: 0x00043131
		public PackIconForkAwesomeKind Icon
		{
			get
			{
				if (!this.Passed)
				{
					return 702;
				}
				return 151;
			}
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00044F46 File Offset: 0x00043146
		public ResultViewModel(string text, bool passed)
		{
			this.Text = text;
			this.Passed = passed;
		}
	}
}
