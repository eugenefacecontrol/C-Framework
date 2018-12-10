using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using ShopByProject.Enums;

namespace ShopByProject.Utils
{
    public static class Browser
    {
        public static IWebDriver WebDriver { get; private set; }
        private static string DefaultDirectory => AppDomain.CurrentDomain.BaseDirectory;
        private const string RelativePath = @"..\..\..\ShopByProject";

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
