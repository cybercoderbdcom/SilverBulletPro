using System;
using Newtonsoft.Json.Linq;
using SilverBulletPro.Core.Models;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000210 RID: 528
	public class HitOutputOptionsConverter : JsonCreationConverter<HitOutputOptions>
	{
		// Token: 0x06001075 RID: 4213 RVA: 0x0004F658 File Offset: 0x0004D858
		protected override HitOutputOptions Create(Type objectType, JObject jObject)
		{
			HitOutputOptions result = null;
			try
			{
				if (jObject.ToString().Contains("\"$type\": \"SilverBulletPro.Core.Models.DatabaseHitOutputOptions"))
				{
					result = jObject.ToObject<DatabaseHitOutputOptions>();
				}
				else if (jObject.ToString().Contains("\"$type\": \"SilverBulletPro.Core.Models.FileSystemHitOutputOptions"))
				{
					result = jObject.ToObject<FileSystemHitOutputOptions>();
				}
				else if (jObject.ToString().Contains("\"$type\": \"SilverBulletPro.Core.Models.TelegramBotHitOutputOptions"))
				{
					result = jObject.ToObject<TelegramBotHitOutputOptions>();
				}
				else if (jObject.ToString().Contains("\"$type\": \"SilverBulletPro.Core.Models.DiscordWebhookHitOutputOptions"))
				{
					result = jObject.ToObject<DiscordWebhookHitOutputOptions>();
				}
				else if (jObject.ToString().Contains("\"$type\": \"SilverBulletPro.Core.Models.CustomWebhookHitOutputOptions"))
				{
					result = jObject.ToObject<CustomWebhookHitOutputOptions>();
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
