using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using HandyControl.Controls;
using PluginFrameworkPro;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Plugins;
using SilverBulletPro.Views.StackerBlocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x0200017E RID: 382
	public partial class PluginsSection : Page
	{
		// Token: 0x06000912 RID: 2322 RVA: 0x00027A40 File Offset: 0x00025C40
		public PluginsSection(IEnumerable<PluginControl> controls)
		{
			this.InitializeComponent();
			this.controls = controls.ToList<PluginControl>();
			foreach (PluginControl pluginControl in this.controls)
			{
				this.pluginSelector.Items.Add(pluginControl.Plugin.Name);
			}
			if (this.controls.Count > 0)
			{
				this.pluginSelector.SelectedIndex = 0;
			}
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00027ADC File Offset: 0x00025CDC
		private void pluginSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.Main.Content = this.controls.First((PluginControl c) => c.Plugin.Name == (string)this.pluginSelector.SelectedValue);
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00027B2C File Offset: 0x00025D2C
		private void Main_Navigated(object sender, NavigationEventArgs e)
		{
			try
			{
				(sender as Frame).NavigationService.RemoveBackEntry();
			}
			catch
			{
			}
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00027B60 File Offset: 0x00025D60
		private void RefreshButton_Click(object sender, RoutedEventArgs e)
		{
			PluginsSection.<>c__DisplayClass5_0 CS$<>8__locals1 = new PluginsSection.<>c__DisplayClass5_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.reloadRenderTransform = this.reloadIcon.RenderTransform;
			CS$<>8__locals1.waitForReloadCompleted = (Storyboard)base.FindResource("WaitForReloadCompleted");
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
				CS$<>8__locals1.waitForReloadCompleted.Begin();
				this.reloadTask = Task.Run(delegate()
				{
					PluginsSection.<>c__DisplayClass5_0.<<RefreshButton_Click>b__0>d <<RefreshButton_Click>b__0>d;
					<<RefreshButton_Click>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
					<<RefreshButton_Click>b__0>d.<>4__this = CS$<>8__locals1;
					<<RefreshButton_Click>b__0>d.<>1__state = -1;
					<<RefreshButton_Click>b__0>d.<>t__builder.Start<PluginsSection.<>c__DisplayClass5_0.<<RefreshButton_Click>b__0>d>(ref <<RefreshButton_Click>b__0>d);
					return <<RefreshButton_Click>b__0>d.<>t__builder.Task;
				}).ContinueWith(delegate(Task t)
				{
					Dispatcher dispatcher = CS$<>8__locals1.<>4__this.Dispatcher;
					Action callback;
					if ((callback = CS$<>8__locals1.<>9__2) == null)
					{
						callback = (CS$<>8__locals1.<>9__2 = delegate()
						{
							CS$<>8__locals1.<>4__this.reloadIcon.RenderTransform = CS$<>8__locals1.reloadRenderTransform;
							CS$<>8__locals1.<>4__this.controls = MainWindow.Plugins.ToList<PluginControl>();
							CS$<>8__locals1.<>4__this.pluginSelector.Items.Clear();
							foreach (PluginControl pluginControl in CS$<>8__locals1.<>4__this.controls)
							{
								CS$<>8__locals1.<>4__this.pluginSelector.Items.Add(pluginControl.Plugin.Name);
							}
							CS$<>8__locals1.waitForReloadCompleted.Stop();
							if (CS$<>8__locals1.<>4__this.controls.Count > 0)
							{
								CS$<>8__locals1.<>4__this.pluginSelector.SelectedIndex = 0;
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
				CS$<>8__locals1.waitForReloadCompleted.Stop();
				base.Dispatcher.Invoke<Transform>(() => CS$<>8__locals1.<>4__this.reloadIcon.RenderTransform = CS$<>8__locals1.reloadRenderTransform);
				base.Dispatcher.Invoke(delegate()
				{
					GlobalData.Logger.Log(ex.Message, 2, true, 0);
				});
			}
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00027C54 File Offset: 0x00025E54
		private void OpenPluginsFolderButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start(Path.Combine(Directory.GetCurrentDirectory(), Constants.PluginsFolder));
			}
			catch
			{
			}
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00027C8C File Offset: 0x00025E8C
		private void RefreshPlugins()
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
					LoggerViewModel logger = GlobalData.Logger;
					Components component = Components.Main;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
					defaultInterpolatedStringHandler.AppendLiteral("The color ");
					defaultInterpolatedStringHandler.AppendFormatted<System.Drawing.Color>(blockPlugin.Background);
					defaultInterpolatedStringHandler.AppendLiteral(" in block plugin ");
					defaultInterpolatedStringHandler.AppendFormatted(blockPlugin.Name);
					defaultInterpolatedStringHandler.AppendLiteral(" is invalid");
					logger.LogError(component, defaultInterpolatedStringHandler.ToStringAndClear(), true, 0);
				}
			}
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00027DCC File Offset: 0x00025FCC
		private void ShowPluginsButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start("https://github.com/mohamm4dx/SilverBulletPro/tree/main/Plugins");
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00027E04 File Offset: 0x00026004
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

		// Token: 0x04000437 RID: 1079
		private List<PluginControl> controls;

		// Token: 0x04000438 RID: 1080
		private Task reloadTask;
	}
}
