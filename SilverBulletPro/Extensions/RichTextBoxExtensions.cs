using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001FC RID: 508
	public static class RichTextBoxExtensions
	{
		// Token: 0x06001031 RID: 4145 RVA: 0x0004E9CC File Offset: 0x0004CBCC
		public static void AppendText(this RichTextBox box, string text, Color color)
		{
			box.Dispatcher.InvokeIfRequired(delegate
			{
				new TextRange(box.Document.ContentEnd, box.Document.ContentEnd)
				{
					Text = text
				}.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(color));
			}, DispatcherPriority.ContextIdle);
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0004EA14 File Offset: 0x0004CC14
		public static void AppendLine(this RichTextBox box, string text, Color color)
		{
			box.Dispatcher.InvokeIfRequired(delegate
			{
				TextRange textRange = new TextRange(box.Document.ContentEnd, box.Document.ContentEnd);
				textRange.Text = text;
				textRange.Text += Environment.NewLine;
				textRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(color));
			}, DispatcherPriority.ContextIdle);
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x0004EA5C File Offset: 0x0004CC5C
		public static void AppendLine(this RichTextBox box, string text)
		{
			box.Dispatcher.InvokeIfRequired(delegate
			{
				box.AppendText(text + Environment.NewLine);
			}, DispatcherPriority.ContextIdle);
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x0004EA9A File Offset: 0x0004CC9A
		public static void AddContextMenu<T>(this RichTextBox box, string header, ContextMenuItemType itemType, RelayCommand<T> command, object commandParameter = null)
		{
			if (box.ContextMenu == null)
			{
				box.ContextMenu = new ContextMenu();
			}
			box.ContextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<T>(itemType, header, command, commandParameter));
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x0004EACA File Offset: 0x0004CCCA
		public static string[] Lines(this RichTextBox box, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
		{
			return new TextRange(box.Document.ContentStart, box.Document.ContentEnd).Text.Split(new string[]
			{
				Environment.NewLine
			}, options);
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x0004EB00 File Offset: 0x0004CD00
		public static void SetText(this RichTextBox richTextBox, string text)
		{
			richTextBox.Document.Blocks.Clear();
			richTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x0004EB2D File Offset: 0x0004CD2D
		public static string GetText(this RichTextBox box)
		{
			return new TextRange(box.Document.ContentStart, box.Document.ContentEnd).Text;
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x0004EB4F File Offset: 0x0004CD4F
		public static string GetTextFromLines(this RichTextBox box)
		{
			return box.Lines(StringSplitOptions.RemoveEmptyEntries).Aggregate((string current, string next) => current + next);
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x0004EB7C File Offset: 0x0004CD7C
		public static string Select(this RichTextBox rtb, int offset, int length, Color color)
		{
			TextSelection selection = rtb.Selection;
			TextPointer contentStart = rtb.Document.ContentStart;
			TextPointer textPointAt = RichTextBoxExtensions.GetTextPointAt(contentStart, offset);
			TextPointer textPointAt2 = RichTextBoxExtensions.GetTextPointAt(contentStart, offset + length);
			selection.Select(textPointAt, textPointAt2);
			selection.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(color));
			return rtb.Selection.Text;
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x0004EBD0 File Offset: 0x0004CDD0
		public static TextPointer GetTextPointAt(TextPointer from, int pos)
		{
			TextPointer textPointer = from;
			int num = 0;
			while (num < pos && textPointer != null)
			{
				if (textPointer.GetPointerContext(LogicalDirection.Backward) == TextPointerContext.Text || textPointer.GetPointerContext(LogicalDirection.Backward) == TextPointerContext.None)
				{
					num++;
				}
				if (textPointer.GetPositionAtOffset(1, LogicalDirection.Forward) == null)
				{
					return textPointer;
				}
				textPointer = textPointer.GetPositionAtOffset(1, LogicalDirection.Forward);
			}
			return textPointer;
		}
	}
}
