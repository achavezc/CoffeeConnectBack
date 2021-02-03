using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Linq;
using Integracion.Deuda.Domain.DTO;
using System.Net;

namespace Core.Utils
{
    public class Mailer
    {
        string _host;
        int _port;
        bool _enabledSSL;
        bool _useDefaultCredentials;
        string _credentialsUser;
        string _credentialPassword;

        public Mailer(string host, int port, bool enabledSSL, bool useDefaultCredentials, string credentialsUser, string credentialsClave)
        {
            _host = host;
            _port = port;
            _enabledSSL = enabledSSL;
            _useDefaultCredentials = useDefaultCredentials;
            _credentialsUser = credentialsUser;
            _credentialPassword = credentialsClave;
        }
        
        public void Send(List<string> correosPara, string correoDe, List<string> correosCopia, List<string> correosCopiaOculta, string asunto, string cuerpo, List<Attachment> adjuntoList = null)
        {
            new Thread(() =>
            {
                if (!correosPara.Any())
                    return;

                Thread.CurrentThread.IsBackground = true;
                this.SendBackGround(correosPara, correoDe, correosCopia, correosCopiaOculta, asunto, cuerpo, adjuntoList);
            }).Start();
        }

        private void SendBackGround(List<string> correosPara, string correoDe, List<string> correosCopia, List<string> correosCopiaOculta, string asunto, string cuerpo, List<Attachment> adjuntoList = null)
        {
            if (!correosPara.Any())
                return;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(correoDe);
            mail.Body = cuerpo;
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            if (adjuntoList != null)
            {
                adjuntoList.ForEach(x => mail.Attachments.Add(x));
            }

            correosPara.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x))
                    mail.To.Add(x);
            });
            correosCopia.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x))
                    mail.CC.Add(x);
            });
            correosCopiaOculta.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x))
                    mail.Bcc.Add(x);
            });

            SmtpClient Cliente = new SmtpClient();

            Cliente.Host = _host;
            if (Convert.ToInt32(_port) > 0)
                Cliente.Port = Convert.ToInt32(_port);

            Cliente.EnableSsl = Convert.ToBoolean(_enabledSSL);
            Cliente.UseDefaultCredentials = Convert.ToBoolean(_useDefaultCredentials);
            if (Convert.ToBoolean(_useDefaultCredentials) == false)
                Cliente.Credentials = new NetworkCredential(_credentialsUser, _credentialPassword);
            try
            {
                Cliente.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
