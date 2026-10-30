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
	// Token: 0x02000146 RID: 326
	public class PageBlockSeleniumSetCookies : Page, IComponentConnector
	{
		// Token: 0x060007AC RID: 1964 RVA: 0x00021DBF File Offset: 0x0001FFBF
		public PageBlockSeleniumSetCookies(BlockSeleniumSetCookies block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtCookies.AddItems(block.Cookies);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00021DE8 File Offset: 0x0001FFE8
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

		// Token: 0x060007AE RID: 1966 RVA: 0x00021E40 File Offset: 0x00020040
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

		// Token: 0x060007AF RID: 1967 RVA: 0x00021E84 File Offset: 0x00020084
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumsetcookies.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00021EB4 File Offset: 0x000200B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00021EBE File Offset: 0x000200BE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((PageBlockSeleniumSetCookies)target).Unloaded += this.Page_Unloaded;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.rtCookies = (RichTextInputBox)target;
		}

		// Token: 0x04000390 RID: 912
		internal RichTextInputBox rtCookies;

		// Token: 0x04000391 RID: 913
		private bool _contentLoaded;
	}
}
