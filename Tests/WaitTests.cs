using MyFramework.Pages.ToolsQA;
using MyFramework.Utils;
using NUnit.Framework;

namespace Tests
{
    public class WaitTests : BaseTest
    {
        [Test]
        public void WebDriverWaitUsage()
        {
            Browser.GoTo(TestSettings.BaseURL);
            var practicePage = new PracticePage();
            practicePage.WaitForBuzzWithWebDriverWait();
        }

        [Test]
        public void DefaultWaitUsage()
        {
            Browser.GoTo(TestSettings.BaseURL);
            var practicePage = new PracticePage();
            practicePage.WaitForBuzzWithDefaultWait();
        }
    }
}
