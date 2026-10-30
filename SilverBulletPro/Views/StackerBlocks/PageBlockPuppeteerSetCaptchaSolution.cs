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
	// Token: 0x020000AC RID: 172
	public class PageBlockPuppeteerSetCaptchaSolution : Page, IComponentConnector
	{
		// Token: 0x06000525 RID: 1317 RVA: 0x0001A4F8 File Offset: 0x000186F8
		public PageBlockPuppeteerSetCaptchaSolution(BlockPuppeteerSetCaptchaSolution block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.captchaTypeBox.Items.Add(3);
			this.captchaTypeBox.Items.Add(4);
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0001A548 File Offset: 0x00018748
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteersetcaptchasolution.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0001A578 File Offset: 0x00018778
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0001A582 File Offset: 0x00018782
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.captchaTypeBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000274 RID: 628
		internal ComboBox captchaTypeBox;

		// Token: 0x04000275 RID: 629
		private bool _contentLoaded;
	}
}
