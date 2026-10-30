using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using SilverBulletPro.CfgConverter;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Models;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001CE RID: 462
	public class ConfigConverterViewModel : ViewModelBase
	{
		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000E69 RID: 3689 RVA: 0x0004A572 File Offset: 0x00048772
		// (set) Token: 0x06000E6A RID: 3690 RVA: 0x0004A57A File Offset: 0x0004877A
		public ObservableCollection<string> ConfigsCollection
		{
			get
			{
				return this.configsCollection;
			}
			set
			{
				this.SetProperty<ObservableCollection<string>>(ref this.configsCollection, value, "ConfigsCollection");
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000E6B RID: 3691 RVA: 0x0004A58F File Offset: 0x0004878F
		// (set) Token: 0x06000E6C RID: 3692 RVA: 0x0004A597 File Offset: 0x00048797
		public ObservableCollection<ConvertedConfigs> ConvertedConfigsCollection
		{
			get
			{
				return this.convertedConfigsCollection;
			}
			set
			{
				this.SetProperty<ObservableCollection<ConvertedConfigs>>(ref this.convertedConfigsCollection, value, "ConvertedConfigsCollection");
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000E6D RID: 3693 RVA: 0x0004A5AC File Offset: 0x000487AC
		// (set) Token: 0x06000E6E RID: 3694 RVA: 0x0004A5B4 File Offset: 0x000487B4
		public bool AddConvertedConfigToListOfConfigs
		{
			get
			{
				return this.addConvertedConfigToListOfConfigs;
			}
			set
			{
				this.SetProperty<bool>(ref this.addConvertedConfigToListOfConfigs, value, "AddConvertedConfigToListOfConfigs");
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000E6F RID: 3695 RVA: 0x0004A5C9 File Offset: 0x000487C9
		// (set) Token: 0x06000E70 RID: 3696 RVA: 0x0004A5D1 File Offset: 0x000487D1
		public double Progress
		{
			get
			{
				return this.progress;
			}
			set
			{
				this.SetProperty<double>(ref this.progress, value, "Progress");
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000E71 RID: 3697 RVA: 0x0004A5E6 File Offset: 0x000487E6
		// (set) Token: 0x06000E72 RID: 3698 RVA: 0x0004A5EE File Offset: 0x000487EE
		public bool ControlsEnabled
		{
			get
			{
				return this.controlsEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this.controlsEnabled, value, "ControlsEnabled");
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000E73 RID: 3699 RVA: 0x0004A603 File Offset: 0x00048803
		public ICommand StopCommand
		{
			get
			{
				return new RelayCommand(new Action(this.Stop));
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x0004A616 File Offset: 0x00048816
		public ICommand StartCommand
		{
			get
			{
				return new RelayCommand<IList>(delegate(IList selectedConfigs)
				{
					this.Start(selectedConfigs.Cast<string>().ToArray<string>());
				});
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000E75 RID: 3701 RVA: 0x0004A629 File Offset: 0x00048829
		public ICommand SaveSelectedCommand
		{
			get
			{
				return new RelayCommand<int>(delegate(int i)
				{
					this.SaveSelected(i);
				});
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x0004A63C File Offset: 0x0004883C
		public ICommand SaveAllCommand
		{
			get
			{
				return new RelayCommand(new Action(this.SaveAll));
			}
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x0004A650 File Offset: 0x00048850
		private void Start(string[] selectedConfigs)
		{
			try
			{
				if (this.ConfigsCollection.Count > 0)
				{
					if (selectedConfigs.Length == 0)
					{
						Alert.Warning("Please select a config!", "Warning", false);
					}
					else
					{
						try
						{
							Task task = this.taskConvert;
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
							CancellationTokenSource cancellationTokenSource = this.cts;
							if (cancellationTokenSource != null)
							{
								cancellationTokenSource.Cancel();
							}
						}
						catch
						{
						}
						try
						{
							CancellationTokenSource cancellationTokenSource2 = this.cts;
							if (cancellationTokenSource2 != null)
							{
								cancellationTokenSource2.Dispose();
							}
						}
						catch
						{
						}
						this.cts = new CancellationTokenSource();
						this.ControlsEnabled = false;
						this.taskConvert = Task.Run(delegate()
						{
							this.StartConvert(selectedConfigs);
						}, this.ct = this.cts.Token).ContinueWith(delegate(Task t)
						{
							t.Dispose();
						});
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
				this.ControlsEnabled = true;
			}
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x0004A794 File Offset: 0x00048994
		private void Stop()
		{
			try
			{
				Task task = this.taskConvert;
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
				CancellationTokenSource cancellationTokenSource = this.cts;
				if (cancellationTokenSource != null)
				{
					cancellationTokenSource.Cancel();
				}
			}
			catch
			{
			}
			try
			{
				CancellationTokenSource cancellationTokenSource2 = this.cts;
				if (cancellationTokenSource2 != null)
				{
					cancellationTokenSource2.Dispose();
				}
			}
			catch
			{
			}
			this.ControlsEnabled = true;
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x0004A814 File Offset: 0x00048A14
		private void StartConvert(string[] selectedConfigs)
		{
			try
			{
				int i;
				int j;
				for (i = 0; i < selectedConfigs.Length; i = j + 1)
				{
					this.ct.ThrowIfCancellationRequested();
					ConfigConverter configConverter = new ConfigConverter(selectedConfigs[i]);
					configConverter.ProgressChanged += this.Converter_ProgressChanged;
					Config config = configConverter.Start();
					System.Windows.Application.Current.Dispatcher.Invoke(delegate()
					{
						this.ConvertedConfigsCollection.Add(new ConvertedConfigs(config, Path.GetFileNameWithoutExtension(selectedConfigs[i])));
					});
					if (this.AddConvertedConfigToListOfConfigs)
					{
						string text = Path.Combine(Constants.ConfigFolder, StringExtension.RemoveInvalidChars(Path.GetFileNameWithoutExtension(selectedConfigs[i])) + ".spk");
						if (File.Exists(text))
						{
							try
							{
								File.Delete(text);
							}
							catch
							{
							}
						}
						IOManager.SaveConfig(config, text);
					}
					j = i;
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
			finally
			{
				this.ControlsEnabled = true;
			}
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x0004A994 File Offset: 0x00048B94
		private void Converter_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.Progress = (double)e.ProgressPercentage;
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x0004A9A4 File Offset: 0x00048BA4
		private void SaveSelected(int index)
		{
			try
			{
				if (this.ConvertedConfigsCollection.Count != 0)
				{
					if (index <= -1)
					{
						Alert.Warning("Please select a converted config!", "Warning", false);
					}
					else
					{
						Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
						{
							Filter = "Config|*.spk",
							FileName = this.ConvertedConfigsCollection[index].FileName
						};
						bool? flag = saveFileDialog.ShowDialog();
						bool flag2 = true;
						if (flag.GetValueOrDefault() == flag2 & flag != null)
						{
							IOManager.SaveConfig(this.ConvertedConfigsCollection[index].Config, saveFileDialog.FileName);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x0004AA58 File Offset: 0x00048C58
		private void SaveAll()
		{
			try
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					for (int i = 0; i < this.ConvertedConfigsCollection.Count; i++)
					{
						ConvertedConfigs convertedConfigs = this.ConvertedConfigsCollection[i];
						IOManager.SaveConfig(convertedConfigs.Config, Path.Combine(folderBrowserDialog.SelectedPath, convertedConfigs.FileName + ".spk"));
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x040006E7 RID: 1767
		private Task taskConvert;

		// Token: 0x040006E8 RID: 1768
		private CancellationTokenSource cts;

		// Token: 0x040006E9 RID: 1769
		private CancellationToken ct;

		// Token: 0x040006EA RID: 1770
		public ObservableCollection<string> configsCollection = new ObservableCollection<string>();

		// Token: 0x040006EB RID: 1771
		private ObservableCollection<ConvertedConfigs> convertedConfigsCollection = new ObservableCollection<ConvertedConfigs>();

		// Token: 0x040006EC RID: 1772
		private bool addConvertedConfigToListOfConfigs;

		// Token: 0x040006ED RID: 1773
		private double progress;

		// Token: 0x040006EE RID: 1774
		private bool controlsEnabled = true;
	}
}
