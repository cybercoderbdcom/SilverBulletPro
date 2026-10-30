using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace SilverBulletPro
{
	// Token: 0x02000017 RID: 23
	public class SortAdorner : Adorner
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00008D38 File Offset: 0x00006F38
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00008D40 File Offset: 0x00006F40
		public ListSortDirection Direction { get; private set; }

		// Token: 0x060000D1 RID: 209 RVA: 0x00008D49 File Offset: 0x00006F49
		public SortAdorner(UIElement element, ListSortDirection dir) : base(element)
		{
			this.Direction = dir;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00008D5C File Offset: 0x00006F5C
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			if (base.AdornedElement.RenderSize.Width < 20.0)
			{
				return;
			}
			TranslateTransform transform = new TranslateTransform(base.AdornedElement.RenderSize.Width - 15.0, (base.AdornedElement.RenderSize.Height - 5.0) / 2.0);
			drawingContext.PushTransform(transform);
			Geometry geometry = SortAdorner.ascGeometry;
			if (this.Direction == ListSortDirection.Descending)
			{
				geometry = SortAdorner.descGeometry;
			}
			drawingContext.DrawGeometry(Brushes.Black, null, geometry);
			drawingContext.Pop();
		}

		// Token: 0x04000056 RID: 86
		private static Geometry ascGeometry = Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

		// Token: 0x04000057 RID: 87
		private static Geometry descGeometry = Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");
	}
}
