using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Senders
{
    public class EmailService
    {
        public string[] Cc { get; set; }
        public string[] Bcc { get; set; }
        public string FilePath { get; set; }
        public MessageStates MessageState { get; private set; }
        public string SenderMail { get; set; }
        public string Password { get; set; }
        public string Smtp { get; set; }
        public int SmtpPort { get; set; }

        public EmailService()
        {
            SenderMail = "wissenakademie.wm6@gmail.com";
            Password = "qweqweasdasd123";
            Smtp = "smtp.gmail.com";
            SmtpPort = 587;
        }
        public EmailService(string senderMail, string password, string smtp, int smtpPort)
        {
            SenderMail = senderMail;
            Password = password;
            Smtp = smtp;
            SmtpPort = smtpPort;
        }

        public async Task SendAsync(EmailModel message, params string[] contacts)
        {
            //var userID = _userId ?? "system";
            try
            {
                var mail = new MailMessage { From = new MailAddress(SenderMail) };
                if (!string.IsNullOrEmpty(FilePath))
                {
                    mail.Attachments.Add(new Attachment(FilePath));
                }
                foreach (var c in contacts)
                {
                    mail.To.Add(c);
                }
                if (Cc != null && Cc.Length > 0)
                {
                    foreach (var cc in Cc)
                    {
                        mail.CC.Add(new MailAddress(cc));
                    }
                }

                if (Bcc != null && Bcc.Length > 0)
                {
                    foreach (var bcc in Bcc)
                    {
                        mail.Bcc.Add(new MailAddress(bcc));
                    }
                }
                mail.Subject = message.Subject;
                mail.Body = message.Body;

                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.HeadersEncoding = Encoding.UTF8;

                var smptClient = new SmtpClient(Smtp, SmtpPort)
                {
                    Credentials = new NetworkCredential(SenderMail, Password),
                    EnableSsl = true
                };
                await smptClient.SendMailAsync(mail);
                MessageState = MessageStates.Delivered;
            }
            catch (Exception)
            {
                MessageState = MessageStates.NotDelivered;
            }

        }

        public void Send(EmailModel message, params string[] contacts)
        {
            Task.Run(async () =>
            {
                await SendAsync(message, contacts);
            });
        }

        public class EmailModel
        {
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Destination { get; set; }
        }
    }
    public enum MessageStates
    {
        NotDelivered,
        Delivered
    }
}