using System;
using MyFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MyFramework.Pages.DevCompanies
{
    public class PageOfCompany : BasePage
    {
        private readonly By contacts = By.XPath("//div[@class = 'dev-right col2']/div[1]/div[1]/div[1]/ul[1]/li");
        private readonly By firmName = By.XPath("//h1");

        public void GetContacts()
        {
            var waiter = new Func<IWebDriver, bool>(driver =>
            {
                var text = Driver.FindElement(contacts).Text;
                if (!text.Contains("⋯"))
                {
                    return true;
                }
                Console.WriteLine($"Current time is : {text}");
//                Browser.Refresh();
                return false;
            });

            Browser.ChangeTab(1);
            WebDriverWait.Until(waiter);
            var a = Driver.FindElements(contacts);
            var name = Driver.FindElement(firmName);
            var post = a[0].Text;
            var phone = a[1].Text;
            var site = a[2].Text;
            Console.WriteLine($"{name.Text} Post: {post}, Phone: {phone}, Site: {site}");
            Browser.Close();
            Browser.ChangeTab(0);
        }
    }
}
