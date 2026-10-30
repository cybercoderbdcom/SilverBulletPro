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
	// Token: 0x020000AA RID: 170
	public class PageBlockPuppeteerOpenBrowser : Page, IComponentConnector
	{
		// Token: 0x0600051D RID: 1309 RVA: 0x0001A41B File Offset: 0x0001861B
		public PageBlockPuppeteerOpenBrowser(BlockPuppeteerOpenBrowser block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.captchaTypeBox.Items.Add(3);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001A448 File Offset: 0x00018648
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteeropenbrowser.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0001A478 File Offset: 0x00018678
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0001A482 File Offset: 0x00018682
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

		// Token: 0x04000271 RID: 625
		internal ComboBox captchaTypeBox;

		// Token: 0x04000272 RID: 626
		private bool _contentLoaded;
	}
}
