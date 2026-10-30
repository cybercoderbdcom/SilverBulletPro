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
	// Token: 0x020000AD RID: 173
	public class PageBlockPuppeteerSwitchToTab : Page, IComponentConnector
	{
		// Token: 0x06000529 RID: 1321 RVA: 0x0001A59C File Offset: 0x0001879C
		public PageBlockPuppeteerSwitchToTab(BlockPuppeteerSwitchToTab block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001A5B4 File Offset: 0x000187B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteerswitchtotab.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001A5E4 File Offset: 0x000187E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001A5EE File Offset: 0x000187EE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000276 RID: 630
		private bool _contentLoaded;
	}
}
