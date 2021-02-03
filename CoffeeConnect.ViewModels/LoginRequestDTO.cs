using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
    public class LoginRequestDTO
    {
       public string UserName { get; set; }
       
        public string Password { get; set; }
        //public string Token { get; set; }
        //public int Usertype { get; set; }
    }


}
