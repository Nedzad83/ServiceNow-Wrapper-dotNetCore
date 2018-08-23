using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Data.Common
{
    public class ResourceLink
    {
        [JsonProperty("link")]
        public string link { get; set; } 

        [JsonProperty("value")]
        public string value { get; set; }  

        public override string ToString() { return value; }
    }
}
