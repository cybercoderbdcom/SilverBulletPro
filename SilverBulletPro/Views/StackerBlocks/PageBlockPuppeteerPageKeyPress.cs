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
	// Token: 0x020000CA RID: 202
	public class PageBlockPuppeteerPageKeyPress : Page, IComponentConnector
	{
		// Token: 0x060005A1 RID: 1441 RVA: 0x0001BE9B File Offset: 0x0001A09B
		public PageBlockPuppeteerPageKeyPress(BlockPuppeteerPageKeyPress block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0001BEB0 File Offset: 0x0001A0B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerpagekeypress.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0001BEE0 File Offset: 0x0001A0E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0001BEEA File Offset: 0x0001A0EA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002AD RID: 685
		private bool _contentLoaded;
	}
}
