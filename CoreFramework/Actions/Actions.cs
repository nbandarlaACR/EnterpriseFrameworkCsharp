using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace LFL.Automation.Framework.Actions
{
    public class Actions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public enum DeviceType
        {
            ANDROID,
            IOS
        }

        public String GetDeviceType()
        {
            return Environment.GetEnvironmentVariable("deviceType").ToUpper();
        }

        public IWebElement WaitUntilElementClickable(IWebDriver driver, IWebElement webElement)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            return webDriverWait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }


        public Boolean WaitUntilTextTobePresent(IWebDriver driver, By by, String text)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            return webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(GetWebElement(driver, by), text));
        }

        public IWebElement WaitUntilElementVisible(IWebDriver driver, By by)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            return webDriverWait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public IWebElement GetWebElement(IWebDriver driver, By by)
        {
            return driver.FindElement(by);
        }
        public void Click(IWebDriver driver, By by)
        {
            try
            {
                IWebElement webElement = GetWebElement(driver, by);
                WaitUntilElementClickable(driver, webElement).Click();
                log.Debug("Successfully performed click operation on locator "+by.ToString());
            }
            catch (Exception ex)
            {
                log.Error("Failed to perform click operation on the locator " + by.ToString(),ex);
                throw new Exception(ex.Message);
                throw new Exception(ex.StackTrace);
            }
            
        }
        public void CheckBoxClick(IWebDriver driver, By by)
        {
            IWebElement webElement = GetWebElement(driver, by);
            try
            {
                webElement.Click();
            }
            catch (Exception e)
            {
                webElement.Click();
            }

        }
        public void SendKeys(IWebDriver driver, By by, String inputText)
        {
            WaitUntilElementVisible(driver, by).SendKeys(inputText);

        }
        public void SelectByVisibleText(IWebDriver driver, By by, String text)
        {
            WaitUntilElementVisible(driver, by);
            SelectElement select = new SelectElement(GetWebElement(driver, by));
            select.SelectByText(text);
        }

        public static void ScrollToTheBottom(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }


        public String GetText(IWebDriver driver, By by)
        {
            WaitUntilElementVisible(driver, by);
            return GetWebElement(driver, by).Text;
        }
    }
}
