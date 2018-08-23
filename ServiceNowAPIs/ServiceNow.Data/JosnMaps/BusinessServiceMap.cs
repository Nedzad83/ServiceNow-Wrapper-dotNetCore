using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Data.JosnMaps
{
    class BusinessServiceMap : DefaultContractResolver
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public BusinessServiceMap()
        {
            this.PropertyMappings = new Dictionary<string, string>
            {
                {"Meta", "meta"},
                {"LastUpdated", "last_updated"},
                {"Disclaimer", "disclaimer"},
                {"License", "license"},
                {"CountResults", "results"},
                {"Term", "term"},
                {"Count", "count"},
            };
        }


        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = this.PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}
