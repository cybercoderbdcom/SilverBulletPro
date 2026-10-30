using System;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;

namespace SilverBulletPro
{
	// Token: 0x0200001A RID: 26
	public class CSharpCompletionData : ICompletionData
	{
		// Token: 0x060000DE RID: 222 RVA: 0x00008F56 File Offset: 0x00007156
		public CSharpCompletionData(string text)
		{
			this.Text = text;
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00008F65 File Offset: 0x00007165
		public ImageSource Image
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00008F68 File Offset: 0x00007168
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00008F70 File Offset: 0x00007170
		public string Text { get; private set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00008F79 File Offset: 0x00007179
		public object Content
		{
			get
			{
				return this.Text;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00008F81 File Offset: 0x00007181
		public object Description
		{
			get
			{
				return "Description for " + this.Text;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00008F93 File Offset: 0x00007193
		public double Priority
		{
			get
			{
				return 0.0;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00008F9E File Offset: 0x0000719E
		public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
		{
			textArea.Document.Replace(completionSegment, this.Text);
		}
	}
}
