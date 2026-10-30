using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using HandyControl.Controls;
using MahApps.Metro.IconPacks;
using SilverBulletPro.Animations;
using SilverBulletPro.Converters;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Views.Main.Configs;
using SilverBulletPro.Views.Main.Configs.OtherOptions;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x0200017C RID: 380
	public partial class ConfigsSection : Page
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x00025AF6 File Offset: 0x00023CF6
		// (set) Token: 0x060008BC RID: 2236 RVA: 0x00025AFE File Offset: 0x00023CFE
		public General GeneralPage { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060008BD RID: 2237 RVA: 0x00025B07 File Offset: 0x00023D07
		// (set) Token: 0x060008BE RID: 2238 RVA: 0x00025B0F File Offset: 0x00023D0F
		public Proxies ProxiesPage { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x00025B18 File Offset: 0x00023D18
		// (set) Token: 0x060008C0 RID: 2240 RVA: 0x00025B20 File Offset: 0x00023D20
		public Inputs InputPage { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x00025B29 File Offset: 0x00023D29
		// (set) Token: 0x060008C2 RID: 2242 RVA: 0x00025B31 File Offset: 0x00023D31
		public Data DataPage { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060008C3 RID: 2243 RVA: 0x00025B3A File Offset: 0x00023D3A
		// (set) Token: 0x060008C4 RID: 2244 RVA: 0x00025B42 File Offset: 0x00023D42
		public Puppeteer PuppeteerPage { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x00025B4B File Offset: 0x00023D4B
		// (set) Token: 0x060008C6 RID: 2246 RVA: 0x00025B53 File Offset: 0x00023D53
		public Selenium SeleniumPage { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x00025B5C File Offset: 0x00023D5C
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x00025B64 File Offset: 0x00023D64
		public Compile CompilePage { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x00025B6D File Offset: 0x00023D6D
		// (set) Token: 0x060008CA RID: 2250 RVA: 0x00025B75 File Offset: 0x00023D75
		public Readme ReadmePage { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x00025B7E File Offset: 0x00023D7E
		// (set) Token: 0x060008CC RID: 2252 RVA: 0x00025B86 File Offset: 0x00023D86
		public Interpreter InterpreterPage { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x00025B8F File Offset: 0x00023D8F
		// (set) Token: 0x060008CE RID: 2254 RVA: 0x00025B97 File Offset: 0x00023D97
		public Ocr OcrPage { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060008CF RID: 2255 RVA: 0x00025BA0 File Offset: 0x00023DA0
		public ConfigViewModel CurrentConfig
		{
			get
			{
				return GlobalData.ConfigManager.CurrentConfig;
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00025BAC File Offset: 0x00023DAC
		public ConfigsSection()
		{
			this.InitializeComponent();
			this.managerFrame = FrameExtension.CreateWithoutNavigation(new Thickness(0.0));
			ContentControl contentControl = this.managerFrame;
			ConfigManager configManager = new ConfigManager();
			configManager.Margin = new Thickness(0.0, 12.0, 0.0, 0.0);
			ConfigManager content = configManager;
			this.ConfigManagerPage = configManager;
			contentControl.Content = content;
			this.tabItemManager.Content = this.managerFrame;
			GlobalData.Logger.LogInfo(Components.ConfigManager, "Initialized Manager Page", false, 0);
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00025C49 File Offset: 0x00023E49
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			this.SettingsSubMenuSizeChanged();
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00025C59 File Offset: 0x00023E59
		public void menuOptionStacker_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (this.CurrentConfig != null && this.StackerPage != null)
			{
				this.mainTabCtrl.SelectedIndex = 1;
				return;
			}
			GlobalData.Logger.LogError(Components.ConfigManager, "Cannot switch to stacker since no config is loaded or the loaded config isn't public", false, 0);
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00025C8A File Offset: 0x00023E8A
		private void TabItemSettings_MouseEnter(object sender, MouseEventArgs e)
		{
			this.mouseEnterSettingsSubMenu = true;
			if (this.settingsSubMenu.Visibility == Visibility.Visible)
			{
				return;
			}
			Task.Run(delegate()
			{
				Task.Delay(235).Wait();
				if (!this.mouseEnterSettingsSubMenu)
				{
					return;
				}
				base.Dispatcher.Invoke(delegate()
				{
					VisibilityAnimation.BeginAnimation(this.settingsSubMenu, Visibility.Visible, 100);
				});
			});
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00025CB3 File Offset: 0x00023EB3
		private void TabItemSettings_MouseLeave(object sender, MouseEventArgs e)
		{
			this.mouseEnterSettingsSubMenu = false;
			Task.Run(delegate()
			{
				Task.Delay(350).Wait();
				if (this.mouseEnterSettingsSubMenu)
				{
					return;
				}
				base.Dispatcher.Invoke(delegate()
				{
					VisibilityAnimation.BeginAnimation(this.settingsSubMenu, Visibility.Collapsed, 100);
				});
			});
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00025CCE File Offset: 0x00023ECE
		private void TabItemSettings_MouseLeave_Icon(object sender, MouseEventArgs e)
		{
			this.mouseEnterSettingsSubMenu = false;
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00025CD7 File Offset: 0x00023ED7
		private void SettingsSubMenu_MouseEnter(object sender, MouseEventArgs e)
		{
			this.mouseEnterSettingsSubMenu = true;
			if (this.settingsSubMenu.Visibility == Visibility.Collapsed)
			{
				VisibilityAnimation.BeginAnimation(this.settingsSubMenu, Visibility.Visible, 50);
			}
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00025CFC File Offset: 0x00023EFC
		private void SettingsSubMenu_MouseLeave(object sender, MouseEventArgs e)
		{
			this.TabItemSettings_MouseLeave(sender, e);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00025D06 File Offset: 0x00023F06
		private void SettingsSubMenu_LostFocus(object sender, RoutedEventArgs e)
		{
			this.SettingsSubMenu_MouseLeave(null, null);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x00025D10 File Offset: 0x00023F10
		private void CloseSubMenu()
		{
			VisibilityAnimation.BeginAnimation(this.settingsSubMenu, Visibility.Collapsed, 90);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00025D20 File Offset: 0x00023F20
		private void TabItem_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (this.oldTabItemManagerWidth != this.tabItemManager.RenderSize.Width || this.oldTabItemStackerWidth != this.tabItemStacker.RenderSize.Width)
			{
				this.SettingsSubMenuSizeChanged();
			}
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00025D6C File Offset: 0x00023F6C
		private double SettingsSubMenuSizeChanged()
		{
			this.oldTabItemManagerWidth = this.tabItemManager.RenderSize.Width;
			this.oldTabItemStackerWidth = this.tabItemStacker.RenderSize.Width;
			MultiBinding multiBinding = new MultiBinding
			{
				UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				Converter = new SettingsSubMenuMarginConverter()
			};
			multiBinding.Bindings.Add(new Binding("RenderSize.Width")
			{
				ElementName = "tabItemManager"
			});
			multiBinding.Bindings.Add(new Binding("RenderSize.Width")
			{
				ElementName = "tabItemStacker"
			});
			this.settingsSubMenu.SetBinding(FrameworkElement.MarginProperty, multiBinding);
			return this.settingsSubMenu.Margin.Left;
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00025E28 File Offset: 0x00024028
		private void TabItemSettings_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				return;
			}
			this.mouseEnterSettingsSubMenu = true;
			if (this.settingsSubMenu.Visibility == Visibility.Visible)
			{
				return;
			}
			base.Dispatcher.Invoke(delegate()
			{
				VisibilityAnimation.BeginAnimation(this.settingsSubMenu, Visibility.Visible, 100);
			});
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00025E60 File Offset: 0x00024060
		private void General_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.SettingsSubMenu_LostFocus(sender, e);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00025E6C File Offset: 0x0002406C
		private void ButtonProxySettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "Proxies";
			PackIconOcticons packIconOcticons = new PackIconOcticons();
			packIconOcticons.Height = 15.0;
			packIconOcticons.Kind = 168;
			Proxies page;
			if ((page = this.ProxiesPage) == null)
			{
				page = (this.ProxiesPage = new Proxies());
			}
			this.SelectSubMenu(name, packIconOcticons, page);
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00025EBC File Offset: 0x000240BC
		private void ButtonPuppeteerSettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "Puppeteer";
			PackIconModern packIconModern = new PackIconModern();
			packIconModern.Height = 14.5;
			packIconModern.Kind = 103;
			packIconModern.Margin = new Thickness(0.0, 1.0, 0.0, 0.0);
			Puppeteer page;
			if ((page = this.PuppeteerPage) == null)
			{
				page = (this.PuppeteerPage = new Puppeteer());
			}
			this.SelectSubMenu(name, packIconModern, page);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00025F38 File Offset: 0x00024138
		private void ButtonSeleniumSettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "Selenium";
			PackIconSimpleIcons packIconSimpleIcons = new PackIconSimpleIcons();
			packIconSimpleIcons.Height = 14.5;
			packIconSimpleIcons.Kind = 1575;
			packIconSimpleIcons.Margin = new Thickness(0.0, 1.0, 0.0, 0.0);
			Selenium page;
			if ((page = this.SeleniumPage) == null)
			{
				page = (this.SeleniumPage = new Selenium());
			}
			this.SelectSubMenu(name, packIconSimpleIcons, page);
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00025FB8 File Offset: 0x000241B8
		private void ButtonDataSettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "Data";
			PackIconMaterialDesign packIconMaterialDesign = new PackIconMaterialDesign();
			packIconMaterialDesign.Width = 15.0;
			packIconMaterialDesign.Kind = 212;
			Data page;
			if ((page = this.DataPage) == null)
			{
				page = (this.DataPage = new Data());
			}
			this.SelectSubMenu(name, packIconMaterialDesign, page);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00026008 File Offset: 0x00024208
		private void ButtonInputSettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "Input";
			PackIconModern packIconModern = new PackIconModern();
			packIconModern.Height = 15.0;
			packIconModern.Kind = 509;
			Inputs page;
			if ((page = this.InputPage) == null)
			{
				page = (this.InputPage = new Inputs());
			}
			this.SelectSubMenu(name, packIconModern, page);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00026058 File Offset: 0x00024258
		private void ButtonCompileSettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "Compile";
			PackIconIonicons packIconIonicons = new PackIconIonicons();
			packIconIonicons.Height = 15.0;
			packIconIonicons.Kind = 112;
			Compile page;
			if ((page = this.CompilePage) == null)
			{
				page = (this.CompilePage = new Compile());
			}
			this.SelectSubMenu(name, packIconIonicons, page);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x000260A4 File Offset: 0x000242A4
		private void ButtonReadmeSettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "Readme";
			PackIconFontAwesome packIconFontAwesome = new PackIconFontAwesome();
			packIconFontAwesome.Height = 15.0;
			packIconFontAwesome.Kind = 1138;
			Readme page;
			if ((page = this.ReadmePage) == null)
			{
				page = (this.ReadmePage = new Readme());
			}
			this.SelectSubMenu(name, packIconFontAwesome, page);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x000260F4 File Offset: 0x000242F4
		private void ButtonInterpreterSettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "Interpreter";
			PackIconMaterial packIconMaterial = new PackIconMaterial();
			packIconMaterial.Kind = 1745;
			Interpreter page;
			if ((page = this.InterpreterPage) == null)
			{
				page = (this.InterpreterPage = new Interpreter());
			}
			this.SelectSubMenu(name, packIconMaterial, page);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00026134 File Offset: 0x00024334
		private void ButtonOcrSettings_Click(object sender, RoutedEventArgs e)
		{
			string name = "OCR";
			PackIconMaterial packIconMaterial = new PackIconMaterial();
			packIconMaterial.Kind = 3457;
			Ocr page;
			if ((page = this.OcrPage) == null)
			{
				page = (this.OcrPage = new Ocr());
			}
			this.SelectSubMenu(name, packIconMaterial, page);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00026174 File Offset: 0x00024374
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.W && ((Frame)this.mainTabCtrl.SelectedContent).Content.GetType() == typeof(Stacker))
				{
					this.DestoryStacker_Click(sender, e);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x000261DC File Offset: 0x000243DC
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

		// Token: 0x060008E9 RID: 2281 RVA: 0x00026240 File Offset: 0x00024440
		public void DestoryStacker_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Alert.Choice("Are you sure you want to close the Stacker?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					GlobalData.ConfigManager.CurrentConfig = null;
					GlobalData.MainWindow.ConfigsSecionPage.tabItemStacker.IsEnabled = false;
					GlobalData.MainWindow.ConfigsSecionPage.tabItemSettings.IsEnabled = false;
					GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.IsEnabled = false;
					GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.Visibility = Visibility.Collapsed;
					GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.Content = null;
					try
					{
						GlobalData.MainWindow.ConfigsSecionPage.StackerPage.Destroy();
					}
					catch
					{
					}
					try
					{
						GlobalData.MainWindow.ConfigsSecionPage.StackerPage = new Stacker();
					}
					catch
					{
					}
					GlobalData.MainWindow.ConfigsSecionPage.mainTabCtrl.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0002635C File Offset: 0x0002455C
		private void SelectSubMenu(string name, PackIconControlBase icon, Page page)
		{
			this.textBlockTabItemSubMenu.Text = name;
			DockPanel dockPanel = this.tabItemSubMenu.Header as DockPanel;
			dockPanel.Children.RemoveAt(0);
			dockPanel.Children.Insert(0, icon);
			this.subMebuFrame = this.CheckFrame(this.subMebuFrame);
			this.subMebuFrame.Content = page;
			this.tabItemSubMenu.IsEnabled = true;
			this.tabItemSubMenu.Content = this.subMebuFrame;
			this.CloseSubMenu();
			this.tabItemSubMenu.Visibility = Visibility.Visible;
			this.mainTabCtrl.SelectedIndex = 3;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x000263F8 File Offset: 0x000245F8
		private void TabCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch ((sender as TabControl).SelectedIndex)
			{
			case 0:
				this.managerFrame = this.CheckFrame(this.managerFrame);
				this.managerFrame.Content = this.ConfigManagerPage;
				this.tabItemManager.Content = this.managerFrame;
				return;
			case 1:
				if (this.StackerPage == null)
				{
					return;
				}
				this.stackerFrame = this.CheckFrame(this.stackerFrame);
				this.stackerFrame.Content = this.StackerPage;
				this.tabItemStacker.Content = this.stackerFrame;
				return;
			case 2:
				if (this.GeneralPage == null)
				{
					this.GeneralPage = new General
					{
						Margin = new Thickness(5.0, 7.0, 5.0, 5.0),
						Background = Brushes.Transparent
					};
					this.GeneralPage.MouseDown += this.General_MouseDown;
				}
				this.settingsFrame = this.CheckFrame(this.settingsFrame);
				this.settingsFrame.Content = this.GeneralPage;
				this.tabItemSettings.Content = this.settingsFrame;
				return;
			default:
				return;
			}
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0002652F File Offset: 0x0002472F
		private Frame CheckFrame(Frame frame)
		{
			return frame ?? FrameExtension.CreateWithoutNavigation(new Thickness(0.0));
		}

		// Token: 0x04000410 RID: 1040
		public ConfigManager ConfigManagerPage;

		// Token: 0x04000411 RID: 1041
		public Stacker StackerPage;

		// Token: 0x0400041C RID: 1052
		private Frame managerFrame;

		// Token: 0x0400041D RID: 1053
		private Frame stackerFrame;

		// Token: 0x0400041E RID: 1054
		private Frame settingsFrame;

		// Token: 0x0400041F RID: 1055
		private Frame subMebuFrame;

		// Token: 0x04000420 RID: 1056
		private double oldTabItemManagerWidth;

		// Token: 0x04000421 RID: 1057
		private double oldTabItemStackerWidth;

		// Token: 0x04000422 RID: 1058
		private bool mouseEnterSettingsSubMenu;
	}
}
