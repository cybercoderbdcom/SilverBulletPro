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
	// Token: 0x020000A8 RID: 168
	public class PageBlockPuppeteerGoForward : Page, IComponentConnector
	{
		// Token: 0x06000515 RID: 1301 RVA: 0x0001A36B File Offset: 0x0001856B
		public PageBlockPuppeteerGoForward(BlockPuppeteerGoForward block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0001A380 File Offset: 0x00018580
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/browser/pageblockpuppeteergoforward.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0001A3B0 File Offset: 0x000185B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0001A3BA File Offset: 0x000185BA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400026F RID: 623
		private bool _contentLoaded;
	}
}
