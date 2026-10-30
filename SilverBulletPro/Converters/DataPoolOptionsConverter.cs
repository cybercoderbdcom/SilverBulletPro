using System;
using Newtonsoft.Json.Linq;
using SilverBulletPro.Core.Enums;
using SilverBulletPro.Core.Models;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000209 RID: 521
	public class DataPoolOptionsConverter : JsonCreationConverter<DataPoolOptions>
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x0600105E RID: 4190 RVA: 0x0004F3E2 File Offset: 0x0004D5E2
		// (set) Token: 0x0600105F RID: 4191 RVA: 0x0004F3EA File Offset: 0x0004D5EA
		public DataPoolType DataPoolType { get; private set; }

		// Token: 0x06001060 RID: 4192 RVA: 0x0004F3F4 File Offset: 0x0004D5F4
		public DataPoolOptionsConverter(string json)
		{
			if (!json.Contains("\"DataPoolType\":"))
			{
				throw new Exception("DataPool is invalid");
			}
			this.DataPoolType = JToken.Parse(json)["Options"]["DataPoolType"].ToObject<DataPoolType>();
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x0004F444 File Offset: 0x0004D644
		protected override DataPoolOptions Create(Type objectType, JObject jObject)
		{
			DataPoolOptions result = null;
			try
			{
				switch (this.DataPoolType)
				{
				case 0:
					result = jObject.ToObject<WordlistDataPoolOptions>();
					break;
				case 1:
					result = jObject.ToObject<FileDataPoolOptions>();
					break;
				case 2:
					result = jObject.ToObject<RangeDataPoolOptions>();
					break;
				case 3:
					result = jObject.ToObject<CombinationsDataPoolOptions>();
					break;
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
