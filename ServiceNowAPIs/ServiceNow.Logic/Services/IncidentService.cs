using ServiceNow.Models;
using ServiceNow.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ServiceNow.Models.Responses;
using ServiceNow.Models.RequestParams;

namespace ServiceNow.Logic.Service
{
    public class IncidentService : IIncidentService
    {
        private readonly IServiceNowClient _serviceNowClient;

        public IncidentService(IServiceNowClient serviceNowClient)
        {
            _serviceNowClient = serviceNowClient;
        }

        public RESTQueryResponse<Incident> GetRecordByQuery(string query)
        {
            var result = _serviceNowClient.GetByQuery<Incident>(query);
            return result;
        }

        public RESTQueryResponse<Incident> GetRecordByQuery(string query, string limit)
        {
            var result = _serviceNowClient.GetByQuery<Incident>(query, limit);
            return result;
        }

        public RESTSingleResponse<Incident> GetRecordByQuery(string detail, string query, string id)
        {
           var result = _serviceNowClient.GetRecordById<Incident>(id);
            return result;
        }

        public RESTQueryResponse<Incident> GetRecordByTable(string query, string table, string limit)
        {
            var result = _serviceNowClient.GetByQuery<Incident>(query, limit);
            return result;
        }

        public RESTQueryResponse<Incident> GetByQueryAndId(string query, string id, DateTime start, DateTime end)
        {
            var result = _serviceNowClient.GetByQueryAndId<Incident>(query, id);
            List<Incident> itemsBetween = new List<Incident>();
            DateTime date;
            foreach (Incident item in result.Result)
            {
                if (DateTime.TryParse(item.Opened_at, out date))
                {
                    if (date < end && date > start)
                        itemsBetween.Add(item);
                }
            }
            result.Result = itemsBetween;
            return result;
        }

        public RESTSingleResponse<IncidentPostResponse> Create(IncidentPostParam @params)
        {
            var result = _serviceNowClient.Post<IncidentPostResponse, IncidentPostParam>(@params);
            return result;
        }

        public RESTSingleResponse<IncidentPutResponse> Update(IncidentPostResponse @params, string id)
        {
            var result = _serviceNowClient.Put<IncidentPutResponse, IncidentPostResponse>(@params, id);
            return result;
        }
    }
}
