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
	// Token: 0x020000D7 RID: 215
	public class PageBlockPuppeteerWaitForResponse : Page, IComponentConnector
	{
		// Token: 0x060005D7 RID: 1495 RVA: 0x0001C49C File Offset: 0x0001A69C
		public PageBlockPuppeteerWaitForResponse(BlockPuppeteerWaitForResponse block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001C4B4 File Offset: 0x0001A6B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerwaitforresponse.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001C4E4 File Offset: 0x0001A6E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001C4EE File Offset: 0x0001A6EE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002BC RID: 700
		private bool _contentLoaded;
	}
}
