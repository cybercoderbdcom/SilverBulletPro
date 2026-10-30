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
	// Token: 0x020000A9 RID: 169
	public class PageBlockPuppeteerNewTab : Page, IComponentConnector
	{
		// Token: 0x06000519 RID: 1305 RVA: 0x0001A3C3 File Offset: 0x000185C3
		public PageBlockPuppeteerNewTab(BlockPuppeteerNewTab block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0001A3D8 File Offset: 0x000185D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteernewtab.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0001A408 File Offset: 0x00018608
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0001A412 File Offset: 0x00018612
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000270 RID: 624
		private bool _contentLoaded;
	}
}
