using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Requests;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x0200010D RID: 269
	public class PageBlockReqsWebSocketClose : Page, IComponentConnector
	{
		// Token: 0x060006C8 RID: 1736 RVA: 0x0001FB5C File Offset: 0x0001DD5C
		public PageBlockReqsWebSocketClose(BlockWebSocketClose block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(WebSocketCloseStatus)))
			{
				WebSocketCloseStatus webSocketCloseStatus = (WebSocketCloseStatus)obj;
				this.webSocketCloseStatusBox.Items.Add(webSocketCloseStatus);
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0001FBE4 File Offset: 0x0001DDE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/websocket/pageblockreqswebsocketclose.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0001FC14 File Offset: 0x0001DE14
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0001FC1E File Offset: 0x0001DE1E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.webSocketCloseStatusBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000339 RID: 825
		internal ComboBox webSocketCloseStatusBox;

		// Token: 0x0400033A RID: 826
		private bool _contentLoaded;
	}
}
