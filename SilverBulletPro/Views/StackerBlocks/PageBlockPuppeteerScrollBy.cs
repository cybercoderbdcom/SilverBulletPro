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
	// Token: 0x020000CF RID: 207
	public class PageBlockPuppeteerScrollBy : Page, IComponentConnector
	{
		// Token: 0x060005B5 RID: 1461 RVA: 0x0001C053 File Offset: 0x0001A253
		public PageBlockPuppeteerScrollBy(BlockPuppeteerScrollBy block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0001C068 File Offset: 0x0001A268
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerscrollby.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0001C098 File Offset: 0x0001A298
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0001C0A2 File Offset: 0x0001A2A2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B2 RID: 690
		private bool _contentLoaded;
	}
}
