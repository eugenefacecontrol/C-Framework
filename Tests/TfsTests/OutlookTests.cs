using System;
using System.IO;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace Tests.TfsTests
{
    public class OutlookTests
    {
        private Outlook.Application app;
        [Test]
        public void OutlookTest()
        {
            app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "This is subject";
            mailItem.To = "ysh@leapwork.com";
            const string path = @"D:\TableWithBugs\test1230030746.html";
            mailItem.Body = File.ReadAllText(path);
//            mailItem.Attachments.Add(path);
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Display(false);
            mailItem.Send();
        }

        [TearDown]
        public void QuitOutLook()
        {
            try
            {
//                app.Quit();
            }
            catch (COMException)
            {
                Console.WriteLine("Oooopsy");
            }
        }
    }
}
