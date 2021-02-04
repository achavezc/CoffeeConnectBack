using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using Newtonsoft.Json;

namespace CoffeeConnect.Service
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _UsersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _UsersRepository = usersRepository;
        }


        



        string dataMenu = @"[
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
            path: '/acopio/operaciones/guiarecepcionmateriaprima-list',
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

        public LoginBE AuthenticateUsers(string username, string password)
        {
            LoginBE loginDTO = new LoginBE();

            var usuariosList = _UsersRepository.AuthenticateUsers(username,  password);

            if (!usuariosList.Any())
                throw new ResultException(new Result { ErrCode = "02", Message = "Login.UsuarioPasswordIncorrecto" });

            
            var usuario = usuariosList.First();

            loginDTO.IdUsuario = usuario.UserId;
            loginDTO.NombreUsuario = usuario.UserName;
            loginDTO.NombreCompletoUsuario = usuario.FullName;

            var empresaList = _UsersRepository.ObtenerEmpresaPorId(usuario.EmpresaId);

            if (empresaList.Any())
            {
                var empresa = empresaList.First();
                loginDTO.RazonSocialEmpresa = empresa.RazonSocial;
                loginDTO.RucEmpresa = empresa.Ruc;
                loginDTO.DireccionEmpresa = empresa.Direccion;
                loginDTO.LogoEmpresa = empresa.Logo;
            }


            List<MenuBE> opciones = JsonConvert.DeserializeObject<List<MenuBE>>(dataMenu);

            loginDTO.Opciones = opciones;

            return loginDTO;           

        }
    }
}
