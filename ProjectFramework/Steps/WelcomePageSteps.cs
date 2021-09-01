using MobileApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace MobileApp.Steps
{
    [Binding]
    class WelcomePageSteps
    {
        private IWebDriver _webDriver;
        private WelcomePage welcomePage => new WelcomePage(_webDriver);
        WelcomePageSteps (IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Given(@"User is in welcome page of the application")]
        public void GivenILaunchTheApplication(Table table) => Assert.AreEqual(table.Rows[0]["WelcomeUserMessage"], welcomePage.GetWelcomeMessage());

        [When(@"User clicks login link")]
        public void ClickLoginLink() => welcomePage.ClickLoginLink();

        [Then(@"User should see okta signin button")]
        public void GetSignInText(Table table) => Assert.AreEqual(table.Rows[0]["SignInMessage"],welcomePage.GetOktaSignInText());

    }
}
