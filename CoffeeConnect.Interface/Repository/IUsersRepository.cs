using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<Usuario> AuthenticateUsers(string username, string password);

        
    }
}
