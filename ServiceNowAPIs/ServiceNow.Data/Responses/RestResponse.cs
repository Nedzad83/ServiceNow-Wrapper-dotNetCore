using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Data.Responses
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

    public class RESTQueryResponse<T> : RestResponse, IRestQueryResponse<T>
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
                if (Result == null) { return 0; }
                return Result.Count;
            }
        }
    }

    public class RESTSingleResponse<T> : RestResponse, IRestSingleResponse<T>
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
