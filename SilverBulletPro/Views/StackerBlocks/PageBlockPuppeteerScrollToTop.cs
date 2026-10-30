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
	// Token: 0x020000D1 RID: 209
	public class PageBlockPuppeteerScrollToTop : Page, IComponentConnector
	{
		// Token: 0x060005BD RID: 1469 RVA: 0x0001C103 File Offset: 0x0001A303
		public PageBlockPuppeteerScrollToTop(BlockPuppeteerScrollToTop block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001C118 File Offset: 0x0001A318
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerscrolltotop.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001C148 File Offset: 0x0001A348
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001C152 File Offset: 0x0001A352
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B4 RID: 692
		private bool _contentLoaded;
	}
}
