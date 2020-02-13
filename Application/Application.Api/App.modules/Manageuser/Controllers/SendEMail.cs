using System;
using System.Net.Mail;

namespace Application.Api.App.modules.Manageuser.Controllers
{
    public static class SendEMail
    {
        //sending mail
        public static void SendMail(string mailTo, string subject, string body)
        {
            string fromMail = "help.hmis@gmail.com";
            MailMessage message = new MailMessage(fromMail, mailTo, subject, body);
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";

            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment(@"C:\Users\v-gaguba\Documents\Attachment.txt");
            //message.Attachments.Add(attachment);

            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(fromMail, "Srichid@123");
            client.Send(message);
        }
        public static void SendMailToCCE(string mailTo, string subject, string body)
        {
            string fromMail = "help.hmis@gmail.com";
            MailMessage message = new MailMessage(fromMail, mailTo, subject, body);
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";

            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment(@"C:\Users\v-gaguba\Documents\Attachment.txt");
            //message.Attachments.Add(attachment);

            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(fromMail, "Srichid@123");
            client.Send(message);
        }
    }
}