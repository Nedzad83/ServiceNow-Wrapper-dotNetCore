using System;
using ServiceNow.Models;
using ServiceNow.Models.Responses;

namespace ServiceNow.Domain.Services
{
    public interface IProblemService
    {
        RESTQueryResponse<Problem> GetByQueryAndId(string query, string id, DateTime start, DateTime end);
        RESTQueryResponse<Problem> GetRecordByQuery(string query);
        RESTQueryResponse<Problem> GetRecordByQuery(string query, string limit);
        RESTQueryResponse<Problem> GetRecordByTable(string query, string table, string limit);
    }
}