using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace LAAG.Controllers
{
    class MailService
    {
        static bool mailSent = false;

        private void sendEmail(String email, String subject, String body) {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("labgronomico@gmail.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body;

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("labgronomico@gmail.com", "Lab.Agro.123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            ////smtp.Host = "smtp.mail.yahoo.com"; // yahoo
            ////smtp.Host = "smtp.live.com"; // hotmail
            ////smtp.Host = "localhost"; // servidor local
            //smtp.Host = "smtp.gmail.com"; // gmail
            //smtp.EnableSsl = true;
        }

        public void registrationEmail(String email, String user, String password) 
        {
            String subject = "Registro de usuario en LAAG";
            String body = "<h1>Registro de usuario</h1><br>" +
                          "<p>Nombre de usuario: "+user+"</p>" +
                          "<p>Contraseña: " + password + "</p>" +
                          "<p>Ingrese en el siguiente enlace para iniciar sesión y utilizar nuestros servicios:</p>" +
                          "<p><a href=\"http://localhost:8080/Account/Login\">Iniciar Sesión</a></p>";
                          //"<p><a href=\"http://localhost:63714/\">Cambiar contraseña</a></p>";
            sendEmail(email, subject, body);
        }

        public void contactEmail(String email, String subject, String body) 
        {
            body = "Responder al correo: <h3>"+email+"</h3><br><br><p>"+body+"</p>";
            sendEmail("labgronomico@gmail.com", subject, body);
        }

        public void recoverUser(String email, String user, String password)
        {
            String subject = "Recuperación de contraseña";
            String body = "<b>Nombre de usuario: </b>" + user + "<br>" +
                          "<b>Contraseña: </b>"+ password;
            sendEmail(email, subject, body);
        }
    }
}
