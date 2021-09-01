using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LFL.Automation.Framework.GenericLib

{
    [Binding]
    public class LoadProperties
    {
        private static IConfigurationRoot _configuration;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [BeforeTestRun(Order = -100)]
        public static IConfigurationRoot getProjectProperties()
        {
            Console.WriteLine("Load properties section>>>>>>>>>>>>>>>>>>");
            var settingsFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "appsettings.*.json");
            if (settingsFiles.Length != 1) throw new Exception($"Expect to have exactly one properties settings file, but found {string.Join(", ", settingsFiles)}.");
            var settingsFile = settingsFiles.First();


            //Environment.SetEnvironmentVariable("platform", "web");

            var builder = new ConfigurationBuilder()
                //.SetBasePath
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile(settingsFiles.First())
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            _configuration = configuration;
            
            Console.WriteLine("Config platform :" + _configuration["platform"]);
            Console.WriteLine("Env var platform : " + Environment.GetEnvironmentVariable("platform"));

            var keys = builder.Build().AsEnumerable().ToList();

            foreach (var key in keys)
            {
                Console.WriteLine("Key is ==>" + key);
                Console.WriteLine("Key Key is ==>" + key.Key);
                Console.WriteLine("Key Value is ==>" + key.Value);
                if (Environment.GetEnvironmentVariable(key.Key) == "" || Environment.GetEnvironmentVariable(key.Key) == null)
                {
                    Environment.SetEnvironmentVariable(key.Key, key.Value);
                }
                Console.WriteLine("Environment Value is ==>" + Environment.GetEnvironmentVariable(key.Key));
             //   log.Info("Environment Value is ==>" + Environment.GetEnvironmentVariable(key.Key));
            }


           /* Console.WriteLine("<=======================================>");
            Console.WriteLine("GetEnvironmentVariables: ");
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                Console.WriteLine("Global Env Vars :  {0} = {1}", de.Key, de.Value);
*/
            return configuration;

        }
    }
}
