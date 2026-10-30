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
	// Token: 0x020000EE RID: 238
	public class PageBlockReqsImapDeleteMail : Page, IComponentConnector
	{
		// Token: 0x06000643 RID: 1603 RVA: 0x0001E32F File Offset: 0x0001C52F
		public PageBlockReqsImapDeleteMail(BlockImapDeleteMail block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001E344 File Offset: 0x0001C544
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimapdeletemail.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001E374 File Offset: 0x0001C574
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001E37E File Offset: 0x0001C57E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000301 RID: 769
		private bool _contentLoaded;
	}
}
