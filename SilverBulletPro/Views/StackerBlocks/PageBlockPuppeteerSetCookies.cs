using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000D2 RID: 210
	public class PageBlockPuppeteerSetCookies : Page, IComponentConnector
	{
		// Token: 0x060005C1 RID: 1473 RVA: 0x0001C15B File Offset: 0x0001A35B
		public PageBlockPuppeteerSetCookies(BlockPuppeteerSetCookies block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtCookies.AddItems(block.Cookies);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0001C184 File Offset: 0x0001A384
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfoScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfoScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
			}
			catch
			{
			}
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0001C1DC File Offset: 0x0001A3DC
		private void Page_Unloaded(object sender, RoutedEventArgs e)
		{
			try
			{
				Action enableScrolling = GlobalData.MainWindow.ConfigsSecionPage.StackerPage.EnableScrolling;
				if (enableScrolling != null)
				{
					enableScrolling();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001C220 File Offset: 0x0001A420
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteersetcookies.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0001C250 File Offset: 0x0001A450
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0001C25C File Offset: 0x0001A45C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((PageBlockPuppeteerSetCookies)target).Loaded += this.Page_Loaded;
				((PageBlockPuppeteerSetCookies)target).Unloaded += this.Page_Unloaded;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.rtCookies = (RichTextInputBox)target;
		}

		// Token: 0x040002B5 RID: 693
		internal RichTextInputBox rtCookies;

		// Token: 0x040002B6 RID: 694
		private bool _contentLoaded;
	}
}
