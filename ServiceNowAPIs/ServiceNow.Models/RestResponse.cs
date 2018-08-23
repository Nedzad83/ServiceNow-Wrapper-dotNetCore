using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Models
{
    public class RestResponse
    {
        string RawJSON { get; set; }
        string ErrorMsg { get; }
        bool IsError { get; }
        int ResultCount { get; }
    }
}
