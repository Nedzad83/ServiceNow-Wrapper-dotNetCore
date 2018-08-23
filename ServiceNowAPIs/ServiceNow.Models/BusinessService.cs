using Newtonsoft.Json;

namespace ServiceNow.Models
{
    public class BusinessService
    {
        [JsonProperty("link")]
        public string link { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }
}
