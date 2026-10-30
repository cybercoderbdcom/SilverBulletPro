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
	// Token: 0x020000D3 RID: 211
	public class PageBlockPuppeteerSetUserAgent : Page, IComponentConnector
	{
		// Token: 0x060005C7 RID: 1479 RVA: 0x0001C2B6 File Offset: 0x0001A4B6
		public PageBlockPuppeteerSetUserAgent(BlockPuppeteerSetUserAgent block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001C2CC File Offset: 0x0001A4CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteersetuseragent.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0001C2FC File Offset: 0x0001A4FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001C306 File Offset: 0x0001A506
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B7 RID: 695
		private bool _contentLoaded;
	}
}
