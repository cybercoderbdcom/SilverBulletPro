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
	// Token: 0x020000FF RID: 255
	public class PageBlockReqsSmtpGetSupportedAuthMethods : Page, IComponentConnector
	{
		// Token: 0x0600068F RID: 1679 RVA: 0x0001F4B7 File Offset: 0x0001D6B7
		public PageBlockReqsSmtpGetSupportedAuthMethods(BlockSmtpGetSupportedAuthMethods block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0001F4CC File Offset: 0x0001D6CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/smtp/pageblockreqssmtpgetsupportedauthmethods.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001F4FC File Offset: 0x0001D6FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001F506 File Offset: 0x0001D706
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000326 RID: 806
		private bool _contentLoaded;
	}
}
