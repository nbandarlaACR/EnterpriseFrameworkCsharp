using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MobileApp.Pages
{
    class HomePage : BasePage
    {
        public IWebDriver driver { get; }
        public HomePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }       
        public By digit_2() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("com.google.android.calculator:id/digit_2") : By.XPath("//XCUIElementTypeButton[@name='Text Button']");
        public By digit_4() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("digit_4") : By.Id("digit_4");
        public By digit_6() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("digit_6") : By.Id("digit_6");
        public By equal() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("eq") : By.Id("eq");
        public By result() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("result_final") : By.Id("result_final");
        public By plus() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.XPath("//android.widget.Button[@content-desc='plus']") : By.XPath("//XCUIElementTypeTextField[@name='Text Input']");
        public By minus() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("com.google.android.calculator:id/op_sub") : By.Id("op_sub");
        public By next_btn() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("com.lowell.app.preprod.onboarding:id/onboarding_next_button") : By.Name("Next");
        public By register_btn() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("com.lowell.app.preprod.welcome:id/welcome_register_button") : By.Name("Register");
        public By register_text() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("com.lowell.app.preprod.registration:id/registration_register_account_heading") : ByAccessibilityId.AccessibilityId("First things first, let’s set up your account.");
        //public By login_btn() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? By.Id("com.lowell.app.preprod.welcome:id/welcome_log_in_cta") : ByAccessibilityId.AccessibilityId("First things first, let’s set up your account.");

        public By google_icon() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? ByAndroidUIAutomator.AndroidUIAutomator("new UiSelector().text('Chrome')") : ByAccessibilityId.AccessibilityId("First things first, let’s set up your account.");
        public By justOnce_btn() => GetDeviceType().Equals(DeviceType.ANDROID.ToString()) ? ByAndroidUIAutomator.AndroidUIAutomator("new UiSelector().text('Just once')") : ByAccessibilityId.AccessibilityId("First things first, let’s set up your account.");






        public String register_expected_text = "First things first, let’s set up your account";

        public void clickNext()
        {
            Click(driver, next_btn());

        }
        public void clickLogin() => Click(driver, login_btn());
        

        public void register()
        {
            Click(driver, register_btn());
            //WaitUntilTextTobePresent(driver, register_text(), register_expected_text);

        }

        public void performAddition()
        {
            Click(driver, digit_2());
            Click(driver, plus());
            Click(driver, digit_4());
            Click(driver, equal());
            
        }

        public void performSubtraction()
        {
            Click(driver, digit_6());
            Click(driver, minus());
            Click(driver, digit_4());
            Click(driver, equal());

            /* //wait(driver,getWebElement(driver,digit_1())).Click();
             //((AndroidDriver<AndroidElement>)driver).FindElementByAccessibilityId("plus").Click();            
             wait(getWebElement(plus)).Click();
             wait(getWebElement(digit_2)).Click();
             wait(getWebElement(equal)).Click();*/

        }

        public String verifyResult()
        {
            return GetText(driver,result());
        }

        public void verifyCommonElements()
        {           
            Click(driver, CommonLocator());
        }



    }
}

