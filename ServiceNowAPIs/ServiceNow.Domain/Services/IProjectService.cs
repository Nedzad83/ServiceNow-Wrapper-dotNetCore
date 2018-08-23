using ServiceNow.Models;
using ServiceNow.Models.Responses;

namespace ServiceNow.Domain.Services
{
    public interface IProjectService
    {
        RESTSingleResponse<Project> GetRecordByProjectName(string query, bool limit, string projectId);
        RESTQueryResponse<Project> GetRecordByQuery(string query);
    }
}