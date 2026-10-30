using System;
using System.Drawing;
using System.Windows.Media;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001FE RID: 510
	public static class TextEditorExtension
	{
		// Token: 0x0600103D RID: 4157 RVA: 0x0004ECA8 File Offset: 0x0004CEA8
		public static void AppendLine(this TextEditor editor, string text, System.Windows.Media.Color foreColor)
		{
			if (text == null)
			{
				return;
			}
			editor.TextArea.ClearSelection();
			editor.TextArea.TextView.LineTransformers.Add(new TextEditorExtension.LineColorizer(editor.LineCount, new SolidColorBrush(foreColor)));
			editor.AppendText(text);
			editor.TextArea.TextView.LineTransformers.Add(new TextEditorExtension.LineColorizer(editor.LineCount, new SolidColorBrush(foreColor)));
			editor.TextArea.TextView.InvalidateVisual();
			editor.TextArea.TextView.InvalidateArrange();
			editor.TextArea.TextView.InvalidateMeasure();
			editor.AppendText(Environment.NewLine);
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0004ED54 File Offset: 0x0004CF54
		public static void AppendLine(this TextEditor editor, string text, System.Drawing.Color foreColor)
		{
			if (text == null)
			{
				return;
			}
			editor.TextArea.ClearSelection();
			editor.TextArea.TextView.LineTransformers.Add(new TextEditorExtension.LineColorizer(editor.LineCount, foreColor.ToBrush()));
			editor.AppendText(text);
			editor.TextArea.TextView.LineTransformers.Add(new TextEditorExtension.LineColorizer(editor.LineCount, foreColor.ToBrush()));
			editor.TextArea.TextView.InvalidateVisual();
			editor.TextArea.TextView.InvalidateArrange();
			editor.TextArea.TextView.InvalidateMeasure();
			editor.AppendText(Environment.NewLine);
		}

		// Token: 0x020002EF RID: 751
		private class LineColorizer : DocumentColorizingTransformer
		{
			// Token: 0x17000255 RID: 597
			// (get) Token: 0x0600132D RID: 4909 RVA: 0x0005628A File Offset: 0x0005448A
			// (set) Token: 0x0600132E RID: 4910 RVA: 0x00056292 File Offset: 0x00054492
			public int LineNumber { get; set; }

			// Token: 0x17000256 RID: 598
			// (get) Token: 0x0600132F RID: 4911 RVA: 0x0005629B File Offset: 0x0005449B
			// (set) Token: 0x06001330 RID: 4912 RVA: 0x000562A3 File Offset: 0x000544A3
			public System.Windows.Media.Brush Foreground { get; set; }

			// Token: 0x06001331 RID: 4913 RVA: 0x000562AC File Offset: 0x000544AC
			public LineColorizer(int lineNumber, System.Windows.Media.Brush foreground)
			{
				this.LineNumber = lineNumber;
				this.Foreground = foreground;
			}

			// Token: 0x06001332 RID: 4914 RVA: 0x000562C2 File Offset: 0x000544C2
			protected override void ColorizeLine(DocumentLine line)
			{
				if (!line.IsDeleted && line.LineNumber == this.LineNumber)
				{
					base.ChangeLinePart(line.Offset, line.EndOffset, new Action<VisualLineElement>(this.ApplyChanges));
				}
			}

			// Token: 0x06001333 RID: 4915 RVA: 0x000562F8 File Offset: 0x000544F8
			private void ApplyChanges(VisualLineElement element)
			{
				element.TextRunProperties.SetForegroundBrush(this.Foreground);
			}
		}

		// Token: 0x020002F0 RID: 752
		private class ColorizeAvalonEdit : DocumentColorizingTransformer
		{
			// Token: 0x17000257 RID: 599
			// (get) Token: 0x06001334 RID: 4916 RVA: 0x0005630B File Offset: 0x0005450B
			// (set) Token: 0x06001335 RID: 4917 RVA: 0x00056313 File Offset: 0x00054513
			public System.Windows.Media.Brush Foreground { get; set; }

			// Token: 0x06001336 RID: 4918 RVA: 0x0005631C File Offset: 0x0005451C
			public ColorizeAvalonEdit(System.Windows.Media.Brush foreground)
			{
				this.Foreground = foreground;
			}

			// Token: 0x06001337 RID: 4919 RVA: 0x0005632C File Offset: 0x0005452C
			protected override void ColorizeLine(DocumentLine line)
			{
				try
				{
					int offset = line.Offset;
					string text = base.CurrentContext.Document.GetText(line);
					int startIndex = 0;
					if (!string.IsNullOrWhiteSpace(text))
					{
						int num;
						while ((num = text.IndexOf(text, startIndex)) >= 0)
						{
							base.ChangeLinePart(offset + num, offset + num + text.Length, delegate(VisualLineElement element)
							{
								element.TextRunProperties.SetForegroundBrush(this.Foreground);
							});
							startIndex = num + 1;
						}
					}
				}
				catch
				{
				}
			}
		}
	}
}
