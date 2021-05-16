using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace SaludCloudV2.Models
{
    public class EnvioCorreo
    {
        public void Enviar(string Email)
        {
            MailMessage correo = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            correo.From = new MailAddress("e8094640621@gmail.com", "SaludCloud", System.Text.Encoding.UTF8);

            correo.To.Add(Email);
            correo.Subject = "Recuperar E-mail";
           // correo.Attachments.Add(new Attachment(Global.filePath));
            correo.Body = @"
                
                <p> Para actualizar tu Contraseña haz Clik en el siguiente enlace:"+ @"</b> </p>
                <p><b>http://localhost:60882/Login/ressetPass</b></p>
            
";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("e8094640621@gmail.com", "franklinp");
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
        }

    }
}