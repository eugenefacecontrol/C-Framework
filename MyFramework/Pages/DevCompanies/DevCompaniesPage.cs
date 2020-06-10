using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages.DevCompanies
{
    public class DevCompaniesPage : BasePage
    {
        private readonly By allNames = By.XPath("//tbody/tr/td[1]/a");

        public PageOfCompany ClickEveryName()
        {
            var a = Driver.FindElements(allNames);
            a[0].Click();
            return new PageOfCompany();
        }
    }
}
