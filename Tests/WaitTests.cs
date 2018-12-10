using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShopByProject.Utils;

namespace ShopByTests
{
    public class WaitTests : BaseTest
    {
        [Test]
        public void WebDriverWaitUsage()
        {
            Browser.GoTo(TestSettings.BaseURL);

        }
    }
}
