using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracion.Deuda.Domain.DTO
{
    public class MailServerSettings
    {
        public string From { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string EnableSsl { get; set; }
        public string UseDefaultCredentials { get; set; }
        public string CredentialsUser { get; set; }
        public string CredentialPassword { get; set; }
    }
}
