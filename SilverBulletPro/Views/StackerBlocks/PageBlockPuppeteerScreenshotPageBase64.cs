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
	// Token: 0x020000CE RID: 206
	public class PageBlockPuppeteerScreenshotPageBase64 : Page, IComponentConnector
	{
		// Token: 0x060005B1 RID: 1457 RVA: 0x0001BFFB File Offset: 0x0001A1FB
		public PageBlockPuppeteerScreenshotPageBase64(BlockPuppeteerScreenshotPageBase64 block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0001C010 File Offset: 0x0001A210
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerscreenshotpagebase64.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001C040 File Offset: 0x0001A240
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0001C04A File Offset: 0x0001A24A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B1 RID: 689
		private bool _contentLoaded;
	}
}
