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
	// Token: 0x020000F8 RID: 248
	public class PageBlockReqsPop3Disconnect : Page, IComponentConnector
	{
		// Token: 0x0600066F RID: 1647 RVA: 0x0001EC77 File Offset: 0x0001CE77
		public PageBlockReqsPop3Disconnect(BlockPop3Disconnect block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0001EC8C File Offset: 0x0001CE8C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/pop3/pageblockreqspop3disconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0001ECBC File Offset: 0x0001CEBC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0001ECC6 File Offset: 0x0001CEC6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000315 RID: 789
		private bool _contentLoaded;
	}
}
