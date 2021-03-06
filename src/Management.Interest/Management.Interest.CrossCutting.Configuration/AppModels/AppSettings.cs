﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace Management.Interest.CrossCutting.Configuration.AppModels
{
    public class AppSettings
    {
        public static AppSettings Settings { get; } = GetAppSetingsFromFile();

        private static AppSettings GetAppSetingsFromFile()
        {
            AppSettings appSettings = null;
            using (StreamReader file = File.OpenText($"{AppDomain.CurrentDomain.BaseDirectory}appsettings.json"))
            {
                var serializer = new JsonSerializer();
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
    }
}
