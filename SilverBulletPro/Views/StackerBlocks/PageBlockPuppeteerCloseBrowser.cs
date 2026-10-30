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
	// Token: 0x020000A5 RID: 165
	public class PageBlockPuppeteerCloseBrowser : Page, IComponentConnector
	{
		// Token: 0x06000509 RID: 1289 RVA: 0x0001A260 File Offset: 0x00018460
		public PageBlockPuppeteerCloseBrowser(BlockPuppeteerCloseBrowser block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0001A278 File Offset: 0x00018478
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteerclosebrowser.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0001A2A8 File Offset: 0x000184A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0001A2B2 File Offset: 0x000184B2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400026C RID: 620
		private bool _contentLoaded;
	}
}
