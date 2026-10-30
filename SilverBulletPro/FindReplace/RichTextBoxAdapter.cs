using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001D7 RID: 471
	public class RichTextBoxAdapter : IEditor
	{
		// Token: 0x06000EBD RID: 3773 RVA: 0x0004B141 File Offset: 0x00049341
		public RichTextBoxAdapter(RichTextBox editor)
		{
			this.rtb = editor;
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000EBE RID: 3774 RVA: 0x0004B150 File Offset: 0x00049350
		public string Text
		{
			get
			{
				return new TextRange(this.rtb.Document.ContentStart, this.rtb.Document.ContentEnd).Text;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000EBF RID: 3775 RVA: 0x0004B17C File Offset: 0x0004937C
		public int SelectionStart
		{
			get
			{
				return RichTextBoxAdapter.GetPos(this.rtb.Document.ContentStart, this.rtb.Selection.Start);
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000EC0 RID: 3776 RVA: 0x0004B1A3 File Offset: 0x000493A3
		public int SelectionLength
		{
			get
			{
				return this.rtb.Selection.Text.Length;
			}
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x0004B1BA File Offset: 0x000493BA
		public void BeginChange()
		{
			this.rtb.BeginChange();
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x0004B1C7 File Offset: 0x000493C7
		public void EndChange()
		{
			this.rtb.EndChange();
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x0004B1D4 File Offset: 0x000493D4
		public void Select(int start, int length)
		{
			TextPointer contentStart = this.rtb.Document.ContentStart;
			this.rtb.Selection.Select(RichTextBoxAdapter.GetPoint(contentStart, start), RichTextBoxAdapter.GetPoint(contentStart, start + length));
			this.rtb.ScrollToVerticalOffset(this.rtb.Selection.Start.GetCharacterRect(LogicalDirection.Forward).Top);
			this.rtb.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Yellow);
			this.oldsel = new TextRange(this.rtb.Selection.Start, this.rtb.Selection.End);
			this.rtb.SelectionChanged += this.rtb_SelectionChanged;
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x0004B297 File Offset: 0x00049497
		private void rtb_SelectionChanged(object sender, RoutedEventArgs e)
		{
			this.oldsel.ApplyPropertyValue(TextElement.BackgroundProperty, null);
			this.rtb.SelectionChanged -= this.rtb_SelectionChanged;
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x0004B2C4 File Offset: 0x000494C4
		public void Replace(int start, int length, string ReplaceWith)
		{
			TextPointer contentStart = this.rtb.Document.ContentStart;
			new TextRange(RichTextBoxAdapter.GetPoint(contentStart, start), RichTextBoxAdapter.GetPoint(contentStart, start + length)).Text = ReplaceWith;
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x0004B300 File Offset: 0x00049500
		private static TextPointer GetPoint(TextPointer start, int x)
		{
			TextPointer positionAtOffset = start.GetPositionAtOffset(x);
			while (new TextRange(start, positionAtOffset).Text.Length < x)
			{
				if (positionAtOffset.GetPositionAtOffset(1, LogicalDirection.Forward) == null)
				{
					return positionAtOffset;
				}
				positionAtOffset = positionAtOffset.GetPositionAtOffset(1, LogicalDirection.Forward);
			}
			return positionAtOffset;
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x0004B341 File Offset: 0x00049541
		private static int GetPos(TextPointer start, TextPointer p)
		{
			return new TextRange(start, p).Text.Length;
		}

		// Token: 0x040006FE RID: 1790
		private RichTextBox rtb;

		// Token: 0x040006FF RID: 1791
		private TextRange oldsel;
	}
}
