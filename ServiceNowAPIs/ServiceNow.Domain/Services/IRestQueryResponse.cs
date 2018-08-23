using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Domain.Services
{
    public interface IRestQueryResponse<T>
    {
        ICollection<T> Result { get; set; }
    }
}
