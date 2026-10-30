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
	// Token: 0x020000E5 RID: 229
	public class PageBlockReqsFtpLogin : Page, IComponentConnector
	{
		// Token: 0x06000612 RID: 1554 RVA: 0x0001D007 File Offset: 0x0001B207
		public PageBlockReqsFtpLogin(BlockFtpLogin block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0001D01C File Offset: 0x0001B21C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftplogin.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0001D04C File Offset: 0x0001B24C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0001D056 File Offset: 0x0001B256
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D4 RID: 724
		private bool _contentLoaded;
	}
}
