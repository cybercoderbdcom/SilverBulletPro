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
	// Token: 0x020000FA RID: 250
	public class PageBlockReqsPop3GetSupportedAuthMethods : Page, IComponentConnector
	{
		// Token: 0x06000677 RID: 1655 RVA: 0x0001ED27 File Offset: 0x0001CF27
		public PageBlockReqsPop3GetSupportedAuthMethods(BlockPop3GetSupportedAuthMethods block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0001ED3C File Offset: 0x0001CF3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/pop3/pageblockreqspop3getsupportedauthmethods.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0001ED6C File Offset: 0x0001CF6C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001ED76 File Offset: 0x0001CF76
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000317 RID: 791
		private bool _contentLoaded;
	}
}
