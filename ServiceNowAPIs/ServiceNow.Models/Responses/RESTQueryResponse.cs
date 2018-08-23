using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Models.Responses
{
    public class RESTQueryResponse<T> : RestResponse
    {
        public RESTQueryResponse()
        {
            this.Result = new List<T>();
        }

        public ICollection<T> Result { get; set; }

        public int ResultCount
        {
            get
            {
                //if (Result == null) { return 0; }
                return Result?.Count ?? 0;
            }
        }
    }
}
