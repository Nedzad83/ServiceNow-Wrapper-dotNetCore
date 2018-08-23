using System;
using ServiceNow.Models;
using ServiceNow.Models.RequestParams;
using ServiceNow.Models.Responses;

namespace ServiceNow.Domain.Services
{
    public interface IIncidentService
    {
        RESTQueryResponse<Incident> GetByQueryAndId(string query, string id, DateTime start, DateTime end);
        RESTQueryResponse<Incident> GetRecordByQuery(string query);
        RESTQueryResponse<Incident> GetRecordByQuery(string query, string limit);
        RESTSingleResponse<Incident> GetRecordByQuery(string detail, string query, string id);
        RESTQueryResponse<Incident> GetRecordByTable(string query, string table, string limit);
        RESTSingleResponse<IncidentPostResponse> Create(IncidentPostParam @params);
        RESTSingleResponse<IncidentPutResponse> Update(IncidentPostResponse @params, string id);
    }
}