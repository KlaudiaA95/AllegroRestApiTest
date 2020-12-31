using Microsoft.Extensions.Configuration;
using System.IO;

namespace AllegroRestApiTests
{
    public class Configuration
    {
        private const string ConfigurationFile = "testsettings.json";
        protected IConfigurationRoot Config { get; }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ApiPath { get; set; }
        public string OAuthPath { get; set; }

        public Configuration()
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ConfigurationFile, true, true)
                .Build();

            ClientId = Config["ClientId"];
            ClientSecret = Config["ClientSecret"];
            ApiPath = Config["ApiPath"];
            OAuthPath = Config["OAuthPath"];
        }
    }
}