using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Views.Main.Settings.Core;

namespace SilverBulletPro.Views.Main.Settings
{
	// Token: 0x0200018C RID: 396
	public partial class CoreSettings : Page
	{
		// Token: 0x060009EC RID: 2540 RVA: 0x0002E01C File Offset: 0x0002C21C
		public CoreSettings()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0002E084 File Offset: 0x0002C284
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
					frame.Content = this.GeneralPage;
					return;
				}
				break;
			}
			case 1:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.ProxiesPage;
					return;
				}
				break;
			}
			case 2:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.CaptchasPage;
					return;
				}
				break;
			}
			case 3:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.PuppeteerPage;
					return;
				}
				break;
			}
			case 4:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.SeleniumPage;
					return;
				}
				break;
			}
			case 5:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.CompilePage;
					return;
				}
				break;
			}
			case 6:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.OcrPage;
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0002E1FC File Offset: 0x0002C3FC
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

		// Token: 0x060009EF RID: 2543 RVA: 0x0002E230 File Offset: 0x0002C430
		private void saveButton_Click(object sender, RoutedEventArgs e)
		{
			IOManager.SaveSettings<CoreSettingsViewModel>(Constants.CoreSettingsFile, GlobalData.Settings.CoreSettings);
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0002E246 File Offset: 0x0002C446
		private void resetButton_Click(object sender, RoutedEventArgs e)
		{
			if (Alert.Choice("Are you sure you want to reset all your SilverBulletPro.Core settings?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				GlobalData.Settings.CoreSettings.Reset();
			}
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0002E26C File Offset: 0x0002C46C
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

		// Token: 0x040004C0 RID: 1216
		private General GeneralPage = new General();

		// Token: 0x040004C1 RID: 1217
		private Proxies ProxiesPage = new Proxies();

		// Token: 0x040004C2 RID: 1218
		private Captchas CaptchasPage = new Captchas();

		// Token: 0x040004C3 RID: 1219
		private Puppeteer PuppeteerPage = new Puppeteer();

		// Token: 0x040004C4 RID: 1220
		private Selenium SeleniumPage = new Selenium();

		// Token: 0x040004C5 RID: 1221
		private Compile CompilePage = new Compile();

		// Token: 0x040004C6 RID: 1222
		private Ocr OcrPage = new Ocr();
	}
}
