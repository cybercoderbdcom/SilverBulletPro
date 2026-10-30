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
	// Token: 0x020000A6 RID: 166
	public class PageBlockPuppeteerCloseTab : Page, IComponentConnector
	{
		// Token: 0x0600050D RID: 1293 RVA: 0x0001A2BB File Offset: 0x000184BB
		public PageBlockPuppeteerCloseTab(BlockPuppeteerCloseTab block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0001A2D0 File Offset: 0x000184D0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteerclosetab.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0001A300 File Offset: 0x00018500
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0001A30A File Offset: 0x0001850A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400026D RID: 621
		private bool _contentLoaded;
	}
}
