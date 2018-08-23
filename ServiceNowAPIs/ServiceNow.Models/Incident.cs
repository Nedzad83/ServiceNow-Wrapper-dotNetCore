using Newtonsoft.Json;

namespace ServiceNow.Models
{
    public class Incident : Record
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("sys_id")]
        public string Sys_Id { get; set; }

        [JsonProperty("impact")]
        public int Impact { get; set; }

        [JsonProperty("sys_created_by")]
        public string Sys_created_by { get; set; }

        [JsonProperty("sys_class_name")]
        public string Sys_class_name { get; set; }

        [JsonProperty("short_description")]
        public string Short_description { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("opened_at")]
        public string Opened_at { get; set; }

        [JsonProperty("closed_at")]
        public string Closed_at { get; set; }

        [JsonProperty("close_code")]
        public string Close_code { get; set; }

        [JsonProperty("close_notes")]
        public string Close_notes { get; set; }

        [JsonProperty("opened_by")]
        public ResourceLink Opened_by { get; set; }

        [JsonProperty("caller_id")]
        public ResourceLink Caller_id { get; set; }

        [JsonProperty("business_service")]
        public BusinessService BusinessService { get; set; }

        [JsonProperty("closed_by")]
        public BusinessService Closed_by { get; set; }

        [JsonProperty("assigned_to")]
        public BusinessService Assigned_to { get; set; }

        [JsonProperty("sys_domain")]
        public BusinessService Sys_domain { get; set; }

        [JsonProperty("assignment_group")]
        public BusinessService Assignment_group { get; set; }

        [JsonProperty("company")]
        public BusinessService Company { get; set; }

        [JsonProperty("u_inc_line_of_business")]
        public BusinessService U_inc_line_of_business { get; set; }
    }
}
