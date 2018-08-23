using ServiceNow.Domain.Services;
using ServiceNow.Models;
using ServiceNow.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Logic.Service
{
    public class ProblemService : IProblemService
    {
        private readonly IServiceNowClient _serviceNowClient;

        public ProblemService(IServiceNowClient serviceNowClient)
        {
            _serviceNowClient = serviceNowClient;
        }

        public RESTQueryResponse<Problem> GetRecordByQuery(string query)
        {
            var result = _serviceNowClient.GetByQuery<Problem>(query);
            return result;
        }

        public RESTQueryResponse<Problem> GetRecordByQuery(string query, string limit)
        {
            var result = _serviceNowClient.GetByQuery<Problem>(query, limit);
            return result;
        }

        public RESTQueryResponse<Problem> GetRecordByTable(string query, string table, string limit)
        {
            var result = _serviceNowClient.GetByQuery<Problem>(query, limit);
            return result;
        }

        public RESTQueryResponse<Problem> GetByQueryAndId(string query, string id, DateTime start, DateTime end)
        {
            var result = _serviceNowClient.GetByQueryAndId<Problem>(query, id);
            List<Problem> itemsBetween = new List<Problem>();
            DateTime date;
            foreach (Problem item in result.Result)
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
    }
}
