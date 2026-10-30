using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000FC RID: 252
	public class PageBlockReqsPop3ReadMail : Page, IComponentConnector
	{
		// Token: 0x06000680 RID: 1664 RVA: 0x0001EFAA File Offset: 0x0001D1AA
		public PageBlockReqsPop3ReadMail(BlockPop3ReadMail block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0001EFC0 File Offset: 0x0001D1C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/pop3/pageblockreqspop3readmail.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0001EFF0 File Offset: 0x0001D1F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0001EFFA File Offset: 0x0001D1FA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400031E RID: 798
		private bool _contentLoaded;
	}
}
