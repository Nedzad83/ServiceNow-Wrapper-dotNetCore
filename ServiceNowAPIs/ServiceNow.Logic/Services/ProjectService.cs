using ServiceNow.Domain.Services;
using ServiceNow.Models;
using ServiceNow.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Logic.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IServiceNowClient _serviceNowClient;

        public ProjectService(IServiceNowClient serviceNowClient)
        {
            _serviceNowClient = serviceNowClient;
        }

        public RESTQueryResponse<Project> GetRecordByQuery(string query)
        {
            var result = _serviceNowClient.GetByQuery<Project>(query);
            return result;
        }

        public RESTSingleResponse<Project> GetRecordByProjectName(string query, bool limit, string projectId)
        {
            var result = _serviceNowClient.GetRecordById<Project>(projectId);
            return result;
        }
    }
}
