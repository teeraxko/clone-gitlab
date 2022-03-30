using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace PTB.BTS.Batch
{
    public static class EmailUtil
    {
        static SmtpClient smtpClient = null;
        private static void CreateSmtpClient()
        {
            smtpClient = new SmtpClient(CommonConfiguration.SmtpServer, CommonConfiguration.SmtpPort);
            if (!CommonConfiguration.UseDefaultCredentials)
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(CommonConfiguration.SmtpUsername, CommonConfiguration.SmtpPassword);
            }

            if (CommonConfiguration.SmtpEnableSSL)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;//tls1.2
            }

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public static void SendMail(string subject, string body, string[] toEmails, string[] ccEmails, string[] bccEmails, Attachment attachment)
        {
            CreateSmtpClient();
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(CommonConfiguration.SmtpUsername, CommonConfiguration.SmtpSenderDisplayName);
            if (toEmails!=null && toEmails.Length > 0)
            {
                mail.To.Add(String.Join(",",toEmails));
            }
            if (ccEmails!=null && ccEmails.Length > 0)
            {
                mail.CC.Add(String.Join(",", ccEmails));
            }
            if (bccEmails!=null && bccEmails.Length > 0)
            {
                mail.Bcc.Add(String.Join(",", bccEmails));
            }            

            mail.Subject = subject;

            body += Environment.NewLine;
            body += CommonConfiguration.CommonEmailFooter;
            mail.Body = body;            

            if (attachment != null)
            {
                mail.Attachments.Add(attachment);
            }

            mail.SubjectEncoding = Encoding.UTF8;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;

            smtpClient.Send(mail);

            if (attachment != null)
            {
                attachment.Dispose();
            }

            mail.Attachments.Clear();
        }

    }
}
