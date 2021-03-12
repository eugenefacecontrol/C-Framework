using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages.SalesForce
{
    public class SalesForceLoginPage : BasePage
    {
        private By InputUsername = By.XPath("//input[@aria-describedby=\"error\"]");
        private By InputPassPw = By.XPath("//input[@autocomplete=\"off\"]");
        private By InputSubmitLogin = By.XPath("//input[@class=\"button r4 wide primary\"]");

        public SalesForceUserPage LoginSalesForce()
        {
            var inputElements = Driver.FindElement(InputUsername);
            var InputPassPwElement = Driver.FindElement(InputPassPw);
            var InputSubmitLoginElement = Driver.FindElement(InputSubmitLogin);

            inputElements.Clear();
            inputElements.SendKeys("rga@leapwork.com");
            InputPassPwElement.Clear();
            InputPassPwElement.SendKeys("Leapwork%123");
            InputSubmitLoginElement.Click();
            return new SalesForceUserPage();
        }
    }
}
