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
	// Token: 0x02000102 RID: 258
	public class PageBlockReqsSshAuthNone : Page, IComponentConnector
	{
		// Token: 0x0600069C RID: 1692 RVA: 0x0001F793 File Offset: 0x0001D993
		public PageBlockReqsSshAuthNone(BlockSshAuthenticateWithNone block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0001F7A8 File Offset: 0x0001D9A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ssh/pageblockreqssshauthnone.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0001F7D8 File Offset: 0x0001D9D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0001F7E2 File Offset: 0x0001D9E2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400032E RID: 814
		private bool _contentLoaded;
	}
}
