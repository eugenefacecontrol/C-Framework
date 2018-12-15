using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Utils;
using NUnit.Framework;

namespace Tests
{
    public class SettigsChecker
    {
        [Test]
        public void CheckSettings()
        {
            Console.WriteLine(TestSettings.ExplicitTimeout);
            TestSettings.GetAllSettings();
        }
    }
}
