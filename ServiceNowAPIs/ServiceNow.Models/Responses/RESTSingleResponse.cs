using ServiceNow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Models.Responses
{
    public class RESTSingleResponse<T> : RestResponse
    {
        public RESTSingleResponse() { }

        public T Result { get; set; }

        public int ResultCount
        {
            get
            {
                if (Result == null) { return 0; }
                return 1;
            }
        }
    }
}
