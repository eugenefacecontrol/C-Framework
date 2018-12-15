using MyFramework.Pages.ToolsQA;
using MyFramework.Utils;
using NUnit.Framework;

namespace Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class WaitTests : BaseTest
    {
        [Test]
        [TestCase("http://toolsqa.wpengine.com/automation-practice-switch-windows/")]
        [TestCase("http://toolsqa.wpengine.com")]
        public void WebDriverWaitUsage(string baseUrl)
        {
            Browser.GoTo(TestSettings.BaseURL);
            var practicePage = new PracticePage();
            practicePage.WaitForBuzzWithWebDriverWait();
        }

        [Test]
        [TestCase("http://toolsqa.wpengine.com/automation-practice-switch-windows/")]
        [TestCase("http://toolsqa.wpengine.com")]
        public void DefaultWaitUsage(string baseUrl)
        {
            Browser.GoTo(baseUrl);
            var practicePage = new PracticePage();
            practicePage.WaitForBuzzWithDefaultWait();
        }
    }
}
