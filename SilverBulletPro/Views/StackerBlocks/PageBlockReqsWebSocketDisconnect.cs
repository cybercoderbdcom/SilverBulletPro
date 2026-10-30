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
	// Token: 0x0200010F RID: 271
	public class PageBlockReqsWebSocketDisconnect : Page, IComponentConnector
	{
		// Token: 0x060006D0 RID: 1744 RVA: 0x0001FCD7 File Offset: 0x0001DED7
		public PageBlockReqsWebSocketDisconnect(BlockWebSocketDisconnect block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0001FCEC File Offset: 0x0001DEEC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/websocket/pageblockreqswebsocketdisconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0001FD1C File Offset: 0x0001DF1C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0001FD26 File Offset: 0x0001DF26
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400033E RID: 830
		private bool _contentLoaded;
	}
}
