using MyFramework.Pages.DevCompanies;
using MyFramework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests
{
    [Parallelizable(ParallelScope.Children)]
    public class DevCompanies : BaseTest
    {
        [Test]
        [TestCase("http://admin:admin@the-internet.herokuapp.com/basic_auth")]
        public void WebDriverWaitUsage(string baseUrl)
        {
            Browser.GoTo(baseUrl);
            var practicePage = new DevCompaniesPage();
            practicePage.ClickEveryName();
        }
    }
}
