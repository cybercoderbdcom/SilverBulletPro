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
	// Token: 0x020000CC RID: 204
	public class PageBlockPuppeteerPageType : Page, IComponentConnector
	{
		// Token: 0x060005A9 RID: 1449 RVA: 0x0001BF4B File Offset: 0x0001A14B
		public PageBlockPuppeteerPageType(BlockPuppeteerPageType block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0001BF60 File Offset: 0x0001A160
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerpagetype.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0001BF90 File Offset: 0x0001A190
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0001BF9A File Offset: 0x0001A19A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002AF RID: 687
		private bool _contentLoaded;
	}
}
