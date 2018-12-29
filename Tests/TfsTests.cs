using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            var id = DateTime.Now.ToString("MMddHHmmss");
            var teamProjectCollection =
                TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
                    new Uri("https://leaptestcompany.visualstudio.com"));

            var workItemStore = teamProjectCollection.GetService<WorkItemStore>();

            Query query = new Query(
                workItemStore,
                "select * from issue where System.TeamProject = @project and System.WorkItemType = @type",
                new Dictionary<string, string> { { "project", "LeapTest" }, { "type", "Bug" } }
            );

            var allBugsCollection = query.RunQuery();

            var allBugsList = allBugsCollection.Cast<WorkItem>().ToList();
            var myBugs = allBugsList.Where(x => x.CreatedBy.Contains("Sheima")).ToList();

            using (FileStream fs = new FileStream($@"c:\Users\Yauhe\test{id}.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<style>");
                    w.WriteLine("table,");
                    w.WriteLine("th,");
                    w.WriteLine("td {");
                    w.WriteLine("border: 1px solid black;");
                    w.WriteLine("}");
                    w.WriteLine("</style>");
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