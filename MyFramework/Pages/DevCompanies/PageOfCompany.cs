using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MyFramework.Pages.DevCompanies
{
    public class PageOfCompany : BasePage
    {
        private readonly By contacts = By.XPath("//div[@class = 'dev-right col2']/div[1]/div[1]/div[1]/ul[1]/li");

        public void GetContacts()
        {
            var waiter = new Func<IWebDriver, bool>(driver =>
            {
                var text = Driver.FindElement(contacts);
                if (text.Displayed)
                {
                    return true;
                }
                Console.WriteLine($"Current time is : {text}");
                return false;
            });

            WebDriverWait.Until(waiter);

            var a = Driver.FindElements(contacts);
            var post = a[0].Text;
            var phone = a[1].Text;
            var site = a[2].Text;
            Console.WriteLine($"Post: {post}, Phone: {phone}, Site: {site}");
        }
    }
}
