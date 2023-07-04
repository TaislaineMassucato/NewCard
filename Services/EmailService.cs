using System.Net;
using System.Net.Mail;

namespace NewCard.Services
{
    public class EmailService
    {
        public bool Send( 
            string toEmail,
            string toNome,           
            string subject,
            string body,
            string fromNome = "tatah .014",
            string fromEmail = "tahdonkshot@gmail.com")
        {
            var smtpCliente = new SmtpClient(Configuracao.Smtp.Host, Configuracao.Smtp.Port);

            smtpCliente.Credentials = new NetworkCredential(Configuracao.Smtp.UserName, Configuracao.Smtp.Password);
            smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpCliente.EnableSsl = true;

            var mail = new MailMessage();

            mail.From = new MailAddress(fromEmail, fromNome);
            mail.To.Add(new MailAddress(toEmail,toNome));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            try
            {
                smtpCliente.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
