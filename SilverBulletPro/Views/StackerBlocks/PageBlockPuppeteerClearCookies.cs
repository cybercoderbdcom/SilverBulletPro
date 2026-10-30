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
	// Token: 0x020000C3 RID: 195
	public class PageBlockPuppeteerClearCookies : Page, IComponentConnector
	{
		// Token: 0x06000583 RID: 1411 RVA: 0x0001BA7C File Offset: 0x00019C7C
		public PageBlockPuppeteerClearCookies(BlockPuppeteerClearCookies block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0001BA94 File Offset: 0x00019C94
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerclearcookies.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0001BAC4 File Offset: 0x00019CC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0001BACE File Offset: 0x00019CCE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002A3 RID: 675
		private bool _contentLoaded;
	}
}
