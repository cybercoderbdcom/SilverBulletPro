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
	// Token: 0x020000C7 RID: 199
	public class PageBlockPuppeteerGetDOM : Page, IComponentConnector
	{
		// Token: 0x06000593 RID: 1427 RVA: 0x0001BC07 File Offset: 0x00019E07
		public PageBlockPuppeteerGetDOM(BlockPuppeteerGetDOM block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0001BC1C File Offset: 0x00019E1C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteergetdom.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0001BC4C File Offset: 0x00019E4C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0001BC56 File Offset: 0x00019E56
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002A8 RID: 680
		private bool _contentLoaded;
	}
}
