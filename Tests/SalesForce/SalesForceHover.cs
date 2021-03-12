using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Jira;
using MyFramework.Pages.SalesForce;
using MyFramework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.SalesForce
{
    public class SalesForceHover : BaseTest
    {
        [Test]
        [TestCase("https://ap15.lightning.force.com/lightning/r/Account/0012v00002WZm26AAD/view")]
        public void SalesForce(string baseUrl)
        {
            Browser.GoTo(baseUrl);
            var practicePage = new SalesForceLoginPage();
            practicePage.LoginSalesForce().HoverName();
        }

        
        

        public void Execute()
        {
            
        }
	}
}
