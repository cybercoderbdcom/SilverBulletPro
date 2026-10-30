using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Discord.WebSocket;
using HandyControl.Controls;
using HandyControl.Data;
using Microsoft.Win32;
using Newtonsoft.Json;
using SilverBulletPro.Converters;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Enums;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Requests;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Dialogs;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace SilverBulletPro.Views.Main.Runner
{
	// Token: 0x0200019A RID: 410
	public partial class RunnerOptions : Page, IStyleConnector
	{
		// Token: 0x06000A7E RID: 2686 RVA: 0x00032524 File Offset: 0x00030724
		public RunnerOptions(RunnerInstance instance)
		{
			this.InitializeComponent();
			this.runnerInstance = instance;
			this.runner = instance.View;
			this.vm = instance.ViewModel;
			this.botsAmountCtrl.Maximum = 200.0;
			this.InitEnvironment();
			this.ovm = this.Clone();
			this.ovm.StartingPoint = this.vm.StartingPoint;
			this.InitGeneral();
			this.InitDataPool();
			this.InitProxies();
			base.DataContext = this.ovm;
			this.ovm.HitOutputOptions = new ObservableCollection<HitOutputOptions>(ListExtensions.RemoveDuplicateItem<HitOutputOptions>(this.ovm.HitOutputOptions, (HitOutputOptions o) => o is DatabaseHitOutputOptions));
			foreach (object newItem in Enum.GetValues(typeof(RobotType)))
			{
				this.robotTypeComboBox.Items.Add(newItem);
			}
			foreach (object newItem2 in Enum.GetValues(typeof(RobotUser.Permission)))
			{
				this.botUserPermissionComboBox.Items.Add(newItem2);
			}
			foreach (KeyValuePair<string, Func<RobotUser, RunnerViewModel, BotData, ValueTuple<string, ParseMode?>>> keyValuePair in TelegramRobot.Commands)
			{
				this.allowedCommandsComboBox.Items.Add(keyValuePair.Key);
			}
			this.allowedCommandsComboBox.Text = this.defaultAllowedCommands;
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00032718 File Offset: 0x00030918
		private void SelectConfig_Click(object sender, RoutedEventArgs e)
		{
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new DialogSelectConfig(new ValueTuple<RunnerOptions, Runner>(this, this.runner)),
				Title = "Select Config"
			}).ShowDialog();
			if (this.EncryptedConfig != null)
			{
				this.configComboBox.Text = this.EncryptedConfig.Settings.Name;
				this.ellipse.Visibility = Visibility.Collapsed;
				this.icon.ImageSource = (ImageSource)new Base64ToImageConverter().Convert(this.EncryptedConfig.Settings.Icon, null, null, null);
				this.ellipseEnc.Visibility = Visibility.Visible;
			}
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x000327C4 File Offset: 0x000309C4
		private void InitEnvironment()
		{
			foreach (string newItem in GlobalData.Settings.Environment.GetWordlistTypeNames())
			{
				this.fileTypeComboBox.Items.Add(newItem);
				this.rangeTypeComboBox.Items.Add(newItem);
				this.combinationsTypeComboBox.Items.Add(newItem);
			}
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00032850 File Offset: 0x00030A50
		private void InitGeneral()
		{
			this.dateTimePicker.SelectedDateTime = new DateTime?(this.vm.Options.StartAt);
			this.configComboBox.DataContext = GlobalData.ConfigManager;
			this.configComboBox.ItemsSource = GlobalData.ConfigManager.ConfigsCollection;
			if (this.runnerInstance.ViewModel.Config != null)
			{
				this.configComboBox.SelectedIndex = GlobalData.ConfigManager.ConfigsCollection.IndexOf(GlobalData.ConfigManager.Configs.FirstOrDefault((ConfigViewModel c) => c.Name == this.runnerInstance.ViewModel.Config.Settings.Name));
				if (this.configComboBox.SelectedIndex == -1)
				{
					this.EncryptedConfig = this.runnerInstance.ViewModel.Config;
					this.configComboBox.Text = this.EncryptedConfig.Settings.Name;
					this.ellipse.Visibility = Visibility.Collapsed;
					this.icon.ImageSource = (ImageSource)new Base64ToImageConverter().Convert(this.EncryptedConfig.Settings.Icon, null, null, null);
					this.ellipseEnc.Visibility = Visibility.Visible;
				}
			}
			foreach (object newItem in Enum.GetValues(typeof(ProxyMode)))
			{
				this.proxyModeComboBox.Items.Add(newItem);
			}
			this.botsAmountCtrl.Value = (double)this.runnerInstance.ViewModel.Options.BotsAmount;
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x000329EC File Offset: 0x00030BEC
		private void InitDataPool()
		{
			try
			{
				switch (this.ovm.DataPoolType)
				{
				case 0:
				{
					WordlistDataPoolOptions wordlistDataPoolOptions = (WordlistDataPoolOptions)this.ovm.DataPoolOptions.First<DataPoolOptions>();
					break;
				}
				case 1:
				{
					FileDataPoolOptions fileDataPoolOptions = (FileDataPoolOptions)this.ovm.DataPoolOptions.First<DataPoolOptions>();
					this.filePathTextBox.Text = fileDataPoolOptions.FileName;
					this.fileTypeComboBox.SelectedItem = fileDataPoolOptions.WordlistType;
					this.chbFileReload.IsChecked = new bool?(fileDataPoolOptions.ReloadTime != null);
					this.fileReloadTime.Value = (double)fileDataPoolOptions.ReloadTime.GetValueOrDefault();
					break;
				}
				case 2:
				{
					RangeDataPoolOptions rangeDataPoolOptions = (RangeDataPoolOptions)this.ovm.DataPoolOptions.First<DataPoolOptions>();
					this.rangeStart.Value = (double)rangeDataPoolOptions.Start;
					this.rangeAmount.Value = (double)rangeDataPoolOptions.Amount;
					this.rangeStep.Value = (double)rangeDataPoolOptions.Step;
					this.rangePad.IsChecked = new bool?(rangeDataPoolOptions.Pad);
					this.rangeTypeComboBox.SelectedItem = rangeDataPoolOptions.WordlistType;
					break;
				}
				case 3:
				{
					CombinationsDataPoolOptions combinationsDataPoolOptions = (CombinationsDataPoolOptions)this.ovm.DataPoolOptions.First<DataPoolOptions>();
					this.combinationsCharSet.Text = combinationsDataPoolOptions.CharSet;
					this.combinationsLen.Value = (double)combinationsDataPoolOptions.Length;
					this.combinationsTypeComboBox.SelectedItem = combinationsDataPoolOptions.WordlistType;
					break;
				}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00032B94 File Offset: 0x00030D94
		private void InitProxies()
		{
			foreach (object obj in Enum.GetValues(typeof(ProxyType)))
			{
				ProxyType proxyType = (ProxyType)obj;
				if (proxyType != 4)
				{
					this.reloadTypeCombobox.Items.Add(proxyType);
				}
			}
			this.reloadTypeCombobox.SelectedIndex = this.ovm.ReloadType;
			foreach (string newItem in Enum.GetNames(typeof(ProxyReloadSource)))
			{
				this.reloadSourceCombobox.Items.Add(newItem);
			}
			this.reloadSourceCombobox.SelectedIndex = this.ovm.ReloadSource;
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00032C74 File Offset: 0x00030E74
		private void SetConfig()
		{
			ConfigViewModel configViewModel = this.configComboBox.SelectedItem as ConfigViewModel;
			Config config = (configViewModel != null) ? configViewModel.Config : null;
			if (config == null)
			{
				config = this.EncryptedConfig;
			}
			if (GlobalData.SBSettings.General.LiveConfigUpdates)
			{
				this.runner.SetConfig(config);
				return;
			}
			this.runner.SetConfig(IOManager.CloneConfig(config));
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00032CD8 File Offset: 0x00030ED8
		private void Accept_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.Verify())
				{
					if (this.tvm != null)
					{
						this.vm = this.tvm;
						this.tvm = null;
					}
					this.vm.Options = this.ovm;
					this.SetConfig();
					this.vm.Options.BotsAmount = (int)this.botsAmountCtrl.Value;
					this.vm.StartingPoint = this.ovm.StartingPoint;
					((MainDialog)base.Parent).Close();
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00032D84 File Offset: 0x00030F84
		private bool Verify()
		{
			if (this.configComboBox.SelectedIndex == -1)
			{
				if (this.EncryptedConfig != null)
				{
					string text = this.configComboBox.Text;
					Config encryptedConfig = this.EncryptedConfig;
					string b;
					if (encryptedConfig == null)
					{
						b = null;
					}
					else
					{
						ConfigSettings settings = encryptedConfig.Settings;
						b = ((settings != null) ? settings.Name : null);
					}
					if (!(text != b))
					{
						goto IL_51;
					}
				}
				throw new Exception("No config selected");
			}
			IL_51:
			bool flag = false;
			if (this.ovm.ProxyMode == null)
			{
				if (this.EncryptedConfig == null)
				{
					flag = ((ConfigViewModel)this.configComboBox.SelectedItem).Config.Settings.NeedsProxies;
				}
				else
				{
					flag = this.EncryptedConfig.Settings.NeedsProxies;
				}
			}
			else if (this.ovm.ProxyMode == 1)
			{
				flag = true;
			}
			if (this.ovm.DataPoolOptions == null)
			{
				throw new Exception("Wordlist is null");
			}
			if (this.ovm.DataPoolOptions.Length == 0 && this.ovm.DataPoolType == null)
			{
				throw new Exception("Wordlist not found");
			}
			if (this.ovm.DataPoolType == 1)
			{
				if (string.IsNullOrWhiteSpace(this.filePathTextBox.Text) || !File.Exists(this.filePathTextBox.Text))
				{
					throw new Exception("File not found");
				}
				RunnerOptionsViewModel runnerOptionsViewModel = this.ovm;
				DataPoolOptions[] dataPoolOptions = new FileDataPoolOptions[]
				{
					new FileDataPoolOptions
					{
						FileName = this.filePathTextBox.Text,
						WordlistType = this.fileTypeComboBox.SelectedItem.ToString(),
						ReloadTime = (this.chbFileReload.IsChecked.GetValueOrDefault() ? new int?(Convert.ToInt32(this.fileReloadTime.Value)) : null)
					}
				};
				runnerOptionsViewModel.DataPoolOptions = dataPoolOptions;
			}
			else if (this.ovm.DataPoolType == 2)
			{
				RunnerOptionsViewModel runnerOptionsViewModel2 = this.ovm;
				DataPoolOptions[] dataPoolOptions = new RangeDataPoolOptions[]
				{
					new RangeDataPoolOptions
					{
						Start = (long)((int)this.rangeStart.Value),
						Amount = (int)this.rangeAmount.Value,
						Step = (int)this.rangeStep.Value,
						Pad = this.rangePad.IsChecked.GetValueOrDefault(),
						WordlistType = this.rangeTypeComboBox.SelectedItem.ToString()
					}
				};
				runnerOptionsViewModel2.DataPoolOptions = dataPoolOptions;
			}
			else if (this.ovm.DataPoolType == 3)
			{
				RunnerOptionsViewModel runnerOptionsViewModel3 = this.ovm;
				DataPoolOptions[] dataPoolOptions = new CombinationsDataPoolOptions[]
				{
					new CombinationsDataPoolOptions
					{
						CharSet = this.combinationsCharSet.Text,
						Length = (int)this.combinationsLen.Value,
						WordlistType = this.combinationsTypeComboBox.SelectedItem.ToString()
					}
				};
				runnerOptionsViewModel3.DataPoolOptions = dataPoolOptions;
			}
			if (flag)
			{
				switch (this.reloadTabControl.SelectedIndex)
				{
				case 0:
					if (this.ovm.Proxylist == null)
					{
						throw new ArgumentNullException("Proxylist is null");
					}
					if (!this.ovm.Proxylist.IsList && !File.Exists(this.ovm.Proxylist.Path))
					{
						throw new Exception("Proxylist not found");
					}
					break;
				case 1:
					if (string.IsNullOrWhiteSpace(this.ovm.ReloadPath))
					{
						throw new ArgumentNullException("Proxy file path is null");
					}
					if (!File.Exists(this.ovm.ReloadPath))
					{
						throw new Exception("Proxy file not found");
					}
					break;
				case 2:
					if (this.ovm.RemoteProxySources.Count == 0)
					{
						throw new Exception("Remote proxy is null");
					}
					break;
				}
			}
			return true;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00033104 File Offset: 0x00031304
		private void DateTimePicker_SelectedDateTimeChanged(object sender, FunctionEventArgs<DateTime?> e)
		{
			if (e != null && e.Info != null)
			{
				this.ovm.StartAt = e.Info.Value;
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0003313D File Offset: 0x0003133D
		private void NumericUpDown_ValueChanged(object sender, FunctionEventArgs<double> e)
		{
			this.ovm.StartIn = new TimeSpan(this.ovm.Hours, this.ovm.Minutes, this.ovm.Seconds);
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00033170 File Offset: 0x00031370
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.tabControl.SelectedIndex == 4 && (this.userTextBox.IsKeyboardFocusWithin || this.allowedCommandsComboBox.IsKeyboardFocusWithin) && e.Key == Key.Return)
			{
				this.AddBotUser_Click(sender, e);
				return;
			}
			if (e.Key == Key.Return)
			{
				this.Accept_Click(sender, null);
			}
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x000331C8 File Offset: 0x000313C8
		private void ConfigComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (this.configComboBox.SelectedItem == null && this.configComboBox.Text == this.EncryptedConfig.Settings.Name)
				{
					this.ellipse.Visibility = Visibility.Collapsed;
					this.icon.ImageSource = (ImageSource)new Base64ToImageConverter().Convert(this.EncryptedConfig.Settings.Icon, null, null, null);
					this.ellipseEnc.Visibility = Visibility.Visible;
					this.ovm.BotsAmount = this.EncryptedConfig.Settings.SuggestedBots;
				}
				else
				{
					this.ellipse.Visibility = Visibility.Visible;
					this.icon.ImageSource = null;
					this.ellipseEnc.Visibility = Visibility.Collapsed;
					this.ovm.BotsAmount = ((ConfigViewModel)this.configComboBox.SelectedItem).Config.Settings.SuggestedBots;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x000332CC File Offset: 0x000314CC
		private void ConfigComboBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.ConfigComboBox_SelectionChanged(sender, null);
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x000332D8 File Offset: 0x000314D8
		private void SelectWordlist_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new DialogSelectWordlist(new ValueTuple<RunnerOptions, Runner>(this, this.runner)),
					Title = "Select Wordlist"
				}).ShowDialog();
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0003333C File Offset: 0x0003153C
		private void AddWordlist_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new DialogAddWordlist(GlobalData.MainWindow.WordlistManagerPage),
					Title = "Add Wordlist"
				}).ShowDialog();
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00033398 File Offset: 0x00031598
		private void SelectFile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "List | *.txt";
				openFileDialog.FilterIndex = 1;
				bool? flag = openFileDialog.ShowDialog();
				bool flag2 = false;
				if (!(flag.GetValueOrDefault() == flag2 & flag != null))
				{
					this.filePathTextBox.Text = openFileDialog.FileName;
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x0003340C File Offset: 0x0003160C
		private void reloadSourceCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.ovm.ReloadSource = this.reloadSourceCombobox.SelectedIndex;
			switch (this.ovm.ReloadSource)
			{
			case 0:
				this.reloadTabControl.SelectedIndex = 0;
				this.selectProxyButton.Visibility = Visibility.Visible;
				this.addRemoteProxySourceButton.Visibility = Visibility.Collapsed;
				this.clearRemoteProxySourcesButton.Visibility = Visibility.Collapsed;
				this.testRemoteProxySourcesButton.Visibility = Visibility.Collapsed;
				return;
			case 1:
				this.reloadTabControl.SelectedIndex = 1;
				this.selectProxyButton.Visibility = Visibility.Collapsed;
				this.addRemoteProxySourceButton.Visibility = Visibility.Collapsed;
				this.clearRemoteProxySourcesButton.Visibility = Visibility.Collapsed;
				this.testRemoteProxySourcesButton.Visibility = Visibility.Collapsed;
				return;
			case 2:
				this.reloadTabControl.SelectedIndex = 2;
				this.selectProxyButton.Visibility = Visibility.Collapsed;
				this.addRemoteProxySourceButton.Visibility = Visibility.Visible;
				this.clearRemoteProxySourcesButton.Visibility = Visibility.Visible;
				this.testRemoteProxySourcesButton.Visibility = Visibility.Visible;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00033504 File Offset: 0x00031704
		private void reloadTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.ovm.ReloadType = this.reloadTypeCombobox.SelectedIndex;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0003351C File Offset: 0x0003171C
		private void remoteProxyTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.ovm.GetRemoteProxySource((RemoteProxySource)(sender as ComboBox).Tag).Type = (sender as ComboBox).SelectedIndex;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0003354C File Offset: 0x0003174C
		private void remoteProxyTypeCombobox_Loaded(object sender, RoutedEventArgs e)
		{
			RemoteProxySource remoteProxySource = this.ovm.GetRemoteProxySource((RemoteProxySource)(sender as ComboBox).Tag);
			remoteProxySource.TypeInitialized = ((sender as ComboBox).Items.Count > 0);
			if (remoteProxySource.TypeInitialized)
			{
				return;
			}
			foreach (object obj in Enum.GetValues(typeof(ProxyType)))
			{
				ProxyType proxyType = (ProxyType)obj;
				if (proxyType != 4)
				{
					(sender as ComboBox).Items.Add(proxyType);
				}
			}
			(sender as ComboBox).SelectedIndex = remoteProxySource.Type;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00033614 File Offset: 0x00031814
		private void removeRemoteProxySourceButton_Click(object sender, RoutedEventArgs e)
		{
			this.ovm.RemoveRemoteProxySource((RemoteProxySource)(sender as Button).Tag);
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x00033631 File Offset: 0x00031831
		private void addRemoteProxySourceButton_Click(object sender, RoutedEventArgs e)
		{
			this.ovm.RemoteProxySources.Add(new RemoteProxySource());
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x00033648 File Offset: 0x00031848
		private void clearRemoteProxySourcesButton_Click(object sender, RoutedEventArgs e)
		{
			if (Alert.Choice("Are you sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
			{
				return;
			}
			this.ovm.RemoteProxySources.Clear();
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00033670 File Offset: 0x00031870
		private void TestRemoteProxySourcesButton_Click(object sender, RoutedEventArgs e)
		{
			RunnerOptions.<TestRemoteProxySourcesButton_Click>d__33 <TestRemoteProxySourcesButton_Click>d__;
			<TestRemoteProxySourcesButton_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<TestRemoteProxySourcesButton_Click>d__.<>4__this = this;
			<TestRemoteProxySourcesButton_Click>d__.<>1__state = -1;
			<TestRemoteProxySourcesButton_Click>d__.<>t__builder.Start<RunnerOptions.<TestRemoteProxySourcesButton_Click>d__33>(ref <TestRemoteProxySourcesButton_Click>d__);
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x000336A7 File Offset: 0x000318A7
		private void SelectProxyButton_Click(object sender, RoutedEventArgs e)
		{
			new MainDialog(new MainDialog.InputDialog
			{
				Title = "Select Proxylist",
				Dialog = new DialogSelectProxylist(this)
			}).ShowDialog();
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x000336D0 File Offset: 0x000318D0
		public void LoadProxiesFromManager(Proxylist proxylist)
		{
			this.ovm.Proxylist = proxylist;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x000336E0 File Offset: 0x000318E0
		private RunnerOptionsViewModel Clone()
		{
			RunnerOptionsViewModel runnerOptionsViewModel = new RunnerOptionsViewModel();
			ObjectExtension.ClonePropertiesTo(this.vm.Options, runnerOptionsViewModel, Array.Empty<string>());
			return runnerOptionsViewModel;
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x0003370C File Offset: 0x0003190C
		private void BotsAmount_ValueChanged(object sender, FunctionEventArgs<double> e)
		{
			try
			{
				this.ovm.BotsAmount = (int)this.botsAmountCtrl.Value;
			}
			catch
			{
			}
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00033748 File Offset: 0x00031948
		private void RemoveHitOutput(object sender, RoutedEventArgs e)
		{
			this.ovm.RemoveHitOutput((HitOutputOptions)(sender as Button).Tag);
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00033768 File Offset: 0x00031968
		private void AddHitOutputOption_Click(object sender, RoutedEventArgs e)
		{
			switch (this.hitOutputOptComboBox.SelectedIndex)
			{
			case 0:
				this.ovm.AddDatabaseHitOutput();
				return;
			case 1:
				this.ovm.AddFileSystemHitOutput();
				return;
			case 2:
				this.ovm.AddDiscordWebhookHitOutput();
				return;
			case 3:
				this.ovm.AddTelegramBotHitOutput();
				return;
			case 4:
				this.ovm.AddCustomWebhookHitOutput();
				return;
			default:
				return;
			}
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x000337D8 File Offset: 0x000319D8
		private void Restore_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "Runner|*.json"
				};
				bool? flag = openFileDialog.ShowDialog();
				bool flag2 = true;
				if (flag.GetValueOrDefault() == flag2 & flag != null)
				{
					this.tvm = new RunnerViewModel(GlobalData.Settings.Environment, GlobalData.Settings.CoreSettings, null);
					this.tvm.Options.HitOutputOptions.Clear();
					this.vm.Options.HitOutputOptions.Clear();
					this.vm.Options.RemoteProxySources.Clear();
					ObjectExtension.ClonePropertiesTo(this.vm, this.tvm, Array.Empty<string>());
					string text = File.ReadAllText(openFileDialog.FileName);
					RunnerSessionData session = JsonConvert.DeserializeObject<RunnerSessionData>(text, new JsonConverter[]
					{
						new HitOutputOptionsConverter(),
						new DataPoolOptionsConverter(text)
					});
					GlobalData.RunnerManager.RestoreSession(session, this.runnerInstance.Id, this.tvm);
					this.tvm.Options.HitOutputOptions = new ObservableCollection<HitOutputOptions>(ListExtensions.RemoveDuplicateItem<HitOutputOptions>(this.tvm.Options.HitOutputOptions, (HitOutputOptions o) => o is DatabaseHitOutputOptions));
					this.ovm.StartingPoint = this.tvm.StartingPoint;
					this.InitGeneral();
					this.InitDataPool();
					this.InitProxies();
					this.ovm.HitOutputOptions = this.tvm.Options.HitOutputOptions;
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0003398C File Offset: 0x00031B8C
		private void RobotConnect_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				RobotType robotType = this.ovm.RobotType;
				if (robotType != null)
				{
					if (robotType == 1)
					{
						using (DiscordSocketClient discordSocketClient = new DiscordSocketClient())
						{
							discordSocketClient.LoginAsync(1, this.ovm.RobotToken, true).GetAwaiter().GetResult();
							discordSocketClient.GetBotGatewayAsync(null).GetAwaiter().GetResult();
							Alert.Success(discordSocketClient.LoginState.ToString(), "Success", false);
						}
					}
				}
				else
				{
					Alert.Success(TelegramBotClientExtensions.GetMeAsync(new TelegramBotClient(this.ovm.RobotToken, null), default(CancellationToken)).GetAwaiter().GetResult().ToString(), "Success", false);
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00033A84 File Offset: 0x00031C84
		private void AddBotUser_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(this.userTextBox.Text))
				{
					Alert.Warning("User is empty", "Warning", false);
				}
				else if (this.botUsersListView.SelectedIndex > -1)
				{
					int selectedIndex = this.botUsersListView.SelectedIndex;
					RobotUser robotUser = this.ovm.RobotUsers[selectedIndex];
					robotUser.User = this.userTextBox.Text;
					robotUser.Access = (RobotUser.Permission)this.botUserPermissionComboBox.SelectedItem;
					robotUser.AllowedCommands = new HashSet<string>(this.allowedCommandsComboBox.Text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
					this.ovm.RobotUsers.RemoveAt(this.botUsersListView.SelectedIndex);
					this.ovm.RobotUsers.Insert(selectedIndex, robotUser);
					this.userTextBox.Text = string.Empty;
					this.allowedCommandsComboBox.Text = this.defaultAllowedCommands;
				}
				else if (this.ovm.RobotUsers.Any((RobotUser b) => b.User.Equals(this.userTextBox.Text, StringComparison.OrdinalIgnoreCase)))
				{
					Alert.Error("This user exists", "Error", false);
				}
				else
				{
					this.ovm.RobotUsers.Add(new RobotUser
					{
						User = this.userTextBox.Text,
						Access = (RobotUser.Permission)this.botUserPermissionComboBox.SelectedItem,
						AllowedCommands = new HashSet<string>(this.allowedCommandsComboBox.Text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
					});
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00033C34 File Offset: 0x00031E34
		private void BotUsersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				RobotUser robotUser = (RobotUser)this.botUsersListView.SelectedItem;
				this.userTextBox.Text = robotUser.User;
				this.botUserPermissionComboBox.SelectedItem = robotUser.Access;
				this.allowedCommandsComboBox.Text = string.Join(", ", robotUser.AllowedCommands);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x00033CAC File Offset: 0x00031EAC
		private void listViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
			string propertyName = gridViewColumnHeader.Tag.ToString();
			if (this.listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(this.listViewSortCol).Remove(this.listViewSortAdorner);
				this.botUsersListView.Items.SortDescriptions.Clear();
			}
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if (this.listViewSortCol == gridViewColumnHeader && this.listViewSortAdorner.Direction == listSortDirection)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			this.listViewSortCol = gridViewColumnHeader;
			this.listViewSortAdorner = new SortAdorner(this.listViewSortCol, listSortDirection);
			AdornerLayer.GetAdornerLayer(this.listViewSortCol).Add(this.listViewSortAdorner);
			this.botUsersListView.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00033D68 File Offset: 0x00031F68
		private void CopyBotUser_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(((RobotUser)this.botUsersListView.SelectedItem).User);
			}
			catch
			{
			}
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x00033DA4 File Offset: 0x00031FA4
		private void CopyBotPermission_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(((RobotUser)this.botUsersListView.SelectedItem).Access.ToString());
			}
			catch
			{
			}
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x00033DF0 File Offset: 0x00031FF0
		private void CopyBotAllowedCommands_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(string.Join(", ", ((RobotUser)this.botUsersListView.SelectedItem).AllowedCommands));
			}
			catch
			{
			}
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00033E38 File Offset: 0x00032038
		private void BotRemoveSelected_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.ovm.RobotUsers.RemoveAt(this.botUsersListView.SelectedIndex);
			}
			catch
			{
			}
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00033E78 File Offset: 0x00032078
		private void ClearBotUsers_Click(object sender, RoutedEventArgs e)
		{
			if (this.ovm.RobotUsers.Count == 0)
			{
				return;
			}
			if (Alert.Choice("Are you sure you want to delete all users", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
			{
				return;
			}
			try
			{
				this.ovm.RobotUsers.Clear();
			}
			catch
			{
			}
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00034518 File Offset: 0x00032718
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 41:
				((ComboBox)target).Loaded += this.remoteProxyTypeCombobox_Loaded;
				((ComboBox)target).SelectionChanged += this.remoteProxyTypeCombobox_SelectionChanged;
				return;
			case 42:
				((Button)target).Click += this.removeRemoteProxySourceButton_Click;
				return;
			case 43:
			case 44:
				break;
			case 45:
				((Button)target).Click += this.RemoveHitOutput;
				return;
			case 46:
				((Button)target).Click += this.RemoveHitOutput;
				return;
			case 47:
				((Button)target).Click += this.RemoveHitOutput;
				return;
			case 48:
				((Button)target).Click += this.RemoveHitOutput;
				return;
			case 49:
				((Button)target).Click += this.RemoveHitOutput;
				break;
			default:
				return;
			}
		}

		// Token: 0x04000524 RID: 1316
		private Runner runner;

		// Token: 0x04000525 RID: 1317
		private RunnerViewModel vm;

		// Token: 0x04000526 RID: 1318
		private RunnerViewModel tvm;

		// Token: 0x04000527 RID: 1319
		private RunnerOptionsViewModel ovm;

		// Token: 0x04000528 RID: 1320
		private RunnerInstance runnerInstance;

		// Token: 0x04000529 RID: 1321
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x0400052A RID: 1322
		private SortAdorner listViewSortAdorner;

		// Token: 0x0400052B RID: 1323
		private string defaultAllowedCommands = "/Start, /AllowedCommands";

		// Token: 0x0400052C RID: 1324
		public Config EncryptedConfig;
	}
}
