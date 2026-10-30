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
	// Token: 0x020000D0 RID: 208
	public class PageBlockPuppeteerScrollToBottom : Page, IComponentConnector
	{
		// Token: 0x060005B9 RID: 1465 RVA: 0x0001C0AB File Offset: 0x0001A2AB
		public PageBlockPuppeteerScrollToBottom(BlockPuppeteerScrollToBottom block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0001C0C0 File Offset: 0x0001A2C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerscrolltobottom.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0001C0F0 File Offset: 0x0001A2F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0001C0FA File Offset: 0x0001A2FA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B3 RID: 691
		private bool _contentLoaded;
	}
}
