
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class ClienteService : IClienteService
    {
        private readonly IMapper _Mapper;
        private IClienteRepository _IClienteRepository;
        private ICorrelativoRepository _ICorrelativoRepository;

        public ClienteService(IClienteRepository clienteRepository, ICorrelativoRepository correlativoRepository, IMapper mapper)
        {
            _IClienteRepository = clienteRepository;

            _ICorrelativoRepository = correlativoRepository;

            _Mapper = mapper;



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
            Cliente cliente = _Mapper.Map<Cliente>(request);
            cliente.FechaRegistro = DateTime.Now;
            cliente.UsuarioRegistro = request.Usuario;
            cliente.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.Cliente);

            int affected = _IClienteRepository.Insertar(cliente);

            return affected;
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
