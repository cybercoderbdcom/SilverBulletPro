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
	// Token: 0x020000E7 RID: 231
	public class PageBlockReqsFtpSendCommand : Page, IComponentConnector
	{
		// Token: 0x0600061A RID: 1562 RVA: 0x0001D0B7 File Offset: 0x0001B2B7
		public PageBlockReqsFtpSendCommand(BlockFtpSendCommand block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0001D0CC File Offset: 0x0001B2CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpsendcommand.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0001D0FC File Offset: 0x0001B2FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0001D106 File Offset: 0x0001B306
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D6 RID: 726
		private bool _contentLoaded;
	}
}
