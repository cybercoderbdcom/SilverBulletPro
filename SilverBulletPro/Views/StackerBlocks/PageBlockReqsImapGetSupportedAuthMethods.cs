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
	// Token: 0x020000F0 RID: 240
	public class PageBlockReqsImapGetSupportedAuthMethods : Page, IComponentConnector
	{
		// Token: 0x0600064B RID: 1611 RVA: 0x0001E3DF File Offset: 0x0001C5DF
		public PageBlockReqsImapGetSupportedAuthMethods(BlockImapGetSupportedAuthMethods block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0001E3F4 File Offset: 0x0001C5F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimapgetsupportedauthmethods.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0001E424 File Offset: 0x0001C624
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0001E42E File Offset: 0x0001C62E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000303 RID: 771
		private bool _contentLoaded;
	}
}
