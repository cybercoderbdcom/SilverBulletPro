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
	// Token: 0x0200010A RID: 266
	public class PageBlockReqsTcpSend : Page, IComponentConnector
	{
		// Token: 0x060006BC RID: 1724 RVA: 0x0001FA53 File Offset: 0x0001DC53
		public PageBlockReqsTcpSend(BlockTcpSend block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001FA68 File Offset: 0x0001DC68
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/tcp/pageblockreqstcpsend.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0001FA98 File Offset: 0x0001DC98
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0001FAA2 File Offset: 0x0001DCA2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000336 RID: 822
		private bool _contentLoaded;
	}
}
