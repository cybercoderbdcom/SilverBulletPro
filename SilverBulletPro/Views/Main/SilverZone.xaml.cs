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
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x02000181 RID: 385
	public partial class SilverZone : Page
	{
		// Token: 0x0600096D RID: 2413 RVA: 0x0002AC88 File Offset: 0x00028E88
		public SilverZone(SilverZoneViewModel viewModel = null)
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = (viewModel ?? GlobalData.SilverZone));
			this.adsPage = new Ads();
			this.verifiedMarketPage = new VerifiedMarket();
			this.notifPage = new Notif();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0002ACDC File Offset: 0x00028EDC
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
					frame.Content = this.adsPage;
					return;
				}
				break;
			}
			case 1:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.verifiedMarketPage;
					return;
				}
				break;
			}
			case 2:
			{
				Frame frame;
				if ((frame = (Frame)(tabControl.SelectedItem as TabItem).Content).Content == null)
				{
					frame.Content = this.notifPage;
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0002AD8C File Offset: 0x00028F8C
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

		// Token: 0x06000970 RID: 2416 RVA: 0x0002ADC0 File Offset: 0x00028FC0
		public void UpdateBadge()
		{
			this.vm.AdsBadge = GlobalData.Ads.AdsDataList.Count;
			this.vm.VerifiedMarketBadge = GlobalData.VerifiedMarket.MarketDataList.Count;
			this.vm.NotifBadge = GlobalData.Notif.NotifDataList.Count;
			GlobalData.MainView.SilverZoneBadge = this.vm.AdsBadge + this.vm.VerifiedMarketBadge + this.vm.NotifBadge;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0002AE48 File Offset: 0x00029048
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

		// Token: 0x04000465 RID: 1125
		private Ads adsPage;

		// Token: 0x04000466 RID: 1126
		private VerifiedMarket verifiedMarketPage;

		// Token: 0x04000467 RID: 1127
		private Notif notifPage;

		// Token: 0x04000468 RID: 1128
		public SilverZoneViewModel vm;
	}
}
