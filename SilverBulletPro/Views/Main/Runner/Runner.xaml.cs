using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using HandyControl.Controls;
using PluginFrameworkPro;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Files;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Plugins;
using SilverBulletPro.Requests;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.StackerBlocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.Main.Runner
{
	// Token: 0x02000199 RID: 409
	public partial class Runner : Page, IStyleConnector
	{
		// Token: 0x06000A45 RID: 2629 RVA: 0x0003040C File Offset: 0x0002E60C
		public Runner(RunnerViewModel vm)
		{
			Runner <>4__this = this;
			this.vm = vm;
			base.DataContext = vm;
			this.InitializeComponent();
			this.botsSlider.Maximum = 200.0;
			vm.MessageArrived += this.LogRunnerData;
			vm.WorkerStatusChanged += this.LogWorkerStatus;
			vm.WorkerStatusChanged += this.ProcessStatusChange;
			vm.FoundHit += this.PlayHitSound;
			vm.FoundHit += this.RegisterHit;
			vm.ReloadProxies += this.PlayReloadSound;
			vm.ReloadProxies += delegate(IRunnerMessaging s)
			{
				<>4__this.LoadProxiesFromManager(s, vm.Options.Proxylist);
			};
			vm.DispatchAction += this.ExecuteAction;
			vm.SaveProgress += this.SaveProgressToDB;
			vm.AskCustomInputs += this.InitCustomInputs;
			if (GlobalData.SBSettings.General.ChangeRunnerInterface)
			{
				GlobalData.Logger.LogInfo(Components.About, "Changed the Runner interface", false, 0);
				Grid.SetColumn(this.rightGrid, 0);
				Grid.SetRow(this.rightGrid, 2);
				Grid.SetColumn(this.bottomLeftGrid, 2);
				Grid.SetRow(this.bottomLeftGrid, 0);
			}
			this.logBox.AppendText("", Colors.White);
			this.logBox.AppendText("Runner initialized succesfully!" + Environment.NewLine, Utils.GetColor("ForegroundMain"));
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x000305D8 File Offset: 0x0002E7D8
		private void LogRunnerData(IRunnerMessaging sender, LogLevel level, string message, bool prompt, int timeout)
		{
			GlobalData.Logger.Log(Components.Runner, level, message, prompt, timeout);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x000305EC File Offset: 0x0002E7EC
		private void LogWorkerStatus(IRunnerMessaging sender)
		{
			RunnerViewModel runnerViewModel = sender as RunnerViewModel;
			if (runnerViewModel.HasStartCondition && runnerViewModel.WaitUntilCts != null && runnerViewModel.WaitUntilCts.IsCancellationRequested && runnerViewModel.WorkerStatus == 1)
			{
				this.logBox.AppendText("The Runner Wait Was Skipped at " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt", CultureInfo.InvariantCulture) + "." + Environment.NewLine, Utils.GetColor("ForegroundOcrRate"));
			}
			switch (runnerViewModel.Master.Status)
			{
			case 0:
				this.logBox.AppendText("Aborted Runner at " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt", CultureInfo.InvariantCulture) + "." + Environment.NewLine, Utils.GetColor("ForegroundBad"));
				return;
			case 1:
			{
				RichTextBox box = this.logBox;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 4);
				defaultInterpolatedStringHandler.AppendLiteral("Started Running Config ");
				defaultInterpolatedStringHandler.AppendFormatted(runnerViewModel.ConfigName);
				defaultInterpolatedStringHandler.AppendLiteral(" with Wordlist ");
				defaultInterpolatedStringHandler.AppendFormatted(runnerViewModel.Options.WordlistName);
				defaultInterpolatedStringHandler.AppendLiteral(" at ");
				defaultInterpolatedStringHandler.AppendFormatted(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt", CultureInfo.InvariantCulture));
				defaultInterpolatedStringHandler.AppendLiteral(".");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				box.AppendText(defaultInterpolatedStringHandler.ToStringAndClear(), Utils.GetColor("ForegroundGood"));
				return;
			}
			case 2:
				this.logBox.AppendText("Sent Abort Request at " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt", CultureInfo.InvariantCulture) + "." + Environment.NewLine, Utils.GetColor("ForegroundCustom"));
				return;
			case 3:
				this.logBox.AppendText("The Runner Waiting To Start at " + ((runnerViewModel.Options.StartCondition is AbsoluteTimeStartCondition) ? runnerViewModel.StartTime.ToString("MM/dd/yyyy hh:mm:ss.fff tt", CultureInfo.InvariantCulture) : (DateTime.Now + runnerViewModel.Options.StartIn).ToString("MM/dd/yyyy hh:mm:ss.fff tt", CultureInfo.InvariantCulture)) + "." + Environment.NewLine, Utils.GetColor("ForegroundRetry"));
				return;
			default:
				return;
			}
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x00030827 File Offset: 0x0002EA27
		private void ExecuteAction(IRunnerMessaging sender, Action action)
		{
			Application.Current.Dispatcher.Invoke(action);
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x0003083C File Offset: 0x0002EA3C
		private void RegisterHit(IRunnerMessaging sender, Hit hit)
		{
			Application.Current.Dispatcher.Invoke(delegate()
			{
				if (this.vm.Config != null && this.vm.Config.Settings.SaveHitsToTextFile)
				{
					try
					{
						GlobalData.Logger.LogInfo(Components.Runner, string.Concat(new string[]
						{
							"Adding ",
							hit.Type,
							" hit ",
							hit.Data,
							" to the text file"
						}), false, 0);
						string text = Path.Combine("Hits", Files.MakeValidFileName(this.vm.Config.Settings.Name, true));
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
						}
						string text2 = Path.Combine(text, hit.Type + ".txt");
						RWLock handle = FileLocker.GetHandle(text2);
						lock (handle)
						{
							File.AppendAllText(text2, hit.Data + " | " + hit.CapturedString + Environment.NewLine);
						}
						return;
					}
					catch (Exception ex)
					{
						GlobalData.Logger.LogError(Components.Runner, string.Concat(new string[]
						{
							"Failed to add ",
							hit.Type,
							" hit ",
							hit.Data,
							" to the text file - ",
							ex.Message
						}), false, 0);
						return;
					}
				}
				try
				{
					GlobalData.Logger.LogInfo(Components.Runner, string.Concat(new string[]
					{
						"Adding ",
						hit.Type,
						" hit ",
						hit.Data,
						" to the DB"
					}), false, 0);
					GlobalData.HitsDB.Add(hit);
					GlobalData.MainWindow.HitsDBPage.AddConfigToFilter(this.vm.ConfigName);
				}
				catch (Exception ex2)
				{
					GlobalData.Logger.LogError(Components.Runner, string.Concat(new string[]
					{
						"Failed to add ",
						hit.Type,
						" hit ",
						hit.Data,
						" to the DB - ",
						ex2.Message
					}), false, 0);
				}
			});
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00030878 File Offset: 0x0002EA78
		private void PlayHitSound(IRunnerMessaging sender, Hit hit)
		{
			if (GlobalData.SBSettings.Sounds.EnableSounds && hit.Type.ToUpper() == "SUCCESS")
			{
				try
				{
					while (this.soundLock)
					{
						Thread.Sleep(10);
					}
					this.soundLock = true;
					this.hitPlayer.Play();
					this.soundLock = false;
				}
				catch
				{
				}
				finally
				{
					this.soundLock = false;
				}
			}
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x00030900 File Offset: 0x0002EB00
		private void PlayReloadSound(IRunnerMessaging sender)
		{
			if (GlobalData.SBSettings.Sounds.EnableSounds)
			{
				try
				{
					while (this.soundLock)
					{
						Thread.Sleep(10);
					}
					this.soundLock = true;
					this.reloadPlayer.Play();
					this.soundLock = false;
				}
				catch
				{
				}
				finally
				{
					this.soundLock = false;
				}
			}
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x00030974 File Offset: 0x0002EB74
		public void LoadProxiesFromManager(IRunnerMessaging sender, Proxylist proxylist)
		{
			List<CProxy> list;
			if (proxylist == null)
			{
				if (this.lastUsedProxylist == null)
				{
					list = GlobalData.ProxyChecker.Proxies.ToList<CProxy>();
				}
				else
				{
					list = GlobalData.ProxyManager.GetProxies(this.lastUsedProxylist, EnumExtensions.ToEnum<ProxyType>(this.lastUsedProxylist.Type, 0, true), "", "");
				}
			}
			else
			{
				ProxyManagerViewModel proxyManager = GlobalData.ProxyManager;
				this.lastUsedProxylist = proxylist;
				list = proxyManager.GetProxies(proxylist, EnumExtensions.ToEnum<ProxyType>(proxylist.Type, 0, true), "", "");
			}
			List<CProxy> list3;
			if (this.vm.Config.Settings.OnlySocks)
			{
				List<CProxy> list2;
				if (list == null)
				{
					list2 = null;
				}
				else
				{
					IEnumerable<CProxy> enumerable = from x in list
					where x.Type > 0
					select x;
					list2 = ((enumerable != null) ? enumerable.ToList<CProxy>() : null);
				}
				list3 = list2;
			}
			else if (this.vm.Config.Settings.OnlySsl)
			{
				List<CProxy> list4;
				if (list == null)
				{
					list4 = null;
				}
				else
				{
					IEnumerable<CProxy> enumerable2 = from x in list
					where x.Type == 0
					select x;
					list4 = ((enumerable2 != null) ? enumerable2.ToList<CProxy>() : null);
				}
				list3 = list4;
			}
			else
			{
				list3 = list;
			}
			if (list3 == null)
			{
				list3 = new List<CProxy>();
			}
			this.vm.ProxyPool = new ProxyPool(list3, this.vm.Options.ShuffleProxies);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x00030ACC File Offset: 0x0002ECCC
		private void ProcessStatusChange(IRunnerMessaging sender)
		{
			switch (this.vm.Master.Status)
			{
			case 0:
				this.SaveRecord();
				this.DisableProgress();
				this.UpdateStartButton("StartRunner", "M13.0455 -8.659125L5.887125 -12.812625C5.279625 -13.16475 4.5 -12.738375 4.5 -12.0285V-3.7215C4.5 -3.01275 5.2785 -2.58525 5.887125 -2.9385L13.0455 -7.092A0.90225 0.90225 0 0 0 13.0455 -8.659125z");
				base.Dispatcher.InvokeIfRequired(delegate
				{
					this.counter.Visibility = Visibility.Collapsed;
				}, DispatcherPriority.ContextIdle);
				return;
			case 1:
				this.UpdateStartButton("StopRunner", "M16,4.995v9.808C16,15.464,15.464,16,14.804,16H4.997C4.446,16,4,15.554,4,15.003V5.196C4,4.536,4.536,4,5.196,4h9.808  C15.554,4,16,4.446,16,4.995z");
				base.Dispatcher.InvokeIfRequired(delegate
				{
					this.counter.Visibility = Visibility.Collapsed;
				}, DispatcherPriority.ContextIdle);
				this.DisableProgress();
				return;
			case 2:
				this.DisableProgress();
				base.Dispatcher.InvokeIfRequired(delegate
				{
					this.counter.Visibility = Visibility.Collapsed;
				}, DispatcherPriority.ContextIdle);
				return;
			case 3:
				this.UpdateStartButton("SkipWait", "M500.5 231.4l-192-160C287.9 54.3 256 68.6 256 96v320c0 27.4 31.9 41.8 52.5 24.6l192-160c15.3-12.8 15.3-36.4 0-49.2zm-256 0l-192-160C31.9 54.3 0 68.6 0 96v320c0 27.4 31.9 41.8 52.5 24.6l192-160c15.3-12.8 15.3-36.4 0-49.2z");
				this.DisableProgress();
				return;
			default:
				return;
			}
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00030B9A File Offset: 0x0002ED9A
		private void SaveProgressToDB(IRunnerMessaging sender)
		{
			this.SaveRecord();
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x00030BA2 File Offset: 0x0002EDA2
		private void InitCustomInputs(IRunnerMessaging sender)
		{
			Application.Current.Dispatcher.Invoke(delegate()
			{
				this.vm.CustomInputs = new List<KeyValuePair<string, string>>();
				foreach (CustomInput customInput in this.vm.Config.Settings.CustomInputs)
				{
					GlobalData.Logger.LogInfo(Components.Runner, "Asking for input " + customInput.Description, false, 0);
					new MainDialog(new MainDialog.InputDialog
					{
						Dialog = new DialogCustomInput(this.vm, customInput),
						Title = "Custom Input"
					}).ShowDialog();
				}
				this.vm.CustomInputsInitialized = true;
			});
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00030BBF File Offset: 0x0002EDBF
		public void OnStartRunner(object sender, EventArgs e)
		{
			this.startButton_Click(this, new RoutedEventArgs());
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00030BD0 File Offset: 0x0002EDD0
		public void startButton_Click(object sender, RoutedEventArgs e)
		{
			switch (this.vm.Master.Status)
			{
			case 0:
				try
				{
					if (this.vm.Config == null)
					{
						throw new Exception("No Config loaded!");
					}
					AppIOManager.CheckRequiredPlugins(from b in GlobalData.BlockPlugins
					select b.Name, this.vm.Config);
				}
				catch (Exception ex)
				{
					GlobalData.Logger.LogError(Components.Runner, ex.Message, true, 0);
					break;
				}
				this.SetupSoundPlayers();
				ThreadPool.SetMinThreads(this.vm.Options.BotsAmount * 2 + 1, this.vm.Options.BotsAmount * 2 + 1);
				ServicePointManager.DefaultConnectionLimit = 10000;
				this.UpdateStartButton("StopRunner", "M16,4.995v9.808C16,15.464,15.464,16,14.804,16H4.997C4.446,16,4,15.554,4,15.003V5.196C4,4.536,4.536,4,5.196,4h9.808  C15.554,4,16,4.446,16,4.995z");
				this.vm.Start();
				if (this.vm.HasStartCondition)
				{
					this.counter.Visibility = Visibility.Visible;
					return;
				}
				break;
			case 1:
				this.vm.Stop();
				this.UpdateStartButton("HardAbortRunner", "M16,4.995v9.808C16,15.464,15.464,16,14.804,16H4.997C4.446,16,4,15.554,4,15.003V5.196C4,4.536,4.536,4,5.196,4h9.808  C15.554,4,16,4.446,16,4.995z");
				return;
			case 2:
				this.vm.ForceStop();
				this.UpdateStartButton("StartRunner", "M13.0455 -8.659125L5.887125 -12.812625C5.279625 -13.16475 4.5 -12.738375 4.5 -12.0285V-3.7215C4.5 -3.01275 5.2785 -2.58525 5.887125 -2.9385L13.0455 -7.092A0.90225 0.90225 0 0 0 13.0455 -8.659125z");
				this.SaveRecord();
				return;
			case 3:
				this.vm.SkipWait();
				this.UpdateStartButton("StopRunner", "M16,4.995v9.808C16,15.464,15.464,16,14.804,16H4.997C4.446,16,4,15.554,4,15.003V5.196C4,4.536,4.536,4,5.196,4h9.808  C15.554,4,16,4.446,16,4.995z");
				break;
			default:
				return;
			}
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x00030D50 File Offset: 0x0002EF50
		private void SetupSoundPlayers()
		{
			string text = "Sounds/" + GlobalData.SBSettings.Sounds.OnHitSound;
			string text2 = "Sounds/" + GlobalData.SBSettings.Sounds.OnReloadSound;
			if (File.Exists(text))
			{
				this.hitPlayer = new SoundPlayer(text);
			}
			if (File.Exists(text2))
			{
				this.reloadPlayer = new SoundPlayer(text2);
			}
			GlobalData.Logger.LogInfo(Components.Runner, "Set up sound players", false, 0);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x00030DCB File Offset: 0x0002EFCB
		public void SetConfig(Config config)
		{
			this.vm.SetConfig(config, GlobalData.SBSettings.General.RecommendedBots);
			this.RetrieveRecord();
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x00030DEE File Offset: 0x0002EFEE
		public void SetWordlist(Wordlist wordlist)
		{
			this.vm.SetWordlist(wordlist);
			this.RetrieveRecord();
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00030E02 File Offset: 0x0002F002
		private void selectConfigButton_Click(object sender, RoutedEventArgs e)
		{
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new DialogSelectConfig(this),
				Title = "Select Config"
			}).ShowDialog();
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00030E2C File Offset: 0x0002F02C
		private void selectListButton_Click(object sender, RoutedEventArgs e)
		{
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new DialogSelectWordlist(this),
				Title = "Select Wordlist"
			}).ShowDialog();
			this.wordlistNameTextBlock.SetResourceReference(Page.ForegroundProperty, (this.vm.Options.DataPoolType != null && this.vm.Options.DataPoolType != 1) ? "ForegroundCustom" : "ForegroundMain");
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00030EA4 File Offset: 0x0002F0A4
		private void hitsFilterButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.ResultsFilter = 2;
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.Runner;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Changed valid filter to ");
			defaultInterpolatedStringHandler.AppendFormatted<BotStatus>(this.vm.ResultsFilter);
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			this.RefreshListView();
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00030F00 File Offset: 0x0002F100
		private void customFilterButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.ResultsFilter = 6;
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.Runner;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Changed valid filter to ");
			defaultInterpolatedStringHandler.AppendFormatted<BotStatus>(this.vm.ResultsFilter);
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			this.RefreshListView();
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00030F5C File Offset: 0x0002F15C
		private void toCheckFilterButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.ResultsFilter = 0;
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.Runner;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Changed valid filter to ");
			defaultInterpolatedStringHandler.AppendFormatted<BotStatus>(this.vm.ResultsFilter);
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			this.RefreshListView();
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00030FB8 File Offset: 0x0002F1B8
		private void RefreshListView()
		{
			this.validListView.ItemsSource = this.vm.EmptyList;
			BotStatus resultsFilter = this.vm.ResultsFilter;
			if (resultsFilter == null)
			{
				this.validListView.ItemsSource = this.vm.ToCheckList;
				return;
			}
			if (resultsFilter == 2)
			{
				this.validListView.ItemsSource = this.vm.HitsList;
				return;
			}
			if (resultsFilter != 6)
			{
				return;
			}
			this.validListView.ItemsSource = this.vm.CustomList;
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x00031037 File Offset: 0x0002F237
		private ListView GetCurrentListView()
		{
			return this.validListView;
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0003103F File Offset: 0x0002F23F
		private void showManagerButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.MainWindow.ShowRunnerManager();
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0003104B File Offset: 0x0002F24B
		private void ListViewItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00031050 File Offset: 0x0002F250
		private void showHTML_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				File.WriteAllText("source.html", ((ValidData)this.GetCurrentListView().SelectedItem).Source);
				Process.Start("source.html");
				GlobalData.Logger.LogInfo(Components.Runner, "Saved the html to source.html and opened it with the default viewer", false, 0);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.Runner, "Couldn't show the HTML - " + ex.Message, true, 0);
			}
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x000310CC File Offset: 0x0002F2CC
		private void showLog_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new DialogShowLog(((ValidData)this.GetCurrentListView().SelectedItem).Log),
					Title = "Complete Log"
				}).Show();
				GlobalData.Logger.LogInfo(Components.Runner, "Opened the log for the hit " + ((ValidData)this.GetCurrentListView().SelectedItem).Data, false, 0);
			}
			catch
			{
				Alert.Error("FAILED", "Error", false);
			}
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00031164 File Offset: 0x0002F364
		private void showLogNotepadPlus_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				try
				{
					NotepadPlusExtension.Clear();
				}
				catch
				{
				}
				List<LogEntry> log = ((ValidData)this.GetCurrentListView().SelectedItem).Log;
				for (int i = 0; i < log.Count; i++)
				{
					NotepadPlusExtension.ShowText(log[i].LogString + Environment.NewLine);
				}
				GlobalData.Logger.LogInfo(Components.Runner, "Opened the log for the hit " + ((ValidData)this.GetCurrentListView().SelectedItem).Data, false, 0);
			}
			catch
			{
				Alert.Error("FAILED", "Error", false);
			}
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x0003121C File Offset: 0x0002F41C
		private void copySelectedData_Click(object sender, RoutedEventArgs e)
		{
			string text = "";
			try
			{
				foreach (object obj in this.GetCurrentListView().SelectedItems)
				{
					ValidData validData = (ValidData)obj;
					text = text + validData.Data + Environment.NewLine;
				}
				LoggerViewModel logger = GlobalData.Logger;
				Components component = Components.Runner;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Copied ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetCurrentListView().SelectedItems.Count);
				defaultInterpolatedStringHandler.AppendLiteral(" data");
				logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
				Clipboard.SetText(text);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.Runner, "Exception while copying data - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00031310 File Offset: 0x0002F510
		private void copySelectedCapture_Click(object sender, RoutedEventArgs e)
		{
			string text = "";
			try
			{
				foreach (object obj in this.GetCurrentListView().SelectedItems)
				{
					ValidData validData = (ValidData)obj;
					text = string.Concat(new string[]
					{
						text,
						validData.Data,
						" | ",
						validData.CapturedData,
						Environment.NewLine
					});
				}
				LoggerViewModel logger = GlobalData.Logger;
				Components component = Components.Runner;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Copied ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetCurrentListView().SelectedItems.Count);
				defaultInterpolatedStringHandler.AppendLiteral(" data");
				logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
				Clipboard.SetText(text);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.Runner, "Exception while copying data - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x00031424 File Offset: 0x0002F624
		private void copySelectedCaptureOnly_Click(object sender, RoutedEventArgs e)
		{
			string text = "";
			try
			{
				foreach (object obj in this.GetCurrentListView().SelectedItems)
				{
					ValidData validData = (ValidData)obj;
					text = text + validData.CapturedData + Environment.NewLine;
				}
				LoggerViewModel logger = GlobalData.Logger;
				Components component = Components.Runner;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Copied ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetCurrentListView().SelectedItems.Count);
				defaultInterpolatedStringHandler.AppendLiteral(" data");
				logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
				Clipboard.SetText(text);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.Runner, "Exception while copying data - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x00031518 File Offset: 0x0002F718
		private void selectAll_Click(object sender, RoutedEventArgs e)
		{
			this.GetCurrentListView().SelectAll();
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x00031528 File Offset: 0x0002F728
		private void copySelectedProxy_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(((ValidData)this.GetCurrentListView().SelectedItem).Proxy);
				GlobalData.Logger.LogInfo(Components.Runner, "Copied the proxy " + ((ValidData)this.GetCurrentListView().SelectedItem).Proxy, false, 0);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.Runner, "Couldn't copy the proxy for the selected hit - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x000315B0 File Offset: 0x0002F7B0
		private void sendToDebugger_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				StackerViewModel stacker = GlobalData.Stacker;
				ValidData validData = this.GetCurrentListView().SelectedItem as ValidData;
				stacker.TestData = validData.Data;
				stacker.TestProxy = validData.Proxy;
				stacker.ProxyType = validData.ProxyType;
				GlobalData.Logger.LogInfo(Components.Runner, "Sent to the debugger", false, 0);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.Runner, "Could not send data and proxy to the debugger - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0003163C File Offset: 0x0002F83C
		private void SaveRecord()
		{
			Wordlist wordlist = null;
			try
			{
				wordlist = this.vm.Options.GetWordlistFromDataPoolOptions(false);
			}
			catch
			{
			}
			GlobalData.RunnerManager.SaveRecord(this.vm.Config, wordlist, (long)this.vm.TestedCount + this.vm.StartingPoint);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x000316A0 File Offset: 0x0002F8A0
		private void RetrieveRecord()
		{
			Wordlist wordlist = null;
			try
			{
				wordlist = this.vm.Options.GetWordlistFromDataPoolOptions(false);
			}
			catch
			{
			}
			this.vm.StartingPoint = GlobalData.RunnerManager.RetrieveRecord(this.vm.Config, (wordlist != null) ? wordlist.Path : null);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00031704 File Offset: 0x0002F904
		public void LabelCustom_MouseEnter(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.vm.CustomCount != 0)
				{
					Label label = e.OriginalSource as Label;
					string toolTip = string.Empty;
					var enumerable = from v in this.vm.CustomList
					select v.Type into cType
					group cType by cType into g
					let customCount = g.Count<string>()
					orderby customCount descending
					select new
					{
						Count = customCount,
						Name = g.Key
					};
					if (enumerable != null && enumerable.Count() > 0)
					{
						enumerable.ToList().ForEach(delegate(ct)
						{
							string toolTip = toolTip;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
							defaultInterpolatedStringHandler.AppendFormatted(ct.Name);
							defaultInterpolatedStringHandler.AppendLiteral(":");
							defaultInterpolatedStringHandler.AppendFormatted<int>(ct.Count);
							defaultInterpolatedStringHandler.AppendLiteral("\n");
							toolTip += defaultInterpolatedStringHandler.ToStringAndClear();
						});
						toolTip = toolTip.TrimEnd('\n');
						label.ToolTip = new ToolTip
						{
							Content = toolTip
						};
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x00031870 File Offset: 0x0002FA70
		public void LabelCustom_MouseLeave(object sender, MouseEventArgs e)
		{
			try
			{
				(e.OriginalSource as Label).ToolTip = null;
			}
			catch
			{
			}
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x000318A4 File Offset: 0x0002FAA4
		private void TextBoxBotsAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			try
			{
				Regex regex = new Regex("[^0-9]+");
				e.Handled = regex.IsMatch(e.Text);
				if (!e.Handled)
				{
					TextBox textBox = (TextBox)sender;
					string str = textBox.Text;
					if (textBox.SelectedText != string.Empty)
					{
						str = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectedText.Length);
					}
					int num = int.Parse(str + e.Text);
					e.Handled = ((double)num > this.botsSlider.Maximum || (double)num <= this.botsSlider.Minimum - 1.0);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x00031974 File Offset: 0x0002FB74
		private void UpdateStartButton(string buttonTitle, string geometry)
		{
			base.Dispatcher.InvokeIfRequired(delegate
			{
				(this.startButton.Content as TextBlock).SetResourceReference(TextBlock.TextProperty, buttonTitle);
				IconElement.SetGeometry(this.startButton, Geometry.Parse(geometry));
			}, DispatcherPriority.ContextIdle);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x000319B4 File Offset: 0x0002FBB4
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (GlobalData.SBSettings.General.ChangeRunnerInterface)
				{
					if (Grid.GetColumn(this.rightGrid) != 0)
					{
						GlobalData.Logger.LogInfo(Components.About, "Changed the Runner interface", false, 0);
						Grid.SetColumn(this.rightGrid, 0);
						Grid.SetRow(this.rightGrid, 2);
						Grid.SetColumn(this.bottomLeftGrid, 2);
						Grid.SetRow(this.bottomLeftGrid, 0);
					}
				}
				else if (Grid.GetColumn(this.rightGrid) != 2)
				{
					GlobalData.Logger.LogInfo(Components.About, "Changed to default Runner interface", false, 0);
					Grid.SetColumn(this.rightGrid, 2);
					Grid.SetRow(this.rightGrid, 0);
					Grid.SetColumn(this.bottomLeftGrid, 0);
					Grid.SetRow(this.bottomLeftGrid, 2);
				}
			}
			catch
			{
			}
			try
			{
				this.wordlistNameTextBlock.SetResourceReference(Page.ForegroundProperty, (this.vm.Options.DataPoolType != null && this.vm.Options.DataPoolType != 1) ? "ForegroundCustom" : "ForegroundMain");
			}
			catch
			{
			}
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

		// Token: 0x06000A6E RID: 2670 RVA: 0x00031B34 File Offset: 0x0002FD34
		private void Wordlist_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (!this.vm.Busy)
				{
					if (e.Data.GetDataPresent(DataFormats.FileDrop))
					{
						string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
						if (array != null && array.Length != 0 && File.Exists(array[0]) && Path.GetExtension(array[0]).ToLower() == ".txt")
						{
							string text = array[0];
							string currentDirectory = Directory.GetCurrentDirectory();
							if (text.StartsWith(currentDirectory))
							{
								text = text.Substring(currentDirectory.Length + 1);
							}
							Wordlist wordlist = new Wordlist(Path.GetFileNameWithoutExtension(text), text, GlobalData.Settings.Environment.WordlistTypes.First<WordlistType>().Name, "", true, false, false);
							wordlist.Type = GlobalData.Settings.Environment.RecognizeWordlistType(wordlist.FirstLine);
							this.SetWordlist(wordlist);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00031C38 File Offset: 0x0002FE38
		private void Wordlist_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00031C44 File Offset: 0x0002FE44
		private void selectConfigButton_Drop(object sender, DragEventArgs e)
		{
			if (this.vm.Busy)
			{
				return;
			}
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
				if (array != null && array.Length != 0 && File.Exists(array[0]))
				{
					string text = array[0];
					string currentDirectory = Directory.GetCurrentDirectory();
					if (text.StartsWith(currentDirectory))
					{
						text = text.Substring(currentDirectory.Length + 1);
					}
					if (Path.GetExtension(array[0]).ToLower() == ".espk")
					{
						string text2 = Alert.CustomInput("Password", "Custom Title", null);
						if (string.IsNullOrEmpty(text2))
						{
							return;
						}
						Config config;
						this.SetConfig(config = IOManager.CloneConfig(IOManager.Unpack(CryptConfig.Decrypt(text, text2), Path.GetFileNameWithoutExtension(text))));
						if (config == null || config.Settings.RequiredPlugins.Length == 0)
						{
							return;
						}
						try
						{
							ValueTuple<IEnumerable<PluginControl>, IEnumerable<IBlockPlugin>> valueTuple = Loader.LoadPlugins(Constants.PluginsFolder);
							IEnumerable<PluginControl> item = valueTuple.Item1;
							IEnumerable<IBlockPlugin> item2 = valueTuple.Item2;
							GlobalData.BlockPlugins = item2.ToList<IBlockPlugin>();
							MainWindow.Plugins = item;
							foreach (IBlockPlugin blockPlugin in item2)
							{
								try
								{
									GlobalData.BlockMappings.Add(new SilverBlock(blockPlugin.GetType(), typeof(BlockPluginPage), blockPlugin.Background, blockPlugin.Foreground, null));
									BlockParser.BlockMappings.Add(blockPlugin.Name, blockPlugin.GetType());
									GlobalData.Logger.LogInfo(Components.Main, "Initialized " + blockPlugin.Name + " block plugin", false, 0);
								}
								catch
								{
								}
							}
							return;
						}
						catch
						{
							return;
						}
					}
					if (Path.GetExtension(array[0]).ToLower() == ".spk")
					{
						using (FileStream fileStream = new FileStream(text, FileMode.Open))
						{
							this.SetConfig(IOManager.CloneConfig(IOManager.Unpack(fileStream, Path.GetFileNameWithoutExtension(text))));
						}
					}
				}
			}
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00031E7C File Offset: 0x0003007C
		private void EnableProgress()
		{
			base.Dispatcher.InvokeIfRequired(delegate
			{
				this.progressDialog.Enable(this.mainGrid, default(TimeSpan));
			}, DispatcherPriority.ContextIdle);
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x00031E96 File Offset: 0x00030096
		private void DisableProgress()
		{
			base.Dispatcher.InvokeIfRequired(delegate
			{
				this.progressDialog.Disable(this.mainGrid, default(TimeSpan));
			}, DispatcherPriority.ContextIdle);
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00031EB0 File Offset: 0x000300B0
		private void TextBoxBotsAmount_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				this.vm.Options.BotsAmount = int.Parse((sender as TextBox).Text);
			}
			catch
			{
			}
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000323A8 File Offset: 0x000305A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 26)
			{
				EventSetter eventSetter = new EventSetter();
				eventSetter.Event = UIElement.MouseRightButtonDownEvent;
				eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseRightButtonDown);
				((Style)target).Setters.Add(eventSetter);
			}
		}

		// Token: 0x04000501 RID: 1281
		private RunnerViewModel vm;

		// Token: 0x04000502 RID: 1282
		private SoundPlayer hitPlayer;

		// Token: 0x04000503 RID: 1283
		private SoundPlayer reloadPlayer;

		// Token: 0x04000504 RID: 1284
		private Proxylist lastUsedProxylist;

		// Token: 0x04000505 RID: 1285
		private bool soundLock;
	}
}
