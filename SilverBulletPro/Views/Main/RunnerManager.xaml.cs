using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using HandyControl.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using SilverBulletPro.Converters;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Dialogs;
using SilverBulletPro.Views.Main.Runner;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x02000180 RID: 384
	public partial class RunnerManager : Page, IStyleConnector
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x00029B34 File Offset: 0x00027D34
		// (set) Token: 0x06000948 RID: 2376 RVA: 0x00029B3C File Offset: 0x00027D3C
		private bool DelegateCalled { get; set; }

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000949 RID: 2377 RVA: 0x00029B48 File Offset: 0x00027D48
		// (remove) Token: 0x0600094A RID: 2378 RVA: 0x00029B80 File Offset: 0x00027D80
		public event RunnerManager.StartRunnerEventHandler StartRunner;

		// Token: 0x0600094B RID: 2379 RVA: 0x00029BB5 File Offset: 0x00027DB5
		protected virtual void OnStartRunner()
		{
			RunnerManager.StartRunnerEventHandler startRunner = this.StartRunner;
			if (startRunner == null)
			{
				return;
			}
			startRunner(this, EventArgs.Empty);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00029BCD File Offset: 0x00027DCD
		public RunnerManager()
		{
			this.vm = GlobalData.RunnerManager;
			base.DataContext = this.vm;
			this.InitializeComponent();
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00029BFC File Offset: 0x00027DFC
		private void addRunnerButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.Create();
			this.helpMessageLabel.Visibility = Visibility.Collapsed;
			RunnerInstance instance;
			if ((instance = this.vm.RunnersCollection.LastOrDefault<RunnerInstance>()) != null)
			{
				this.ShowRunnerOptions(instance);
			}
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00029C3C File Offset: 0x00027E3C
		private void removeRunnerButton_Click(object sender, RoutedEventArgs e)
		{
			int id = (int)((FrameworkElement)((ContextMenu)(e.Source as MenuItem).Parent).PlacementTarget).Tag;
			if (this.vm.Get(id).ViewModel.Master.Status != null)
			{
				Alert.Error("The Runner is active! Please stop it before removing it.", "Error", false);
				return;
			}
			this.vm.Remove(id);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00029CB0 File Offset: 0x00027EB0
		private void startRunnerButton_Click(object sender, RoutedEventArgs e)
		{
			int id = (int)((FrameworkElement)((ContextMenu)(e.Source as MenuItem).Parent).PlacementTarget).Tag;
			RunnerInstance runnerInstance = this.vm.Get(id);
			this.StartRunner += runnerInstance.View.OnStartRunner;
			this.OnStartRunner();
			this.StartRunner -= runnerInstance.View.OnStartRunner;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00029D28 File Offset: 0x00027F28
		private void RunnerInstanceGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (this.runnerMouseDown)
				{
					if (this.DelegateCalled)
					{
						this.DelegateCalled = false;
					}
					else
					{
						int id = (int)(sender as FrameworkElement).Tag;
						GlobalData.MainWindow.ShowRunner(this.vm.Get(id).View);
					}
				}
			}
			finally
			{
				this.runnerMouseDown = false;
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00029D94 File Offset: 0x00027F94
		private void RunnerInstanceGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.runnerMouseDown = true;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00029D9D File Offset: 0x00027F9D
		private void RunnerInstanceGrid_MouseLeave(object sender, MouseEventArgs e)
		{
			this.runnerMouseDown = false;
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00029DA8 File Offset: 0x00027FA8
		private static T FindParent<T>(DependencyObject child) where T : DependencyObject
		{
			DependencyObject parent = VisualTreeHelper.GetParent(child);
			if (parent == null)
			{
				return default(T);
			}
			T t = parent as T;
			if (t != null)
			{
				return t;
			}
			return RunnerManager.FindParent<T>(parent);
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00029DE8 File Offset: 0x00027FE8
		private void selectConfig_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.RightButton != MouseButtonState.Released || e.MiddleButton != MouseButtonState.Released)
			{
				return;
			}
			int id = (int)((FrameworkElement)((FrameworkElement)(sender as FrameworkElement).Parent).Parent).Tag;
			RunnerInstance runnerInstance = GlobalData.MainWindow.RunnerManagerPage.vm.Get(id);
			if (!runnerInstance.ViewModel.Busy)
			{
				this.DelegateCalled = true;
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new DialogSelectConfig(runnerInstance.View),
					Title = "Select Config"
				}).ShowDialog();
				this.DelegateCalled = false;
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00029E88 File Offset: 0x00028088
		private void selectWordlist_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.RightButton != MouseButtonState.Released || e.MiddleButton != MouseButtonState.Released)
			{
				return;
			}
			int id = (int)((FrameworkElement)((FrameworkElement)(sender as FrameworkElement).Parent).Parent).Tag;
			RunnerInstance runnerInstance = GlobalData.MainWindow.RunnerManagerPage.vm.Get(id);
			if (!runnerInstance.ViewModel.Busy)
			{
				this.DelegateCalled = true;
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new DialogSelectList(runnerInstance.View),
					Title = "Select List"
				}).ShowDialog();
				this.DelegateCalled = false;
			}
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00029F28 File Offset: 0x00028128
		private void selectProxies_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.RightButton != MouseButtonState.Released || e.MiddleButton != MouseButtonState.Released)
			{
				return;
			}
			int id = (int)((FrameworkElement)((FrameworkElement)(sender as FrameworkElement).Parent).Parent).Tag;
			RunnerInstance runnerInstance = GlobalData.MainWindow.RunnerManagerPage.vm.Get(id);
			if (!runnerInstance.ViewModel.Busy)
			{
				this.DelegateCalled = true;
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new DialogSetProxies(runnerInstance.ViewModel),
					Title = "Set Proxies"
				}).ShowDialog();
				this.DelegateCalled = false;
			}
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00029FC8 File Offset: 0x000281C8
		private void selectBots_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.RightButton != MouseButtonState.Released)
			{
				return;
			}
			int id = (int)((FrameworkElement)((FrameworkElement)(sender as FrameworkElement).Parent).Parent).Tag;
			RunnerInstance runnerInstance = GlobalData.MainWindow.RunnerManagerPage.vm.Get(id);
			if (!runnerInstance.ViewModel.Busy)
			{
				this.DelegateCalled = true;
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new DialogSelectBots(runnerInstance.ViewModel, runnerInstance.ViewModel.Options.BotsAmount),
					Title = "Select Bots Number"
				}).ShowDialog();
				this.DelegateCalled = false;
			}
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0002A070 File Offset: 0x00028270
		private void stopAllRunnersButton_Click(object sender, RoutedEventArgs e)
		{
			foreach (RunnerInstance runnerInstance in from r in this.vm.RunnersCollection
			where r.ViewModel.Busy
			select r)
			{
				this.StartRunner += runnerInstance.View.OnStartRunner;
				this.OnStartRunner();
				this.StartRunner -= runnerInstance.View.OnStartRunner;
			}
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0002A114 File Offset: 0x00028314
		private void removeAllRunnersButton_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Alerter.YesOrNo("Are you sure you want to remove all Runners?", "Confirmation"))
			{
				List<RunnerInstance> list = (from r in this.vm.RunnersCollection
				where !r.ViewModel.Busy
				select r).ToList<RunnerInstance>();
				for (int i = list.Count - 1; i >= 0; i--)
				{
					this.vm.RunnersCollection.Remove(list[i]);
				}
			}
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0002A198 File Offset: 0x00028398
		private void startAllRunnersButton_Click(object sender, RoutedEventArgs e)
		{
			foreach (RunnerInstance runnerInstance in from r in this.vm.RunnersCollection
			where !r.ViewModel.Busy
			select r)
			{
				this.StartRunner += runnerInstance.View.OnStartRunner;
				this.OnStartRunner();
				this.StartRunner -= runnerInstance.View.OnStartRunner;
			}
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0002A23C File Offset: 0x0002843C
		private void LabelCustom_MouseEnter(object sender, MouseEventArgs e)
		{
			try
			{
				int id = (int)RunnerManager.FindParent<Grid>(sender as DependencyObject).Tag;
				GlobalData.MainWindow.RunnerManagerPage.vm.Get(id).View.LabelCustom_MouseEnter(sender, e);
			}
			catch
			{
			}
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0002A298 File Offset: 0x00028498
		private void LabelCustom_MouseLeave(object sender, MouseEventArgs e)
		{
			try
			{
				(e.OriginalSource as Label).ToolTip = null;
			}
			catch
			{
			}
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0002A2CC File Offset: 0x000284CC
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.vm.RunnersCollection.Count > 0)
			{
				this.helpMessageLabel.Visibility = Visibility.Collapsed;
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

		// Token: 0x0600095E RID: 2398 RVA: 0x0002A350 File Offset: 0x00028550
		private void RunnerSettings_Click(object sender, RoutedEventArgs e)
		{
			int id = (int)((FrameworkElement)((ContextMenu)(e.Source as MenuItem).Parent).PlacementTarget).Tag;
			this.ShowRunnerOptions(id);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0002A38E File Offset: 0x0002858E
		private void ShowRunnerOptions(int id)
		{
			this.ShowRunnerOptions(this.vm.Get(id));
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0002A3A4 File Offset: 0x000285A4
		private void ShowRunnerOptions(RunnerInstance instance)
		{
			MainDialog mainDialog = new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new RunnerOptions(instance),
				ResizeMode = ResizeMode.CanResize,
				DisableMinimize = true,
				InitialWidth = new int?(550),
				InitialHeight = new int?(425),
				SizeToContent = SizeToContent.Manual
			});
			mainDialog.Background = Brushes.Transparent;
			mainDialog.KeyDown += delegate(object s, KeyEventArgs e)
			{
				if (e.Key == Key.Escape)
				{
					MainDialog mainDialog2 = s as MainDialog;
					if (mainDialog2 == null)
					{
						return;
					}
					mainDialog2.Close();
				}
			};
			mainDialog.ShowDialog();
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0002A434 File Offset: 0x00028634
		private void saveRunnerToTextFile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int id = (int)((FrameworkElement)((ContextMenu)(e.Source as MenuItem).Parent).PlacementTarget).Tag;
				RunnerInstance runnerInstance = this.vm.Get(id);
				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					Filter = "Runner|*.json",
					FileName = "Runner (" + runnerInstance.ViewModel.ConfigName + ")"
				};
				bool? flag = saveFileDialog.ShowDialog();
				bool flag2 = true;
				if (flag.GetValueOrDefault() == flag2 & flag != null)
				{
					RunnerSessionData runnerSessionData = new RunnerSessionData
					{
						Options = runnerInstance.ViewModel.Options,
						Config = ((runnerInstance.ViewModel.Config != null) ? runnerInstance.ViewModel.ConfigName : "")
					};
					File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(runnerSessionData));
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0002A538 File Offset: 0x00028738
		private void restoreRunner_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int id = (int)((FrameworkElement)((ContextMenu)(e.Source as MenuItem).Parent).PlacementTarget).Tag;
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "Runner|*.json"
				};
				bool? flag = openFileDialog.ShowDialog();
				bool flag2 = true;
				if (flag.GetValueOrDefault() == flag2 & flag != null)
				{
					string text = File.ReadAllText(openFileDialog.FileName);
					RunnerSessionData session = JsonConvert.DeserializeObject<RunnerSessionData>(text, new JsonConverter[]
					{
						new HitOutputOptionsConverter(),
						new DataPoolOptionsConverter(text)
					});
					RunnerInstance runnerInstance = this.vm.Get(id);
					runnerInstance.ViewModel.Options.RemoteProxySources.Clear();
					this.vm.RestoreSession(session, id, runnerInstance.ViewModel);
					runnerInstance.ViewModel.Options.HitOutputOptions = new ObservableCollection<HitOutputOptions>(ListExtensions.RemoveDuplicateItem<HitOutputOptions>(runnerInstance.ViewModel.Options.HitOutputOptions, (HitOutputOptions o) => o is DatabaseHitOutputOptions));
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0002A680 File Offset: 0x00028880
		private void cloneRunner_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int id = (int)((FrameworkElement)((ContextMenu)(e.Source as MenuItem).Parent).PlacementTarget).Tag;
				this.vm.Clone(this.vm.Get(id));
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x0002A6F0 File Offset: 0x000288F0
		private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			try
			{
				ScrollViewer scrollViewer = e.OriginalSource as ScrollViewer;
				if (scrollViewer != null && scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible)
				{
					scrollViewer.Padding = new Thickness(5.0, 0.0, 15.0, 5.0);
				}
				else
				{
					((ScrollViewer)e.OriginalSource).Padding = new Thickness(2.0, 0.0, 6.0, 0.0);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0002A794 File Offset: 0x00028994
		private void ShowRunnerMenu_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ContextMenu contextMenu = (ContextMenu)base.FindResource("RunnerMenu");
				contextMenu.IsOpen = false;
				contextMenu.PlacementTarget = (FrameworkElement)sender;
				contextMenu.Placement = PlacementMode.Left;
				contextMenu.IsOpen = true;
				this.canOpenRunnerMenu = true;
			}
			catch
			{
			}
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0002A7F0 File Offset: 0x000289F0
		private void RunnerMenu_Closed(object sender, RoutedEventArgs e)
		{
			try
			{
				((ContextMenu)sender).Placement = PlacementMode.MousePoint;
			}
			catch
			{
			}
			((ContextMenu)e.Source).Visibility = Visibility.Visible;
			this.canOpenRunnerMenu = true;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0002A838 File Offset: 0x00028A38
		private void RunnerMenu_Opening(object sender, ContextMenuEventArgs e)
		{
			e.Handled = !this.canOpenRunnerMenu;
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0002A849 File Offset: 0x00028A49
		private void RunnerMenu_Opened(object sender, RoutedEventArgs e)
		{
			e.Handled = !this.canOpenRunnerMenu;
			if (!this.canOpenRunnerMenu)
			{
				((ContextMenu)e.Source).Visibility = Visibility.Collapsed;
				((ContextMenu)e.Source).IsOpen = false;
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0002A884 File Offset: 0x00028A84
		private void ShowRunnerMenu_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			this.canOpenRunnerMenu = false;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0002AAE0 File Offset: 0x00028CE0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 17:
				((Border)target).MouseLeave += this.RunnerInstanceGrid_MouseLeave;
				((Border)target).MouseLeftButtonUp += this.RunnerInstanceGrid_MouseLeftButtonUp;
				((Border)target).PreviewMouseDown += this.RunnerInstanceGrid_PreviewMouseDown;
				return;
			case 18:
				((TextBlock)target).MouseDown += this.selectConfig_MouseDown;
				return;
			case 19:
				((TextBlock)target).MouseDown += this.selectConfig_MouseDown;
				return;
			case 20:
				((TextBlock)target).MouseDown += this.selectWordlist_MouseDown;
				return;
			case 21:
				((TextBlock)target).MouseDown += this.selectWordlist_MouseDown;
				return;
			case 22:
				((TextBlock)target).MouseDown += this.selectBots_MouseDown;
				return;
			case 23:
				((TextBlock)target).MouseDown += this.selectBots_MouseDown;
				return;
			case 24:
				((TextBlock)target).MouseDown += this.selectProxies_MouseDown;
				return;
			case 25:
				((TextBlock)target).MouseDown += this.selectProxies_MouseDown;
				return;
			case 26:
				((TextBlock)target).MouseEnter += this.LabelCustom_MouseEnter;
				((TextBlock)target).MouseLeave += this.LabelCustom_MouseLeave;
				return;
			case 27:
				((Button)target).Click += this.ShowRunnerMenu_Click;
				((Button)target).MouseRightButtonUp += this.ShowRunnerMenu_MouseRightButtonUp;
				return;
			default:
				return;
			}
		}

		// Token: 0x04000458 RID: 1112
		private bool runnerMouseDown;

		// Token: 0x04000459 RID: 1113
		private bool canOpenRunnerMenu = true;

		// Token: 0x0400045A RID: 1114
		private RunnerManagerViewModel vm;

		// Token: 0x02000259 RID: 601
		// (Invoke) Token: 0x06001147 RID: 4423
		public delegate void StartRunnerEventHandler(object sender, EventArgs e);
	}
}
