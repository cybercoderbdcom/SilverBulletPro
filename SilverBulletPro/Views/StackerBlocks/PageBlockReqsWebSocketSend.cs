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
	// Token: 0x02000111 RID: 273
	public class PageBlockReqsWebSocketSend : Page, IComponentConnector
	{
		// Token: 0x060006D8 RID: 1752 RVA: 0x0001FD88 File Offset: 0x0001DF88
		public PageBlockReqsWebSocketSend(BlockWebSocketSend block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(WebSocketMessageType)))
			{
				WebSocketMessageType webSocketMessageType = (WebSocketMessageType)obj;
				if (webSocketMessageType != 2)
				{
					this.webSocketMsgTypeBox.Items.Add(webSocketMessageType);
				}
			}
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0001FE14 File Offset: 0x0001E014
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/websocket/pageblockreqswebsocketsend.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0001FE44 File Offset: 0x0001E044
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0001FE4E File Offset: 0x0001E04E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.webSocketMsgTypeBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000340 RID: 832
		internal ComboBox webSocketMsgTypeBox;

		// Token: 0x04000341 RID: 833
		private bool _contentLoaded;
	}
}
