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
	// Token: 0x020000CD RID: 205
	public class PageBlockPuppeteerScreenshotPage : Page, IComponentConnector
	{
		// Token: 0x060005AD RID: 1453 RVA: 0x0001BFA3 File Offset: 0x0001A1A3
		public PageBlockPuppeteerScreenshotPage(BlockPuppeteerScreenshotPage block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0001BFB8 File Offset: 0x0001A1B8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerscreenshotpage.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0001BFE8 File Offset: 0x0001A1E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0001BFF2 File Offset: 0x0001A1F2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B0 RID: 688
		private bool _contentLoaded;
	}
}
