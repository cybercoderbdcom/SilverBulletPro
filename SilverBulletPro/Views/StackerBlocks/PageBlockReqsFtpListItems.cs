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
	// Token: 0x020000E4 RID: 228
	public class PageBlockReqsFtpListItems : Page, IComponentConnector
	{
		// Token: 0x0600060E RID: 1550 RVA: 0x0001CFAF File Offset: 0x0001B1AF
		public PageBlockReqsFtpListItems(BlockFtpListItems block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0001CFC4 File Offset: 0x0001B1C4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftplistitems.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0001CFF4 File Offset: 0x0001B1F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0001CFFE File Offset: 0x0001B1FE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D3 RID: 723
		private bool _contentLoaded;
	}
}
