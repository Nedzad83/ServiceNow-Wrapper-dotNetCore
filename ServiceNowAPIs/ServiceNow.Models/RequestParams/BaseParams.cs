using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Models.RequestParams
{
    public class BaseParams
    {
        public bool active { get; set; } = true;
        public bool u_resolved { get; set; } = false;
    }
}
