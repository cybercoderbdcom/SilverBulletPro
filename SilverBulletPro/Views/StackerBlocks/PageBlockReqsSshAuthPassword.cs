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
	// Token: 0x02000103 RID: 259
	public class PageBlockReqsSshAuthPassword : Page, IComponentConnector
	{
		// Token: 0x060006A0 RID: 1696 RVA: 0x0001F7EB File Offset: 0x0001D9EB
		public PageBlockReqsSshAuthPassword(BlockSshAuthenticateWithPassword block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0001F800 File Offset: 0x0001DA00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ssh/pageblockreqssshauthpassword.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0001F830 File Offset: 0x0001DA30
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0001F83A File Offset: 0x0001DA3A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400032F RID: 815
		private bool _contentLoaded;
	}
}
