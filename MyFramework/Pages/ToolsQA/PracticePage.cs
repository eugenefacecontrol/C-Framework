using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages.ToolsQA
{
    public class PracticePage : BasePage
    {
        private readonly By clockBy = By.Id("clock");

        public void WaitForBuzzWithWebDriverWait()
        {
            var waiter = new Func<IWebDriver, bool> (driver =>
            {
                var text = Driver.FindElement(clockBy).Text;
                if (text.Contains("Buzz"))
                {
                    return true;
                }
                Console.WriteLine($"Current time is : {text}");
                return false;
            });

            WebDriverWait.Until(waiter);
        }

        public void WaitForBuzzWithDefaultWait()
        {
            var clock = Driver.FindElement(clockBy);
            DefaultWait = new DefaultWait<IWebElement>(clock)
            {
                Timeout = TimeSpan.FromMinutes(2),
                PollingInterval = TimeSpan.FromSeconds(1)
            };

            var waiter = new Func<IWebElement, bool>(element =>
            {
                var text = element.Text;
                if (text.Contains("Buzz"))
                {
                    return true;
                }
                Console.WriteLine($"Current time is : {text}");
                return false;
            });

            DefaultWait.Until(waiter);
        }

    }
}
