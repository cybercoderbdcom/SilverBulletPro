using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using HandyControl.Controls;
using HandyControl.Data;
using MdXaml;
using Newtonsoft.Json.Linq;
using PluginFrameworkPro;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Main.Configs.OtherOptions;

namespace SilverBulletPro.Views.Main.Configs
{
	// Token: 0x0200019B RID: 411
	public partial class ConfigManager : Page, IStyleConnector
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000AAC RID: 2732 RVA: 0x00034651 File Offset: 0x00032851
		private IEnumerable<ConfigViewModel> Selected
		{
			get
			{
				return this.configsListView.SelectedItems.Cast<ConfigViewModel>();
			}
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x00034663 File Offset: 0x00032863
		public void OnSaveConfig(object sender, EventArgs e)
		{
			this.SaveConfigButton_Click(this, new RoutedEventArgs());
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x00034674 File Offset: 0x00032874
		public ConfigManager()
		{
			this.vm = GlobalData.ConfigManager;
			base.DataContext = this.vm;
			this.InitializeComponent();
			this.SetFilters();
			if (GlobalData.SBSettings.General.ConfigManagerViewMode == ConfigManagerViewMode.ListView)
			{
				this.ButtonListViewConfig_Click(null, null);
				return;
			}
			this.ButtonGridViewConfig_Click(null, null);
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x000346CC File Offset: 0x000328CC
		public bool CheckSaved()
		{
			Stacker stackerPage = GlobalData.MainWindow.ConfigsSecionPage.StackerPage;
			if (this.vm.CurrentConfig == null || GlobalData.SBSettings.General.DisableNotSavedWarning || stackerPage == null)
			{
				return true;
			}
			stackerPage.SetScript();
			ConfigViewModel configViewModel = GlobalData.Stacker.ConfigViewModel;
			return configViewModel == null || this.vm.SavedHash == configViewModel.Config.Script.GetHashCode().ToString() + configViewModel.Config.Settings.GetHashCode().ToString();
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x00034768 File Offset: 0x00032968
		public void SaveState()
		{
			ConfigViewModel configViewModel = GlobalData.Stacker.ConfigViewModel;
			if (configViewModel != null)
			{
				this.vm.SavedHash = configViewModel.Config.Script.GetHashCode().ToString() + configViewModel.Config.Settings.GetHashCode().ToString();
			}
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x000347C4 File Offset: 0x000329C4
		private void loadConfigButton_Click(object sender, RoutedEventArgs e)
		{
			if (!this.CheckSaved())
			{
				GlobalData.Logger.LogWarning(Components.Stacker, "Config not saved, prompting quit confirmation", false, 0);
				if (Alert.Choice("The Config in Stacker wasn't saved.\nAre you sure you want to load another config?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
				{
					return;
				}
			}
			this.LoadConfig(this.vm.HoveredConfigViewModel);
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x00034814 File Offset: 0x00032A14
		private void RadioButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (e.ClickCount >= 1 && (e.LeftButton == MouseButtonState.Pressed || e.LeftButton == MouseButtonState.Released))
				{
					this.loadConfigButton_Click(sender, e);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00034858 File Offset: 0x00032A58
		private void SaveConfigButton_Click(object sender, RoutedEventArgs e)
		{
			this.SaveConfig();
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x00034860 File Offset: 0x00032A60
		private void deleteConfigsButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.ReloadTaskIsCompleted())
				{
					GlobalData.Logger.LogWarning(Components.ConfigManager, "Deletion initiated, prompting warning", false, 0);
					if (Alert.Choice("This will delete the physical files from your disk! Are you sure you want to continue?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
					{
						if (this.gridViewConfigScrollViwer.Visibility == Visibility.Visible)
						{
							this.vm.Remove(this.vm.HoveredConfigViewModel);
							if (this.vm.HoveredConfigViewModel == this.vm.CurrentConfig)
							{
								this.vm.CurrentConfig = null;
								this.vm.HoveredConfigViewModel = null;
								GlobalData.MainWindow.ConfigsSecionPage.tabItemStacker.IsEnabled = false;
								GlobalData.MainWindow.ConfigsSecionPage.tabItemSettings.IsEnabled = false;
								GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.IsEnabled = false;
							}
						}
						else
						{
							bool flag = this.Selected.Any((ConfigViewModel c) => c == this.vm.CurrentConfig);
							this.vm.Remove(this.Selected);
							if (flag)
							{
								this.vm.CurrentConfig = null;
								this.vm.HoveredConfigViewModel = null;
								GlobalData.MainWindow.ConfigsSecionPage.tabItemStacker.IsEnabled = false;
								GlobalData.MainWindow.ConfigsSecionPage.tabItemSettings.IsEnabled = false;
								GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.IsEnabled = false;
							}
							GlobalData.Logger.LogInfo(Components.ConfigManager, "Deletion completed", false, 0);
						}
					}
					else
					{
						GlobalData.Logger.LogInfo(Components.ConfigManager, "Deletion cancelled", false, 0);
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x00034A10 File Offset: 0x00032C10
		private void rescanConfigsButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.RefreshReadme();
			}
			catch
			{
			}
			Transform reloadRenderTransform = this.reloadIcon.RenderTransform;
			Storyboard waitForReloadCompleted = (Storyboard)base.FindResource("WaitForReloadCompleted");
			try
			{
				Task task = this.reloadTask;
				if (task != null)
				{
					task.Dispose();
				}
			}
			catch
			{
			}
			try
			{
				waitForReloadCompleted.Begin();
				Action <>9__1;
				this.reloadTask = Task.Run(new Action(this.vm.Rescan)).ContinueWith(delegate(Task t)
				{
					Dispatcher dispatcher = this.Dispatcher;
					Action callback;
					if ((callback = <>9__1) == null)
					{
						callback = (<>9__1 = delegate()
						{
							waitForReloadCompleted.Stop();
							this.reloadIcon.RenderTransform = reloadRenderTransform;
							if (this.gridViewConfigScrollViwer.Visibility == Visibility.Visible)
							{
								this.gridViewConfig.ItemsSource = null;
								this.gridViewConfig.ItemsSource = this.vm.ConfigsCollection;
							}
						});
					}
					dispatcher.Invoke(callback);
					try
					{
						t.Dispose();
					}
					catch
					{
					}
				});
			}
			catch (Exception ex)
			{
				Exception ex3;
				Exception ex2 = ex3;
				Exception ex = ex2;
				waitForReloadCompleted.Stop();
				base.Dispatcher.Invoke<Transform>(() => this.reloadIcon.RenderTransform = reloadRenderTransform);
				base.Dispatcher.Invoke(delegate()
				{
					GlobalData.Logger.Log(ex.Message, 2, true, 0);
				});
			}
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x00034B20 File Offset: 0x00032D20
		private void newConfigButton_Click(object sender, RoutedEventArgs e)
		{
			if (!this.CheckSaved())
			{
				GlobalData.Logger.LogWarning(Components.Stacker, "Config not saved, prompting quit confirmation", false, 0);
				if (Alert.Choice("The Config in Stacker wasn't saved.\r\nAre you sure you want to create a new config?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
				{
					return;
				}
			}
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new DialogNewConfig(this),
				Title = "New Config"
			}).ShowDialog();
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x00034B84 File Offset: 0x00032D84
		private void searchButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.SearchString = this.filterTextBox.Text;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00034B9C File Offset: 0x00032D9C
		private void FilterTypeComboBox_LostFocus(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x00034B9E File Offset: 0x00032D9E
		private void FilterTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.searchButton_Click(this, null);
			}
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00034BB1 File Offset: 0x00032DB1
		private void FilterTextBox_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			this.searchButton_Click(this, null);
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00034BBB File Offset: 0x00032DBB
		private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.filterTextBox.Text))
			{
				this.searchButton_Click(this, null);
			}
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00034BD8 File Offset: 0x00032DD8
		private void openConfigFolderButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start(Path.Combine(Directory.GetCurrentDirectory(), Constants.ConfigFolder));
			}
			catch
			{
				GlobalData.Logger.LogError(Components.ConfigManager, "No config folder found!", true, 0);
			}
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00034C20 File Offset: 0x00032E20
		public void SaveConfig()
		{
			if (this.vm.CurrentConfig == null || GlobalData.MainWindow.ConfigsSecionPage.StackerPage == null || GlobalData.MainWindow.ConfigsSecionPage.GeneralPage == null)
			{
				GlobalData.Logger.LogError(Components.ConfigManager, "No config eligible for saving!", true, 0);
				return;
			}
			if (this.vm.CurrentConfig.Remote)
			{
				GlobalData.Logger.LogError(Components.ConfigManager, "The config was pulled from a remote source and cannot be saved!", true, 0);
				return;
			}
			if (this.vm.CurrentConfigName == string.Empty)
			{
				GlobalData.Logger.LogError(Components.ConfigManager, "Empty config name, cannot save", true, 0);
				return;
			}
			StackerViewModel stacker = GlobalData.Stacker;
			stacker.ConvertKeychains();
			stacker.ConvertPlugins();
			if (stacker.View == StackerView.Blocks)
			{
				stacker.LS.FromBlocks(stacker.GetList());
			}
			this.vm.CurrentConfig.Config.Script = stacker.LS.Script;
			GlobalData.Logger.LogInfo(Components.ConfigManager, "Saving config " + this.vm.CurrentConfigName, false, 0);
			this.vm.CurrentConfig.Config.Settings.LastModified = new DateTime?(DateTime.Now);
			this.vm.CurrentConfig.Config.Settings.Version = GlobalData.AppVersion + " [" + GlobalData.Edition + "]";
			this.vm.CurrentConfig.Config.Settings.RequiredPlugins = this.vm.GetRequiredPlugins(this.vm.CurrentConfig).ToArray<string>();
			GlobalData.Logger.LogInfo(Components.ConfigManager, "Converted the unbinded observables and set the Last Modified date", false, 0);
			try
			{
				this.vm.SaveCurrent();
				this.SaveState();
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.ConfigManager, "Failed to save the config. Reason: " + ex.Message, true, 0);
			}
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x00034E10 File Offset: 0x00033010
		public void LoadConfig(ConfigViewModel config)
		{
			if (config == null)
			{
				GlobalData.Logger.LogError(Components.ConfigManager, "The config to load cannot be null", true, 0);
				return;
			}
			try
			{
				AppIOManager.CheckRequiredPlugins(from b in GlobalData.BlockPlugins
				select b.Name, config.Config);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.ConfigManager, ex.Message, true, 0);
				return;
			}
			this.vm.CurrentConfig = config;
			if (this.vm.CurrentConfig.Remote)
			{
				GlobalData.Logger.LogError(Components.ConfigManager, "The config was pulled from a remote source and cannot be edited!", true, 0);
				this.vm.CurrentConfig = null;
				return;
			}
			GlobalData.Logger.LogInfo(Components.ConfigManager, "Loading config: " + this.vm.CurrentConfig.Name, false, 0);
			GlobalData.MainWindow.ConfigsSecionPage.tabItemStacker.IsEnabled = true;
			GlobalData.MainWindow.ConfigsSecionPage.tabItemSettings.IsEnabled = true;
			GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.IsEnabled = true;
			StackerViewModel stackerViewModel = new StackerViewModel(this.vm.CurrentConfig);
			if (GlobalData.MainWindow.ConfigsSecionPage.StackerPage != null)
			{
				stackerViewModel.TestData = GlobalData.Stacker.TestData;
				stackerViewModel.TestProxy = GlobalData.Stacker.TestProxy;
				stackerViewModel.ProxyType = GlobalData.Stacker.ProxyType;
			}
			GlobalData.Stacker = stackerViewModel;
			Stacker stackerPage = GlobalData.MainWindow.ConfigsSecionPage.StackerPage;
			if (stackerPage != null)
			{
				stackerPage.Destroy();
			}
			GlobalData.MainWindow.ConfigsSecionPage.StackerPage = new Stacker();
			GlobalData.Logger.LogInfo(Components.ConfigManager, "Created and assigned a new Stacker instance", false, 0);
			GlobalData.MainWindow.ConfigsSecionPage.GeneralPage = new General();
			GlobalData.MainWindow.ConfigsSecionPage.ProxiesPage = new Proxies();
			GlobalData.MainWindow.ConfigsSecionPage.InputPage = new Inputs();
			GlobalData.MainWindow.ConfigsSecionPage.DataPage = new Data();
			GlobalData.MainWindow.ConfigsSecionPage.PuppeteerPage = new Puppeteer();
			GlobalData.MainWindow.ConfigsSecionPage.CompilePage = new Compile();
			GlobalData.MainWindow.ConfigsSecionPage.ReadmePage = new Readme();
			GlobalData.MainWindow.ConfigsSecionPage.InterpreterPage = new Interpreter();
			Ocr ocrPage = GlobalData.MainWindow.ConfigsSecionPage.OcrPage;
			ConfigSettings configSettings = (ConfigSettings)((ocrPage != null) ? ocrPage.DataContext : null);
			if (configSettings != null)
			{
				configSettings.VariableList.Clear();
			}
			GlobalData.MainWindow.ConfigsSecionPage.OcrPage = new Ocr();
			GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.Visibility = Visibility.Collapsed;
			GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.Content = null;
			GlobalData.Logger.LogInfo(Components.ConfigManager, "Created and assigned a new Other Options instance", false, 0);
			GlobalData.MainWindow.ConfigsSecionPage.menuOptionStacker_MouseDown(this, null);
			GlobalData.MainWindow.ConfigsSecionPage.StackerPage.SetScript();
			this.SaveState();
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0003511C File Offset: 0x0003331C
		public void CreateConfig(string name, string category, string author, string icon = "")
		{
			if (!this.ReloadTaskIsCompleted())
			{
				return;
			}
			ConfigViewModel configViewModel = new ConfigViewModel(name, category, new Config(new ConfigSettings
			{
				Name = name,
				Author = author
			}, string.Empty), false);
			this.vm.Add(configViewModel);
			this.vm.CurrentConfig = configViewModel;
			StackerViewModel stackerViewModel = new StackerViewModel(this.vm.CurrentConfig);
			if (!string.IsNullOrWhiteSpace(icon))
			{
				configViewModel.Config.Settings.Icon = icon;
			}
			if (GlobalData.MainWindow.ConfigsSecionPage.StackerPage != null)
			{
				stackerViewModel.TestData = GlobalData.Stacker.TestData;
				stackerViewModel.TestProxy = GlobalData.Stacker.TestProxy;
				stackerViewModel.ProxyType = GlobalData.Stacker.ProxyType;
			}
			GlobalData.Stacker = stackerViewModel;
			Stacker stackerPage = GlobalData.MainWindow.ConfigsSecionPage.StackerPage;
			if (stackerPage != null)
			{
				stackerPage.Destroy();
			}
			GlobalData.MainWindow.ConfigsSecionPage.StackerPage = new Stacker();
			GlobalData.Logger.LogInfo(Components.ConfigManager, "Created and assigned a new Stacker instance", false, 0);
			GlobalData.MainWindow.ConfigsSecionPage.GeneralPage = new General();
			GlobalData.MainWindow.ConfigsSecionPage.ProxiesPage = new Proxies();
			GlobalData.MainWindow.ConfigsSecionPage.InputPage = new Inputs();
			GlobalData.MainWindow.ConfigsSecionPage.DataPage = new Data();
			GlobalData.MainWindow.ConfigsSecionPage.PuppeteerPage = new Puppeteer();
			GlobalData.MainWindow.ConfigsSecionPage.SeleniumPage = new Selenium();
			GlobalData.MainWindow.ConfigsSecionPage.CompilePage = new Compile();
			GlobalData.MainWindow.ConfigsSecionPage.ReadmePage = new Readme();
			GlobalData.MainWindow.ConfigsSecionPage.InterpreterPage = new Interpreter();
			GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.Visibility = Visibility.Collapsed;
			GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.Content = null;
			GlobalData.Logger.LogInfo(Components.ConfigManager, "Created and assigned a new Other Options instance", false, 0);
			GlobalData.MainWindow.ConfigsSecionPage.tabItemStacker.IsEnabled = true;
			GlobalData.MainWindow.ConfigsSecionPage.tabItemSettings.IsEnabled = true;
			GlobalData.MainWindow.ConfigsSecionPage.tabItemSubMenu.IsEnabled = true;
			GlobalData.MainWindow.ConfigsSecionPage.menuOptionStacker_MouseDown(this, null);
			this.SaveConfig();
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0003536C File Offset: 0x0003356C
		private void configsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.HoveredConfigViewModel = (ConfigViewModel)this.configsListView.SelectedItem;
			}
			catch
			{
			}
			try
			{
				this.vm.HoveredConfig = this.vm.HoveredConfigViewModel.Config;
			}
			catch
			{
			}
			try
			{
				this.RefreshReadme();
			}
			catch
			{
			}
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x000353F0 File Offset: 0x000335F0
		private void listViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
			string propertyName = gridViewColumnHeader.Tag.ToString();
			if (this.listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(this.listViewSortCol).Remove(this.listViewSortAdorner);
				this.configsListView.Items.SortDescriptions.Clear();
			}
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if (this.listViewSortCol == gridViewColumnHeader && this.listViewSortAdorner.Direction == listSortDirection)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			this.listViewSortCol = gridViewColumnHeader;
			this.listViewSortAdorner = new SortAdorner(this.listViewSortCol, listSortDirection);
			AdornerLayer.GetAdornerLayer(this.listViewSortCol).Add(this.listViewSortAdorner);
			this.configsListView.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x000354A9 File Offset: 0x000336A9
		private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.loadConfigButton_Click(this, new RoutedEventArgs());
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x000354B8 File Offset: 0x000336B8
		private void ButtonGridViewConfig_Click(object sender, RoutedEventArgs e)
		{
			this.configsListView.Visibility = Visibility.Collapsed;
			this.gridViewConfigScrollViwer.Visibility = Visibility.Visible;
			try
			{
				if (GlobalData.SBSettings.General.ConfigManagerViewMode != ConfigManagerViewMode.GridView)
				{
					GlobalData.SBSettings.General.ConfigManagerViewMode = ConfigManagerViewMode.GridView;
					JToken jtoken = JToken.Parse(IOManager.ReadString(Constants.SBSettingsFile));
					jtoken["General"]["ConfigManagerViewMode"] = (byte)GlobalData.SBSettings.General.ConfigManagerViewMode;
					IOManager.SaveString(Constants.SBSettingsFile, jtoken.ToString());
				}
			}
			catch
			{
			}
			this.borderGeneralDetails.Visibility = Visibility.Collapsed;
			this.vm.HoveredConfig = null;
			this.CloseReadme();
			this.configsListView.SelectedIndex = -1;
			this.vm.HoveredConfigViewModel = null;
			this.vm.HoveredConfig = null;
			this.borderBasicBetails.BorderThickness = new Thickness(1.0, 0.0, 1.0, 1.0);
			this.borderBasicBetails.CornerRadius = new CornerRadius(0.0, 0.0, 10.0, 0.0);
			this.buttonGridViewConfig.Foreground = Brushes.LightSteelBlue;
			this.buttonListViewConfig.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00035630 File Offset: 0x00033830
		private void ButtonListViewConfig_Click(object sender, RoutedEventArgs e)
		{
			this.gridViewConfigScrollViwer.Visibility = Visibility.Collapsed;
			try
			{
				if (GlobalData.SBSettings.General.ConfigManagerViewMode != ConfigManagerViewMode.ListView)
				{
					GlobalData.SBSettings.General.ConfigManagerViewMode = ConfigManagerViewMode.ListView;
					JToken jtoken = JToken.Parse(IOManager.ReadString(Constants.SBSettingsFile));
					jtoken["General"]["ConfigManagerViewMode"] = (byte)GlobalData.SBSettings.General.ConfigManagerViewMode;
					IOManager.SaveString(Constants.SBSettingsFile, jtoken.ToString());
				}
			}
			catch
			{
			}
			this.configsListView.Visibility = Visibility.Visible;
			this.borderGeneralDetails.Visibility = Visibility.Visible;
			this.CloseReadme();
			this.vm.HoveredConfig = null;
			this.vm.HoveredConfigViewModel = null;
			this.configsListView.SelectedIndex = -1;
			this.gridViewConfig.ItemsSource = null;
			this.gridViewConfig.ItemsSource = this.vm.ConfigsCollection;
			this.borderBasicBetails.BorderThickness = new Thickness(1.0, 0.0, 1.0, 0.0);
			this.borderBasicBetails.CornerRadius = new CornerRadius(0.0, 0.0, 0.0, 0.0);
			this.buttonListViewConfig.Foreground = Brushes.LightSteelBlue;
			this.buttonGridViewConfig.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x000357BC File Offset: 0x000339BC
		private void copyConfig_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				DataObject dataObject = new DataObject();
				dataObject.SetData(DataFormats.FileDrop, string.Concat(new string[]
				{
					Environment.CurrentDirectory,
					"\\",
					Constants.ConfigFolder,
					"\\",
					this.vm.HoveredConfigViewModel.FileName,
					".spk"
				}), true);
				Clipboard.SetDataObject(dataObject);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00035850 File Offset: 0x00033A50
		private void pasteConfig_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				IDataObject dataObject = Clipboard.GetDataObject();
				if (dataObject.GetDataPresent(DataFormats.FileDrop))
				{
					string path = string.Empty;
					try
					{
						path = (dataObject.GetData(DataFormats.FileDrop) as string[]).FirstOrDefault<string>();
					}
					catch (InvalidCastException)
					{
						path = (string)dataObject.GetData(DataFormats.FileDrop);
					}
					this.PasteConfig(path, true);
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x000358E0 File Offset: 0x00033AE0
		private void PasteConfig(string path, bool invokeRescan = true)
		{
			string extension;
			if (path != null && ((extension = Path.GetExtension(path)).Equals(".spk", StringComparison.OrdinalIgnoreCase) || extension.Equals(".svb", StringComparison.OrdinalIgnoreCase) || extension.Equals(".loli", StringComparison.OrdinalIgnoreCase) || extension.Equals(".lolix", StringComparison.OrdinalIgnoreCase) || extension.Equals(".anom", StringComparison.OrdinalIgnoreCase)))
			{
				if (!File.Exists(path))
				{
					return;
				}
				string fileName = Path.GetFileName(path);
				string text = string.Concat(new string[]
				{
					Environment.CurrentDirectory,
					"\\",
					Constants.ConfigFolder,
					"\\",
					fileName
				});
				if (File.Exists(Constants.ConfigFolder + "\\" + fileName))
				{
					MessageBoxResult messageBoxResult;
					if ((messageBoxResult = Alert.Choice("The File you want to copy already exists. Do you want to replace it?", "File exists [" + Path.GetFileNameWithoutExtension(path) + "]", MessageBoxButton.YesNoCancel, MessageBoxImage.Question)) == MessageBoxResult.Yes)
					{
						bool flag = path == text;
						if (!flag)
						{
							File.Delete(text);
						}
						File.Copy(path, Constants.ConfigFolder + "\\" + fileName, flag);
						if (invokeRescan)
						{
							this.rescanConfigsButton_Click(null, null);
						}
						return;
					}
					if (messageBoxResult == MessageBoxResult.No)
					{
						string destFileName = PathExtension.Rename(Constants.ConfigFolder + "\\" + Path.GetFileName(path));
						File.Copy(path, destFileName, false);
						if (invokeRescan)
						{
							this.rescanConfigsButton_Click(null, null);
						}
						return;
					}
					return;
				}
				else
				{
					File.Copy(path, Constants.ConfigFolder + "\\" + Path.GetFileName(path), false);
					if (invokeRescan)
					{
						this.rescanConfigsButton_Click(null, null);
					}
				}
			}
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x00035A58 File Offset: 0x00033C58
		private void configsListView_DragEnter(object sender, DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					e.Effects = DragDropEffects.Copy;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00035A94 File Offset: 0x00033C94
		private void configsListView_Drop(object sender, DragEventArgs e)
		{
			try
			{
				string[] locations = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (locations != null)
				{
					Task.Run(delegate()
					{
						for (int i = 0; i < locations.Length; i++)
						{
							try
							{
								string loc = locations[i];
								string extension;
								if (loc != null && File.Exists(loc) && ((extension = Path.GetExtension(loc)).Equals(".spk", StringComparison.OrdinalIgnoreCase) || extension.Equals(".svb", StringComparison.OrdinalIgnoreCase) || extension.Equals(".loli", StringComparison.OrdinalIgnoreCase) || extension.Equals(".lolix", StringComparison.OrdinalIgnoreCase) || extension.Equals(".anom", StringComparison.OrdinalIgnoreCase)))
								{
									this.Dispatcher.Invoke(delegate()
									{
										this.PasteConfig(loc, false);
									});
								}
							}
							catch
							{
							}
						}
						this.Dispatcher.Invoke(delegate()
						{
							this.rescanConfigsButton_Click(null, null);
						});
					});
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00035AFC File Offset: 0x00033CFC
		private void configsListView_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
				{
					Key key = e.Key;
					if (key != Key.C)
					{
						if (key == Key.V)
						{
							this.pasteConfig_Click(sender, e);
						}
					}
					else
					{
						this.copyConfig_Click(sender, e);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00035B54 File Offset: 0x00033D54
		public void ShowReadme()
		{
			try
			{
				this.showReadmeButton.Foreground = Brushes.LightSteelBlue;
				this.borderConfigReadme.Visibility = Visibility.Visible;
				this.borderGeneralDetails.Visibility = Visibility.Collapsed;
				this.borderBasicBetails.BorderThickness = new Thickness(1.0, 0.0, 1.0, 1.0);
				if (this.vm.HoveredConfig.Settings.UseMarkdown)
				{
					this.readMeMarkdown.Markdown = this.vm.HoveredConfig.Settings.AdditionalInfo;
				}
				else
				{
					this.readMeTextBlock.Text = this.vm.HoveredConfig.Settings.AdditionalInfo;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00035C2C File Offset: 0x00033E2C
		public void CloseReadme()
		{
			if (this.borderConfigReadme.Visibility == Visibility.Visible || !this.showReadmeButton.IsEnabled)
			{
				this.borderConfigReadme.Visibility = Visibility.Collapsed;
				this.readMeTextBlock.Text = string.Empty;
				this.borderBasicBetails.BorderThickness = new Thickness(1.0, 0.0, 1.0, 0.0);
				this.readMeMarkdown.Markdown = string.Empty;
				this.showReadmeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
				if (this.configsListView.Visibility == Visibility.Visible)
				{
					this.borderGeneralDetails.Visibility = Visibility.Visible;
				}
			}
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00035CE4 File Offset: 0x00033EE4
		public void RefreshReadme()
		{
			if (this.borderConfigReadme.Visibility != Visibility.Visible || !this.showReadmeButton.IsEnabled)
			{
				return;
			}
			if (string.IsNullOrEmpty(this.vm.HoveredConfig.Settings.AdditionalInfo))
			{
				this.CloseReadme();
				return;
			}
			if (this.vm.HoveredConfig.Settings.UseMarkdown)
			{
				this.readMeTextBlock.Text = string.Empty;
				this.readMeTextBlock.Visibility = Visibility.Collapsed;
				this.readMeMarkdown.Visibility = Visibility.Visible;
				this.readMeMarkdown.Markdown = this.vm.HoveredConfig.Settings.AdditionalInfo;
				this.readMeMarkdown.UpdateLayout();
				return;
			}
			this.readMeMarkdown.Markdown = string.Empty;
			this.readMeMarkdown.Visibility = Visibility.Collapsed;
			this.readMeTextBlock.Visibility = Visibility.Visible;
			this.readMeTextBlock.Text = this.vm.HoveredConfig.Settings.AdditionalInfo;
			this.readMeTextBlock.UpdateLayout();
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00035DF0 File Offset: 0x00033FF0
		private void RadioButton_Click(object sender, RoutedEventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			if (Keyboard.Modifiers == ModifierKeys.Control)
			{
				bool? isChecked = radioButton.IsChecked;
				bool flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					radioButton.IsChecked = new bool?(false);
					this.vm.HoveredConfigViewModel = null;
					this.vm.HoveredConfig = null;
					try
					{
						this.CloseReadme();
					}
					catch
					{
					}
					return;
				}
			}
			try
			{
				this.vm.HoveredConfigViewModel = (ConfigViewModel)radioButton.Tag;
			}
			catch
			{
			}
			try
			{
				this.vm.HoveredConfig = this.vm.HoveredConfigViewModel.Config;
			}
			catch
			{
			}
			try
			{
				this.RefreshReadme();
			}
			catch
			{
			}
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00035ED8 File Offset: 0x000340D8
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				this.RefreshReadme();
			}
			catch
			{
			}
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00035F00 File Offset: 0x00034100
		private bool ReloadTaskIsCompleted()
		{
			bool result;
			try
			{
				if (!this.reloadTask.IsCompleted)
				{
					GlobalData.Logger.Log("Wait for the Reload to finish!", 2, true, 0);
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00035F4C File Offset: 0x0003414C
		private void Path_Initialized(object sender, EventArgs e)
		{
			Path path = sender as Path;
			if (!(bool)path.Tag)
			{
				path.Fill = "A6A6A6".ToBrush();
			}
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x00035F80 File Offset: 0x00034180
		private void showConfiginExplorer_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.OpenExplorer(Path.Combine(Directory.GetCurrentDirectory(), Constants.ConfigFolder, this.vm.HoveredConfigViewModel.FileName + ".spk"), true);
			}
			catch
			{
			}
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x00035FD4 File Offset: 0x000341D4
		private void SelectFilter_Click(object sender, RoutedEventArgs e)
		{
			this.popupFilter.IsOpen = true;
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00035FE4 File Offset: 0x000341E4
		private void Filter_Selected(object sender, RoutedEventArgs e)
		{
			IEnumerable<CheckComboBoxItem> enumerable = this.stackPanelFilters.FindVisualChildren<CheckComboBoxItem>();
			ConfigFilterType? cfgFilter = null;
			ConfigFilterType[] array = (from i in enumerable.Where(delegate(CheckComboBoxItem i)
			{
				if (i.IsSelected)
				{
					object tag3 = i.Tag;
					return ((tag3 != null) ? tag3.ToString() : null) != "All";
				}
				return false;
			})
			select (ConfigFilterType)i.Content).ToArray<ConfigFilterType>();
			if (array.Length != 0)
			{
				cfgFilter = new ConfigFilterType?(EnumExtension.ToEnumFlags<ConfigFilterType>(array));
			}
			CheckComboBoxItem checkComboBoxItem = (CheckComboBoxItem)sender;
			object tag = checkComboBoxItem.Tag;
			if (((tag != null) ? tag.ToString() : null) == "All")
			{
				using (IEnumerator<CheckComboBoxItem> enumerator = enumerable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CheckComboBoxItem checkComboBoxItem2 = enumerator.Current;
						object tag2 = checkComboBoxItem2.Tag;
						if (!(((tag2 != null) ? tag2.ToString() : null) == "All"))
						{
							checkComboBoxItem2.Selected -= this.Filter_Selected;
							checkComboBoxItem2.Unselected -= this.Filter_UnSelected;
							ConfigFilterType configFilterType = (ConfigFilterType)checkComboBoxItem2.Content;
							if (cfgFilter == null)
							{
								cfgFilter = new ConfigFilterType?(configFilterType);
							}
							else if (!cfgFilter.Value.HasFlag(configFilterType))
							{
								cfgFilter |= configFilterType;
							}
							checkComboBoxItem2.IsSelected = checkComboBoxItem.IsSelected;
							checkComboBoxItem2.Selected += this.Filter_Selected;
							checkComboBoxItem2.Unselected += this.Filter_UnSelected;
						}
					}
					goto IL_293;
				}
			}
			CheckComboBoxItem checkComboBoxItem3 = (CheckComboBoxItem)this.stackPanelFilters.Children[0];
			checkComboBoxItem3.Unselected -= this.Filter_UnSelected;
			checkComboBoxItem3.IsSelected = false;
			checkComboBoxItem3.Unselected += this.Filter_UnSelected;
			ConfigFilterType configFilterType2 = (ConfigFilterType)checkComboBoxItem.Content;
			if (cfgFilter == null)
			{
				cfgFilter = new ConfigFilterType?(configFilterType2);
			}
			else if (!cfgFilter.Value.HasFlag(configFilterType2))
			{
				cfgFilter |= configFilterType2;
			}
			IL_293:
			if (!enumerable.Any((CheckComboBoxItem i) => i.IsSelected))
			{
				cfgFilter = new ConfigFilterType?(ConfigFilterType.Name);
				enumerable.First(delegate(CheckComboBoxItem i)
				{
					object tag3 = i.Tag;
					if (((tag3 != null) ? tag3.ToString() : null) != "All")
					{
						ConfigFilterType configFilterType3 = (ConfigFilterType)i.Content;
						ConfigFilterType? cfgFilter = cfgFilter;
						return configFilterType3 == cfgFilter.GetValueOrDefault() & cfgFilter != null;
					}
					return false;
				}).IsSelected = true;
			}
			this.vm.FilterType = cfgFilter.GetValueOrDefault(ConfigFilterType.Name);
			JToken jtoken = JToken.Parse(IOManager.ReadString(Constants.SBSettingsFile));
			jtoken["General"]["ConfigFilterType"] = (ushort)this.vm.FilterType;
			IOManager.SaveString(Constants.SBSettingsFile, jtoken.ToString());
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0003634C File Offset: 0x0003454C
		private void Filter_UnSelected(object sender, RoutedEventArgs e)
		{
			this.Filter_Selected(sender, e);
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x00036358 File Offset: 0x00034558
		private void SetFilters()
		{
			int num = 0;
			ConfigFilterType? configFilterType = null;
			foreach (object obj in Enum.GetValues(typeof(ConfigFilterType)))
			{
				ConfigFilterType configFilterType2 = (ConfigFilterType)obj;
				CheckComboBoxItem checkComboBoxItem = new CheckComboBoxItem
				{
					Content = configFilterType2
				};
				checkComboBoxItem.Style = (base.FindResource("CheckComboBoxItemBaseStyle") as Style);
				if (GlobalData.SBSettings.General.ConfigFilterType.HasFlag(configFilterType2))
				{
					num++;
					if (configFilterType == null)
					{
						configFilterType = new ConfigFilterType?(configFilterType2);
					}
					else if (!configFilterType.Value.HasFlag(configFilterType2))
					{
						configFilterType |= configFilterType2;
					}
					checkComboBoxItem.IsSelected = true;
				}
				checkComboBoxItem.Selected += this.Filter_Selected;
				checkComboBoxItem.Unselected += this.Filter_UnSelected;
				this.stackPanelFilters.Children.Add(checkComboBoxItem);
			}
			if (num == this.stackPanelFilters.Children.Count - 1)
			{
				CheckComboBoxItem checkComboBoxItem2 = (CheckComboBoxItem)this.stackPanelFilters.Children[0];
				checkComboBoxItem2.Selected -= this.Filter_Selected;
				checkComboBoxItem2.IsSelected = true;
				checkComboBoxItem2.Selected += this.Filter_Selected;
			}
			this.vm.FilterType = configFilterType.GetValueOrDefault(ConfigFilterType.Name);
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x00036A10 File Offset: 0x00034C10
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 17:
				((RadioButton)target).Click += this.RadioButton_Click;
				((RadioButton)target).MouseDoubleClick += this.RadioButton_MouseDoubleClick;
				return;
			case 18:
				((Path)target).Initialized += this.Path_Initialized;
				return;
			case 19:
				((Path)target).Initialized += this.Path_Initialized;
				return;
			case 20:
				((Path)target).Initialized += this.Path_Initialized;
				return;
			case 21:
				((Path)target).Initialized += this.Path_Initialized;
				return;
			case 22:
				((Path)target).Initialized += this.Path_Initialized;
				return;
			case 23:
				((Path)target).Initialized += this.Path_Initialized;
				return;
			case 24:
				((Path)target).Initialized += this.Path_Initialized;
				return;
			case 25:
				((Path)target).Initialized += this.Path_Initialized;
				return;
			case 26:
			case 27:
			case 28:
			case 29:
				break;
			case 30:
			{
				EventSetter eventSetter = new EventSetter();
				eventSetter.Event = Control.MouseDoubleClickEvent;
				eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
				((Style)target).Setters.Add(eventSetter);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x04000554 RID: 1364
		private ConfigManagerViewModel vm;

		// Token: 0x04000555 RID: 1365
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x04000556 RID: 1366
		private SortAdorner listViewSortAdorner;

		// Token: 0x04000557 RID: 1367
		private Task reloadTask;
	}
}
