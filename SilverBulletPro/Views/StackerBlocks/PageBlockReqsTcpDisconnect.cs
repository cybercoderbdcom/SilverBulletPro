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
	// Token: 0x02000108 RID: 264
	public class PageBlockReqsTcpDisconnect : Page, IComponentConnector
	{
		// Token: 0x060006B4 RID: 1716 RVA: 0x0001F9A3 File Offset: 0x0001DBA3
		public PageBlockReqsTcpDisconnect(BlockTcpDisconnect block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0001F9B8 File Offset: 0x0001DBB8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/tcp/pageblockreqstcpdisconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0001F9E8 File Offset: 0x0001DBE8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0001F9F2 File Offset: 0x0001DBF2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000334 RID: 820
		private bool _contentLoaded;
	}
}
