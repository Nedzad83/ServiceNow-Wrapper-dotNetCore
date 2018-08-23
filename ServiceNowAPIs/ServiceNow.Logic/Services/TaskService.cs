using ServiceNow.Domain.Services;
using ServiceNow.Logic.Client;
using ServiceNow.Models;
using ServiceNow.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Logic.Service
{
    public class TaskService : ITaskService
    {
        private readonly IServiceNowClient _serviceNowClient;

        public TaskService(IServiceNowClient serviceNowClient)
        {
            _serviceNowClient = serviceNowClient;
        }

        public RESTQueryResponse<Task> GetRecordByQuery<TParam>(TParam param) where TParam : class
        {
            var result = _serviceNowClient.GetByQuery<Task, TParam>(param);
            return result;
        }


        public RESTSingleResponse<Task> GetRecordByQuery<TParam>(string query)
        {
            var result = _serviceNowClient.GetRecordById<Task>(query);
            return result;
        }

        public RESTQueryResponse<Task> GetRecordByQuery<TParam>(string query, string limit)
        {
            var result = _serviceNowClient.GetByQuery<Task>(query, limit);
            return result;
        }

        public RESTQueryResponse<Task> GetByQueryAndId<TParam>(string query, string id, DateTime start, DateTime end)
        {
            var result = _serviceNowClient.GetByQueryAndId<Task>(query, id);
            List<Task> itemsBetween = new List<Task>();
            foreach (Task item in result.Result)
            {
                if (DateTime.TryParse(item.Opened_at, out DateTime date))
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
