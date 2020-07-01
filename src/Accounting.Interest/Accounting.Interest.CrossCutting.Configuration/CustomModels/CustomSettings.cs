using Newtonsoft.Json;
using System;
using System.IO;

namespace Accounting.Interest.CrossCutting.Configuration.CustomModels
{
    public class CustomSettings
    {
        public static CustomSettings Settings { get; } = GetAppSetingsFromFile();

        private static CustomSettings GetAppSetingsFromFile()
        {
            CustomSettings appSettings = null;
            using (StreamReader file = File.OpenText($"{AppDomain.CurrentDomain.BaseDirectory}customsettings.json"))
            {
                var serializer = new JsonSerializer();
                appSettings = (CustomSettings)serializer.Deserialize(file, typeof(CustomSettings));
            }
            return appSettings;
        }

        [JsonProperty("interest")]
        public InterestSettings Interest { get; set; }

        [JsonProperty("gitHubRepositoryUrl")]
        public string GitHubRepositoryUrl { get; set; }
    }
}
