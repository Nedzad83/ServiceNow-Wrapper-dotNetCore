using ServiceNow.Logic.Constants;
using ServiceNow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNow.Logic.Resolvers
{
    public static class TableResolver
    {
        private static Dictionary<Type, string> tablesDictionary = new Dictionary<Type, string>()
        {
            { typeof(Incident), Tables.Incident},
            { typeof(IncidentPostResponse), Tables.Incident},
            { typeof(IncidentPutResponse), Tables.Incident},
            { typeof(Problem), Tables.Problem},
            { typeof(Project), Tables.Project},
            { typeof(Task), Tables.Task},
        };

        public static string GetTableName<T>()
        {
            string  result = tablesDictionary[typeof(T)];

            if (string.IsNullOrWhiteSpace(result))
            {
                throw new Exception("Procedure name was not found for this type.");
            }

            return result;
        }
    }
}
