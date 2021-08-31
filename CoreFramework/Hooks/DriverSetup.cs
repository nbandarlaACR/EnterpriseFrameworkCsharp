using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using LFL.Automation.Framework.Hooks;
using OpenQA.Selenium.Safari;

[assembly : Parallelizable(ParallelScope.Fixtures)]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace LFL.Automation.Framework.Hooks
{
    
    [Binding]
    public class DriverSetup
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IObjectContainer _objectContainer;
        public IWebDriver WebDriver;
        public static IWebDriver desktopDriver;
        private String _testRunType = Environment.GetEnvironmentVariable("testrun");
        private String _platform = Environment.GetEnvironmentVariable("platform");
        private String _deviceType = Environment.GetEnvironmentVariable("deviceType");
        private String _bsUserName= Environment.GetEnvironmentVariable("bsUser");
        private String _bsKey = Environment.GetEnvironmentVariable("bsKey");
        private String _bsURL = Environment.GetEnvironmentVariable("bsURL");
        private String browser = Environment.GetEnvironmentVariable("browser");
        private static Uri appiumLocalServer = new Uri("http://127.0.01:4723/wd/hub");
        private AppiumOptions caps = null;
        private String _appURL = Environment.GetEnvironmentVariable("URL");


        public DriverSetup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        [BeforeScenario(Order = 0)]
        public void beforeScenario(IObjectContainer objectContainer)
        {
            Console.WriteLine("******************** Driver setup ************");
            log.Info("in driver setup before scenario");

            WebDriver = createDriverInstance();
            this._objectContainer.RegisterInstanceAs(WebDriver);

        }

        public IWebDriver createDriverInstance()
        {
            //log.Info("logging driversetup >>>>>>>>>>>");
            
            
                if (_platform.ToLower().Equals("web"))
                {
                    if (browser.ToLower().Equals("chrome"))
                    {
                        WebDriver = new ChromeDriver();
                    }
                    else if (browser.ToLower().Equals("firefox"))
                    {
                        WebDriver = new FirefoxDriver();
                    }
                    else { throw new Exception("No browser value selected in the properties.json file"); }
                WebDriver.Navigate().GoToUrl(_appURL);
                }
                else { throw new Exception("No platform value selected in the properties.json file"); }
            
            
            return WebDriver;

        }      
       
    }
}
