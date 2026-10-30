using System;
using System.Net.Http;
using Newtonsoft.Json;
using SilverBulletPro.Core;

namespace SilverBulletPro.Updater
{
	// Token: 0x020001D0 RID: 464
	internal static class UpdateChecker
	{
		// Token: 0x06000E92 RID: 3730 RVA: 0x0004AE54 File Offset: 0x00049054
		public static T Run<T>(string url)
		{
			string text = string.Empty;
			using (HttpClient httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
				httpClient.DefaultRequestHeaders.Accept.TryParseAdd("application/vnd.github.v3+json");
				text = httpClient.GetAsync(url).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}
			return JsonConvert.DeserializeObject<T>(text);
		}
	}
}
