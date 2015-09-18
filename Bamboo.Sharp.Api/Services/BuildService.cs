﻿using System.Linq;
using System.Threading.Tasks;
using Bamboo.Sharp.Api.Model;
using RestSharp;

namespace Bamboo.Sharp.Api.Services
{
    public class BuildService : BaseService
    {
        //Supported resources
        private const string GetBuildResource = "result?expand=results.result.jiraIssues";
        private const string GetBuildsResource = "result/{0}?expand=results.result.jiraIssues";

        //Base requests
        private readonly IRestRequest _baseGetBuildRequest = new RestRequest
        {
            Resource = GetBuildResource,
            RootElement = "results",
            Method = Method.GET
        };

        //Implemenations
        public Results GetBuilds()
        {
            return Client.Execute<Results>(_baseGetBuildRequest);
        }

        public async Task<Results> GetResultsAsync()
        {
            return await Client.ExecuteAsync<Results>(_baseGetBuildRequest);
        }

        public Results GetBuildsByPlanKey(string planKey)
        {
            IRestRequest GetBuildsRequest = new RestRequest
            {
                Resource = string.Format(GetBuildsResource, planKey),
                RootElement = "results",
                Method = Method.GET
            };

            return Client.Execute<Results>(GetBuildsRequest);
        }

        public async Task<Results> GetBuildsByPlanKeyAsync(string planKey)
        {
            IRestRequest GetBuildsRequest = new RestRequest
            {
                Resource = string.Format(GetBuildsResource, planKey),
                RootElement = "results",
                Method = Method.GET
            };

            return await Client.ExecuteAsync<Results>(GetBuildsRequest);;
        }
    }
}
