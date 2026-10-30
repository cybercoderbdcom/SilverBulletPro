using System;
using System.Drawing;
using System.Windows.Forms;

namespace SilverBulletPro
{
	// Token: 0x0200002C RID: 44
	public static class WinFormRichTextBoxExtensions
	{
		// Token: 0x06000197 RID: 407 RVA: 0x0000CDD9 File Offset: 0x0000AFD9
		public static void AppendText(this RichTextBox box, string text, Color color)
		{
			box.SelectionStart = box.TextLength;
			box.SelectionLength = 0;
			box.SelectionColor = color;
			box.AppendText(text);
			box.SelectionColor = box.ForeColor;
			box.AppendText(Environment.NewLine);
		}
	}
}
