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
	// Token: 0x02000113 RID: 275
	public class PageBlockReqsWebSocketState : Page, IComponentConnector
	{
		// Token: 0x060006E0 RID: 1760 RVA: 0x0001FEC3 File Offset: 0x0001E0C3
		public PageBlockReqsWebSocketState(BlockWebSocketState block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0001FED8 File Offset: 0x0001E0D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/websocket/pageblockreqswebsocketstate.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0001FF08 File Offset: 0x0001E108
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0001FF12 File Offset: 0x0001E112
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000343 RID: 835
		private bool _contentLoaded;
	}
}
