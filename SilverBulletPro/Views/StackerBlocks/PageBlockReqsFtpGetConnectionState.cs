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
	// Token: 0x020000E0 RID: 224
	public class PageBlockReqsFtpGetConnectionState : Page, IComponentConnector
	{
		// Token: 0x060005FE RID: 1534 RVA: 0x0001CE4F File Offset: 0x0001B04F
		public PageBlockReqsFtpGetConnectionState(BlockFtpGetConnectionState block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0001CE64 File Offset: 0x0001B064
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpgetconnectionstate.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0001CE94 File Offset: 0x0001B094
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001CE9E File Offset: 0x0001B09E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002CF RID: 719
		private bool _contentLoaded;
	}
}
