using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Commands
{
    public class AuthenticateUser : ICommand
    {
        public string Code { get; set; }
        public string Password { get; set; }
    }
}
