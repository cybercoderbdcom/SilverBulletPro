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
	// Token: 0x020000DF RID: 223
	public class PageBlockReqsFtpFileExists : Page, IComponentConnector
	{
		// Token: 0x060005FA RID: 1530 RVA: 0x0001CDF4 File Offset: 0x0001AFF4
		public PageBlockReqsFtpFileExists(BlockFtpFileExists block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0001CE0C File Offset: 0x0001B00C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpfileexists.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0001CE3C File Offset: 0x0001B03C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0001CE46 File Offset: 0x0001B046
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002CE RID: 718
		private bool _contentLoaded;
	}
}
