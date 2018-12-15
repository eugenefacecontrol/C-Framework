using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyFramework.Utils;
using OpenQA.Selenium;

namespace MyFramework.Pages.Google
{
    public class GoogleHomePage : BasePage
    {
        protected By searchFieldBy = By.Name("q");

        public void SearchForSmth()
        {
            var searchField = Driver.FindElement(searchFieldBy);
            searchField.SendKeys("Sauce labs");
            searchField.Submit();
            Thread.Sleep(TimeSpan.FromSeconds(TestSettings.ImplicitTimeout));
        }
    }
}
