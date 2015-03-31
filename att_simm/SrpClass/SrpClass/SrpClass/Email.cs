using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SrpClass
{
    public class Email
    {
        /// <summary>
        /// Send a email
        /// </summary>
        /// <param name="body">The html used for the email</param>
        /// <param name="receiver">The person who will receive the email</param>
        /// <param name="subject">The subject of said email.</param>
        /// <param name="sender">The sender of said email.</param>
        /// <returns></returns>
        public static bool SendEmail(string body, string receiver, string subject, string sender)
        {
            //Example call:
            //string body = System.IO.File.ReadAllText(Server.MapPath("EmailTemplate/Offre-Exceptionnelle.html"));
            //body = body.Replace("%CONTENUTABLEAU%", "<tr><td>asdasd</td><td>asdasd</td><td>asdasdas</td></tr>");
            //Response.Write(functions.sendMail(body, "srobichaud@publi-web.net", "Test email"));
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(sender);
            msg.To.Add(receiver);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Send(msg);
            }
            catch
            {
                return false;
            }
            msg.Dispose();
            return true;
        }
    }
}
