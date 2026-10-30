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
	// Token: 0x020000CB RID: 203
	public class PageBlockPuppeteerPageKeyUp : Page, IComponentConnector
	{
		// Token: 0x060005A5 RID: 1445 RVA: 0x0001BEF3 File Offset: 0x0001A0F3
		public PageBlockPuppeteerPageKeyUp(BlockPuppeteerPageKeyUp block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0001BF08 File Offset: 0x0001A108
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerpagekeyup.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0001BF38 File Offset: 0x0001A138
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0001BF42 File Offset: 0x0001A142
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002AE RID: 686
		private bool _contentLoaded;
	}
}
