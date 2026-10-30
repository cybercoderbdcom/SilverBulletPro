using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using HandyControl.Controls;
using java.util;
using LiteDB;
using PluginFrameworkPro;
using SilverBulletPro.Animations;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Plugins;
using SilverBulletPro.UserControls;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Main;
using SilverBulletPro.Views.Main.Runner;
using SilverBulletPro.Views.Main.Settings;
using SilverBulletPro.Views.StackerBlocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro
{
	// Token: 0x02000011 RID: 17
	public partial class MainWindow : GlowWindow
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002EAA File Offset: 0x000010AA
		public RunnerManager RunnerManagerPage
		{
			get
			{
				return this._runnerManager.Value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002EB7 File Offset: 0x000010B7
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00002EBF File Offset: 0x000010BF
		public Runner CurrentRunnerPage { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00002EC8 File Offset: 0x000010C8
		public ProxyManager ProxyManagerPage
		{
			get
			{
				return this._proxyManager.Value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002ED5 File Offset: 0x000010D5
		public WordlistManager WordlistManagerPage
		{
			get
			{
				return this._wordlistManager.Value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00002EE2 File Offset: 0x000010E2
		public ConfigsSection ConfigsSecionPage
		{
			get
			{
				return this._configsPage.Value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002EEF File Offset: 0x000010EF
		public HitsDB HitsDBPage
		{
			get
			{
				return this._hitsDB.Value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00002EFC File Offset: 0x000010FC
		public ToolsSection ToolsSectionPage
		{
			get
			{
				return this._toolsSection.Value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002F09 File Offset: 0x00001109
		public PluginsSection PluginsPage
		{
			get
			{
				return this._plugins.Value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002F16 File Offset: 0x00001116
		public SBSettings SBSettingsPage
		{
			get
			{
				return this._sbSettings.Value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00002F23 File Offset: 0x00001123
		public CoreSettings CoreSettingsPage
		{
			get
			{
				return this._coreSettings.Value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00002F30 File Offset: 0x00001130
		public SilverZone SilverZonePage
		{
			get
			{
				return this._silverZone.Value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00002F3D File Offset: 0x0000113D
		public About AboutPage
		{
			get
			{
				return this._about.Value;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002F4C File Offset: 0x0000114C
		public MainWindow()
		{
			GlobalData.MainWindow = this;
			File.WriteAllText(Constants.LogFile, "");
			this.InitializeComponent();
			MainWindowViewModel dataContext;
			if ((dataContext = GlobalData.MainView) == null)
			{
				dataContext = (GlobalData.MainView = new MainWindowViewModel());
			}
			base.DataContext = dataContext;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("SilverBullet ");
			defaultInterpolatedStringHandler.AppendFormatted(GlobalData.AppVersion);
			defaultInterpolatedStringHandler.AppendLiteral(" [");
			defaultInterpolatedStringHandler.AppendFormatted(GlobalData.Edition);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			base.Title = defaultInterpolatedStringHandler.ToStringAndClear();
			this.CreateDirectories();
			this.InitCsScript();
			this.InitEnvironmentSettings();
			this.CheckEnvAndCustomKeychains();
			this.InitSettings();
			this.CreateOrLoadSettings();
			this.BackupDB();
			base.Topmost = GlobalData.SBSettings.General.AlwaysOnTop;
			this.LoadPlugins();
			this.SetMappings();
			this.AddBlockPluginsToMappings();
			this.CreateInstanceOfViewModels();
			this.AutoCreateRunner();
			GlobalData.Logger.LogInfo(Components.Main, "Initialized RunnerManager", false, 0);
			GlobalData.Logger.LogInfo(Components.Main, "Initialized ProxyManager", false, 0);
			GlobalData.Logger.LogInfo(Components.Main, "Initialized WordlistManager", false, 0);
			GlobalData.Logger.LogInfo(Components.Main, "Initialized ConfigManager", false, 0);
			GlobalData.Logger.LogInfo(Components.Main, "Initialized HitsDB", false, 0);
			GlobalData.Logger.LogInfo(Components.Main, "Initialized Settings", false, 0);
			GlobalData.Logger.LogInfo(Components.Main, "Initialized Tools", false, 0);
			GlobalData.Logger.LogInfo(Components.Main, "Initialized Plugins", false, 0);
			GlobalData.Logger.LogInfo(Components.Main, "Initialized About", false, 0);
			int startingWidth = GlobalData.SBSettings.General.StartingWidth;
			int startingHeight = GlobalData.SBSettings.General.StartingHeight;
			try
			{
				if (startingWidth > 10)
				{
					base.MinWidth = (double)startingWidth;
				}
				if (startingHeight > 10)
				{
					base.MinHeight = (double)startingHeight;
				}
			}
			catch
			{
			}
			this.IsEnabledSnow(true);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003200 File Offset: 0x00001400
		private void CreateDirectories()
		{
			foreach (string path in from f in new string[]
			{
				Constants.CaptchasFolder,
				Constants.ConfigFolder,
				Directory.GetParent(Constants.DataBaseFile).Name,
				Constants.HitsFolder,
				Constants.PluginsFolder,
				Constants.ScreenshotsFolder,
				Directory.GetParent(Constants.SBSettingsFile).Name,
				Constants.SoundsFolder,
				Constants.WordlistsFolder,
				Constants.NodeModulesFolder,
				Constants.ChromeExtensionsFolder,
				Constants.NativeLibsFolder,
				Constants.CompiledFolder
			}
			select Path.Combine(Directory.GetCurrentDirectory(), f))
			{
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000032FC File Offset: 0x000014FC
		private void InitCsScript()
		{
			try
			{
				string path = Path.Combine(Constants.CompiledFolder, Constants.CsScriptFile);
				if (!File.Exists(path))
				{
					return;
				}
				string text = File.ReadAllText(path);
				if (string.IsNullOrWhiteSpace(text))
				{
					return;
				}
				ScriptCompiler.CsScript = text;
			}
			catch
			{
			}
			try
			{
				new StringJoiner(",");
			}
			catch
			{
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003374 File Offset: 0x00001574
		private void InitEnvironmentSettings()
		{
			try
			{
				GlobalData.Settings.Environment = IOManager.ParseEnvironmentSettings(Constants.EnvFile);
			}
			catch
			{
				GlobalData.Logger.LogError(Components.Main, "Could not find / parse the Environment Settings file. Please fix the issue and try again.", true, 0);
				Environment.Exit(0);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000033C4 File Offset: 0x000015C4
		private void CheckEnvAndCustomKeychains()
		{
			if (GlobalData.Settings.Environment.WordlistTypes.Count == 0 || GlobalData.Settings.Environment.CustomKeychains.Count == 0)
			{
				GlobalData.Logger.LogError(Components.Main, "At least one WordlistType and one CustomKeychain must be defined in the Environment Settings file.", true, 0);
				Environment.Exit(0);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003415 File Offset: 0x00001615
		private void InitSettings()
		{
			GlobalData.Settings.CoreSettings = new CoreSettingsViewModel();
			GlobalData.Settings.ProxyManagerSettings = new ProxyManagerSettings();
			GlobalData.SBSettings = new SBSettingsViewModel();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003440 File Offset: 0x00001640
		private void CreateOrLoadSettings()
		{
			if (!File.Exists(Constants.CoreSettingsFile))
			{
				Alert.Warning("Core Settings file not found, generating a default one", "Warning", false);
				GlobalData.Logger.LogWarning(Components.Main, "Core Settings file not found, generating a default one", false, 0);
				IOManager.SaveSettings<CoreSettingsViewModel>(Constants.CoreSettingsFile, GlobalData.Settings.CoreSettings);
				GlobalData.Logger.LogInfo(Components.Main, "Created the default Core Settings file " + Constants.CoreSettingsFile, false, 0);
			}
			else
			{
				GlobalData.Settings.CoreSettings = IOManager.LoadSettings<CoreSettingsViewModel>(Constants.CoreSettingsFile);
				GlobalData.Logger.LogInfo(Components.Main, "Loaded the existing Core Settings file", false, 0);
			}
			if (!File.Exists(Constants.ProxyManagerSettingsFile))
			{
				GlobalData.Logger.LogWarning(Components.Main, "Proxy manager Settings file not found, generating a default one", false, 0);
				GlobalData.Settings.ProxyManagerSettings.ProxySiteUrls.Add(Constants.DefaultProxySiteUrl);
				GlobalData.Settings.ProxyManagerSettings.ActiveProxySiteUrl = Constants.DefaultProxySiteUrl;
				GlobalData.Settings.ProxyManagerSettings.ProxyKeys.Add(Constants.DefaultProxyKey);
				GlobalData.Settings.ProxyManagerSettings.ActiveProxyKey = Constants.DefaultProxyKey;
				IOManager.SaveSettings<ProxyManagerSettings>(Constants.ProxyManagerSettingsFile, GlobalData.Settings.ProxyManagerSettings);
				GlobalData.Logger.LogInfo(Components.Main, "Created the default proxy manager Settings file " + Constants.ProxyManagerSettingsFile, false, 0);
			}
			else
			{
				GlobalData.Settings.ProxyManagerSettings = IOManager.LoadSettings<ProxyManagerSettings>(Constants.ProxyManagerSettingsFile);
				GlobalData.Logger.LogInfo(Components.Main, "Loaded the existing proxy manager Settings file", false, 0);
			}
			if (!File.Exists(Constants.SBSettingsFile))
			{
				Alert.Error("SilverBulletPro Settings file not found, generating a default one", "Error", false);
				GlobalData.Logger.LogWarning(Components.Main, "SilverBulletPro Settings file not found, generating a default one", false, 0);
				AppIOManager.SaveSettings(Constants.SBSettingsFile, GlobalData.SBSettings);
				GlobalData.Logger.LogInfo(Components.Main, "Created the default SilverBulletPro Settings file " + Constants.SBSettingsFile, false, 0);
				return;
			}
			GlobalData.SBSettings = AppIOManager.LoadSettings(Constants.SBSettingsFile);
			GlobalData.Logger.LogInfo(Components.Main, "Loaded the existing SilverBulletPro Settings file", false, 0);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003624 File Offset: 0x00001824
		private void BackupDB()
		{
			try
			{
				if (GlobalData.SBSettings.General.BackupDB && (!File.Exists(Constants.DataBaseBackupFile) || (File.Exists(Constants.DataBaseBackupFile) && (DateTime.Now - File.GetCreationTime(Constants.DataBaseBackupFile)).TotalDays > 1.0)))
				{
					using (LiteDatabase liteDatabase = new LiteDatabase("filename=" + Constants.DataBaseFile + "; Connection=Shared;", null))
					{
						liteDatabase.GetCollection<CProxy>("proxies", 10);
						File.Delete(Constants.DataBaseBackupFile);
						File.Copy(Constants.DataBaseFile, Constants.DataBaseBackupFile);
						GlobalData.Logger.LogInfo(Components.Main, "Backed up the DB", false, 0);
					}
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.Main, "Could not backup the DB: " + ex.Message, false, 0);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003728 File Offset: 0x00001928
		private void LoadPlugins()
		{
			ValueTuple<IEnumerable<PluginControl>, IEnumerable<IBlockPlugin>> valueTuple = Loader.LoadPlugins(Constants.PluginsFolder);
			IEnumerable<PluginControl> item = valueTuple.Item1;
			GlobalData.BlockPlugins = valueTuple.Item2.ToList<IBlockPlugin>();
			MainWindow.Plugins = item;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000375C File Offset: 0x0000195C
		private void SetMappings()
		{
			GlobalData.BlockMappings = new List<SilverBlock>
			{
				new SilverBlock(typeof(BlockRequest), typeof(PageBlockRequest), System.Drawing.Color.LimeGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockKeycheck), typeof(PageBlockKeycheck), System.Drawing.Color.DodgerBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockParse), typeof(PageBlockParse), System.Drawing.Color.Gold, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockLambdaParser), typeof(PageBlockLambdaParser), CustomColors.Salomie, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockScriptCode), typeof(PageBlockScript), System.Drawing.Color.White, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockShellCommand), typeof(PageBlockShellCommand), CustomColors.PaleChestnut, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockNativeLibInvoke), typeof(PageBlockNativeLibInvoke), CustomColors.PaleChestnut, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveTextCaptcha), typeof(PageBlockSolveTextCaptcha), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveImageCaptcha), typeof(PageBlockSolveImageCaptcha), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveFunCaptcha), typeof(PageBlockSolveFunCaptcha), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveRecaptchaV2), typeof(PageBlockSolveRecaptchaV2), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveRecaptchaV3), typeof(PageBlockSolveRecaptchaV3), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveHCaptcha), typeof(PageBlockSolveHCaptcha), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveKeyCaptcha), typeof(PageBlockSolveKeyCaptcha), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveGeeTestCaptcha), typeof(PageBlockSolveGeeTestCaptcha), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSolveCapyCaptcha), typeof(PageBlockSolveCapyCaptcha), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockReportLastSolution), typeof(PageBlockReportLastSolution), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCFBypass), typeof(PageBlockCFBypass), CustomColors.BeautyBush, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDestroyCFBypass), typeof(PageBlockDestroyCFBypass), CustomColors.BeautyBush, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockOcr), typeof(PageBlockOcr), CustomColors.ElectricBlue, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBase64ToBytes), typeof(PageBlockUtilityBase64ToBytes), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBytesToBase64), typeof(PageBlockUtilityBytesToBase64), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBase64ToString), typeof(PageBlockUtilityBase64ToString), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBigIntegerToBytes), typeof(PageBlockUtilityBigIntegerToBytes), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBytesToBigInteger), typeof(PageBlockUtilityBytesToBigInteger), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBinaryStringToBytes), typeof(PageBlockUtilityBinaryStringToBytes), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBytesToBinaryString), typeof(PageBlockUtilityBytesToBinaryString), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockHexToBytes), typeof(PageBlockUtilityHexToBytes), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBytesToHex), typeof(PageBlockUtilityBytesToHex), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockReadableSize), typeof(PageBlockUtilityReadableSize), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockIntegerToBytes), typeof(PageBlockUtilityIntegerToBytes), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockNumberToWords), typeof(PageBlockUtilityNumberToWords), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockWordsToNumber), typeof(PageBlockUtilityWordsToNumber), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockStringToBytes), typeof(PageBlockUtilityStringToBytes), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBytesToString), typeof(PageBlockUtilityBytesToString), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCreateDirPath), typeof(PageBlockUtilityCreatePath), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileAppend), typeof(PageBlockUtilityFileAppend), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileAppendLines), typeof(PageBlockUtilityFileAppendLines), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileExists), typeof(PageBlockUtilityFileExists), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileCopy), typeof(PageBlockUtilityFileCopy), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileDelete), typeof(PageBlockUtilityFileDelete), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileMove), typeof(PageBlockUtilityFileMove), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileRead), typeof(PageBlockUtilityFileRead), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileReadBytes), typeof(PageBlockUtilityFileReadBytes), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileReadLines), typeof(PageBlockUtilityFileReadLines), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileWrite), typeof(PageBlockUtilityFileWrite), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileWriteBytes), typeof(PageBlockUtilityFileWriteBytes), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFileWriteLines), typeof(PageBlockUtilityFileWriteLines), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFolderDelete), typeof(PageBlockUtilityFolderDelete), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFolderExists), typeof(PageBlockUtilityFolderExists), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockGetFilesInFolder), typeof(PageBlockUtilityGetFilesInFolder), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSvgToPng), typeof(PageBlockUtilitySvgToPng), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockClearCookies), typeof(PageBlockUtilityClearCookies), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDelay), typeof(PageBlockUtilityDelay), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockGetHwid), typeof(PageBlockUtilityGetHwid), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTlgSendMessage), typeof(PageBlockUtilityTlgSendMessage), System.Drawing.Color.Wheat, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockMergeByteArrays), typeof(PageBlockFuncMergeByteArrays), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockConstantString), typeof(PageBlockFuncConstantString), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockConstantDictionary), typeof(PageBlockFuncConstantDictionary), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockConstantList), typeof(PageBlockFuncConstantList), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockConstantByteArray), typeof(PageBlockFuncConstantByteArray), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockAesEncrypt), typeof(PageBlockFuncAesEncrypt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockAesDecrypt), typeof(PageBlockFuncAesDecrypt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockHash), typeof(PageBlockFuncHash), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockHmac), typeof(PageBlockFuncHmac), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockJwtEncode), typeof(PageBlockFuncJwtEncode), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockJwtDecode), typeof(PageBlockFuncJwtDecode), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockPbkdf2Pkcs5), typeof(PageBlockFuncPbkdf2Pkcs5), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRsaEncrypt), typeof(PageBlockFuncRsaEncrypt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRsaDecrypt), typeof(PageBlockFuncRsaDecrypt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRsaPkcs1Pad2), typeof(PageBlockFuncRsaPkcs1Pad2), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRsaDigitalSign), typeof(PageBlockFuncRsaDigitalSign), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockScrypt), typeof(PageBlockFuncScrypt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockBcrypt), typeof(PageBlockFuncBcrypt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockXor), typeof(PageBlockFuncXor), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockAws4Signature), typeof(PageBlockFuncAws4Signature), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCryptoJsEncrypt), typeof(PageBlockFuncCryptoJsEncrypt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCryptoJsDecrypt), typeof(PageBlockFuncCryptoJsDecrypt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockAddKeyValuePair), typeof(PageBlockFuncAddKeyValuePair), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDictGetKey), typeof(PageBlockFuncDictGetKey), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDictGetValue), typeof(PageBlockFuncDictGetValue), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDictRemove), typeof(PageBlockFuncDictRemove), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDictionaryToList), typeof(PageBlockFuncDictionaryToList), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDictionaryToString), typeof(PageBlockFuncDictionaryToString), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockComputeEx), typeof(PageBlockFuncComputeEx), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCeiling), typeof(PageBlockFuncCeiling), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockAbsolute), typeof(PageBlockFuncAbs), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFloor), typeof(PageBlockFuncFloor), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTakeMaxFloat), typeof(PageBlockFuncTakeMaxFloat), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTakeMinFloat), typeof(PageBlockFuncTakeMinFloat), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRandomFloat), typeof(PageBlockFuncRandFloat), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRoundFloat), typeof(PageBlockFuncRoundFloat), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRoundToInteger), typeof(PageBlockFuncRoundToInteger), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTakeMinInt), typeof(PageBlockFuncTakeMinInt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTakeMaxInt), typeof(PageBlockFuncTakeMaxInt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRandomInt), typeof(PageBlockFuncRandInt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockAddToList), typeof(PageBlockFuncAddToList), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockConcatLists), typeof(PageBlockFuncConcatLists), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCreateListOfNumbers), typeof(PageBlockCreateListOfNumbers), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockGetListLength), typeof(PageBlockFuncGetListLength), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockGetRandomItem), typeof(PageBlockFuncGetRandomItem), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockListIndexOf), typeof(PageBlockFuncListIndexOf), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockJoinList), typeof(PageBlockFuncJoinList), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockMapLists), typeof(PageBlockFuncMapLists), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRemoveAllFromList), typeof(PageBlockFuncRemoveAllFromList), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRemoveDuplicates), typeof(PageBlockFuncRemoveDuplicates), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRemoveFromList), typeof(PageBlockFuncRemoveFromList), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockShuffle), typeof(PageBlockFuncShuffle), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSortList), typeof(PageBlockFuncSortList), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockListToDictionary), typeof(PageBlockFuncListToDictionary), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockZipLists), typeof(PageBlockFuncZipLists), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCountOccurrences), typeof(PageBlockFuncCountOccurrences), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockEncodeHtmlEntities), typeof(PageBlockFuncEncodeHtmlEntities), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDecodeHtmlEntities), typeof(PageBlockFuncDecodeHtmlEntities), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockStrLength), typeof(PageBlockFuncLength), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRandomString), typeof(PageBlockFuncRandomString), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRegexReplace), typeof(PageBlockFuncRegexReplace), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRegexMatch), typeof(PageBlockFuncRegexMatch), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockReplaceString), typeof(PageBlockFuncReplace), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockReverseString), typeof(PageBlockFuncReverse), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSplit), typeof(PageBlockFuncSplit), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSubstring), typeof(PageBlockFuncSubstring), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCharAt), typeof(PageBlockFuncCharAt), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRemoveStr), typeof(PageBlockFuncRemoveString), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockToLowerCase), typeof(PageBlockFuncToLowercase), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockToUpperCase), typeof(PageBlockFuncToUppercase), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockToTitleCase), typeof(PageBlockFuncToTitlecase), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTranslate), typeof(PageBlockFuncTranslate), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTrim), typeof(PageBlockFuncTrim), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockUnescape), typeof(PageBlockFuncUnescape), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockUrlEncode), typeof(PageBlockFuncUrlEncode), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockUrlDecode), typeof(PageBlockFuncUrlDecode), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCurrentUnixTime), typeof(PageBlockFuncCurrentUnixTime), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDateToUnixTime), typeof(PageBlockFuncDateToUnixTime), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockDateToSolar), typeof(PageBlockFuncDateToSolar), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockUnixTimeToDate), typeof(PageBlockFuncUnixTimeToDate), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockUnixTimeToISO8601), typeof(PageBlockFuncUnixTimeToISO8601), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCurrentDateTime), typeof(PageBlockFuncCurrentDateTime), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCalcDateTimeDifference), typeof(PageBlockFuncCalcDateTimeDifference), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockCalcRelativeTime), typeof(PageBlockFuncCalcRelativeTime), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockGenerateGuid), typeof(PageBlockFuncGenerateGuid), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockRandomUserAgent), typeof(PageBlockFuncRandomUserAgent), System.Drawing.Color.YellowGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpConnect), typeof(PageBlockReqsFtpConnect), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpLogin), typeof(PageBlockReqsFtpLogin), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpDisconnect), typeof(PageBlockReqsFtpDisconnect), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpDownloadFile), typeof(PageBlockReqsFtpDownloadFile), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpUploadFile), typeof(PageBlockReqsFtpUploadFile), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpUpload), typeof(PageBlockReqsFtpUpload), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpDownload), typeof(PageBlockReqsFtpDownload), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpListItems), typeof(PageBlockReqsFtpListItems), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpGetFileLength), typeof(PageBlockReqsFtpGetFileSize), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpFileExists), typeof(PageBlockReqsFtpFileExists), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpDeleteFile), typeof(PageBlockReqsFtpDeleteFile), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpDelete), typeof(PageBlockReqsFtpDelete), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpChangeDirectory), typeof(PageBlockReqsFtpChangeDirectory), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpGetCurrentDirectory), typeof(PageBlockReqsFtpGetCurrentDir), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpGetFileDateTime), typeof(PageBlockReqsFtpGetFileDateTime), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpGetConnectionState), typeof(PageBlockReqsFtpGetConnectionState), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpSendCommand), typeof(PageBlockReqsFtpSendCommand), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockFtpReadResponse), typeof(PageBlockReqsFtpReadResponse), CustomColors.Corn, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapConnect), typeof(PageBlockReqsImapConnect), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapLogin), typeof(PageBlockReqsImapLogin), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapDisconnect), typeof(PageBlockReqsImapDisconnect), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapReadMail), typeof(PageBlockReqsImapReadMail), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapReadMailRaw), typeof(PageBlockReqsImapReadMailRaw), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapSearchMails), typeof(PageBlockReqsImapSearchMails), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapSelectFolder), typeof(PageBlockReqsImapSelectFolder), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapDeleteMail), typeof(PageBlockReqsImapDeleteMail), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockImapGetSupportedAuthMethods), typeof(PageBlockReqsImapGetSupportedAuthMethods), CustomColors.Orchid, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSmtpConnect), typeof(PageBlockReqsSmtpConnect), CustomColors.LightBrown, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSmtpLogin), typeof(PageBlockReqsSmtpLogin), CustomColors.LightBrown, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSmtpDisconnect), typeof(PageBlockReqsSmtpDisconnect), CustomColors.LightBrown, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSmtpSendMail), typeof(PageBlockReqsSmtpSendMail), CustomColors.LightBrown, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSmtpGetSupportedAuthMethods), typeof(PageBlockReqsSmtpGetSupportedAuthMethods), CustomColors.LightBrown, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockPop3Connect), typeof(PageBlockReqsPop3Connect), CustomColors.Mantis, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockPop3Login), typeof(PageBlockReqsPop3Login), CustomColors.Mantis, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockPop3Disconnect), typeof(PageBlockReqsPop3Disconnect), CustomColors.Mantis, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockPop3GetMails), typeof(PageBlockReqsPop3GetMails), CustomColors.Mantis, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockPop3ReadMail), typeof(PageBlockReqsPop3ReadMail), CustomColors.Mantis, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockPop3GetSupportedAuthMethods), typeof(PageBlockReqsPop3GetSupportedAuthMethods), CustomColors.Mantis, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockSshAuthenticateWithNone), typeof(PageBlockReqsSshAuthNone), CustomColors.MayaBlue, default(System.Drawing.Color), null)
				{
					Suffix = " (SSH)"
				},
				new SilverBlock(typeof(BlockSshAuthenticateWithPassword), typeof(PageBlockReqsSshAuthPassword), CustomColors.MayaBlue, default(System.Drawing.Color), null)
				{
					Suffix = " (SSH)"
				},
				new SilverBlock(typeof(BlockSshAuthenticateWithPK), typeof(PageBlockReqsSshAuthPk), CustomColors.MayaBlue, default(System.Drawing.Color), null)
				{
					Suffix = " (SSH)"
				},
				new SilverBlock(typeof(BlockSshDisconnect), typeof(PageBlockReqsSshDisconnect), CustomColors.MayaBlue, default(System.Drawing.Color), null)
				{
					Suffix = " (SSH)"
				},
				new SilverBlock(typeof(BlockSshRunCommand), typeof(PageBlockReqsSshRunCommand), CustomColors.MayaBlue, default(System.Drawing.Color), null)
				{
					Suffix = " (SSH)"
				},
				new SilverBlock(typeof(BlockTcpConnect), typeof(PageBlockReqsTcpConnect), System.Drawing.Color.MediumPurple, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTcpDisconnect), typeof(PageBlockReqsTcpDisconnect), System.Drawing.Color.MediumPurple, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTcpRead), typeof(PageBlockReqsTcpRead), System.Drawing.Color.MediumPurple, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTcpSend), typeof(PageBlockReqsTcpSend), System.Drawing.Color.MediumPurple, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTcpSendRead), typeof(PageBlockReqsTcpSendRead), System.Drawing.Color.MediumPurple, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockTcpSendReadHttp), typeof(PageBlockReqsTcpSendReadHttp), System.Drawing.Color.MediumPurple, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockWebSocketConnect), typeof(PageBlockReqsWebSocketConnect), CustomColors.MossGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockWebSocketDisconnect), typeof(PageBlockReqsWebSocketDisconnect), CustomColors.MossGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockWebSocketRead), typeof(PageBlockReqsWebSocketRead), CustomColors.MossGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockWebSocketSend), typeof(PageBlockReqsWebSocketSend), CustomColors.MossGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockWebSocketSendAudio), typeof(PageBlockReqsWebSocketSendAudio), CustomColors.MossGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockWebSocketClose), typeof(PageBlockReqsWebSocketClose), CustomColors.MossGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockWebSocketState), typeof(PageBlockReqsWebSocketState), CustomColors.MossGreen, default(System.Drawing.Color), null),
				new SilverBlock(typeof(BlockPuppeteerOpenBrowser), typeof(PageBlockPuppeteerOpenBrowser), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerNewTab), typeof(PageBlockPuppeteerNewTab), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGoBack), typeof(PageBlockPuppeteerGoBack), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGoForward), typeof(PageBlockPuppeteerGoForward), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerReload), typeof(PageBlockPuppeteerReload), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSwitchToTab), typeof(PageBlockPuppeteerSwitchToTab), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerCloseTab), typeof(PageBlockPuppeteerCloseTab), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerCloseBrowser), typeof(PageBlockPuppeteerCloseBrowser), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerClick), typeof(PageBlockPuppeteerClick), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerExists), typeof(PageBlockPuppeteerExists), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGetAttributeValue), typeof(PageBlockPuppeteerGetAttributeValue), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGetAttributeValueAll), typeof(PageBlockPuppeteerGetAttributeValueAll), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGetHeight), typeof(PageBlockPuppeteerGetHeight), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGetWidth), typeof(PageBlockPuppeteerGetWidth), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGetPositionX), typeof(PageBlockPuppeteerGetPositionX), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGetPositionY), typeof(PageBlockPuppeteerGetPositionY), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerIsDisplayed), typeof(PageBlockPuppeteerIsDisplayed), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerScreenshotElement), typeof(PageBlockPuppeteerScreenshotElem), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerScreenshotElementBase64), typeof(PageBlockPuppeteerScreenshotElemBase64), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSelect), typeof(PageBlockPuppeteerSelect), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSelectByIndex), typeof(PageBlockPuppeteerSelectByIndex), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSelectByText), typeof(PageBlockPuppeteerSelectByText), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSetAttributeValue), typeof(PageBlockPuppeteerSetAttributeValue), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSubmit), typeof(PageBlockPuppeteerSubmit), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSwitchToFrame), typeof(PageBlockPuppeteerSwitchToFrame), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerTypeElement), typeof(PageBlockPuppeteerTypeElem), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerTypeElementHuman), typeof(PageBlockPuppeteerTypeElemHuman), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerUploadFiles), typeof(PageBlockPuppeteerUploadFiles), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerWaitForElement), typeof(PageBlockPuppeteerWaitForElem), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerNavigateTo), typeof(PageBlockPuppeteerNavigateTo), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerWaitForNavigation), typeof(PageBlockPuppeteerWaitForNavigation), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerWaitForResponse), typeof(PageBlockPuppeteerWaitForResponse), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGetCookies), typeof(PageBlockPuppeteerGetCookies), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerClearCookies), typeof(PageBlockPuppeteerClearCookies), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSetCookies), typeof(PageBlockPuppeteerSetCookies), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSetUserAgent), typeof(PageBlockPuppeteerSetUserAgent), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSetCaptchaSolution), typeof(PageBlockPuppeteerSetCaptchaSolution), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerGetDOM), typeof(PageBlockPuppeteerGetDOM), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSetViewport), typeof(PageBlockPuppeteerSetViewport), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerSwitchToMainFrame), typeof(PageBlockPuppeteerSwitchToMainFrame), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerPageKeyPress), typeof(PageBlockPuppeteerPageKeyPress), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerPageKeyDown), typeof(PageBlockPuppeteerPageKeyDown), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerPageKeyUp), typeof(PageBlockPuppeteerPageKeyUp), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerScreenshotPage), typeof(PageBlockPuppeteerScreenshotPage), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerScreenshotPageBase64), typeof(PageBlockPuppeteerScreenshotPageBase64), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerScrollBy), typeof(PageBlockPuppeteerScrollBy), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerScrollToTop), typeof(PageBlockPuppeteerScrollToTop), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerScrollToBottom), typeof(PageBlockPuppeteerScrollToBottom), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerPageType), typeof(PageBlockPuppeteerPageType), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerExecuteFunc), typeof(PageBlockPuppeteerExecuteFunc), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockPuppeteerExecuteJs), typeof(PageBlockPuppeteerExecuteJs), CustomColors.DarkSalmon, default(System.Drawing.Color), null)
				{
					Suffix = " (Puppeteer)"
				},
				new SilverBlock(typeof(BlockSeleniumOpenBrowser), typeof(PageBlockSeleniumOpenBrowser), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumNewTab), typeof(PageBlockSeleniumNewTab), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumFullScreen), typeof(PageBlockSeleniumFullScreen), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumMinimize), typeof(PageBlockSeleniumMinimize), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumMaximize), typeof(PageBlockSeleniumMaximize), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGoBack), typeof(PageBlockSeleniumGoBack), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGoForward), typeof(PageBlockSeleniumGoForward), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumReload), typeof(PageBlockSeleniumReload), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSetBrowserSize), typeof(PageBlockSeleniumSetBrowserSize), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSwitchToTab), typeof(PageBlockSeleniumSwitchToTab), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumCloseTab), typeof(PageBlockSeleniumCloseTab), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumCloseBrowser), typeof(PageBlockSeleniumCloseBrowser), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumClick), typeof(PageBlockSeleniumClick), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumExists), typeof(PageBlockSeleniumExists), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetAttributeValue), typeof(PageBlockSeleniumGetAttributeValue), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetAttributeValueAll), typeof(PageBlockSeleniumGetAttributeValueAll), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSetAttributeValue), typeof(PageBlockSeleniumSetAttributeValue), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetHeight), typeof(PageBlockSeleniumGetHeight), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetWidth), typeof(PageBlockSeleniumGetWidth), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetPositionX), typeof(PageBlockSeleniumGetPositionX), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetPositionY), typeof(PageBlockSeleniumGetPositionY), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetText), typeof(PageBlockSeleniumGetText), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumIsDisplayed), typeof(PageBlockSeleniumIsDisplayed), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumIsEnabled), typeof(PageBlockSeleniumIsEnabled), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumIsSelected), typeof(PageBlockSeleniumIsSelected), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumLocationX), typeof(PageBlockSeleniumLocationX), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumLocationY), typeof(PageBlockSeleniumLocationY), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumScreenshotElement), typeof(PageBlockSeleniumScreenshotElem), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumScreenshotBase64), typeof(PageBlockSeleniumScreenshotElemBase64), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSelect), typeof(PageBlockSeleniumSelect), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSelectByIndex), typeof(PageBlockSeleniumSelectByIndex), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSelectByText), typeof(PageBlockSeleniumSelectByText), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumClearField), typeof(PageBlockSeleniumClearField), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumTypeElement), typeof(PageBlockSeleniumTypeElement), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumTypeElementHuman), typeof(PageBlockSeleniumTypeElemHuman), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSubmit), typeof(PageBlockSeleniumSubmit), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSwitchToFrame), typeof(PageBlockSeleniumSwitchToFrame), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumWaitForElement), typeof(PageBlockSeleniumWaitForElement), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumNavigateTo), typeof(PageBlockSeleniumNavigateTo), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetCookies), typeof(PageBlockSeleniumGetCookies), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumClearCookies), typeof(PageBlockSeleniumClearCookies), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSetCookies), typeof(PageBlockSeleniumSetCookies), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumGetDOM), typeof(PageBlockSeleniumGetDOM), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSwitchToMainFrame), typeof(PageBlockSeleniumSwitchToMainFrame), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSwitchToParentFrame), typeof(PageBlockSeleniumSwitchToParentFrame), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumSwitchToAlert), typeof(PageBlockSeleniumSwitchToAlert), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumPageKeyPress), typeof(PageBlockSeleniumPageKeyPress), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumPageKeyDown), typeof(PageBlockSeleniumPageKeyDown), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumPageKeyUp), typeof(PageBlockSeleniumPageKeyUp), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumScreenshotPage), typeof(PageBlockSeleniumScreenshotPage), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumScreenshotPageBase64), typeof(PageBlockSeleniumScreenshotPageBase64), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumPageType), typeof(PageBlockSeleniumPageType), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumScrollBy), typeof(PageBlockSeleniumScrollBy), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				},
				new SilverBlock(typeof(BlockSeleniumExecuteJs), typeof(PageBlockSeleniumExecuteJs), CustomColors.Fern, default(System.Drawing.Color), null)
				{
					Suffix = " (Selenium)"
				}
			};
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000072A0 File Offset: 0x000054A0
		private void AddBlockPluginsToMappings()
		{
			foreach (IBlockPlugin blockPlugin in GlobalData.BlockPlugins)
			{
				try
				{
					GlobalData.BlockMappings.Add(new SilverBlock(blockPlugin.GetType(), typeof(BlockPluginPage), blockPlugin.Background, blockPlugin.Foreground, null));
					BlockParser.BlockMappings.Add(blockPlugin.Name, blockPlugin.GetType());
					GlobalData.Logger.LogInfo(Components.Main, "Initialized " + blockPlugin.Name + " block plugin", false, 0);
				}
				catch (Exception ex)
				{
					LoggerViewModel logger = GlobalData.Logger;
					Components component = Components.Main;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
					defaultInterpolatedStringHandler.AppendLiteral("Error in ");
					defaultInterpolatedStringHandler.AppendFormatted(blockPlugin.Name);
					defaultInterpolatedStringHandler.AppendLiteral(" plugin:");
					defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
					defaultInterpolatedStringHandler.AppendFormatted(ex.Message);
					logger.LogError(component, defaultInterpolatedStringHandler.ToStringAndClear(), true, 0);
					Environment.Exit(0);
				}
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000073C8 File Offset: 0x000055C8
		private void CreateInstanceOfViewModels()
		{
			if (GlobalData.MainView == null)
			{
				GlobalData.MainView = new MainWindowViewModel();
			}
			GlobalData.RunnerManager = new RunnerManagerViewModel();
			GlobalData.ProxyManager = new ProxyManagerViewModel();
			GlobalData.ProxyChecker = new ProxyCheckerViewModel();
			GlobalData.WordlistManager = new WordlistManagerViewModel();
			GlobalData.ConfigManager = new ConfigManagerViewModel(true);
			GlobalData.HitsDB = new HitsDBViewModel();
			GlobalData.SilverZone = new SilverZoneViewModel();
			GlobalData.VerifiedMarket = new VerifiedMarketViewModel();
			GlobalData.Ads = new AdsViewModel();
			GlobalData.Notif = new NotifViewModel();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000744C File Offset: 0x0000564C
		private void AutoCreateRunner()
		{
			if (GlobalData.SBSettings.General.AutoCreateRunner & !GlobalData.RunnerManager.RestoreSession())
			{
				GlobalData.RunnerManager.Create();
				this.CurrentRunnerPage = GlobalData.RunnerManager.RunnersCollection.FirstOrDefault<RunnerInstance>().View;
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000749D File Offset: 0x0000569D
		public override void EndInit()
		{
			this.MinimizeToSysTray();
			base.EndInit();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000074AC File Offset: 0x000056AC
		internal void Snow()
		{
			if (this.snowBuffer >= 100)
			{
				for (int i = 0; i < this.Root.Children.Count; i++)
				{
					if (this.Root.Children[i].GetType() == typeof(Snowflake))
					{
						this.Root.Children.RemoveAt(i);
						break;
					}
				}
			}
			int num = this.rand.Next(-500, (int)this.Root.ActualWidth - 100);
			int num2 = -100;
			int num3 = this.rand.Next(5, 15);
			Snowflake snowflake = new Snowflake
			{
				Width = (double)num3,
				Height = (double)num3,
				RenderTransform = new TranslateTransform
				{
					X = (double)num,
					Y = (double)num2
				},
				HorizontalAlignment = HorizontalAlignment.Left,
				VerticalAlignment = VerticalAlignment.Top,
				IsHitTestVisible = false
			};
			Grid.SetColumn(snowflake, 1);
			Grid.SetRow(snowflake, 2);
			this.Root.Children.Add(snowflake);
			TimeSpan timeSpan = TimeSpan.FromSeconds((double)this.rand.Next(1, 4));
			num += this.rand.Next(100, 500);
			DoubleAnimation animation = new DoubleAnimation
			{
				To = new double?((double)num),
				Duration = timeSpan
			};
			snowflake.RenderTransform.BeginAnimation(TranslateTransform.XProperty, animation);
			num2 = (int)this.Root.ActualHeight + 200;
			DoubleAnimation animation2 = new DoubleAnimation
			{
				To = new double?((double)num2),
				Duration = timeSpan
			};
			snowflake.RenderTransform.BeginAnimation(TranslateTransform.YProperty, animation2);
			this.snowBuffer++;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00007668 File Offset: 0x00005868
		internal void ClearSnow()
		{
			for (int i = 0; i < this.Root.Children.Count; i++)
			{
				if (this.Root.Children[i].GetType() == typeof(Snowflake))
				{
					this.Root.Children.RemoveAt(i);
				}
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000076C8 File Offset: 0x000058C8
		internal void IsEnabledSnow(bool init = false)
		{
			try
			{
				if (GlobalData.SBSettings.Themes.EnableSnow)
				{
					this.SnowTimer = new DispatcherTimer
					{
						Interval = TimeSpan.FromMilliseconds((double)(10000 / GlobalData.SBSettings.Themes.SnowAmount))
					};
					this.SnowTimer.Tick += this.SnowTimer_Tick;
					this.SnowTimer.Start();
				}
				else if (this.SnowTimer == null)
				{
					if (!init)
					{
						this.ClearSnow();
					}
				}
				else
				{
					this.SnowTimer.Stop();
					this.SnowTimer.Tick -= this.SnowTimer_Tick;
					this.SnowTimer = null;
					this.ClearSnow();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007790 File Offset: 0x00005990
		private void SnowTimer_Tick(object sender, EventArgs e)
		{
			this.Snow();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00007798 File Offset: 0x00005998
		protected override void OnContentRendered(EventArgs e)
		{
			base.OnContentRendered(e);
			base.NonClientAreaContent = new NonClientAreaContent();
			this.SelectRunner();
			App.SetLanguageDictionary(new CultureInfo(GlobalData.SBSettings.Language.CultureName));
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000077CB File Offset: 0x000059CB
		public void ShowRunnerManager()
		{
			this.CurrentRunnerPage = null;
			this.NavigationFrame.Content = this.RunnerManagerPage;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000077E5 File Offset: 0x000059E5
		public void ShowRunner(Runner page)
		{
			this.CurrentRunnerPage = page;
			this.NavigationFrame.Content = page;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000077FA File Offset: 0x000059FA
		public void SelectRunner()
		{
			this.CustomTabItem_Click(this.Panel.GetVisualChild<CustomTabItem>(), null);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000780E File Offset: 0x00005A0E
		private void CustomTabItem_Click(object sender, RoutedEventArgs e)
		{
			this.ClickedCustomTabItem(sender, false);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007818 File Offset: 0x00005A18
		private void ClickedCustomTabItem(object sender, bool navigated = false)
		{
			if (sender == null)
			{
				return;
			}
			CustomTabItem customTabItem = sender as CustomTabItem;
			SolidColorBrush selectedColorBrush = ResourceExtension.GetBrush("ForegroundMainTabCtrlSelectedItem", "");
			if (this.Panel.FindVisualChildren<CustomTabItem>().ToList<CustomTabItem>().FirstOrDefault((CustomTabItem i) => i.Foreground == selectedColorBrush) == customTabItem)
			{
				return;
			}
			this.UnSelectItems(customTabItem);
			ForegroundColorAnimation.BeginAnimation(customTabItem, selectedColorBrush, 300);
			customTabItem.SetResourceReference(Control.ForegroundProperty, "ForegroundMainTabCtrlSelectedItem");
			BackgroundColorAnimation.BeginAnimation(customTabItem, ResourceExtension.GetBrush("MainTabCtrlSelectedItemBackground", ""), 300);
			customTabItem.SetResourceReference(Control.BackgroundProperty, "MainTabCtrlSelectedItemBackground");
			if (!navigated)
			{
				this.SelectContentByPage(customTabItem.Tag as string);
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000078D8 File Offset: 0x00005AD8
		private void UnSelectItems(CustomTabItem currentTabItem)
		{
			List<CustomTabItem> list = this.Panel.FindVisualChildren<CustomTabItem>().ToList<CustomTabItem>();
			for (int i = 0; i < list.Count; i++)
			{
				CustomTabItem customTabItem = list[i];
				if (customTabItem == currentTabItem)
				{
					customTabItem.Cursor = Cursors.Arrow;
				}
				else
				{
					customTabItem.SetResourceReference(Control.BackgroundProperty, "MainTabCtrlUnSelectedItemBackground");
					customTabItem.SetResourceReference(Control.ForegroundProperty, "ForegroundMainTabCtrlUnSelectedItem");
					customTabItem.Cursor = Cursors.Hand;
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000794C File Offset: 0x00005B4C
		private void SelectContentByPage(string page)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(page);
			if (num <= 1499549408U)
			{
				if (num <= 587470654U)
				{
					if (num != 314979090U)
					{
						if (num != 587470654U)
						{
							return;
						}
						if (!(page == "SBSettingsPage"))
						{
							return;
						}
						this.NavigationFrame.Content = this.SBSettingsPage;
						this.SBSettingsPage.Tag = "SBSettings";
						this.NavigationFrame.Tag = "SBSettings";
						return;
					}
					else
					{
						if (!(page == "ConfigsSecionPage"))
						{
							return;
						}
						this.NavigationFrame.Content = this.ConfigsSecionPage;
						this.ConfigsSecionPage.Tag = "Configs";
						this.NavigationFrame.Tag = "Configs";
						return;
					}
				}
				else if (num != 821397102U)
				{
					if (num != 1110725603U)
					{
						if (num != 1499549408U)
						{
							return;
						}
						if (!(page == "PluginsPage"))
						{
							return;
						}
						this.NavigationFrame.Content = this.PluginsPage;
						this.PluginsPage.Tag = "Plugins";
						this.NavigationFrame.Tag = "Plugins";
						return;
					}
					else
					{
						if (!(page == "WordlistManagerPage"))
						{
							return;
						}
						this.NavigationFrame.Content = this.WordlistManagerPage;
						this.WordlistManagerPage.Tag = "Wordlists";
						this.NavigationFrame.Tag = "Wordlists";
						return;
					}
				}
				else
				{
					if (!(page == "HitsDBPage"))
					{
						return;
					}
					this.NavigationFrame.Content = this.HitsDBPage;
					this.HitsDBPage.Tag = "HitsDB";
					this.NavigationFrame.Tag = "HitsDB";
					return;
				}
			}
			else if (num <= 3154925024U)
			{
				if (num != 2054601953U)
				{
					if (num != 2635903693U)
					{
						if (num != 3154925024U)
						{
							return;
						}
						if (!(page == "CoreSettingsPage"))
						{
							return;
						}
						this.NavigationFrame.Content = this.CoreSettingsPage;
						this.CoreSettingsPage.Tag = "CoreSettings";
						this.NavigationFrame.Tag = "CoreSettings";
						return;
					}
					else
					{
						if (!(page == "SilverZonePage"))
						{
							return;
						}
						this.NavigationFrame.Content = this.SilverZonePage;
						this.SilverZonePage.Tag = "SilverZone";
						this.NavigationFrame.Tag = "SilverZone";
						return;
					}
				}
				else
				{
					if (!(page == "ProxyManagerPage"))
					{
						return;
					}
					this.NavigationFrame.Content = this.ProxyManagerPage;
					this.ProxyManagerPage.Tag = "Proxies";
					this.NavigationFrame.Tag = "Proxies";
					return;
				}
			}
			else if (num != 3634794672U)
			{
				if (num != 3679480033U)
				{
					if (num != 3823605701U)
					{
						return;
					}
					if (!(page == "AboutPage"))
					{
						return;
					}
					this.NavigationFrame.Content = this.AboutPage;
					this.AboutPage.Tag = "About";
					this.NavigationFrame.Tag = "About";
					return;
				}
				else
				{
					if (!(page == "RunnerManagerPage"))
					{
						return;
					}
					this.NavigationFrame.Content = ((this.CurrentRunnerPage == null) ? this.RunnerManagerPage : this.CurrentRunnerPage);
					this.RunnerManagerPage.Tag = "Runner";
					this.NavigationFrame.Tag = "Runner";
					return;
				}
			}
			else
			{
				if (!(page == "ToolsSectionPage"))
				{
					return;
				}
				this.NavigationFrame.Content = this.ToolsSectionPage;
				this.ToolsSectionPage.Tag = "Tools";
				this.NavigationFrame.Tag = "Tools";
				return;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00007CDC File Offset: 0x00005EDC
		private void NavigationFrame_Navigated(object sender, NavigationEventArgs e)
		{
			string text = (e.Content as Page).Tag as string;
			CustomTabItem customTabItem = this.Panel.FindVisualChildren<CustomTabItem>().FirstOrDefault((CustomTabItem i) => i.Tag as string == e.Content.GetType().Name + "Page");
			if (!string.IsNullOrWhiteSpace(text))
			{
				this.NavigationFrame.SetResourceReference(FrameworkElement.TagProperty, text);
			}
			if (customTabItem == null)
			{
				return;
			}
			this.ClickedCustomTabItem(customTabItem, true);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00007D54 File Offset: 0x00005F54
		private bool CheckOnQuit()
		{
			int num = GlobalData.RunnerManager.RunnersCollection.Count((RunnerInstance r) => r.ViewModel.Busy);
			if (!GlobalData.SBSettings.General.DisableQuitWarning || num > 0)
			{
				GlobalData.Logger.LogWarning(Components.Main, "Prompting quit confirmation", false, 0);
				if (num == 0)
				{
					if (Alert.Choice("Are you sure you want to quit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
					{
						return false;
					}
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(57, 1);
					defaultInterpolatedStringHandler.AppendLiteral("There are ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(num);
					defaultInterpolatedStringHandler.AppendLiteral(" active runners. Are you sure you want to quit?");
					if (Alert.Choice(defaultInterpolatedStringHandler.ToStringAndClear(), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
					{
						return false;
					}
				}
			}
			if (!GlobalData.SBSettings.General.DisableNotSavedWarning && !GlobalData.MainWindow.ConfigsSecionPage.ConfigManagerPage.CheckSaved())
			{
				GlobalData.Logger.LogWarning(Components.Main, "Config not saved, prompting quit confirmation", false, 0);
				if (Alert.Choice("The Config in Stacker wasn't saved.\nAre you sure you want to quit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
				{
					return false;
				}
			}
			GlobalData.Logger.LogInfo(Components.Main, "Saving RunnerManager session to the database", false, 0);
			GlobalData.RunnerManager.SaveSession();
			GlobalData.Logger.LogInfo(Components.Main, "Quit sequence initiated", false, 0);
			return true;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00007E94 File Offset: 0x00006094
		public void SetStyle()
		{
			try
			{
				SolidColorBrush brush = Utils.GetBrush("BackgroundMain");
				if (!GlobalData.SBSettings.Themes.UseImage)
				{
					base.Background = brush;
					this.NavigationFrame.Background = brush;
				}
				else
				{
					if (File.Exists(GlobalData.SBSettings.Themes.BackgroundImage))
					{
						base.Background = new ImageBrush(new BitmapImage(new Uri(GlobalData.SBSettings.Themes.BackgroundImage)))
						{
							Opacity = (double)GlobalData.SBSettings.Themes.BackgroundImageOpacity / 100.0
						};
					}
					else
					{
						base.Background = brush;
					}
					if (File.Exists(GlobalData.SBSettings.Themes.BackgroundLogo))
					{
						ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri(GlobalData.SBSettings.Themes.BackgroundLogo)));
						imageBrush.AlignmentX = AlignmentX.Center;
						imageBrush.AlignmentY = AlignmentY.Center;
						imageBrush.Stretch = Stretch.None;
						imageBrush.Opacity = (double)GlobalData.SBSettings.Themes.BackgroundImageOpacity / 100.0;
						this.NavigationFrame.Background = imageBrush;
					}
					else
					{
						this.NavigationFrame.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name + ";component/Images/Themes/empty.png", UriKind.RelativeOrAbsolute)));
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00008010 File Offset: 0x00006210
		private void GlowWindow_SourceInitialized(object sender, EventArgs e)
		{
			try
			{
				this.silverZoneTimer = new Timer(delegate(object _)
				{
					try
					{
						ValueTuple<int, int, int> badges = this.GetBadges();
						int silverZoneBadge = badges.Item1 + badges.Item2 + badges.Item3;
						GlobalData.MainView.SilverZoneBadge = silverZoneBadge;
						GlobalData.SilverZone.AdsBadge = badges.Item1;
						GlobalData.SilverZone.VerifiedMarketBadge = badges.Item2;
						GlobalData.SilverZone.NotifBadge = badges.Item3;
					}
					catch
					{
					}
					try
					{
						base.Dispatcher.Invoke(delegate()
						{
							((NonClientAreaContent)base.NonClientAreaContent).CheckForUpdate(false);
						});
					}
					catch
					{
					}
				}, null, TimeSpan.Zero, TimeSpan.FromMinutes(30.0));
				BlockRequest.DefaultHttpRequestLib = GlobalData.Settings.CoreSettings.General.DefaultHttpRequestLib;
			}
			catch
			{
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00008078 File Offset: 0x00006278
		[return: TupleElementNames(new string[]
		{
			"AdsCount",
			"VeriMarketCount",
			"NotifCount"
		})]
		public ValueTuple<int, int, int> GetBadges()
		{
			int count;
			int count2;
			int count3;
			using (HttpClient httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
				count = Regex.Matches(httpClient.GetStringAsync(GlobalData.AdsAddr).ConfigureAwait(false).GetAwaiter().GetResult(), "\"Address\":\"").Count;
				count2 = Regex.Matches(httpClient.GetStringAsync(GlobalData.VerifiedMarketAddr).ConfigureAwait(false).GetAwaiter().GetResult(), "\"CreationDate\":\"").Count;
				count3 = Regex.Matches(httpClient.GetStringAsync(GlobalData.NotifAddr).ConfigureAwait(false).GetAwaiter().GetResult(), "\"Message\":\"").Count;
			}
			return new ValueTuple<int, int, int>(count, count2, count3);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00008160 File Offset: 0x00006360
		private void GlowWindow_Closing(object sender, CancelEventArgs e)
		{
			try
			{
				e.Cancel = !this.CheckOnQuit();
			}
			catch
			{
			}
			try
			{
				if (!e.Cancel)
				{
					this.NotifyIcon.Dispose();
					this.NotifyIcon.CloseContextControl();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000081C4 File Offset: 0x000063C4
		public void MinimizeToSysTray()
		{
			try
			{
				this.NotifyIcon.Visibility = ((!GlobalData.SBSettings.General.MinimizeToSysTray) ? Visibility.Collapsed : Visibility.Visible);
			}
			catch
			{
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00008208 File Offset: 0x00006408
		private void GlowWindow_StateChanged(object sender, EventArgs e)
		{
			try
			{
				if (GlobalData.SBSettings.General.MinimizeToSysTray && base.WindowState == WindowState.Minimized)
				{
					base.Hide();
					this.NotifyIcon.ShowBalloonTip("SilverBullet Pro", "Application minimized to tray", 1);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00008260 File Offset: 0x00006460
		private void ButtonPush_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				base.WindowState = WindowState.Normal;
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
			try
			{
				base.Show();
			}
			catch
			{
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000082AC File Offset: 0x000064AC
		private void NotifyIcon_MouseDoubleClick(object sender, RoutedEventArgs e)
		{
			this.ButtonPush_OnClick(this, e);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000082B6 File Offset: 0x000064B6
		private void NotifyIcon_Click(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000082B8 File Offset: 0x000064B8
		private void SilverZoneBadged_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (this.silverZoneBadgedMouseDown)
				{
					this.CustomTabItem_Click(this.tabItemSilverZone, e);
				}
			}
			finally
			{
				this.silverZoneBadgedMouseDown = false;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000082F4 File Offset: 0x000064F4
		private void SilverZoneBadged_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.silverZoneBadgedMouseDown = true;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000082FD File Offset: 0x000064FD
		private void SilverZoneBadged_MouseLeave(object sender, MouseEventArgs e)
		{
			this.silverZoneBadgedMouseDown = false;
		}

		// Token: 0x04000034 RID: 52
		private Random rand = new Random();

		// Token: 0x04000035 RID: 53
		private int snowBuffer;

		// Token: 0x04000036 RID: 54
		private bool silverZoneBadgedMouseDown;

		// Token: 0x04000037 RID: 55
		private Timer silverZoneTimer;

		// Token: 0x04000038 RID: 56
		private Lazy<RunnerManager> _runnerManager = new Lazy<RunnerManager>();

		// Token: 0x0400003A RID: 58
		private Lazy<ProxyManager> _proxyManager = new Lazy<ProxyManager>();

		// Token: 0x0400003B RID: 59
		private Lazy<WordlistManager> _wordlistManager = new Lazy<WordlistManager>();

		// Token: 0x0400003C RID: 60
		private Lazy<ConfigsSection> _configsPage = new Lazy<ConfigsSection>();

		// Token: 0x0400003D RID: 61
		private Lazy<HitsDB> _hitsDB = new Lazy<HitsDB>();

		// Token: 0x0400003E RID: 62
		private Lazy<ToolsSection> _toolsSection = new Lazy<ToolsSection>();

		// Token: 0x0400003F RID: 63
		private Lazy<PluginsSection> _plugins = new Lazy<PluginsSection>(() => new PluginsSection(MainWindow.Plugins));

		// Token: 0x04000040 RID: 64
		private Lazy<SBSettings> _sbSettings = new Lazy<SBSettings>();

		// Token: 0x04000041 RID: 65
		private Lazy<CoreSettings> _coreSettings = new Lazy<CoreSettings>();

		// Token: 0x04000042 RID: 66
		private Lazy<SilverZone> _silverZone = new Lazy<SilverZone>(() => new SilverZone(null));

		// Token: 0x04000043 RID: 67
		private Lazy<About> _about = new Lazy<About>();

		// Token: 0x04000044 RID: 68
		public static IEnumerable<PluginControl> Plugins;

		// Token: 0x04000045 RID: 69
		public DispatcherTimer SnowTimer;
	}
}
