using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using ServiceNow.Data.Common;

namespace ServiceNow.Common.Converter 
{
    public class ResourceLinkConverter : JsonConverter
    {
        public override bool CanRead { get { return false; } }
        public override bool CanWrite { get { return base.CanWrite; } }
        public override bool CanConvert(Type objectType) { return objectType == typeof(ResourceLink); }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JToken sys_id = JToken.FromObject(value.ToString());
                sys_id.WriteTo(writer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
