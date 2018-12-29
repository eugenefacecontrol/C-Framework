using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using NUnit.Framework;

namespace Tests
{
    public class TfsTests
    {
        [Test]
        public void TfsTest()
        {
            var teamProjectCollection =
                TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
                    new Uri("https://leaptestcompany.visualstudio.com"));

            var workItemStore = teamProjectCollection.GetService<WorkItemStore>();

            Query query = new Query(
                workItemStore,
                "select * from issue where System.TeamProject = @project and System.WorkItemType = @type and System.CreatedDate = @date",
                new Dictionary<string, string> { { "project", "LeapTest" }, { "type", "Bug" }, {"date", DateTime.Now.ToString("d")} }
            );

            var itemCollection = query.RunQuery();
        }


        public static void SetWindowsCreds(string url, string username, string password)
        {
            var rdcProcess = new Process
            {
                StartInfo =
                {
                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                    Arguments = "/generic:[Add the URL]" + url + "/user:[Add Username]" + username +
                                " /pass:[Add Password]" + password
                }
            };
            rdcProcess.Start();
        }
    }
}