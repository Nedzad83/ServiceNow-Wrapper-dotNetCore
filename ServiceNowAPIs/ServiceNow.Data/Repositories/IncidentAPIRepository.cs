using Microsoft.Extensions.Configuration;
using ServiceNow.Data.Client;
using ServiceNow.Data.Interfaces;
using ServiceNow.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Data.Repositories
{
    public class IncidentAPIRepository
    {
        private readonly TableAPIClient<Incident> _tableAPIRepository;

        private readonly IConfiguration _configuration;

        public IncidentAPIRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var userName = _configuration.GetSection("Credentials").GetSection("Username").Value;
            var password = _configuration.GetSection("Credentials").GetSection("Password").Value;
            var instance = _configuration.GetSection("Credentials").GetSection("MyInstance").Value;
            if (_tableAPIRepository == null)
                _tableAPIRepository = new TableAPIClient<Incident>("incident", instance, userName, password);
        }

        public IRestQueryResponse<Incident> GetRecordByQuery(string query)
        {
            IRestQueryResponse<Incident> result = _tableAPIRepository.GetByQuery(query);
            return result;
        }

        public IRestQueryResponse<Incident> GetRecordByQuery(string query, string limit)
        {
            IRestQueryResponse<Incident> result = _tableAPIRepository.GetByQuery(query, limit);
            return result;
        }

        public IRestSingleResponse<Incident> GetRecordByQuery(string detail, string query, string id)
        {
            IRestSingleResponse<Incident> result = _tableAPIRepository.GetRecordById(id);
            return result;
        }

        public IRestQueryResponse<Incident> GetRecordByTable(string query, string table, string limit)
        {
            IRestQueryResponse<Incident> result = _tableAPIRepository.GetByQuery(query, limit);
            return result;
        }

        public IRestQueryResponse<Incident> GetByQueryAndId(string query, string id, DateTime start, DateTime end)
        {
            IRestQueryResponse<Incident> result = _tableAPIRepository.GetByQueryAndId(query, id);
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
    }
}
