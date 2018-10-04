﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Campaign;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaContext : IEloquaContext
    {
        private readonly IRestClient _restClient;

        public EloquaContext(IRestClient restClient)
        {
            _restClient = restClient;
            Contacts = new DbSet<Contact>(restClient);
            Bulk = new BulkApi(restClient);
            Campaigns = new DbSet<Campaign>(restClient);
            Emails = new DbSet<Email>(restClient);
            EmailDeployments = new DbSet<EmailDeployment>(restClient);
        }

        public IBulkApi Bulk { get; }
        public IDbSet<Contact> Contacts { get; }
        public IDbSet<Campaign> Campaigns { get; }
        public IDbSet<Email> Emails { get; }
        public IDbSet<EmailDeployment> EmailDeployments { get; }

        public static IRestClient CreateClient(string site, string username, string password, Uri baseUri)
        {
            var restClient = new RestClient
            {
                BaseUrl = baseUri,
                Authenticator = new HttpBasicAuthenticator(site + "\\" + username, password)
            };
            restClient.AddHandler("text/plain", new JsonDeserializer());
            return restClient;
        }


        public async Task<Result> DisableCustomCampaignObjectsAsync(long customObjectInstanceId,long activationId, long customObjectschemaId = 121)
        {

            const string restApiPath = "/api/REST/2.0/data/";
        

            var requestUrl = $"{restApiPath}customObject/{customObjectschemaId}/instance/{customObjectInstanceId}";
            var request = new RestRequest(requestUrl, Method.PUT);

            dynamic customObjectData = new ExpandoObject();
            dynamic fieldValue = new ExpandoObject();


            fieldValue.id = activationId;
            fieldValue.value = 0;

            customObjectData.fieldValues = new List<object> { fieldValue };

            var serialized = JsonConvert.SerializeObject(customObjectData, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await _restClient.ExecuteTaskAsync(request);


            return response.StatusCode == HttpStatusCode.OK? Result.FromSuccess(): Result.FromError(response.ErrorMessage);

        }

        public async Task<Result> UpdateCustomCampaignObjectsAsync(int state, long customObjectInstanceId, long activationId, long customObjectschemaId = 121)
        {

            const string restApiPath = "/api/REST/2.0/data/";


            var requestUrl = $"{restApiPath}customObject/{customObjectschemaId}/instance/{customObjectInstanceId}";
            var request = new RestRequest(requestUrl, Method.PUT);

            dynamic customObjectData = new ExpandoObject();
            dynamic fieldValue = new ExpandoObject();


            fieldValue.id = activationId;
            fieldValue.value = state;

            customObjectData.fieldValues = new List<object> { fieldValue };

            var serialized = JsonConvert.SerializeObject(customObjectData, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await _restClient.ExecuteTaskAsync(request);


            return response.StatusCode == HttpStatusCode.OK ? Result.FromSuccess() : Result.FromError(response.ErrorMessage);

        }

        public async Task<List<CustomObjectData>> SearchCustomCampaignObjectsAsync(string searchTerm, long customObjectschemaId = 121)
        {

            const string restApiPath = "/api/REST/2.0/data/";


            var requestUrl = $"{restApiPath}customObject/{customObjectschemaId}/instances?search={searchTerm}";

            var request = new RestRequest(requestUrl, Method.GET);

            var response = await _restClient.ExecuteTaskAsync(request);

            var resultObject = JsonConvert.DeserializeObject<Element<CustomObjectData>>(response.Content);

            var results = new List<CustomObjectData>();

            foreach (var element in resultObject.Elements)
            {
                results.Add(element);
            }

            return results;

        }

        public async Task<Result> CreateCustomCampaignObjectsAsync( string emailAddress,long eloquaContactId, int state, long activationId, long customObjectschemaId = 121)
        {

            const string restApiPath = "/api/REST/2.0/data/";


            var requestUrl = $"{restApiPath}customObject/{customObjectschemaId}/instance";
            var request = new RestRequest(requestUrl, Method.POST);

            dynamic customObjectData = new ExpandoObject();
            dynamic fieldValue = new ExpandoObject();


            fieldValue.id = activationId;
            fieldValue.value = state;

            customObjectData.fieldValues = new List<object> { fieldValue };
            customObjectData.contactId = eloquaContactId;
            customObjectData.uniqueCode = emailAddress;

            var serialized = JsonConvert.SerializeObject(customObjectData, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await _restClient.ExecuteTaskAsync(request);


            return response.StatusCode == HttpStatusCode.OK ? Result.FromSuccess() : Result.FromError(response.ErrorMessage);

        }
    }
}
