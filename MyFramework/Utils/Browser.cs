using System;
using System.IO;
using MyFramework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        private static string UserName = "EugeneFaceControl";
        private static string AccessKey = "78941e8d-bfad-4208-960d-aaced86db1b0";
        private static string Url = $"https://{UserName}:{AccessKey}@ondemand.saucelabs.com:443/wd/hub";
        private static string Hub = "http://localhost:4444/wd/hub";


        public static void Init(BrowserEnum browserName)
        {
            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    var chromeDriverPath = Path.GetFullPath(Path.Combine(DefaultDirectory, RelativePath, @"Utils\Drivers"));
                    WebDriver = new ChromeDriver(chromeDriverPath);
                    break;
                case BrowserEnum.FireFox:
                    break;
                case BrowserEnum.Grid:
                    WebDriver = new ChromeDriver();
                    DesiredCapabilities capabilities = new DesiredCapabilities();
                    capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
                    capabilities.SetCapability(CapabilityType.Version, "");
                    capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    WebDriver = new RemoteWebDriver(new Uri(Hub), capabilities);
                    break;
                case BrowserEnum.SauceLabs:
                    var options = new ChromeOptions();
                    options.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows), true);
                    options.AddAdditionalCapability(CapabilityType.Version, "", true);

                    WebDriver = new RemoteWebDriver(new Uri(Url), options);
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
