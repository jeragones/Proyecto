using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace LAAG.App_Code

{
    public class MailService
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
                          "<p>Ingrese en el siguiente enlace para realizar su cambio de contraseña:</p>" +
                          "<p><a href=\"http://localhost:63714/\">Cambiar contraseña</a></p>";
<<<<<<< HEAD

            //for (int i = 101; i < 200; i++ )
            //{
                sendEmail(email, subject, body);
            //}
        }

        public void contactEmail(String email, String subject, String body) {
            body = "Responder al correo: <h3>"+email+"</h3><br><br><p>"+body+"</p>";
            sendEmail("labgronomico@gmail.com", subject, body);
        }
=======
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
>>>>>>> nspinozam
    }
}

