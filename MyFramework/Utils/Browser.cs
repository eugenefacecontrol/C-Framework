using System;
using System.IO;
using MyFramework.Enums;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;

namespace MyFramework.Utils
{
    public class Browser
    {
        [ThreadStatic] public static IWebDriver WebDriver;
        private static string DefaultDirectory => AppDomain.CurrentDomain.BaseDirectory;
        private const string RelativePath = @"..\..\..\MyFramework";
        private static readonly string UrlSauceLabs = $"https://ondemand.saucelabs.com:443/wd/hub";
        private static string Hub = "http://localhost:4444/wd/hub";

        public static void Init(BrowserEnum browserName)
        {
            var options = new ChromeOptions();
            var chromeDriverPath = Path.GetFullPath(Path.Combine(DefaultDirectory, RelativePath, @"Utils\Drivers"));
            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    WebDriver = new ChromeDriver(chromeDriverPath);
                    break;
                case BrowserEnum.FireFox:
                    WebDriver = new FirefoxDriver(chromeDriverPath);
                    break;
                case BrowserEnum.Grid:
                    options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
                    options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
                    WebDriver = new RemoteWebDriver(new Uri(Hub), options);
                    break;
                case BrowserEnum.SauceLabs:
                    options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
                    options.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows), true);
                    options.AddAdditionalCapability("username", TestSettings.SauceUsername, true);
                    options.AddAdditionalCapability("accessKey", TestSettings.SauceAccessKey, true);
                    options.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);

                    WebDriver = new RemoteWebDriver(new Uri(UrlSauceLabs), options.ToCapabilities());
                    break;
                case BrowserEnum.BrowserStack:
                    options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
                    options.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows), true);
                    options.AddAdditionalCapability("username", TestSettings.SauceUsername, true);
                    options.AddAdditionalCapability("accessKey", TestSettings.SauceAccessKey, true);
                    options.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
                    Console.WriteLine();
                    WebDriver = new RemoteWebDriver(new Uri(UrlSauceLabs), options.ToCapabilities());
                    break;
                default:
                    throw new Exception("Unknown browser!");
            }
            WebDriver.Manage().Window.Maximize();
        }

        public static void FocusOnElement(IWebElement element)
        {
            var action = new Actions(WebDriver);
            action.MoveToElement(element).Perform();
        }

        public static void GoTo(string url)
        {
            WebDriver.Url = url;
        }

        public static void Close()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }

        public static IWebDriver SwitchToFrame(IWebElement element) => WebDriver.SwitchTo().Frame(element);

        public static void SetImplicitWait(double seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static string TakeScreenShot(string testName)
        {
            var screenShotFile = Path.Combine(DefaultDirectory, RelativePath, $@"bin\Debug\{testName}.jpg");
            WebDriver.TakeScreenshot().SaveAsFile(screenShotFile, ScreenshotImageFormat.Png);
            return screenShotFile;
        }

        public static void ExecuteJs(string jsString, IWebElement element)
        {
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            var result = js?.ExecuteScript(jsString, element);
            Console.WriteLine(result);
        }

        public static void ExecuteJs(string jsString)
        {
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            var result = js?.ExecuteScript(jsString);
            Console.WriteLine(result);
        }

    }
}
