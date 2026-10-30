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
	// Token: 0x020000E6 RID: 230
	public class PageBlockReqsFtpReadResponse : Page, IComponentConnector
	{
		// Token: 0x06000616 RID: 1558 RVA: 0x0001D05F File Offset: 0x0001B25F
		public PageBlockReqsFtpReadResponse(BlockFtpReadResponse block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0001D074 File Offset: 0x0001B274
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpreadresponse.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0001D0A4 File Offset: 0x0001B2A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0001D0AE File Offset: 0x0001B2AE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D5 RID: 725
		private bool _contentLoaded;
	}
}
