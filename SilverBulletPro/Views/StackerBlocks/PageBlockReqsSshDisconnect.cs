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
	// Token: 0x02000105 RID: 261
	public class PageBlockReqsSshDisconnect : Page, IComponentConnector
	{
		// Token: 0x060006A8 RID: 1704 RVA: 0x0001F89B File Offset: 0x0001DA9B
		public PageBlockReqsSshDisconnect(BlockSshDisconnect block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0001F8B0 File Offset: 0x0001DAB0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ssh/pageblockreqssshdisconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001F8E0 File Offset: 0x0001DAE0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001F8EA File Offset: 0x0001DAEA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000331 RID: 817
		private bool _contentLoaded;
	}
}
