using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.Models.User
{
    public class User
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int EmpresaId { get; set; }

        public int? ClienteId { get; set; }

        

    }
}
