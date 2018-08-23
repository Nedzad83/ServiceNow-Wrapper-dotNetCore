using Microsoft.Extensions.Configuration;
using ServiceNow.Data.Client;
using ServiceNow.Data.Interfaces;
using ServiceNow.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Data.Repositories
{
    public class ProjectAPIRepository
    {
        private readonly TableAPIClient<Project> _projectAPIRepository;

        private readonly IConfiguration _configuration;

        public ProjectAPIRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var userName = _configuration.GetSection("Credentials").GetSection("Username").Value;
            var password = _configuration.GetSection("Credentials").GetSection("Password").Value;
            var instance = _configuration.GetSection("Credentials").GetSection("MyInstance").Value;
            if (_projectAPIRepository == null)
                _projectAPIRepository = new TableAPIClient<Project>("cmdb_ci_service", instance, userName, password);
        }

        public IRestQueryResponse<Project> GetRecordByQuery(string query)
        {
            IRestQueryResponse<Project> result = _projectAPIRepository.GetByQuery(query);
            return result;
        }

        public IRestSingleResponse<Project> GetRecordByProjectName(string query, bool limit, string projectId)
        {
            IRestSingleResponse<Project> result = _projectAPIRepository.GetRecordById(projectId);
            return result;
        }
    }
}
