using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SilverBulletPro.Core;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro
{
	// Token: 0x02000012 RID: 18
	public class AppIOManager
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x00008583 File Offset: 0x00006783
		public static void SaveSettings(string settingsFile, SBSettingsViewModel settings)
		{
			File.WriteAllText(settingsFile, JsonConvert.SerializeObject(settings, 1));
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00008592 File Offset: 0x00006792
		public static SBSettingsViewModel LoadSettings(string settingsFile)
		{
			return JsonConvert.DeserializeObject<SBSettingsViewModel>(File.ReadAllText(settingsFile));
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000085A0 File Offset: 0x000067A0
		public static void CheckRequiredPlugins(IEnumerable<string> available, Config config)
		{
			foreach (string text in config.Settings.RequiredPlugins)
			{
				if (!available.Contains(text))
				{
					throw new Exception("This config requires the plugin " + text + " which is missing from the Plugins folder and hence cannot be opened!");
				}
			}
		}

		// Token: 0x0400004E RID: 78
		private static JsonSerializerSettings settings = new JsonSerializerSettings
		{
			TypeNameHandling = 3
		};
	}
}
