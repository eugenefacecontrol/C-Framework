using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Client;
using MyFramework.Utils;
using NUnit.Framework;
using WorkItem = Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem;

namespace Tests.TfsTests
{
    public class TfsTests
    {
        private const string Url = "https://leaptestcompany.visualstudio.com";

        [Test]
        public void TfsTest()
        {
            var id = DateTime.Now.ToString("MMddHHmmss");
            var teamProjectCollection =
                TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
                    new Uri(Url));

            var workItemStore = teamProjectCollection.GetService<WorkItemStore>();

            var query = workItemStore.GetBugs();

            var allBugsCollection = query.RunQuery();

            var allBugsList = allBugsCollection.Cast<WorkItem>().ToList();
            var myBugs = allBugsList.Where(x => x.CreatedBy.Contains("Sheima")).ToList();

            using (var fs = new FileStream($@"C:\TableWithBugs\test{id}.html", FileMode.Create))
            {
                using (var w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<style>");
                    w.WriteLine("table,");
                    w.WriteLine("th,");
                    w.WriteLine("td {");
                    w.WriteLine("border: 1px solid black;");
                    w.WriteLine("}");
                    w.WriteLine("</style>");
                    w.WriteLine("<html>");
                    w.WriteLine("<body>");
                    w.WriteLine("<table>");
                    w.WriteLine("<tr>");
                    w.WriteLine("<th>Id</th>");
                    w.WriteLine("<th>Bug name</th>");
                    w.WriteLine("<th>Title</th>");
                    w.WriteLine("</tr>");
                    foreach (var bug in myBugs)
                    {
                        w.WriteLine("<tr>");
                        w.WriteLine($"<td>{bug.Id}</td>");
                        w.WriteLine($"<td>{bug.CreatedBy}</td>");
                        w.WriteLine($"<td>{bug.Title}</td>");
                        w.WriteLine("</tr>");
                    }
                    w.WriteLine("</table>");
                    w.WriteLine("</body>");
                    w.WriteLine("</html>");
                }
            }
        }

        [Test]
        public void RestExample()
        {
            var connection = new VssConnection(new Uri(Url), new VssClientCredentials());
            var witClient = connection.GetClient<WorkItemTrackingHttpClient>();
            var queryHierarchyItems = witClient.GetQueriesAsync("LeapTest", depth: 2).Result;
            var myQueriesFolder = queryHierarchyItems.FirstOrDefault(qhi => qhi.Name.Equals("My Queries"));
            if (myQueriesFolder != null)
            {
                var queryName = "REST Sample";
                QueryHierarchyItem newBugsQuery = null;
                if (myQueriesFolder.Children != null)
                {
                    newBugsQuery = myQueriesFolder.Children.FirstOrDefault(qhi => qhi.Name.Equals(queryName));
                }

                if (newBugsQuery == null)
                {
                    newBugsQuery = new QueryHierarchyItem()
                    {
                        Name = queryName,
                        Wiql = "SELECT * from issue where System.TeamProject = @project and System.WorkItemType = @type",
                        IsFolder = false
                    };
                    newBugsQuery = witClient.CreateQueryAsync(newBugsQuery, "LeapTest", myQueriesFolder.Name).Result;
                }
            }

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