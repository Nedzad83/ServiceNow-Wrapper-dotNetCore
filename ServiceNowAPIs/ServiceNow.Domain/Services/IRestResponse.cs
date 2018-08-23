using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Domain.Services
{
    public interface IRestResponse
    {
        string RawJSON { get; set; }
        string ErrorMsg { get; }
        bool IsError { get; }
        int ResultCount { get; }
    }
}
