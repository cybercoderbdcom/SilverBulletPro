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
	// Token: 0x020000A7 RID: 167
	public class PageBlockPuppeteerGoBack : Page, IComponentConnector
	{
		// Token: 0x06000511 RID: 1297 RVA: 0x0001A313 File Offset: 0x00018513
		public PageBlockPuppeteerGoBack(BlockPuppeteerGoBack block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0001A328 File Offset: 0x00018528
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteergoback.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0001A358 File Offset: 0x00018558
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0001A362 File Offset: 0x00018562
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400026E RID: 622
		private bool _contentLoaded;
	}
}
