using System;
using System.Collections.Generic;
using System.Linq;
using PluginFrameworkPro;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Configuration;
using SilverBulletPro.Core.Models;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro
{
	// Token: 0x0200000D RID: 13
	public static class GlobalData
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002B2C File Offset: 0x00000D2C
		public static IApplication App
		{
			get
			{
				return new AppConfiguration
				{
					RunnerManager = GlobalData.RunnerManager,
					ProxyManager = GlobalData.ProxyManager,
					ProxyChecker = GlobalData.ProxyChecker,
					WordlistManager = GlobalData.WordlistManager,
					ConfigManager = GlobalData.ConfigManager,
					HitsDB = GlobalData.HitsDB,
					Settings = GlobalData.Settings,
					Logger = GlobalData.Logger,
					Alerter = GlobalData.Alerter
				};
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002BB3 File Offset: 0x00000DB3
		public static string AppVersion
		{
			get
			{
				return IApplication.AppVersion;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002BBA File Offset: 0x00000DBA
		public static string Edition
		{
			get
			{
				return IApplication.Edition;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002BC1 File Offset: 0x00000DC1
		public static string CompilerVer
		{
			get
			{
				return IApplication.CompilerVersion;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002BC8 File Offset: 0x00000DC8
		public static IEnumerable<BlockBase> BlockPluginsAsBase
		{
			get
			{
				return GlobalData.BlockPlugins.Cast<BlockBase>();
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002BD4 File Offset: 0x00000DD4
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002BDB File Offset: 0x00000DDB
		public static MainWindow MainWindow { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002BE3 File Offset: 0x00000DE3
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002BEA File Offset: 0x00000DEA
		public static LogWindow LogWindow { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002BF2 File Offset: 0x00000DF2
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002BF9 File Offset: 0x00000DF9
		public static MainWindowViewModel MainView { get; set; } = null;

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002C01 File Offset: 0x00000E01
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002C08 File Offset: 0x00000E08
		public static RunnerManagerViewModel RunnerManager { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002C10 File Offset: 0x00000E10
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00002C17 File Offset: 0x00000E17
		public static ProxyManagerViewModel ProxyManager { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002C1F File Offset: 0x00000E1F
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002C26 File Offset: 0x00000E26
		public static ProxyCheckerViewModel ProxyChecker { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002C2E File Offset: 0x00000E2E
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002C35 File Offset: 0x00000E35
		public static WordlistManagerViewModel WordlistManager { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002C3D File Offset: 0x00000E3D
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002C44 File Offset: 0x00000E44
		public static ConfigManagerViewModel ConfigManager { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002C4C File Offset: 0x00000E4C
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002C53 File Offset: 0x00000E53
		public static StackerViewModel Stacker { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002C5B File Offset: 0x00000E5B
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002C62 File Offset: 0x00000E62
		public static HitsDBViewModel HitsDB { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002C6A File Offset: 0x00000E6A
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002C71 File Offset: 0x00000E71
		public static SilverZoneViewModel SilverZone { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002C79 File Offset: 0x00000E79
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002C80 File Offset: 0x00000E80
		public static AdsViewModel Ads { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002C88 File Offset: 0x00000E88
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002C8F File Offset: 0x00000E8F
		public static VerifiedMarketViewModel VerifiedMarket { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002C97 File Offset: 0x00000E97
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002C9E File Offset: 0x00000E9E
		public static NotifViewModel Notif { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002CA6 File Offset: 0x00000EA6
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00002CAD File Offset: 0x00000EAD
		public static Alerter Alerter { get; set; } = new Alerter();

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002CB5 File Offset: 0x00000EB5
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002CBC File Offset: 0x00000EBC
		public static LoggerViewModel Logger { get; set; } = new LoggerViewModel();

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002CC4 File Offset: 0x00000EC4
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002CCB File Offset: 0x00000ECB
		public static GlobalSettings Settings { get; set; } = new GlobalSettings();

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002CD3 File Offset: 0x00000ED3
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002CDA File Offset: 0x00000EDA
		public static SBSettingsViewModel SBSettings { get; set; }

		// Token: 0x04000018 RID: 24
		public static List<SilverBlock> BlockMappings = new List<SilverBlock>();

		// Token: 0x04000019 RID: 25
		public static List<IBlockPlugin> BlockPlugins;

		// Token: 0x0400002C RID: 44
		internal static readonly string AdsAddr = "https://raw.githubusercontent.com/mohamm4dx/SilverBulletPro/main/SilverZone/Ad.json";

		// Token: 0x0400002D RID: 45
		internal static readonly string VerifiedMarketAddr = "https://raw.githubusercontent.com/mohamm4dx/SilverBulletPro/main/SilverZone/Market.json";

		// Token: 0x0400002E RID: 46
		internal static readonly string NotifAddr = "https://raw.githubusercontent.com/mohamm4dx/SilverBulletPro/main/SilverZone/Notif.json";
	}
}
