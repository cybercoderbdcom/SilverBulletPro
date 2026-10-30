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
	// Token: 0x020000AB RID: 171
	public class PageBlockPuppeteerReload : Page, IComponentConnector
	{
		// Token: 0x06000521 RID: 1313 RVA: 0x0001A49C File Offset: 0x0001869C
		public PageBlockPuppeteerReload(BlockPuppeteerReload block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0001A4B4 File Offset: 0x000186B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteerreload.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001A4E4 File Offset: 0x000186E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0001A4EE File Offset: 0x000186EE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000273 RID: 627
		private bool _contentLoaded;
	}
}
