using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceNow.Domain.Services;
using ServiceNow.Models;
using ServiceNow.Models.RequestParams;
using ServiceNow.Models.Responses;

namespace ServiceNow.API.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("Tasks")]
        public RESTQueryResponse<Models.Task> Get()
        {
            //var query = @"active=true^u_resolved=false";
            var param = new TaskParams();
            var result = _taskService.GetRecordByQuery(param);
            return result;
        }

        [HttpGet("Tasks/{limit}")]
        public RESTQueryResponse<Models.Task> Get(string limit)
        {
            var query = @"active=true^u_resolved=false";
            var result = _taskService.GetRecordByQuery<TaskParams>(query, limit);
            return result;
        }

        [HttpGet("Tasks/{taskId}/{startDate}/{endDate}/{limit}")]
        public RESTQueryResponse<Models.Task> Get(string taskId, string startDate, string endDate, string limit)
        {
            if (!DateTime.TryParse(startDate, out DateTime start))
            {
                //return BadRequest("Error on startDate format");
                // handle failure..
            }
            if (!DateTime.TryParse(endDate, out DateTime end))
            {
                // handle failure..
            }
            var query = "?sysparm_limit=" + limit + "&sysparm_query=business_service=";
            var result = _taskService.GetByQueryAndId<TaskParams>(query, taskId, start, end);
            return result;
        }
    }
}