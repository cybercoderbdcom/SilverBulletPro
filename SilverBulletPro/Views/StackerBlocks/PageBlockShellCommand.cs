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
	// Token: 0x020000A2 RID: 162
	public class PageBlockShellCommand : Page, IComponentConnector
	{
		// Token: 0x060004F3 RID: 1267 RVA: 0x0001997D File Offset: 0x00017B7D
		public PageBlockShellCommand(BlockShellCommand block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00019994 File Offset: 0x00017B94
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/interop/pageblockshellcommand.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000199C4 File Offset: 0x00017BC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x000199CE File Offset: 0x00017BCE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000260 RID: 608
		private bool _contentLoaded;
	}
}
