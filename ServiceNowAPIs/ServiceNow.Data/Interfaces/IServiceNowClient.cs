using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Data.Interfaces
{
    public interface IServiceNowClient<T> where T : ServiceNow.Data.Common.Record
    {
        void Delete(string id);
        IRestSingleResponse<T> GetById(string id);
        IRestSingleResponse<T> GetByQuery(string query, bool limit);
        IRestSingleResponse<T> Post(T record);
        IRestSingleResponse<T> Put(T record);
    }
}
