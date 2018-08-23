using System;
using ServiceNow.Models;
using ServiceNow.Models.Responses;

namespace ServiceNow.Domain.Services
{
    public interface ITaskService
    {
        RESTQueryResponse<Task> GetByQueryAndId<TParam>(string query, string id, DateTime start, DateTime end);
        RESTSingleResponse<Task> GetRecordByQuery<TParam>(string query);
        RESTQueryResponse<Task> GetRecordByQuery<TParam>(TParam param) where TParam : class;
        RESTQueryResponse<Task> GetRecordByQuery<TParam>(string query, string limit);
    }
}