using Newtonsoft.Json;

namespace ServiceNow.Models
{
    /// <summary>
    /// Base class for a service now record..
    /// </summary>
    public abstract class Record
    {
        [JsonProperty("sys_id")]
        public string sys_id { get; set; }

        public bool ShouldSerializesys_id() { return false; }
    }
}
