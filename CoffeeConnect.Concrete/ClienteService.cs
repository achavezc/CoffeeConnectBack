
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using CoffeeConnect.Models.User;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGYM.Common;

namespace CoffeeConnect.Service
{
    public partial class ClienteService : IClienteService
    {
        private readonly IMapper _Mapper;
        private IClienteRepository _IClienteRepository;
        private IUsersService _IUsersService;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<ParametrosSettings> _ParametrosSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IEmpresaRepository _IEmpresaRepository;

        public ClienteService(IClienteRepository clienteRepository, IEmpresaRepository empresaRepository, IUsersService userService, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<ParametrosSettings> parametrosSettings, IWebHostEnvironment webHostEnvironment)
        {
            _IClienteRepository = clienteRepository;
            _IUsersService = userService;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
            _ParametrosSettings = parametrosSettings;
            _webHostEnvironment = webHostEnvironment;
            _IEmpresaRepository = empresaRepository;
        }


        public List<ConsultaClienteBE> ConsultarCliente(ConsultaClienteRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Cliente.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IClienteRepository.ConsultarCliente(request);
            return list.ToList();
        }

        public int RegistrarCliente(RegistrarActualizarClienteRequestDTO request)
        {
            int validarUsuario = _IUsersService.ValidarUsuario(request.CorreoElectronico);
            if (validarUsuario > 0)
            {
                throw new ResultException(new Result { ErrCode = "01", Message = "Ya existe un cliente con el mismo Email" });
            }
            Cliente cliente = _Mapper.Map<Cliente>(request);
            cliente.FechaRegistro = DateTime.Now;
            cliente.UsuarioRegistro = request.Usuario;
            cliente.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.Cliente);

            int clienteId = _IClienteRepository.Insertar(cliente);

            User user = new User();
            user.UserName = request.CorreoElectronico;
            user.FullName = request.RazonSocial;
            user.EmailId = request.CorreoElectronico;
            user.Password = cliente.Numero;
            user.CreatedDate = DateTime.Now;
            user.EmpresaId = request.EmpresaId;
            user.ClienteId = clienteId;
            user.Activo = 1;
            user.EstadoId = "01";
            
          
         
            int userId = _IUsersService.RegistrarUsuario(user);
            int rolId = int.Parse(_ParametrosSettings.Value.RoleId);
            int userRolId = _IUsersService.RegistrarRolUsuario(userId, rolId);

            EmailManager emailManager = new EmailManager();

            string pathPlantilla = String.Empty;
            string asunto = String.Empty;

            Empresa empresa= _IEmpresaRepository.ObtenerEmpresaPorId(request.EmpresaId);
            

            string correoFrom = _ParametrosSettings.Value.CorreoFrom;
            string logo = String.Empty;

            if (empresa!=null && !String.IsNullOrEmpty(empresa.CorreoFrom))
            {
                //correoFrom = empresa.CorreoFrom;
                logo = empresa.Logo;
            }            

            if (cliente.TipoClienteId == ClienteTipo.Nacional)
            {
                pathPlantilla = $"{this._webHostEnvironment.ContentRootPath}\\plantillas_correo\\bienvenidaES.html";
                asunto = "Bienvenido a Coffee Connect!";
            }
            else
            {
                pathPlantilla = $"{this._webHostEnvironment.ContentRootPath}\\plantillas_correo\\bienvenidaEN.html";
                asunto = "Welcome to Coffee Connect!";
            }
            //emailManager.SendEmail();
          

            string url = _ParametrosSettings.Value.UrlSistema;

            var responseTask = Task.Run(() => emailManager.SendEmailBienvenida(pathPlantilla, asunto, request.RazonSocial, request.CorreoElectronico, request.CorreoElectronico, cliente.Numero,url, correoFrom, "/assets/img/"+ logo)) ;

            return clienteId;
        }

        public int ActualizarCliente(RegistrarActualizarClienteRequestDTO request)
        {
            Cliente cliente = _Mapper.Map<Cliente>(request);
            cliente.FechaUltimaActualizacion = DateTime.Now;
            cliente.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _IClienteRepository.Actualizar(cliente);

            return affected;
        }

        public ConsultaClientePorIdBE ConsultarClientePorId(ConsultaClientePorIdRequestDTO request)
        {
            return _IClienteRepository.ConsultarClientePorId(request.ClienteId);
        }

        public int AnularCliente(AnularClienteRequestDTO request)
        {
            int result = 0;
            if (request.ClienteId > 0)
            {
                result = _IClienteRepository.Anular(request.ClienteId, DateTime.Now, request.Usuario, ClienteEstados.Anulado);
            }
            return result;
        }

    }
}
