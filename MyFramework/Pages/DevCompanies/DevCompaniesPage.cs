using System;
using MyFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages.DevCompanies
{
    public class DevCompaniesPage : BasePage
    {
        private readonly By allNames = By.XPath("//tbody/tr/td[1]/a");

        public void ClickEveryName()
        {
            var allNamesElements = Driver.FindElements(allNames);

            foreach(var element in allNamesElements)
            {
                Browser.ExecuteJs("window.open(arguments[0].href, '_blank')", element);
                var pageOfCompany = new PageOfCompany();
                pageOfCompany.GetContacts();
            }
            //a[0].Click();
        }
    }
}
