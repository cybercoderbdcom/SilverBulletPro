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
	// Token: 0x020000D8 RID: 216
	public class PageBlockReqsFtpChangeDirectory : Page, IComponentConnector
	{
		// Token: 0x060005DB RID: 1499 RVA: 0x0001C4F7 File Offset: 0x0001A6F7
		public PageBlockReqsFtpChangeDirectory(BlockFtpChangeDirectory block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0001C50C File Offset: 0x0001A70C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpchangedirectory.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0001C53C File Offset: 0x0001A73C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0001C546 File Offset: 0x0001A746
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002BD RID: 701
		private bool _contentLoaded;
	}
}
