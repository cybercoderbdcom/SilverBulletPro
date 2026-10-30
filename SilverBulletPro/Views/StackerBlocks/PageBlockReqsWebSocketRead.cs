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
	// Token: 0x02000110 RID: 272
	public class PageBlockReqsWebSocketRead : Page, IComponentConnector
	{
		// Token: 0x060006D4 RID: 1748 RVA: 0x0001FD2F File Offset: 0x0001DF2F
		public PageBlockReqsWebSocketRead(BlockWebSocketRead block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0001FD44 File Offset: 0x0001DF44
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/websocket/pageblockreqswebsocketread.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0001FD74 File Offset: 0x0001DF74
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0001FD7E File Offset: 0x0001DF7E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400033F RID: 831
		private bool _contentLoaded;
	}
}
