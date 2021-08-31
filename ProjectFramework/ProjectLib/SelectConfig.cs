using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Autofac;
using Microsoft.Extensions.Logging;


namespace MobileApp.ProjectLib

{
    public class SelectConfig
    {
        public static SelectConfig selectConfig;
        private static IConfigurationRoot _configuration;
        public string path;
        public static IContainer _container;
        public static SelectConfig get()
        {

            if (selectConfig == null)
            {
                selectConfig = new SelectConfig();
            }
            return selectConfig;
        }
        public IConfigurationRoot getConfiguration()
        {
            string env = Environment.GetEnvironmentVariable("Environment");
            path = Directory.GetCurrentDirectory() + "\\Resources\\" + env + "\\";
           
            var settingsFiles = Directory.GetFiles(path, "BaseConfig.json");
            if (settingsFiles.Length != 1) throw new Exception($"Expect to have exactly one configuration-specfic settings file, but found {string.Join(", ", settingsFiles)}.");
            var settingsFile = settingsFiles.First();



            var builder = new ConfigurationBuilder()
                .AddJsonFile("BaseConfig.json", optional: true, reloadOnChange: true)
                .AddJsonFile(settingsFile)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            _configuration = configuration;
            
            return configuration;

        }
    }    
}
