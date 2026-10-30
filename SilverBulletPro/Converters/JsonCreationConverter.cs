using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000214 RID: 532
	public abstract class JsonCreationConverter<T> : JsonConverter
	{
		// Token: 0x06001080 RID: 4224
		protected abstract T Create(Type objectType, JObject jObject);

		// Token: 0x06001081 RID: 4225 RVA: 0x0004F7BF File Offset: 0x0004D9BF
		public override bool CanConvert(Type objectType)
		{
			return typeof(T) == objectType;
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x0004F7D4 File Offset: 0x0004D9D4
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			object result;
			try
			{
				JObject jobject = JObject.Load(reader);
				T t = this.Create(objectType, jobject);
				serializer.Populate(jobject.CreateReader(), t);
				result = t;
			}
			catch (JsonReaderException)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x0004F824 File Offset: 0x0004DA24
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
