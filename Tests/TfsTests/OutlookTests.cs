using System;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace Tests.TfsTests
{
    public class OutlookTests
    {
        private Outlook.Application app;
        const string path = @"D:\TableWithBugs\test1230025835.html";

        [Test]
        public void OutlookTest()
        {
            app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "This is subject";
            mailItem.To = "ysh@leapwork.com";
            mailItem.HTMLBody = File.ReadAllText(path);
//            mailItem.Body = 
//            mailItem.Attachments.Add(path);
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Display(false);
            mailItem.Send();
        }

        [Test]
        public void SendMessageWithMail()
        {
            MailMessage msg = new MailMessage("zhenya113@mail.ru", "ysh@leapwork.com");
            msg.IsBodyHtml = true;
            msg.Subject = "Test subject";
            msg.Body = File.ReadAllText(path);

            SmtpClient mailClient = new SmtpClient("smtp.mail.ru", 993);
            mailClient.Send(msg);
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
