using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CoreFramework.Hooks
{
    [Binding]
    public class Logging
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ScenarioContext _scenarioContext;

        //[BeforeTestRun(Order = -99)]
        public static void BeforTestRun()
        {
            string customPattern = null;
            string scenarioName = Environment.GetEnvironmentVariable("scenarioTag");
            if(scenarioName ==null || scenarioName.Equals(""))            
                scenarioName = "NOT_YET_CREATED";
            
                string browserName = Environment.GetEnvironmentVariable("browser");
                if (browserName == null || browserName.Equals(""))
                browserName = "NOT_YET_CREATED";
                string platformName = Environment.GetEnvironmentVariable("platformName");
                if(platformName == null || platformName.Equals(""))                
                    platformName = "NOT_YET_CREATED";

            customPattern = "Tag : " + scenarioName + " | " + " Platform : " + platformName + " | " + " Browser : " + browserName;

            log4net.ThreadContext.Properties["custompattern"] = customPattern;


            }

        //[BeforeScenario(Order = -98)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            string customPattern = null;
            customPattern = "Tag : " + scenarioContext.Get<string>("scenarioTag") + " | " + " Platform : " + Environment.GetEnvironmentVariable("platform") + " | " + " Browser : " + Environment.GetEnvironmentVariable("browser");
            log4net.LogicalThreadContext.Properties["customproperty"] = customPattern;
        }
        
        //[BeforeScenario(Order = -99)]
        public void FindScenarioTags(ScenarioContext scenarioContext)
        {
            scenarioContext.Add("scenarioTag", GetScenarioTag(scenarioContext));
            Environment.SetEnvironmentVariable("scenarioTag", GetScenarioTag(scenarioContext));
        }

        public string GetScenarioTag(ScenarioContext scenarioContext)
        {
            string scenario_tag = null;
            string[] scenarioTags = scenarioContext.ScenarioInfo.Tags;

            foreach(var scenarioTag in scenarioTags)
            {
                if (scenarioTag.Contains("test-"))
                {
                    scenario_tag = scenarioTag.Split("test-")[1];
                    break;
                }
            }
            if(scenario_tag == null)            
                scenario_tag = "TAG_NOT_CREATED";                 
            
            return scenario_tag;
        }
            
        
    }
}
