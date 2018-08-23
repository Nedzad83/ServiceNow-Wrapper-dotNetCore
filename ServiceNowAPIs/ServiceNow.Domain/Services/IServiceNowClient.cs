using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ServiceNow.Models.Responses;

namespace ServiceNow.Domain.Services
{
    public interface IServiceNowClient
    {
        RESTSingleResponse<T> GetRecordById<T>(string id);
        RESTQueryResponse<T> GetByQuery<T>(string query);
        RESTQueryResponse<TResult> GetByQuery<TResult, TParam>(TParam param) where TParam : class;
        RESTQueryResponse<T> GetByQuery<T>(string query, string limit);
        RESTQueryResponse<T> GetByQueryAndId<T>(string query, string Id);
        HttpStatusCode Delete<T>(string id);
        RESTSingleResponse<TResult> Post<TResult, TParam>(TParam @params);
        RESTSingleResponse<TResult> Put<TResult, TParam>(TParam @params, string id);
        //IRestSingleResponse<T> GetById<T>(string id) where T : class;
        //IRestSingleResponse<T> GetByQuery<T>(string query, bool limit) where T : class;
        //IRestSingleResponse<T> Post<T>(T record) where T : class;
        //IRestSingleResponse<T> Put<T>(T record) where T : class;
    }
}
