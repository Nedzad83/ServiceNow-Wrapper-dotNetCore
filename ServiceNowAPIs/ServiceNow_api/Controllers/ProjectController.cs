using Microsoft.AspNetCore.Mvc;
using ServiceNow.Domain.Services;
using ServiceNow.Models;
using ServiceNow.Models.Responses;

namespace ServiceNow.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("Projects")]
        public RESTQueryResponse<Project> Get()
        {
            var query = @"active=true^u_resolved=false";
            var result = _projectService.GetRecordByQuery(query);
            return result;
        }

        [HttpGet("Projects/{projectId}")]
        public RESTSingleResponse<Project> Get(string projectId)
        {
            var query = @"active=true^u_resolved=false";
            var result = _projectService.GetRecordByProjectName(query, false, projectId);
            return result;
        }
    }
}