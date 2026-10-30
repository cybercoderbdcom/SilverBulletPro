using System;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;

namespace SilverBulletPro
{
	// Token: 0x0200001C RID: 28
	public class ScriptCompletionData : ICompletionData
	{
		// Token: 0x060000EB RID: 235 RVA: 0x0000902C File Offset: 0x0000722C
		public ScriptCompletionData(string text, string description)
		{
			this.Text = text;
			this.Description = description;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00009042 File Offset: 0x00007242
		public ImageSource Image
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00009045 File Offset: 0x00007245
		// (set) Token: 0x060000EE RID: 238 RVA: 0x0000904D File Offset: 0x0000724D
		public string Text { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00009056 File Offset: 0x00007256
		public object Content
		{
			get
			{
				return this.Text;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x0000905E File Offset: 0x0000725E
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00009066 File Offset: 0x00007266
		public object Description { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x0000906F File Offset: 0x0000726F
		public double Priority
		{
			get
			{
				return 0.0;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000907A File Offset: 0x0000727A
		public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
		{
			textArea.Document.Replace(completionSegment, this.Text);
		}
	}
}
