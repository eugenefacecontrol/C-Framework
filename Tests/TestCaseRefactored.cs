using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    class TestSuite
    {
        private IWebDriver webDriver;

        public TestSuite()
        {
            var options = new ChromeOptions();
            var driverService = ChromeDriverService.CreateDefaultService(@"\\YauheniSheima\LEAPWORK\SeleniumCodeGenerator\Release\App_Data", "chromedriver.exe");
            webDriver = new ChromeDriver(driverService, options);
        }
        private void ValidatationMethod1()
        {
            webDriver.Navigate().GoToUrl("https://www.tut.by");
        }

        private void ValidatationMethod2()
        {
            var action2 = new OpenQA.Selenium.Interactions.Actions(webDriver);
            action2.ClickAndHold(webDriver.FindElement(By.XPath("//h1[@class=\"header-title\"]"))).Build().Perform();
        }

        [TestMethod]
        public void Execute()
        {
            //            ValidationMethod1();
        }
    }
}