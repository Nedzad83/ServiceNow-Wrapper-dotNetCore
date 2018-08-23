using Newtonsoft.Json;

namespace ServiceNow.Models
{
    public class Project : Record
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sys_id")]
        public string Id { get; set; }
    }
}
