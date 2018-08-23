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
    public class IncidentController : Controller
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet("Incidents")]
        public RESTQueryResponse<Incident> Get()
        {
            var query = @"active=true^u_resolved=false";
            var result = _incidentService.GetRecordByQuery(query);
            return result;
        }

        [HttpGet("Incidents/{detail}/{id}")]
        public RESTSingleResponse<Incident> Get(string detail, string id)
        {
            var query = @"active=true^u_resolved=false";
            var result = _incidentService.GetRecordByQuery(query, detail, id);
            return result;
        }

        [HttpGet("Incidents/{limit}")]
        public RESTQueryResponse<Incident> Get(string limit)
        {
            var query = @"active=true^u_resolved=false";
            var result = _incidentService.GetRecordByQuery(query, limit);
            return result;
        }

        [HttpGet("Incidents/{projectId}/{startDate}/{endDate}/{limit}/{offset}")]
        public RESTQueryResponse<Incident> Get( string projectId, string startDate, string endDate, string limit, string offset )
        {
            if (!DateTime.TryParse(startDate, out DateTime start))
            {
                // handle failure..
            }
            if (!DateTime.TryParse(endDate, out DateTime end))
            {
                // handle parse failure
            }
            //var query = "?sysparm_limit=10&sysparm_query=business_service=";
            var query = "?sysparm_limit=" + limit + "&sysparm_offset="+ offset + "&sysparm_query=business_service=";
            var result = _incidentService.GetByQueryAndId(query, projectId, start, end);
            return result;
        }

        [HttpPost("Create")]
        public RESTSingleResponse<IncidentPostResponse> Post([FromBody]IncidentPostParam @params)
        {
            var result = _incidentService.Create(@params);
            return result;
        }

        [HttpPut("Update")]
        public RESTSingleResponse<IncidentPutResponse> Update([FromBody]IncidentPostResponse @params, string id)
        {
            var result = _incidentService.Update(@params, id);
            return result;
        }
    }
}