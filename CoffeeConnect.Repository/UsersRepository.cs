using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using CoffeeConnect.DTO;
using CoffeeConnect.Models.User;

namespace CoffeeConnect.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public UsersRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }



        private string dataMenu = @"[
  {
    path: '',
    title: 'Productor.Label',
    icon: 'ft-home',
    class: 'has-sub',
    badge: '',
    badgeClass: '',
    isExternalLink: false,
    submenu: [
      {
        path: '',
        title: 'Productor.Operaciones.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/uikit/feather',
            title: 'Productor.Operaciones.RegistroActividades.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/uikit/font-awesome',
            title: 'Productor.Operaciones.RegistroCosechas.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      },
      {
        path: '',
        title: 'Productor.Administracion.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/uikit/feather',
            title: 'Productor.Administracion.Productor.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/uikit/font-awesome',
            title: 'Productor.Administracion.EntidadesCertificadoras.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/uikit/font-awesome',
            title: 'Productor.Administracion.MaestrosGenerales.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      }
    ]
  },
  {
    path: '',
    title: 'Acopio.Label',
    icon: 'ft-message-square',
    class: 'has-sub',
    badge: '',
    badgeClass: '',
    isExternalLink: false,
    submenu: [
      {
        path: '',
        title: 'Acopio.Operaciones.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/uikit/feather',
            title: 'Acopio.Operaciones.RecepcionMateriaPrima.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/uikit/font-awesome',
            title: 'Acopio.Operaciones.RecepcionProductoTerminado.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      },
      {
        path: '',
        title: 'Acopio.Administracion.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/uikit/feather',
            title: 'Acopio.Administracion.Proveedores.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/uikit/font-awesome',
            title: 'Acopio.Administracion.Terceros.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          },
          {
            path: '/uikit/font-awesome',
            title: 'Acopio.Administracion.MaestrosGenerales.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      }
    ]
  },
  {
    path: '',
    title: 'Planta.Label',
    icon: 'ft-home',
    class: 'has-sub',
    badge: '',
    badgeClass: '',
    isExternalLink: false,
    submenu: [
      {
        path: '',
        title: 'Planta.Operaciones.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          {
            path: '/uikit/feather',
            title: 'Planta.Operaciones.GuiaIngreso.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      },
      {
        path: '',
        title: 'Planta.Administracion.Label',
        icon: 'ft-arrow-right submenu-icon',
        class: 'has-sub',
        badge: '',
        badgeClass: '',
        isExternalLink: false,
        submenu: [
          
          {
            path: '/uikit/font-awesome',
            title: 'Planta.Administracion.MaestrosGenerales.Label',
            icon: 'ft-arrow-right submenu-icon',
            class: '',
            badge: '',
            badgeClass: '',
            isExternalLink: false,
            submenu: [
              
            ]
          }
        ]
      }
    ]
  },
{
    path: '',
    title: 'Exportador.Label',
    icon: 'ft-life-buoy',
    class: '',
    badge: '',
    badgeClass: '',
    isExternalLink: true,
    submenu: [
      
    ]
  },
{
    path: '',
    title: 'Transporte.Label',
    icon: 'ft-book',
    class: '',
    badge: '',
    badgeClass: '',
    isExternalLink: true,
    submenu: [
      
    ]
  }
]";
        //public LoginResponseViewModel GetUserDetailsbyCredentials(string username)
        //{
        //    try
        //    {
        //        var result = (from user in _context.Users
        //                      join userinrole in _context.UsersInRoles on user.UserId equals userinrole.UserId
        //                      where user.UserName == username

        //                      select new LoginResponseViewModel
        //                      {
        //                          UserId = user.UserId,
        //                          RoleId = userinrole.RoleId,
        //                          Status = user.Status,
        //                          UserName = user.UserName,
        //                          FullName = user.FullName
        //                      }).SingleOrDefault();

        //        if (result != null)
        //        {
        //            List<MenuViewModel> opciones = JsonConvert.DeserializeObject<List<MenuViewModel>>(dataMenu);

        //            result.Opciones = opciones;

        //            return result;
        //        }

        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



        public IEnumerable<Usuario> AuthenticateUsers(string username, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserName", username);
            parameters.Add("@Password", password);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<Usuario>("uspUsuarioValidarCredenciales", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<ConsultaOpcionesPorUsuario> ConsultarOpcionesPorUsuario(int usuarioId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("UserId", usuarioId);
          


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaOpcionesPorUsuario>("uspOpcionesPorUsuario", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public int Insertar(User user)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@UserName", user.UserName);
            parameters.Add("@FullName", user.FullName);
            parameters.Add("@EmailId", user.EmailId);
            parameters.Add("@Password", user.Password);
            parameters.Add("@CreatedDate", user.CreatedDate);
            parameters.Add("@EmpresaId", user.EmpresaId); 
            parameters.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspUserInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("UserId");

            return id;
        }

        public int InsertarRoles(int userId ,int userRolId)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@UserId", userId);
            parameters.Add("@RoleIdint", userRolId);
            
            parameters.Add("@UserRolesId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspUserRolesInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("UserRolesId");

            return id;
        }


    }
}
