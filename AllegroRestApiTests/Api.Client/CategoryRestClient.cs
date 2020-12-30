using RestSharp;
using System;

namespace AllegroRestApiTests
{
    public class CategoryRestClient
    {
        private readonly RestClient _restClient;
        public static readonly string categoriesBasePath = "sale/categories";

        public CategoryRestClient(Configuration configuration)
        {
            configuration = new Configuration();
            _restClient = new RestClient(configuration.ApiPath);
        }

        public IRestResponse GetCategoryIds(string parentId, string token)
        {
            var request = new RestRequest(categoriesBasePath, Method.GET);
            AddRequestHeaders(request, token);
            AddCategoryRequestParam(parentId, request);
            return _restClient.Execute(request);
        }

        public IRestResponse GetCategory(string token, string resource)
        {
            var request = new RestRequest(categoriesBasePath + "/" + resource, Method.GET);
            AddRequestHeaders(request, token);
            return _restClient.Execute(request);
        }

        public IRestResponse GetWrongHeadersError(string token)
        {
            var request = new RestRequest(categoriesBasePath, Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+jsontest");
            return _restClient.Execute(request);
        }

        private static void AddRequestHeaders(RestRequest request, string token)
        {
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Accept", "application/vnd.allegro.public.v1+json");
        }

        private static void AddCategoryRequestParam(string parentId, RestRequest request)
        {
            if (!String.IsNullOrEmpty(parentId))
            {
                request.AddParameter("parent.id", parentId);
            }
        }
    }
}