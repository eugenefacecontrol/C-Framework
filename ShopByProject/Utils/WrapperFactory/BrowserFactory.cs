using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ShopByProject.Enums;

namespace ShopByProject.Utils.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<BrowserEnum, IWebDriver>
            Drivers = new Dictionary<BrowserEnum, IWebDriver>();

        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    throw new NullReferenceException(
                        "The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                }

                return driver;
            }
            private set => driver = value;
        }

        public static void InitBrowser(BrowserEnum browserName)
        {
            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    if (Driver == null)
                    {
                        driver = new ChromeDriver();
                        Drivers.Add(BrowserEnum.Chrome, Driver);
                    }
                    break;
                case BrowserEnum.FireFox:
                    if (Driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add(BrowserEnum.FireFox, Driver);
                    }
                    break;
                case BrowserEnum.Grid:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserName), browserName, null);
            }
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}