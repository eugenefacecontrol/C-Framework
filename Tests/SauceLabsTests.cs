using MyFramework.Pages.Google;
using MyFramework.Utils;
using NUnit.Framework;

namespace Tests
{
    public class SauceLabsTests : BaseTest
    {

        [Test]
        [TestCase("https://www.google.by")]
        public void SauceTest(string baseUrl)
        {
            Browser.GoTo(baseUrl);
            var googleHomePage = new GoogleHomePage();
            googleHomePage.SearchForSmth();
            
        }
    }
}
