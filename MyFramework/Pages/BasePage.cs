using System;
using MyFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        protected WebDriverWait WebDriverWait;
        protected DefaultWait<IWebElement> DefaultWait;

        public BasePage()
        {
            Driver = Browser.WebDriver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TestSettings.ExplicitTimeout));
        }
    }
}
