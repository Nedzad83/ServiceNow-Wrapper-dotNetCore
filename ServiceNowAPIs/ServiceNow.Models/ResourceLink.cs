using Newtonsoft.Json;

namespace ServiceNow.Models
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
