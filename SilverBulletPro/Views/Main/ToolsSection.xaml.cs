using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using HandyControl.Controls;
using SilverBulletPro.Views.Main.Tools;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x02000185 RID: 389
	public partial class ToolsSection : Page
	{
		// Token: 0x06000994 RID: 2452 RVA: 0x0002BBC4 File Offset: 0x00029DC4
		public ToolsSection()
		{
			this.InitializeComponent();
			this.ListGenerator = new ListGenerator();
			this.WordlistTools = new WordlistTools();
			this.BrowserTools = new BrowserTools();
			this.TessDataDownloader = new TessDataDownloader();
			this.ConfigConverter = new ConfigConverter();
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0002BC14 File Offset: 0x00029E14
		private void Frame_Navigated(object sender, NavigationEventArgs e)
		{
			try
			{
				(sender as Frame).NavigationService.RemoveBackEntry();
			}
			catch
			{
			}
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0002BC48 File Offset: 0x00029E48
		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TabControl tabControl = sender as TabControl;
			switch (tabControl.SelectedIndex)
			{
			case 0:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.ListGenerator;
					return;
				}
				break;
			}
			case 1:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.BrowserTools;
					return;
				}
				break;
			}
			case 2:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.WordlistTools;
					return;
				}
				break;
			}
			case 3:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.TessDataDownloader;
					return;
				}
				break;
			}
			case 4:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.ConfigConverter;
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0002BD5C File Offset: 0x00029F5C
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (GlobalData.SBSettings.General.DisableAnimationMode)
				{
					this.trans.TransitionStoryboard = new Storyboard();
				}
				else if (!GlobalData.SBSettings.General.DisableAnimationMode)
				{
					this.trans.TransitionStoryboard = null;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400047B RID: 1147
		private ListGenerator ListGenerator;

		// Token: 0x0400047C RID: 1148
		private WordlistTools WordlistTools;

		// Token: 0x0400047D RID: 1149
		private BrowserTools BrowserTools;

		// Token: 0x0400047E RID: 1150
		private TessDataDownloader TessDataDownloader;

		// Token: 0x0400047F RID: 1151
		private ConfigConverter ConfigConverter;
	}
}
