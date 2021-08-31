using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LFL.Automation.Framework.Hooks
{
    [Binding]
    public class Hooks
    {
        public IWebDriver WebDriver;
        public ScenarioContext scenarioContext;

        Hooks(IWebDriver webDriver, ScenarioContext context)
        {
            WebDriver = webDriver;
            scenarioContext = context;
        }
      
        [AfterScenario (Order = 0)]
        public void AfterScenario()
        {
            WebDriver.Close();
            WebDriver.Quit();
            WebDriver.Dispose();
        }

    }
}
