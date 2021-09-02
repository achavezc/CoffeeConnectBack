using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using CoffeeConnect.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<Usuario> AuthenticateUsers(string username, string password);

        IEnumerable<ConsultaOpcionesPorUsuario> ConsultarOpcionesPorUsuario(int usuarioId);
        int Insertar(User user);
        int InsertarRoles(int userId, int userRolId);
        IEnumerable<ConsultaRolesPorUsuario> ConsultarRolesPorUsuario(int usuarioId);
        int ValidarUsuario(string correo);
    }
}
