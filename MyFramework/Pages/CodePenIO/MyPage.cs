using MyFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Pages.CodePenIO
{
    public class MyPage : BasePage
    {
        By buttonBy = By.CssSelector("html body button#target");
        By aboutUsBy = By.XPath("//*[@id='menu-item-314681']/a");
        By iframe = By.Id("result");

        public void DoubleClick()
        {
            Actions actions = new Actions(Driver);
            Browser.SwitchToFrame(Driver.FindElement(iframe));
            var button = Driver.FindElement(buttonBy);
            actions.DoubleClick(button).Perform();
            Driver.SwitchTo().Alert().Dismiss();
        }

        public void Scroll()
        {
            var aboutUs = Driver.FindElement(aboutUsBy);
            Browser.FocusOnElement(aboutUs);
            Console.WriteLine(aboutUs.Displayed);
        }
    }
}
