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
	// Token: 0x0200010C RID: 268
	public class PageBlockReqsTcpSendReadHttp : Page, IComponentConnector
	{
		// Token: 0x060006C4 RID: 1732 RVA: 0x0001FB03 File Offset: 0x0001DD03
		public PageBlockReqsTcpSendReadHttp(BlockTcpSendReadHttp block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001FB18 File Offset: 0x0001DD18
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/tcp/pageblockreqstcpsendreadhttp.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0001FB48 File Offset: 0x0001DD48
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0001FB52 File Offset: 0x0001DD52
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000338 RID: 824
		private bool _contentLoaded;
	}
}
