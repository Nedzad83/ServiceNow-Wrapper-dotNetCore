using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Models.Responses
{
    public abstract class RestResponse
    {
        public string RawJSON { get; set; }
        public string ErrorMsg { get; set; }

        public RestResponse()
        {
            this.RawJSON = String.Empty;
            this.ErrorMsg = String.Empty;
        }

        public bool IsError
        {
            get
            {
                if (ErrorMsg.Length > 0) { return true; }
                return false;
            }
        }
    }
}
