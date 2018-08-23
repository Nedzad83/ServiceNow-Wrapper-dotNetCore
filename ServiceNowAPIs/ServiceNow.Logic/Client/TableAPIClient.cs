using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using ServiceNow.Domain.Services;
using ServiceNow.Logic.Resolvers;
using ServiceNow.Models.Responses;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace ServiceNow.Logic.Client
{
    public class TableAPIClient : IServiceNowClient
    {
        private String _TableName;
        private String _sNowURL;
        private RestClient ServiceNowClient;

        public TableAPIClient(String sNowURL, String userName, string password)
        {
            HttpBasicAuthenticator credentials = new HttpBasicAuthenticator(userName, password );
            _TableName = string.Empty;
            _sNowURL = sNowURL;

            ServiceNowClient = new RestClient()
            {
                Authenticator = credentials
            };
        }

        private String URL
        {
            get
            {
                return string.Concat(_sNowURL, _TableName);
            }
        }

        private string ParseWebException(WebException ex)
        {
            string message = ex.Message + "\n\n";

            if (ex.Response != null)
            {
                var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                dynamic obj = JsonConvert.DeserializeObject(resp);

                message = "status: " + obj.status + "\n";
                message += ex.Message + "\n\n";
                message += "message: " + obj.error.message + "\n";
                message += "detail: " + obj.error.detail + "\n";
            }

            return message;
        }

        public RESTSingleResponse<T> GetRecordById<T>(string id)
        {
            var response = new RESTSingleResponse<T>();

            try
            {
                _TableName = TableResolver.GetTableName<T>();
                var request = new RestRequest(Method.GET);
                ServiceNowClient.BaseUrl = new Uri(URL + "/" + id);
                IRestResponse res = ServiceNowClient.Execute(request);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    RESTSingleResponse<T> tmp = JsonConvert.DeserializeObject<RESTSingleResponse<T>>(res.Content);
                    if (tmp != null) { response.Result = tmp.Result; }
                }
            }
            catch (WebException ex)
            {
                response.ErrorMsg = ParseWebException(ex);
            }
            catch (Exception ex)
            {
                response.ErrorMsg = "An error occured retrieving the REST response: " + ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Retrieves all record..
        /// </summary>
        public RESTQueryResponse<T> GetByQuery<T>(string query)
        {
            var response = new RESTQueryResponse<T>();

            try
            {
                _TableName = TableResolver.GetTableName<T>();
                var request = new RestRequest(Method.GET);
                ServiceNowClient.BaseUrl = new Uri(URL);
                IRestResponse res = ServiceNowClient.Execute(request);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    RESTQueryResponse<T> tmp = JsonConvert.DeserializeObject<RESTQueryResponse<T>>(res.Content);
                    if (tmp != null) { response.Result = tmp.Result; }
                }
            }
            catch (WebException ex)
            {
                response.ErrorMsg = ParseWebException(ex);
            }
            catch (Exception ex)
            {
                response.ErrorMsg = "An error occured retrieving the REST response: " + ex.Message;
            }
            
            return response;
        }

        /// <summary>
        /// Retrieves a record..
        /// </summary>
        public RESTQueryResponse<T> GetByQuery<T>(string query, string limit)
        {
            var response = new RESTQueryResponse<T>();

            try
            {
                _TableName = TableResolver.GetTableName<T>();
                var request = new RestRequest(Method.GET);
                ServiceNowClient.BaseUrl = new Uri(URL + "?sysparm_limit=" + limit);
                IRestResponse res = ServiceNowClient.Execute(request);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    RESTQueryResponse<T> tmp = JsonConvert.DeserializeObject<RESTQueryResponse<T>>(res.Content);
                    if (tmp != null) { response.Result = tmp.Result; }
                }
            }
            catch (WebException ex)
            {
                response.ErrorMsg = ParseWebException(ex);
            }
            catch (Exception ex)
            {
                response.ErrorMsg = "An error occured retrieving the REST response: " + ex.Message;
            }

            return response;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public RESTQueryResponse<T> GetByQueryAndId<T>(string query, string Id)
        {
            var response = new RESTQueryResponse<T>();

            try
            {
                _TableName = TableResolver.GetTableName<T>();
                var request = new RestRequest(Method.GET);
                ServiceNowClient.BaseUrl = new Uri(URL + query + Id);
                IRestResponse res = ServiceNowClient.Execute(request);
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    RESTQueryResponse<T> tmp = JsonConvert.DeserializeObject<RESTQueryResponse<T>>(res.Content);
                    if (tmp != null) { response.Result = tmp.Result; }
                }
            }
            catch (WebException ex)
            {
                response.ErrorMsg = ParseWebException(ex);
            }
            catch (Exception ex)
            {
                response.ErrorMsg = "An error occured retrieving the REST response: " + ex.Message;
            }

            return response;
        }
        
        public HttpStatusCode Delete<T>(string id)
        {
            try
            {
                _TableName = TableResolver.GetTableName<T>();
                var request = new RestRequest(Method.DELETE);
                ServiceNowClient.BaseUrl = new Uri(URL + "/" + id);
                IRestResponse res = ServiceNowClient.Execute(request);
                return res.StatusCode;
            }
            catch (WebException ex)
            {
                string ErrorMsg = ParseWebException(ex);
                throw new Exception(ErrorMsg);
            }
        }

        public RESTQueryResponse<TResult> GetByQuery<TResult, TParam>(TParam param) where TParam: class
        {
            var response = new RESTQueryResponse<TResult>();

            try
            {
                var query = ParameterParser.Parse(param);
                _TableName = TableResolver.GetTableName<TResult>();
                var request = new RestRequest(Method.GET);
                ServiceNowClient.BaseUrl = new Uri($"{URL}?{query}");
                IRestResponse res = ServiceNowClient.Execute(request);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    RESTQueryResponse<TResult> tmp = JsonConvert.DeserializeObject<RESTQueryResponse<TResult>>(res.Content);
                    if (tmp != null) { response.Result = tmp.Result; }
                }
            }
            catch (WebException ex)
            {
                response.ErrorMsg = ParseWebException(ex);
            }
            catch (Exception ex)
            {
                response.ErrorMsg = "An error occured retrieving the REST response: " + ex.Message;
            }

            return response;
        }

        public RESTSingleResponse<TResult> Post<TResult, TParam>(TParam @params)
        {
            string _params = JsonConvert.SerializeObject(@params,Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var response = new RESTSingleResponse<TResult>();

            _TableName = TableResolver.GetTableName<TResult>();
            var request = new RestRequest(Method.POST);
            ServiceNowClient.BaseUrl = new Uri(URL);
           
            request.AddParameter("application/json", _params, ParameterType.RequestBody);
            
            IRestResponse res = ServiceNowClient.Execute(request);

            if (res.StatusCode != HttpStatusCode.BadRequest)
            {
                RESTSingleResponse<TResult> tmp = JsonConvert.DeserializeObject<RESTSingleResponse<TResult>>(res.Content);
                if (tmp != null) { response.Result = tmp.Result; }
            }
            return response;
        }

        public RESTSingleResponse<TResult> Put<TResult, TParam>(TParam @params, string id)
        {
            string _params = JsonConvert.SerializeObject(@params, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var response = new RESTSingleResponse<TResult>();

            _TableName = TableResolver.GetTableName<TResult>();
            var request = new RestRequest(Method.PUT);
            ServiceNowClient.BaseUrl = new Uri($"{URL}/{id}");

            request.AddHeader("accept", "application/json");
            //request.AddHeader("authorization", "Basic T01TX0FwcF9Vc2VyOjBzY2FyOTk=");
            //request.AddHeader("content-type", "application/json");

            request.AddParameter("application/json", _params, ParameterType.RequestBody);

            IRestResponse res = ServiceNowClient.Execute(request);

            if (res.StatusCode != HttpStatusCode.BadRequest)
            {
                RESTSingleResponse<TResult> tmp = JsonConvert.DeserializeObject<RESTSingleResponse<TResult>>(res.Content);
                if (tmp != null) { response.Result = tmp.Result; }
            }
            return response;
        }

        /*
        IRestSingleResponse<T> IServiceNowClient.GetById<T>(string id)
        {
            var response = new RESTSingleResponse<T>();

            try
            {
                response.RawJSON = ServiceNowClient.DownloadString(URL + "/" + id + "?&sysparm_fields=" + _FieldList);

                RESTSingleResponse<T> tmp = JsonConvert.DeserializeObject<RESTSingleResponse<T>>(response.RawJSON);
                if (tmp != null) { response.Result = tmp.Result; }
            }
            catch (WebException ex)
            {
                response.ErrorMsg = ParseWebException(ex);
            }
            catch (Exception ex)
            {
                response.ErrorMsg = "An error occured retrieving the REST response: " + ex.Message;
            }

            return response;
        }

        IRestSingleResponse<T> IServiceNowClient.GetByQuery<T>(string query, bool limit)
        {
            throw new NotImplementedException();
        }
        
        IRestSingleResponse<T> IServiceNowClient.Post<T>(T record)
        {
            var response = new RESTSingleResponse<T>();

            try
            {
                string data = JsonConvert.SerializeObject(record, new ResourceLinkConverter());
                response.RawJSON = ServiceNowClient.UploadString(URL + "?&sysparm_fields=" + _FieldList, "POST", data);

                RESTSingleResponse<T> tmp = JsonConvert.DeserializeObject<RESTSingleResponse<T>>(response.RawJSON);
                if (tmp != null) { response.Result = tmp.Result; }
            }
            catch (WebException ex)
            {
                response.ErrorMsg = ParseWebException(ex);
            }
            catch (Exception ex)
            {
                response.ErrorMsg = "An error occured retrieving the REST response: " + ex.Message;
            }
            
            return response;
        }
 
        IRestSingleResponse<T> IServiceNowClient.Put<T>(T record)
        {
            var response = new RESTSingleResponse<T>();

            try
            {
                string data = JsonConvert.SerializeObject(record, new ResourceLinkConverter());
                //TODO: issue with the type
                //response.RawJSON = ServiceNowClient.UploadString(URL + "/" + record.sys_id + "?&sysparm_fields=" + _FieldList, "PUT", data);

                RESTSingleResponse<T> tmp = JsonConvert.DeserializeObject<RESTSingleResponse<T>>(response.RawJSON);
                if (tmp != null) { response.Result = tmp.Result; }
            }
            catch (WebException ex)
            {
                response.ErrorMsg = ParseWebException(ex);
            }
            catch (Exception ex)
            {
                response.ErrorMsg = "An error occured retrieving the REST response: " + ex.Message;
            }

            return response;
        }*/
    }
}
