using Microsoft.Extensions.Configuration;
using ServiceNow.Data.Client;
using ServiceNow.Data.Interfaces;
using ServiceNow.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Data.Repositories
{
    public class ProblemAPIRepository
    {
        private readonly TableAPIClient<Problem> _problemAPIRepository;

        private readonly IConfiguration _configuration;

        public ProblemAPIRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var userName = _configuration.GetSection("Credentials").GetSection("Username").Value;
            var password = _configuration.GetSection("Credentials").GetSection("Password").Value;
            var instance = _configuration.GetSection("Credentials").GetSection("MyInstance").Value;
            if (_problemAPIRepository == null)
                _problemAPIRepository = new TableAPIClient<Problem>("problem", instance, userName, password);
        }

        public IRestQueryResponse<Problem> GetRecordByQuery(string query)
        {
            IRestQueryResponse<Problem> result = _problemAPIRepository.GetByQuery(query);
            return result;
        }

        public IRestQueryResponse<Problem> GetRecordByQuery(string query, string limit)
        {
            IRestQueryResponse<Problem> result = _problemAPIRepository.GetByQuery(query, limit);
            return result;
        }

        public IRestQueryResponse<Problem> GetRecordByTable(string query, string table, string limit)
        {
            IRestQueryResponse<Problem> result = _problemAPIRepository.GetByQuery(query, limit);
            return result;
        }

        public IRestQueryResponse<Problem> GetByQueryAndId(string query, string id, DateTime start, DateTime end)
        {
            IRestQueryResponse<Problem> result = _problemAPIRepository.GetByQueryAndId(query, id);
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
