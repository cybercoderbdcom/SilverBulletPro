using System;
using System.Drawing;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;

namespace SilverBulletPro
{
	// Token: 0x0200001B RID: 27
	internal sealed class CustomizedBrush : HighlightingBrush
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x00008FB2 File Offset: 0x000071B2
		public CustomizedBrush(System.Windows.Media.Color color)
		{
			this.brush = CustomizedBrush.CreateFrozenBrush(color);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00008FC8 File Offset: 0x000071C8
		public CustomizedBrush(System.Drawing.Color c)
		{
			System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
			this.brush = CustomizedBrush.CreateFrozenBrush(color);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00009009 File Offset: 0x00007209
		public override System.Windows.Media.Brush GetBrush(ITextRunConstructionContext context)
		{
			return this.brush;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00009011 File Offset: 0x00007211
		public override string ToString()
		{
			return this.brush.ToString();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000901E File Offset: 0x0000721E
		private static SolidColorBrush CreateFrozenBrush(System.Windows.Media.Color color)
		{
			SolidColorBrush solidColorBrush = new SolidColorBrush(color);
			solidColorBrush.Freeze();
			return solidColorBrush;
		}

		// Token: 0x0400005C RID: 92
		private readonly SolidColorBrush brush;
	}
}
