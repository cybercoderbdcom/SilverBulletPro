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
	// Token: 0x020000D4 RID: 212
	public class PageBlockPuppeteerSetViewport : Page, IComponentConnector
	{
		// Token: 0x060005CB RID: 1483 RVA: 0x0001C30F File Offset: 0x0001A50F
		public PageBlockPuppeteerSetViewport(BlockPuppeteerSetViewport block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001C324 File Offset: 0x0001A524
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteersetviewport.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0001C354 File Offset: 0x0001A554
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0001C35E File Offset: 0x0001A55E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B8 RID: 696
		private bool _contentLoaded;
	}
}
