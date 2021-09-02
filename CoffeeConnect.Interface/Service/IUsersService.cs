

using CoffeeConnect.DTO;
using CoffeeConnect.Models.User;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Service
{
    public interface IUsersService
    {
        LoginBE AuthenticateUsers(string username, string password);
        int RegistrarUsuario(User request);
        int RegistrarRolUsuario(int userId, int userRolId);
        int ValidarUsuario(string correo);
    }
}