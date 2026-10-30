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
	// Token: 0x020000EB RID: 235
	public class PageBlockDestroyCFBypass : Page, IComponentConnector
	{
		// Token: 0x0600062C RID: 1580 RVA: 0x0001D447 File Offset: 0x0001B647
		public PageBlockDestroyCFBypass(BlockDestroyCFBypass block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0001D45C File Offset: 0x0001B65C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/http/pageblockdestroycfbypass.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001D48C File Offset: 0x0001B68C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0001D496 File Offset: 0x0001B696
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002E0 RID: 736
		private bool _contentLoaded;
	}
}
