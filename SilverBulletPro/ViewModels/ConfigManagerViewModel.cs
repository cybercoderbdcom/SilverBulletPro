using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PluginFrameworkPro;
using RestSharp;
using SilverBulletPro.CfgConverter;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Formats;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Models;
using SilverBulletPro.Repositories;
using SilverBulletPro.Views.Main.Configs;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B2 RID: 434
	public class ConfigManagerViewModel : ViewModelBase, IConfigManager
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x00044064 File Offset: 0x00042264
		// (set) Token: 0x06000C44 RID: 3140 RVA: 0x0004406C File Offset: 0x0004226C
		public ObservableCollection<ConfigViewModel> ConfigsCollection
		{
			get
			{
				return this.configsCollection;
			}
			private set
			{
				this.configsCollection = value;
				this.OnPropertyChanged("ConfigsCollection");
				this.OnPropertyChanged("Total");
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000C45 RID: 3141 RVA: 0x0004408B File Offset: 0x0004228B
		public ICommand ShowReadmeCommand
		{
			get
			{
				return new RelayCommand(delegate()
				{
					ConfigManager configManagerPage = GlobalData.MainWindow.ConfigsSecionPage.ConfigManagerPage;
					if (configManagerPage.borderConfigReadme.Visibility == Visibility.Collapsed)
					{
						configManagerPage.ShowReadme();
						return;
					}
					configManagerPage.CloseReadme();
				}, () => this.ConfigsCollection.Count > 0 && this.HoveredConfig != null && !string.IsNullOrWhiteSpace(this.HoveredConfig.Settings.AdditionalInfo));
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x000440BD File Offset: 0x000422BD
		public ICommand EncryptCfgCommand
		{
			get
			{
				return new RelayCommand(delegate()
				{
					try
					{
						string text = Alert.CustomInput("Password", "Custom Title", null);
						if (!string.IsNullOrEmpty(text))
						{
							string text2 = Path.Combine(Environment.CurrentDirectory, Constants.ConfigFolder, (this.HoveredConfigViewModel.Category == "Default") ? (this.HoveredConfigViewModel.FileName + ".spk") : (this.HoveredConfigViewModel.Category + "\\" + this.HoveredConfigViewModel.FileName + ".spk"));
							SaveFileDialog saveFileDialog = new SaveFileDialog
							{
								Filter = "Config Enc|*.espk",
								FileName = Path.GetFileNameWithoutExtension(text2)
							};
							bool? flag = saveFileDialog.ShowDialog();
							bool flag2 = false;
							if (!(flag.GetValueOrDefault() == flag2 & flag != null))
							{
								string path = text2;
								string password = text;
								string outputPath;
								if (!(Path.GetExtension(saveFileDialog.FileName).ToLower() == ".espk"))
								{
									SaveFileDialog saveFileDialog2 = saveFileDialog;
									outputPath = (saveFileDialog2.FileName += ".espk");
								}
								else
								{
									outputPath = saveFileDialog.FileName;
								}
								CryptConfig.Encrypt(path, password, outputPath);
							}
						}
					}
					catch (Exception ex)
					{
						GlobalData.Logger.Log(ex.Message, 2, true, 0);
					}
				}, () => this.HoveredConfig != null && this.HoveredConfigViewModel != null && !this.HoveredConfigViewModel.Remote);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000C47 RID: 3143 RVA: 0x000440DC File Offset: 0x000422DC
		public ICommand DownloadCommand
		{
			get
			{
				return new RelayCommand(delegate()
				{
					try
					{
						string fileName = string.Empty;
						try
						{
							fileName = Path.GetFileNameWithoutExtension(PathExtension.RemoveIllegalCharacters(this.HoveredConfigViewModel.Name));
						}
						catch
						{
						}
						SaveFileDialog saveFileDialog = new SaveFileDialog
						{
							Filter = "Config|*.spk",
							FileName = fileName
						};
						bool? flag = saveFileDialog.ShowDialog();
						bool flag2 = false;
						if (!(flag.GetValueOrDefault() == flag2 & flag != null) && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
						{
							IOManager.SaveConfig(this.HoveredConfig, saveFileDialog.FileName);
						}
					}
					catch
					{
					}
				}, () => this.HoveredConfig != null && this.HoveredConfigViewModel != null && this.HoveredConfigViewModel.Remote);
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x000440FB File Offset: 0x000422FB
		public IEnumerable<ConfigViewModel> Configs
		{
			get
			{
				return this.ConfigsCollection;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000C49 RID: 3145 RVA: 0x00044103 File Offset: 0x00042303
		public int Total
		{
			get
			{
				return this.ConfigsCollection.Count;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000C4A RID: 3146 RVA: 0x00044110 File Offset: 0x00042310
		// (set) Token: 0x06000C4B RID: 3147 RVA: 0x00044118 File Offset: 0x00042318
		public string SavedHash { get; set; } = "0";

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000C4C RID: 3148 RVA: 0x00044121 File Offset: 0x00042321
		// (set) Token: 0x06000C4D RID: 3149 RVA: 0x00044129 File Offset: 0x00042329
		public Config HoveredConfig
		{
			get
			{
				return this.hoveredConfig;
			}
			set
			{
				this.hoveredConfig = value;
				this.OnPropertyChanged("HoveredConfig");
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x0004413D File Offset: 0x0004233D
		// (set) Token: 0x06000C4F RID: 3151 RVA: 0x00044145 File Offset: 0x00042345
		public ConfigViewModel HoveredConfigViewModel
		{
			get
			{
				return this.hoveredConfigViewModel;
			}
			set
			{
				this.hoveredConfigViewModel = value;
				this.OnPropertyChanged("HoveredConfigViewModel");
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000C50 RID: 3152 RVA: 0x00044159 File Offset: 0x00042359
		// (set) Token: 0x06000C51 RID: 3153 RVA: 0x00044161 File Offset: 0x00042361
		public ConfigViewModel CurrentConfig
		{
			get
			{
				return this.currentConfig;
			}
			set
			{
				this.currentConfig = value;
				this.OnPropertyChanged("CurrentConfigName");
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000C52 RID: 3154 RVA: 0x00044175 File Offset: 0x00042375
		public string CurrentConfigName
		{
			get
			{
				if (this.CurrentConfig != null)
				{
					return this.CurrentConfig.Name;
				}
				return "None";
			}
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00044190 File Offset: 0x00042390
		public ConfigManagerViewModel(bool init = false)
		{
			this._diskRepo = new ConfigRepository(Constants.ConfigFolder);
			this.init = init;
			this.Rescan();
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x000441E0 File Offset: 0x000423E0
		public IEnumerable<string> GetRequiredPlugins(ConfigViewModel config)
		{
			return (from IBlockPlugin p in new SvbScript(config.Config.Script).ToBlocks().OnlyPlugins()
			select p.Name).Distinct<string>();
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000C55 RID: 3157 RVA: 0x00044235 File Offset: 0x00042435
		// (set) Token: 0x06000C56 RID: 3158 RVA: 0x0004423D File Offset: 0x0004243D
		public string SearchString
		{
			get
			{
				return this.searchString;
			}
			set
			{
				this.searchString = value;
				this.OnPropertyChanged("SearchString");
				CollectionViewSource.GetDefaultView(this.ConfigsCollection).Refresh();
				this.OnPropertyChanged("Total");
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000C57 RID: 3159 RVA: 0x0004426C File Offset: 0x0004246C
		// (set) Token: 0x06000C58 RID: 3160 RVA: 0x00044274 File Offset: 0x00042474
		public ConfigFilterType FilterType
		{
			get
			{
				return this.filterType;
			}
			set
			{
				this.filterType = value;
				this.OnPropertyChanged("FilterType");
			}
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00044288 File Offset: 0x00042488
		public void HookFilters()
		{
			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate()
			{
				((CollectionView)CollectionViewSource.GetDefaultView(this.ConfigsCollection)).Filter = new Predicate<object>(this.ConfigsFilter);
			}));
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x000442A8 File Offset: 0x000424A8
		private bool ConfigsFilter(object item)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = this.FilterType.ToString().Split(',', StringSplitOptions.None);
			if (array.Length > 1)
			{
				for (int i = 0; i < array.Length; i++)
				{
					string sourceByFilterType = this.GetSourceByFilterType(item, Enum.Parse<ConfigFilterType>(array[i]));
					if (i == array.Length - 1)
					{
						stringBuilder.Append(sourceByFilterType);
					}
					else
					{
						stringBuilder.AppendLine(sourceByFilterType);
					}
				}
			}
			else
			{
				stringBuilder.Append(this.GetSourceByFilterType(item, this.FilterType));
			}
			return CultureInfo.InvariantCulture.CompareInfo.IndexOf(stringBuilder.ToString(), this.searchString, CompareOptions.IgnoreCase) >= 0;
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x00044354 File Offset: 0x00042554
		private string GetSourceByFilterType(object item, ConfigFilterType type)
		{
			ConfigViewModel configViewModel = item as ConfigViewModel;
			string empty = string.Empty;
			if (type <= ConfigFilterType.PuppeteerPresent)
			{
				if (type <= ConfigFilterType.NeedsProxies)
				{
					switch (type)
					{
					case ConfigFilterType.Name:
						return configViewModel.Name;
					case ConfigFilterType.Author:
					{
						Config config = configViewModel.Config;
						string result;
						if (config == null)
						{
							result = null;
						}
						else
						{
							ConfigSettings settings = config.Settings;
							result = ((settings != null) ? settings.Author : null);
						}
						return result;
					}
					case ConfigFilterType.Name | ConfigFilterType.Author:
						break;
					case ConfigFilterType.Category:
						return configViewModel.Category;
					default:
						if (type == ConfigFilterType.NeedsProxies)
						{
							ConfigSettings settings2 = configViewModel.Config.Settings;
							return (settings2 != null) ? settings2.NeedsProxies.ToString() : null;
						}
						break;
					}
				}
				else
				{
					if (type == ConfigFilterType.CaptchasNeeded)
					{
						return configViewModel.Config.CaptchasNeeded.ToString();
					}
					if (type == ConfigFilterType.PuppeteerPresent)
					{
						return configViewModel.Config.PuppeteerPresent.ToString();
					}
				}
			}
			else if (type <= ConfigFilterType.OcrNeeded)
			{
				if (type == ConfigFilterType.SeleniumPresent)
				{
					return configViewModel.Config.SeleniumPresent.ToString();
				}
				if (type == ConfigFilterType.OcrNeeded)
				{
					return configViewModel.Config.OcrNeeded.ToString();
				}
			}
			else
			{
				if (type == ConfigFilterType.HasCFBypass)
				{
					return configViewModel.Config.HasCFBypass.ToString();
				}
				if (type == ConfigFilterType.LastModified)
				{
					return configViewModel.Config.LastModifiedString;
				}
			}
			return configViewModel.Name;
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x000444D0 File Offset: 0x000426D0
		public List<ConfigViewModel> GetConfigsFromDisk(bool sort = false, bool reverse = false)
		{
			List<ConfigViewModel> list = this._diskRepo.Get().ToList<ConfigViewModel>();
			if (sort)
			{
				list.Sort((ConfigViewModel m1, ConfigViewModel m2) => m1.Config.Settings.LastModified.GetValueOrDefault().CompareTo(m2.Config.Settings.LastModified.GetValueOrDefault()));
				if (reverse)
				{
					list.Reverse();
				}
			}
			return list;
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x00044520 File Offset: 0x00042720
		public IEnumerable<ConfigViewModel> GetConfigsFromSources()
		{
			List<ConfigViewModel> list = new List<ConfigViewModel>();
			foreach (Source source in GlobalData.SBSettings.Sources.Sources)
			{
				try
				{
					list.AddRange(this.PullSource(source));
				}
				catch (Exception ex)
				{
					GlobalData.Logger.LogError(Components.ConfigManager, "Error with API " + source.ApiUrl + "\r\nReason: " + ex.Message, true, 0);
				}
			}
			if (GlobalData.SBSettings.Sources.ShowRemoteCustomConfigs && !this.init)
			{
				list.AddRange(this.PullSourceFromGithub("https://api.github.com/repos/mohamm4dx/SilverBulletPro/contents/Configs?ref=main"));
			}
			this.init = false;
			return list;
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x000445F0 File Offset: 0x000427F0
		public IEnumerable<ConfigViewModel> PullSource(Source source)
		{
			RestRequest restRequest = new RestRequest(source.ApiUrl, 0);
			RestClient restClient = new RestClient();
			List<ConfigViewModel> list = new List<ConfigViewModel>();
			Source.AuthMode auth = source.Auth;
			if (auth != Source.AuthMode.ApiKey)
			{
				if (auth == Source.AuthMode.UserPass)
				{
					string str = Encode.ToBase64(source.Username + ":" + source.Password);
					RestRequestExtensions.AddHeader(restRequest, "Authorization", "Basic " + str);
				}
			}
			else
			{
				RestRequestExtensions.AddHeader(restRequest, "Authorization", source.ApiKey);
			}
			byte[] array = new byte[0];
			RestResponse restResponse = RestClientSyncExtensions.Get(restClient, restRequest);
			array = restResponse.RawBytes;
			string path = string.Empty;
			try
			{
				path = new ContentDisposition(restResponse.Headers.FirstOrDefault((HeaderParameter h) => h.Name == "Content-Disposition").Value.ToString()).FileName;
			}
			catch
			{
			}
			if (restResponse.Content != null)
			{
				HeaderParameter headerParameter = restResponse.Headers.FirstOrDefault((HeaderParameter h) => h.Name == "Result");
				string text;
				if (headerParameter == null)
				{
					text = null;
				}
				else
				{
					object value = headerParameter.Value;
					text = ((value != null) ? value.ToString() : null);
				}
				string text2;
				if ((text2 = text) != null && text2 != null && text2 == "Error")
				{
					throw new Exception("The server says: " + Encoding.ASCII.GetString(array));
				}
			}
			try
			{
				using (ZipArchive zipArchive = new ZipArchive(new MemoryStream(array), ZipArchiveMode.Read))
				{
					for (int i = 0; i < zipArchive.Entries.Count; i++)
					{
						try
						{
							ZipArchiveEntry zipArchiveEntry = zipArchive.Entries[i];
							string text3 = Path.GetDirectoryName(zipArchiveEntry.FullName).Replace("\\", " - ");
							string text4 = string.IsNullOrEmpty(text3) ? "Remote" : ("Remote - " + text3);
							using (Stream stream = zipArchiveEntry.Open())
							{
								ConfigConverter configConverter = new ConfigConverter(StreamExtension.ReadAllBytes(stream), Path.GetFileName(zipArchiveEntry.FullName));
								Config config;
								if (!configConverter.CanConvert)
								{
									config = IOManager.Unpack(stream, Path.GetFileNameWithoutExtension(path));
								}
								else
								{
									config = configConverter.Start();
								}
								list.Add(new ConfigViewModel(string.Empty, text4, config, true));
							}
						}
						catch
						{
						}
					}
				}
			}
			catch
			{
			}
			return list;
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x00044898 File Offset: 0x00042A98
		public IEnumerable<ConfigViewModel> PullSourceFromGithub(string url = "https://api.github.com/repos/mohamm4dx/SilverBulletPro/contents/Configs?ref=main")
		{
			RestRequest restRequest = new RestRequest(url, 0);
			RestRequestExtensions.AddHeader(restRequest, "User-Agent", Constants.UserAgent);
			RestClient restClient = new RestClient();
			RestResponse restResponse = RestClientSyncExtensions.Get(restClient, restRequest);
			List<ConfigViewModel> list = new List<ConfigViewModel>();
			if (!restResponse.IsSuccessful)
			{
				return list;
			}
			RemoteConfigFromGithub[] remoteConfigs = IOManager.DeserializeObject<RemoteConfigFromGithub[]>(restResponse.Content);
			if (remoteConfigs == null || remoteConfigs.Length == 0)
			{
				return list;
			}
			int i = 0;
			Func<string, bool> <>9__0;
			while (i < remoteConfigs.Length)
			{
				if (remoteConfigs[i].Extension.Equals(".spk", StringComparison.OrdinalIgnoreCase))
				{
					goto IL_BF;
				}
				IEnumerable<string> supportedExtensions = ConfigConverter.SupportedExtensions;
				Func<string, bool> predicate;
				if ((predicate = <>9__0) == null)
				{
					predicate = (<>9__0 = ((string e) => e.Equals(remoteConfigs[i].Extension, StringComparison.OrdinalIgnoreCase)));
				}
				if (supportedExtensions.Any(predicate))
				{
					goto IL_BF;
				}
				IL_231:
				int j = i;
				i = j + 1;
				continue;
				IL_BF:
				if (remoteConfigs[i].Type.Equals("file", StringComparison.OrdinalIgnoreCase) && remoteConfigs[i].Size != 0L)
				{
					restRequest.Resource = remoteConfigs[i].DownloadUrl;
					byte[] array = new byte[0];
					restResponse = RestClientSyncExtensions.Get(restClient, restRequest);
					array = restResponse.RawBytes;
					if (array.Length == 0)
					{
						HeaderParameter headerParameter = restResponse.Headers.FirstOrDefault((HeaderParameter h) => h.Name == "Result");
						string text;
						if (headerParameter == null)
						{
							text = null;
						}
						else
						{
							object value = headerParameter.Value;
							text = ((value != null) ? value.ToString() : null);
						}
						string text2;
						if ((text2 = text) != null && text2 != null && text2 == "Error")
						{
							throw new Exception("The server says: " + Encoding.ASCII.GetString(array));
						}
					}
					try
					{
						string text3 = "Remote";
						using (MemoryStream memoryStream = new MemoryStream(array))
						{
							ConfigConverter configConverter = new ConfigConverter(array, remoteConfigs[i].Name);
							Config config;
							if (!configConverter.CanConvert)
							{
								config = IOManager.Unpack(memoryStream, Path.GetFileNameWithoutExtension(remoteConfigs[i].Name));
							}
							else
							{
								config = configConverter.Start();
							}
							list.Add(new ConfigViewModel("", text3, config, true));
						}
					}
					catch
					{
					}
					goto IL_231;
				}
				goto IL_231;
			}
			return list;
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00044B1C File Offset: 0x00042D1C
		public void Add(ConfigViewModel config)
		{
			this._diskRepo.Add(config);
			this.ConfigsCollection.Add(config);
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x00044B36 File Offset: 0x00042D36
		public void Rescan()
		{
			this.ConfigsCollection = new ObservableCollection<ConfigViewModel>(this.GetConfigsFromDisk(true, true).Concat(this.GetConfigsFromSources()));
			this.HookFilters();
			this.OnPropertyChanged("Total");
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x00044B67 File Offset: 0x00042D67
		public void Update(ConfigViewModel config)
		{
			this._diskRepo.Update(config);
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x00044B75 File Offset: 0x00042D75
		public void SaveCurrent()
		{
			this.Update(this.CurrentConfig);
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x00044B83 File Offset: 0x00042D83
		public void Remove(ConfigViewModel config)
		{
			this._diskRepo.Remove(config);
			this.ConfigsCollection.Remove(config);
			this.OnPropertyChanged("Total");
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x00044BAC File Offset: 0x00042DAC
		public void Remove(IEnumerable<ConfigViewModel> configs)
		{
			ConfigViewModel[] array = configs.ToArray<ConfigViewModel>();
			foreach (ConfigViewModel item in array)
			{
				this.ConfigsCollection.Remove(item);
			}
			this._diskRepo.Remove(array);
			this.OnPropertyChanged("Total");
		}

		// Token: 0x04000636 RID: 1590
		private ConfigRepository _diskRepo;

		// Token: 0x04000637 RID: 1591
		private ObservableCollection<ConfigViewModel> configsCollection;

		// Token: 0x04000638 RID: 1592
		private bool init;

		// Token: 0x0400063A RID: 1594
		private Config hoveredConfig;

		// Token: 0x0400063B RID: 1595
		private ConfigViewModel hoveredConfigViewModel;

		// Token: 0x0400063C RID: 1596
		private ConfigViewModel currentConfig;

		// Token: 0x0400063D RID: 1597
		private string searchString = "";

		// Token: 0x0400063E RID: 1598
		private ConfigFilterType filterType = ConfigFilterType.Name;
	}
}
