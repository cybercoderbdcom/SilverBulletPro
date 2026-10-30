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
	// Token: 0x020000E3 RID: 227
	public class PageBlockReqsFtpGetFileSize : Page, IComponentConnector
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x0001CF57 File Offset: 0x0001B157
		public PageBlockReqsFtpGetFileSize(BlockFtpGetFileLength block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0001CF6C File Offset: 0x0001B16C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpgetfilesize.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0001CF9C File Offset: 0x0001B19C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0001CFA6 File Offset: 0x0001B1A6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D2 RID: 722
		private bool _contentLoaded;
	}
}
