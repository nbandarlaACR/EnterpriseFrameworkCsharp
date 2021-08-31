using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ProjectLib
{
    public class RunData : IRunData
    {
        private static IConfigurationRoot _configuration;

        public RunData()
        {
            _configuration = SelectConfig.get().getConfiguration();
        }

        public string AppURL => GetValue("URL");
        private static string GetValue(string key)
        {
            return _configuration[key];
        }
    }

    public interface IRunData
    {
        string AppURL { get; }
    }
}
