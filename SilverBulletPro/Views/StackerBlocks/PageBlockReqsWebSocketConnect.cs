using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x0200010E RID: 270
	public class PageBlockReqsWebSocketConnect : Page, IComponentConnector
	{
		// Token: 0x060006CC RID: 1740 RVA: 0x0001FC38 File Offset: 0x0001DE38
		public PageBlockReqsWebSocketConnect(BlockWebSocketConnect block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtCustomCookies.AddItems(block.CustomCookies);
			this.rtCustomHeaders.AddItems(block.CustomHeaders);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0001FC70 File Offset: 0x0001DE70
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/websocket/pageblockreqswebsocketconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0001FCA0 File Offset: 0x0001DEA0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0001FCAA File Offset: 0x0001DEAA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.rtCustomCookies = (RichTextInputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.rtCustomHeaders = (RichTextInputBox)target;
		}

		// Token: 0x0400033B RID: 827
		internal RichTextInputBox rtCustomCookies;

		// Token: 0x0400033C RID: 828
		internal RichTextInputBox rtCustomHeaders;

		// Token: 0x0400033D RID: 829
		private bool _contentLoaded;
	}
}
