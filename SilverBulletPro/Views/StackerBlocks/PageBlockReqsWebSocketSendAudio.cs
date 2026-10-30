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
	// Token: 0x02000112 RID: 274
	public class PageBlockReqsWebSocketSendAudio : Page, IComponentConnector
	{
		// Token: 0x060006DC RID: 1756 RVA: 0x0001FE68 File Offset: 0x0001E068
		public PageBlockReqsWebSocketSendAudio(BlockWebSocketSendAudio block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0001FE80 File Offset: 0x0001E080
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/websocket/pageblockreqswebsocketsendaudio.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x0001FEB0 File Offset: 0x0001E0B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x0001FEBA File Offset: 0x0001E0BA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000342 RID: 834
		private bool _contentLoaded;
	}
}
