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
	// Token: 0x020000C6 RID: 198
	public class PageBlockPuppeteerGetCookies : Page, IComponentConnector
	{
		// Token: 0x0600058F RID: 1423 RVA: 0x0001BBAF File Offset: 0x00019DAF
		public PageBlockPuppeteerGetCookies(BlockPuppeteerGetCookies block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0001BBC4 File Offset: 0x00019DC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteergetcookies.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0001BBF4 File Offset: 0x00019DF4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0001BBFE File Offset: 0x00019DFE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002A7 RID: 679
		private bool _contentLoaded;
	}
}
