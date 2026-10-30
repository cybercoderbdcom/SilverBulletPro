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
	// Token: 0x020000D5 RID: 213
	public class PageBlockPuppeteerSwitchToMainFrame : Page, IComponentConnector
	{
		// Token: 0x060005CF RID: 1487 RVA: 0x0001C367 File Offset: 0x0001A567
		public PageBlockPuppeteerSwitchToMainFrame(BlockPuppeteerSwitchToMainFrame block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0001C37C File Offset: 0x0001A57C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerswitchtomainframe.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0001C3AC File Offset: 0x0001A5AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0001C3B6 File Offset: 0x0001A5B6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B9 RID: 697
		private bool _contentLoaded;
	}
}
