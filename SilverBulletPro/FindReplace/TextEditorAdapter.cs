using System;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001D5 RID: 469
	public class TextEditorAdapter : IEditor
	{
		// Token: 0x06000EAD RID: 3757 RVA: 0x0004AFFF File Offset: 0x000491FF
		public TextEditorAdapter(TextEditor editor)
		{
			this.te = editor;
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x0004B00E File Offset: 0x0004920E
		public string Text
		{
			get
			{
				return this.te.Text;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000EAF RID: 3759 RVA: 0x0004B01B File Offset: 0x0004921B
		public int SelectionStart
		{
			get
			{
				return this.te.SelectionStart;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0004B028 File Offset: 0x00049228
		public int SelectionLength
		{
			get
			{
				return this.te.SelectionLength;
			}
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x0004B035 File Offset: 0x00049235
		public void BeginChange()
		{
			this.te.BeginChange();
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x0004B042 File Offset: 0x00049242
		public void EndChange()
		{
			this.te.EndChange();
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x0004B050 File Offset: 0x00049250
		public void Select(int start, int length)
		{
			this.te.Select(start, length);
			TextLocation location = this.te.Document.GetLocation(start);
			this.te.ScrollTo(location.Line, location.Column);
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x0004B095 File Offset: 0x00049295
		public void Replace(int start, int length, string ReplaceWith)
		{
			this.te.Document.Replace(start, length, ReplaceWith);
		}

		// Token: 0x040006FC RID: 1788
		private TextEditor te;
	}
}
