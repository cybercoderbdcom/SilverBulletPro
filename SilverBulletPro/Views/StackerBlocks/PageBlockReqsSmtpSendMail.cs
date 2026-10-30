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
	// Token: 0x02000101 RID: 257
	public class PageBlockReqsSmtpSendMail : Page, IComponentConnector
	{
		// Token: 0x06000698 RID: 1688 RVA: 0x0001F73A File Offset: 0x0001D93A
		public PageBlockReqsSmtpSendMail(BlockSmtpSendMail block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0001F750 File Offset: 0x0001D950
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/smtp/pageblockreqssmtpsendmail.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0001F780 File Offset: 0x0001D980
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0001F78A File Offset: 0x0001D98A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400032D RID: 813
		private bool _contentLoaded;
	}
}
