﻿using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ShopByProject.Enums;
using ShopByProject.Utils;

namespace ShopByTests
{
    [TestFixture]
    public class BaseTest
    {

        public string Id { get; set; }

        [SetUp]
        public void SetUp()
        {
            Id = DateTime.Now.ToString("MMddHHmmss");
            BrowserInit(TestSettings.BrowserName);
        }

        [TearDown]
        public void CleanUp()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
                {
                    var name = $"{TestContext.CurrentContext.Test.Name} {Id}";
                    var screenShotFile = Browser.TakeScreenShot(name);
                    TestContext.AddTestAttachment(screenShotFile, name);
                }
            }
            finally
            {
                Browser.Close();
            }
        }

        public void BrowserInit(BrowserEnum browserName)
        {
            Browser.Init(browserName);
            Browser.SetImplicitWait(TestSettings.ImplicitTimeout);
        }

    }
}
