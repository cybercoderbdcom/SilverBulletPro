using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PuppeteerSharp;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000C8 RID: 200
	public class PageBlockPuppeteerNavigateTo : Page, IComponentConnector
	{
		// Token: 0x06000597 RID: 1431 RVA: 0x0001BC60 File Offset: 0x00019E60
		public PageBlockPuppeteerNavigateTo(BlockPuppeteerNavigateTo block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(WaitUntilNavigation)))
			{
				WaitUntilNavigation waitUntilNavigation = (WaitUntilNavigation)obj;
				this.loadedEventComboBox.Items.Add(waitUntilNavigation);
			}
			this.rtCustomHeaders.AddItems(block.CustomHeaders);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0001BCF8 File Offset: 0x00019EF8
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

		// Token: 0x06000599 RID: 1433 RVA: 0x0001BD50 File Offset: 0x00019F50
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

		// Token: 0x0600059A RID: 1434 RVA: 0x0001BD94 File Offset: 0x00019F94
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteernavigateto.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0001BDC4 File Offset: 0x00019FC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0001BDD0 File Offset: 0x00019FD0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((PageBlockPuppeteerNavigateTo)target).Loaded += this.Page_Loaded;
				((PageBlockPuppeteerNavigateTo)target).Unloaded += this.Page_Unloaded;
				return;
			case 2:
				this.loadedEventComboBox = (ComboBox)target;
				return;
			case 3:
				this.rtCustomHeaders = (RichTextInputBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040002A9 RID: 681
		internal ComboBox loadedEventComboBox;

		// Token: 0x040002AA RID: 682
		internal RichTextInputBox rtCustomHeaders;

		// Token: 0x040002AB RID: 683
		private bool _contentLoaded;
	}
}
