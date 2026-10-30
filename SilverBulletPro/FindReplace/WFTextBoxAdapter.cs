using System;
using System.Windows.Forms;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001D8 RID: 472
	internal class WFTextBoxAdapter : IEditor
	{
		// Token: 0x06000EC8 RID: 3784 RVA: 0x0004B354 File Offset: 0x00049554
		public WFTextBoxAdapter(TextBoxBase ttb)
		{
			this.tb = ttb;
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000EC9 RID: 3785 RVA: 0x0004B363 File Offset: 0x00049563
		public string Text
		{
			get
			{
				return this.tb.Text;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000ECA RID: 3786 RVA: 0x0004B370 File Offset: 0x00049570
		public int SelectionStart
		{
			get
			{
				return this.tb.SelectionStart;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000ECB RID: 3787 RVA: 0x0004B37D File Offset: 0x0004957D
		public int SelectionLength
		{
			get
			{
				return this.tb.SelectionLength;
			}
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x0004B38A File Offset: 0x0004958A
		public void BeginChange()
		{
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x0004B38C File Offset: 0x0004958C
		public void EndChange()
		{
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x0004B38E File Offset: 0x0004958E
		public void Select(int start, int length)
		{
			this.tb.Select(start, length);
			this.tb.ScrollToCaret();
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x0004B3A8 File Offset: 0x000495A8
		public void Replace(int start, int length, string ReplaceWith)
		{
			this.tb.Text = this.tb.Text.Substring(0, start) + ReplaceWith + this.tb.Text.Substring(start + length);
		}

		// Token: 0x04000700 RID: 1792
		private TextBoxBase tb;
	}
}
