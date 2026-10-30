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
	// Token: 0x02000107 RID: 263
	public class PageBlockReqsTcpConnect : Page, IComponentConnector
	{
		// Token: 0x060006B0 RID: 1712 RVA: 0x0001F94B File Offset: 0x0001DB4B
		public PageBlockReqsTcpConnect(BlockTcpConnect block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001F960 File Offset: 0x0001DB60
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/tcp/pageblockreqstcpconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0001F990 File Offset: 0x0001DB90
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0001F99A File Offset: 0x0001DB9A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000333 RID: 819
		private bool _contentLoaded;
	}
}
