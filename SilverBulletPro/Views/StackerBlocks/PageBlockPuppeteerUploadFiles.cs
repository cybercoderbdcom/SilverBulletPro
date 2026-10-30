using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000C1 RID: 193
	public class PageBlockPuppeteerUploadFiles : Page, IComponentConnector
	{
		// Token: 0x06000579 RID: 1401 RVA: 0x0001B7A4 File Offset: 0x000199A4
		public PageBlockPuppeteerUploadFiles(BlockPuppeteerUploadFiles block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtFilePaths.AddItems(block.FilePaths);
			foreach (object obj in Enum.GetValues(typeof(FindElementBy)))
			{
				FindElementBy findElementBy = (FindElementBy)obj;
				if (ReflectionExtension.GetAttribute<IgnorePuppeteer>(findElementBy) == null)
				{
					this.findByComboBox.Items.Add(findElementBy);
				}
			}
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0001B848 File Offset: 0x00019A48
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

		// Token: 0x0600057B RID: 1403 RVA: 0x0001B8A0 File Offset: 0x00019AA0
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

		// Token: 0x0600057C RID: 1404 RVA: 0x0001B8E4 File Offset: 0x00019AE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/elements/pageblockpuppeteeruploadfiles.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0001B914 File Offset: 0x00019B14
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001B920 File Offset: 0x00019B20
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((PageBlockPuppeteerUploadFiles)target).Loaded += this.Page_Loaded;
				((PageBlockPuppeteerUploadFiles)target).Unloaded += this.Page_Unloaded;
				return;
			case 2:
				this.findByComboBox = (ComboBox)target;
				return;
			case 3:
				this.rtFilePaths = (RichTextInputBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400029E RID: 670
		internal ComboBox findByComboBox;

		// Token: 0x0400029F RID: 671
		internal RichTextInputBox rtFilePaths;

		// Token: 0x040002A0 RID: 672
		private bool _contentLoaded;
	}
}
