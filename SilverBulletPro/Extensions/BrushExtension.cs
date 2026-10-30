using System;
using System.Windows.Media;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F2 RID: 498
	public static class BrushExtension
	{
		// Token: 0x0600101D RID: 4125 RVA: 0x0004E10B File Offset: 0x0004C30B
		public static Brush ToBrush(this string hexColor)
		{
			return (Brush)BrushExtension.bc.ConvertFrom((!hexColor.StartsWith("#")) ? ("#" + hexColor) : hexColor);
		}

		// Token: 0x04000771 RID: 1905
		private static BrushConverter bc = new BrushConverter();
	}
}
