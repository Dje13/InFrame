using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace InFrameTools
{

    /// <summary>
    /// 
    /// </summary>
    class MailSender : IDisposable
    {

        protected SmtpClient _smtpServer;

        protected string _mailFrom;
        protected string _mailFromName;
        protected bool _isMailFromInCopy;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smtpServerName"></param>
        /// <param name="smptUser"></param>
        /// <param name="smtpPassword"></param>
        /// <param name="mailFrom"></param>
        /// <param name="mailFromName"></param>
        /// <param name="smtpPort"></param>
        /// <param name="isMailFromInCopy"></param>
        public MailSender(string smtpServerName, string smptUser, string smtpPassword, string mailFrom, string mailFromName, int smtpPort = -1, bool isMailFromInCopy = true)
        {
            this._smtpServer = new SmtpClient(smtpServerName);
            if (smtpPort != -1)
            {
                this._smtpServer.Port = smtpPort;
            }
            this._smtpServer.Credentials =
            new System.Net.NetworkCredential(smptUser, smtpPassword);
            _mailFrom = mailFrom;
            _mailFromName = mailFromName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Recipient"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="body_format"></param>
        /// <param name="CC"></param>
        public void SendMail(string Recipient, string subject, string body, string body_format = "", string CC = "")
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(this._mailFrom, this._mailFromName);
            //mail.From = new MailAddress("DoNotReply@Eurofins.com", "Demand Board Automation");
            List<string> Dest = Recipient.Split(';').ToList();
            foreach (string curDest in Dest)
            {
                mail.To.Add(curDest);
            }
            if (!String.IsNullOrEmpty(CC))
            {
                List<string> CCs = CC.Split(';').ToList();
                foreach (string curCC in CCs)
                {
                    mail.CC.Add(curCC);
                }

            }
            if (this._isMailFromInCopy)
            {
                mail.CC.Add(this._mailFrom);
            }

            mail.Subject = subject;
            mail.Body = body;
            if (body_format == "HTML")
            {
                mail.IsBodyHtml = true;
            }
            this._smtpServer.Send(mail);
        }


        public void Dispose()
        {
            this._smtpServer.Dispose();
        }


    }
}
