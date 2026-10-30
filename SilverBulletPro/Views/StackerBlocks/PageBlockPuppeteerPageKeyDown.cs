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
	// Token: 0x020000C9 RID: 201
	public class PageBlockPuppeteerPageKeyDown : Page, IComponentConnector
	{
		// Token: 0x0600059D RID: 1437 RVA: 0x0001BE43 File Offset: 0x0001A043
		public PageBlockPuppeteerPageKeyDown(BlockPuppeteerPageKeyDown block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0001BE58 File Offset: 0x0001A058
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerpagekeydown.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0001BE88 File Offset: 0x0001A088
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0001BE92 File Offset: 0x0001A092
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002AC RID: 684
		private bool _contentLoaded;
	}
}
