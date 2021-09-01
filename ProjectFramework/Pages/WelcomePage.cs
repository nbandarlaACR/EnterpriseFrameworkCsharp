using LFL.Automation.Framework.Actions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Pages
{
    class WelcomePage : Actions
    {

        private IWebDriver _driver { get; }
        public WelcomePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        ////*************** PAGE OBJECTS ***************////
        ///
        private readonly By _welcomeMessage = By.Id("user_label");
        private readonly By _loginLink = By.LinkText("Login with ACR ID");
        private readonly By _okta_SignIn_Btn = By.XPath("//h2[@class='okta-form-title o-form-head']");


        ////*************** PAGE METHODS ***************////

        public string GetWelcomeMessage() => GetText(_driver,_welcomeMessage);
        public void ClickLoginLink() => Click(_driver, _loginLink);
        public string GetOktaSignInText() => GetText(_driver, _okta_SignIn_Btn);



    }
}
