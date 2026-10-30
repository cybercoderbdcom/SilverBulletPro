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
	// Token: 0x020000E9 RID: 233
	public class PageBlockReqsFtpUploadFile : Page, IComponentConnector
	{
		// Token: 0x06000622 RID: 1570 RVA: 0x0001D2E9 File Offset: 0x0001B4E9
		public PageBlockReqsFtpUploadFile(BlockFtpUploadFile block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001D300 File Offset: 0x0001B500
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpuploadfile.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0001D330 File Offset: 0x0001B530
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0001D33A File Offset: 0x0001B53A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.fileModeBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040002DB RID: 731
		internal ComboBox fileModeBox;

		// Token: 0x040002DC RID: 732
		private bool _contentLoaded;
	}
}
