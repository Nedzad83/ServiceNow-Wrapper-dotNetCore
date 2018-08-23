using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Models.RequestParams
{
    public class IncidentPostParam
    {
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("urgency")]
        public long Urgency { get; set; }

        [JsonProperty("impact")]
        public long Impact { get; set; }

        [JsonProperty("assignment_group")]
        public string AssignmentGroup { get; set; }
    }
}
