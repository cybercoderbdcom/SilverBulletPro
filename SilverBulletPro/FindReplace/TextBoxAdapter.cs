using System;
using System.Windows.Controls;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001D6 RID: 470
	public class TextBoxAdapter : IEditor
	{
		// Token: 0x06000EB5 RID: 3765 RVA: 0x0004B0AA File Offset: 0x000492AA
		public TextBoxAdapter(TextBox editor)
		{
			this.te = editor;
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000EB6 RID: 3766 RVA: 0x0004B0B9 File Offset: 0x000492B9
		public string Text
		{
			get
			{
				return this.te.Text;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x0004B0C6 File Offset: 0x000492C6
		public int SelectionStart
		{
			get
			{
				return this.te.SelectionStart;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x0004B0D3 File Offset: 0x000492D3
		public int SelectionLength
		{
			get
			{
				return this.te.SelectionLength;
			}
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x0004B0E0 File Offset: 0x000492E0
		public void BeginChange()
		{
			this.te.BeginChange();
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x0004B0ED File Offset: 0x000492ED
		public void EndChange()
		{
			this.te.EndChange();
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x0004B0FA File Offset: 0x000492FA
		public void Select(int start, int length)
		{
			this.te.Select(start, length);
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x0004B109 File Offset: 0x00049309
		public void Replace(int start, int length, string ReplaceWith)
		{
			this.te.Text = this.te.Text.Substring(0, start) + ReplaceWith + this.te.Text.Substring(start + length);
		}

		// Token: 0x040006FD RID: 1789
		private TextBox te;
	}
}
