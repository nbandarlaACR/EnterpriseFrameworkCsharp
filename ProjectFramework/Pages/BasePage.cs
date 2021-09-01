using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LFL.Automation.Framework.Actions;

namespace MobileApp.Pages
{
    public class BasePage : Actions

    {
      
        public By CommonLocator() => GetDeviceType().Equals(DeviceType.ANDROID) ? By.Id("hamburger") : By.Id("hamburger");
        public readonly By acceptCookies_web = By.XPath("//div[@id='cookieConsent']/descendant::button");
        public readonly By linkFromDBSuccessMessage = By.XPath("//div[@class='alert alert-info']");
        public By login_btn() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("com.lowell.app.preprod.welcome:id/welcome_log_in_cta") : By.Name("Log in");

       

        public void AcceptCookies(IWebDriver driver)
        {
            try
            {
                Click(driver, acceptCookies_web);
            }
            catch (Exception e)
            {
                Console.WriteLine("Accpet cookies not found!" + e);
            }
        }              

    }
}
