using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllegroRestApiTests
{
    public class OAuthTokenHelper
    {
        public static string GetToken(Configuration configuration)
        {
            var restclient = new RestClient(configuration.OAuthPath);
            RestRequest request = new RestRequest() { Method = Method.POST };
            string credentials = configuration.ClientId + ":" + configuration.ClientSecret;
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

            var response = restclient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response)["access_token"].ToString();
        }
    }
}