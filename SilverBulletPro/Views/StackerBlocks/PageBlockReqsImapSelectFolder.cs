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
	// Token: 0x020000F5 RID: 245
	public class PageBlockReqsImapSelectFolder : Page, IComponentConnector
	{
		// Token: 0x06000660 RID: 1632 RVA: 0x0001E76B File Offset: 0x0001C96B
		public PageBlockReqsImapSelectFolder(BlockImapSelectFolder block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0001E780 File Offset: 0x0001C980
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimapselectfolder.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0001E7B0 File Offset: 0x0001C9B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0001E7BA File Offset: 0x0001C9BA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400030D RID: 781
		private bool _contentLoaded;
	}
}
