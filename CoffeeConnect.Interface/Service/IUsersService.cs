

using CoffeeConnect.DTO;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Service
{
    public interface IUsersService
    {
        LoginBE AuthenticateUsers(string username, string password);
    }
}