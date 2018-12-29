using MyFramework.Pages.CodePenIO;
using MyFramework.Utils;
using NUnit.Framework;

namespace Tests
{
    public class DoubleClickTests : BaseTest
    {
        [Test]
        [TestCase("https://codepen.io/YaiheniSheima/full/BvQGJq")]
        public void TestDoubleClick(string baseUrl)
        {
            Browser.GoTo(baseUrl);
            var myPage = new MyPage();
            myPage.DoubleClick();
        }

        [Test]
        [TestCase("https://www.howtogeek.com/255653/how-to-find-your-chrome-profile-folder-on-windows-mac-and-linux/")]
        public void TestScroll(string baseUrl)
        {
            Browser.GoTo(baseUrl);
            var myPage = new MyPage();
            myPage.Scroll();
        }
    }
}
