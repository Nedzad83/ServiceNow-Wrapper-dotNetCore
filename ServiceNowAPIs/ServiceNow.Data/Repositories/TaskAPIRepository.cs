using Microsoft.Extensions.Configuration;
using ServiceNow.Data.Client;
using ServiceNow.Data.Interfaces;
using ServiceNow.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Data.Repositories
{
    public class TaskAPIRepository
    {
        private readonly TableAPIClient<ServiceNowTask> _taskAPIRepository;

        private readonly IConfiguration _configuration;

        public TaskAPIRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var userName = _configuration.GetSection("Credentials").GetSection("Username").Value;
            var password = _configuration.GetSection("Credentials").GetSection("Password").Value;
            var instance = _configuration.GetSection("Credentials").GetSection("MyInstance").Value;
            if (_taskAPIRepository == null)
                _taskAPIRepository = new TableAPIClient<ServiceNowTask>("task", instance, userName, password);
        }

        public IRestQueryResponse<ServiceNowTask> GetRecordByQuery(string query)
        {
            IRestQueryResponse<ServiceNowTask> result = _taskAPIRepository.GetByQuery(query);
            return result;
        }

        public IRestQueryResponse<ServiceNowTask> GetRecordByQuery(string query, string limit)
        {
            IRestQueryResponse<ServiceNowTask> result = _taskAPIRepository.GetByQuery(query, limit);
            return result;
        }

        public IRestQueryResponse<ServiceNowTask> GetByQueryAndId(string query, string id, DateTime start, DateTime end)
        {
            IRestQueryResponse<ServiceNowTask> result = _taskAPIRepository.GetByQueryAndId(query, id);
            List<ServiceNowTask> itemsBetween = new List<ServiceNowTask>();
            DateTime date;
            foreach (ServiceNowTask item in result.Result)
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
