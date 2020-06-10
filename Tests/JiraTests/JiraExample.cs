using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Jira;
using NUnit.Framework;

namespace Tests.JiraTests
{
    public class JiraExample
    {
        [Test]
        public void TestJira()
        {
            Jira jiraConnection = Jira.CreateRestClient("https://leaptestcompany.visualstudio.com/", "ysh@leapwork.com", "Vsawewc!23");
            var myOpenBugs = GetMyOpenBugs();
            var jiraIssues = jiraConnection.Issues.Queryable;
            var issues = from i in jiraIssues
                         where i.Summary == new LiteralMatch("Studio: Browser stack Mac OS Iphone 8 doesn't work")
                select i;
        }

        static string GetAllBugs()
        {
            return "project = LW AND resolution = Unresolved ORDER BY priority DESC";
        }

        static string GetMyOpenBugs()
        {
            return "project = LW AND reporter = currentUser() ORDER BY created DESC";
        }
    }
}
