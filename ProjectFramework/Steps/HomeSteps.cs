using MobileApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MobileApp.Steps
{
    [Binding]
    public class HomeSteps
    {
        public IWebDriver WebDriver;

        HomePage homePage => new HomePage(WebDriver);      
        
        HomeSteps(IWebDriver webDriver)
        {
            WebDriver = webDriver;            
        }

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            Console.WriteLine("In given statement");
        }

        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnyTwoNumbers(String num1, String num2)
        {
            homePage.performAddition();
           
            
        }

        [When(@"I subtract '(.*)' from '(.*)'")]
        public void WhenISubtractAnyTwoNumbers(String num1, String num2)
        {
            homePage.performSubtraction();

        }

        [Then(@"I should see result '(.*)'")]
        public void ThenIShouldSeeResult(String expectedResult)
        {           
           // Assert.AreEqual(homePage.verifyResult(), expectedResult);
        }

        [When(@"user has launched the app and click register")]
        public void launchApp()
        {
            /*AndroidDriver<AndroidElement> driver = ((AndroidDriver<AndroidElement>)WebDriver);
            Console.WriteLine("<================ Package before", driver.CurrentPackage);
            Console.WriteLine("<================ Acctivity before", driver.CurrentActivity);
            Thread.Sleep(2000);
            Console.WriteLine("Package After===============>", driver.CurrentPackage);
            Console.WriteLine("Acctivity After=============>", driver.CurrentActivity);
            //driver.Navigate().GoToUrl("https://www.youtube.com/");
            var contexts = ((IContextAware)driver).Contexts;
            string webviewContext = null;
            for (int i = 0; i < contexts.Count; i++)
            {
                Console.WriteLine(contexts[i]);
                if (contexts[i].Contains("WEBVIEW"))
                {
                    webviewContext = contexts[i];
                    break;
                }
            }
            driver.Context = webviewContext;
            driver.Navigate().GoToUrl("https://www.youtube.com/");*/


            homePage.clickNext();
            homePage.register();    

        }



        
    }
}
