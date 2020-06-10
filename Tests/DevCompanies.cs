using MyFramework.Pages.DevCompanies;
using MyFramework.Utils;
using NUnit.Framework;

namespace Tests
{
    [Parallelizable(ParallelScope.Children)]
    public class DevCompanies
    {
        [Test]
        [TestCase("https://companies.dev.by/")]
        public void WebDriverWaitUsage(string baseUrl)
        {
            Browser.Init(MyFramework.Enums.BrowserEnum.Chrome);
            Browser.GoTo(baseUrl);
            var practicePage = new DevCompaniesPage();
            practicePage.ClickEveryName();
        }
    }
}
