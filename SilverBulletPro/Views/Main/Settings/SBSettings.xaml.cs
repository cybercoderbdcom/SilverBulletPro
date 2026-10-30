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
using SilverBulletPro.Core;

namespace SilverBulletPro.Views.Main.Settings
{
	// Token: 0x0200018D RID: 397
	public partial class SBSettings : Page
	{
		// Token: 0x060009F4 RID: 2548 RVA: 0x0002E4A5 File Offset: 0x0002C6A5
		public SBSettings()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x0002E4E0 File Offset: 0x0002C6E0
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

		// Token: 0x060009F6 RID: 2550 RVA: 0x0002E514 File Offset: 0x0002C714
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
					frame.Content = this.SoundsPage;
					return;
				}
				break;
			}
			case 2:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.SourcesPage;
					return;
				}
				break;
			}
			case 3:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.ThemesPage;
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0002E5F4 File Offset: 0x0002C7F4
		private void saveButton_Click(object sender, RoutedEventArgs e)
		{
			AppIOManager.SaveSettings(Constants.SBSettingsFile, GlobalData.SBSettings);
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0002E605 File Offset: 0x0002C805
		private void resetButton_Click(object sender, RoutedEventArgs e)
		{
			if (Alert.Choice("Are you sure you want to reset all your SilverBulletPro settings?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				GlobalData.SBSettings.Reset();
			}
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0002E628 File Offset: 0x0002C828
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

		// Token: 0x040004CD RID: 1229
		private General GeneralPage = new General();

		// Token: 0x040004CE RID: 1230
		private Sounds SoundsPage = new Sounds();

		// Token: 0x040004CF RID: 1231
		private Sources SourcesPage = new Sources();

		// Token: 0x040004D0 RID: 1232
		private Themes ThemesPage = new Themes();
	}
}
