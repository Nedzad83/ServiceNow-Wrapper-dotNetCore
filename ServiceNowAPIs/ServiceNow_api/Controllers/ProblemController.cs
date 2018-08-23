using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceNow.Logic;
using ServiceNow.Models;
using ServiceNow.Domain;
using ServiceNow.Domain.Services;
using ServiceNow.Models.Responses;

namespace ServiceNow.API.Controllers
{
    [Route("api/[controller]")]
    public class ProblemController : Controller
    {
        private readonly IProblemService _problemService;

        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpGet("Problems")]
        public RESTQueryResponse<Problem> Get()
        {
            var query = @"active=true^u_resolved=false";
            var result = _problemService.GetRecordByQuery(query);
            return result;
        }

        [HttpGet("Problems/{limit}")]
        public RESTQueryResponse<Problem> Get(string limit)
        {
            var query = @"active=true^u_resolved=false";
            var result = _problemService.GetRecordByQuery(query, limit);
            return result;
        }

        [HttpGet("Problems/{problemId}/{startDate}/{endDate}/{limit}")]
        public RESTQueryResponse<Problem> Get(string problemId, string startDate, string endDate, string limit)
        {
            if (!DateTime.TryParse(startDate, out DateTime start))
            {
                // handle failure..
            }
            if (!DateTime.TryParse(endDate, out DateTime end))
            {
                // handle failure..
            }
            //var query = "?sysparm_limit=10&sysparm_query=business_service=";
            var query = "?sysparm_limit=" + limit + "&sysparm_query=business_service=";
            RESTQueryResponse<Problem> result = _problemService.GetByQueryAndId(query, problemId, start, end);
            return result;
        }
    }
}