using LFL.Automation.Framework.GenericLib;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace CoreFramework.Hooks
{
    [Binding]
    public class SpecFlowReports
    {
        private IWebDriver _webDriver;
        private static string testResultsPath;
        private static string screenshotsPath;

        public ISpecFlowOutputHelper SpecFlowOutputHelper;
        public SpecFlowReports(IWebDriver webDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _webDriver = webDriver;
            SpecFlowOutputHelper = specFlowOutputHelper;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string basePath = Regex.Replace(System.AppContext.BaseDirectory.ToString(), "bin(.*)", "");
            testResultsPath = basePath + "TestResults\\";
            screenshotsPath = testResultsPath + "Screenshots\\";
            if (!Directory.Exists(testResultsPath))
            {
                Directory.CreateDirectory(testResultsPath);
            }
            if (!Directory.Exists(screenshotsPath))
            {
                Directory.CreateDirectory(screenshotsPath);
            }
            else
            {
                string[] files = Directory.GetFiles(screenshotsPath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
        }

       
        [AfterStep]
        public void TakeScreenshotAfterStep(ScenarioContext ScenarioContext)
        {            
            if(_webDriver is ITakesScreenshot takesScreenshot)
            {                  
                string path = screenshotsPath + "FailedScreenshot-" + Utilities.generateSixDigitRandomNumber() + ".png";
                if (Environment.GetEnvironmentVariable("TakeSuccessScreenshots").Equals("true"))
                {
                    if (ScenarioContext.TestError != null)
                    {
                        takesScreenshot.GetScreenshot().SaveAsFile(path);
                        SpecFlowOutputHelper.AddAttachment(path);
                        SpecFlowOutputHelper.WriteLine(ScenarioContext.TestError.Message);
                    }
                    else
                    {
                        takesScreenshot.GetScreenshot().SaveAsFile(path);
                        SpecFlowOutputHelper.AddAttachment(path);
                    }
                    
                }
                else
                {
                    if(ScenarioContext.TestError != null)
                    {
                        takesScreenshot.GetScreenshot().SaveAsFile(path);
                        SpecFlowOutputHelper.AddAttachment(path);
                        SpecFlowOutputHelper.WriteLine(ScenarioContext.TestError.Message);
                    }
                }
                
            }
        }
    }
}
