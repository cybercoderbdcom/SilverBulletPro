using System;
using System.Drawing;
using System.Windows.Media;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F3 RID: 499
	public static class ColorExtension
	{
		// Token: 0x0600101E RID: 4126 RVA: 0x0004E137 File Offset: 0x0004C337
		public static System.Windows.Media.Color ToMediaColor(this System.Drawing.Color color)
		{
			return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0004E15A File Offset: 0x0004C35A
		public static System.Windows.Media.Brush ToBrush(this System.Drawing.Color color)
		{
			return new SolidColorBrush(color.ToMediaColor());
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0004E167 File Offset: 0x0004C367
		public static System.Windows.Media.Brush ToBrush(this System.Windows.Media.Color color)
		{
			return new SolidColorBrush(color);
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0004E16F File Offset: 0x0004C36F
		public static System.Windows.Media.Color ToMediaColor(this string hexColor)
		{
			return (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString((!hexColor.StartsWith("#")) ? ("#" + hexColor) : hexColor);
		}
	}
}
