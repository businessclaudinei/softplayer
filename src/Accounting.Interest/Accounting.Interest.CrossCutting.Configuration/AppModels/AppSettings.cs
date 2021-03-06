﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Accounting.Interest.CrossCutting.Configuration.AppModels
{
    public class AppSettings
    {
        public static AppSettings Settings { get; } = GetAppSetingsFromFile();

        private static AppSettings GetAppSetingsFromFile()
        {
            AppSettings appSettings = null;
            using (StreamReader file = File.OpenText($"{AppDomain.CurrentDomain.BaseDirectory}appsettings.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                appSettings = (AppSettings)serializer.Deserialize(file, typeof(AppSettings));
            }
            return appSettings;
        }

        [JsonProperty("error")]
        public ErrorSettings Error { get; set; }

        [JsonProperty("appLocale")]
        public string AppLocale { get; set; }

        [JsonProperty("redisCacheSettings")]
        public RedisCacheSettings RedisCache { get; set; }

        [JsonProperty("serviceClients")]
        public IDictionary<string, ServiceClientSettings> ServiceClients { get; set; }
    }
}
