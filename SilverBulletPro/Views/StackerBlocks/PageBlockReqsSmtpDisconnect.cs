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
	// Token: 0x020000FE RID: 254
	public class PageBlockReqsSmtpDisconnect : Page, IComponentConnector
	{
		// Token: 0x0600068B RID: 1675 RVA: 0x0001F45F File Offset: 0x0001D65F
		public PageBlockReqsSmtpDisconnect(BlockSmtpDisconnect block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0001F474 File Offset: 0x0001D674
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/smtp/pageblockreqssmtpdisconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001F4A4 File Offset: 0x0001D6A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001F4AE File Offset: 0x0001D6AE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000325 RID: 805
		private bool _contentLoaded;
	}
}
