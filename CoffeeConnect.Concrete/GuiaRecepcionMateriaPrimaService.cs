﻿
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class GuiaRecepcionMateriaPrimaService : IGuiaRecepcionMateriaPrimaService
    {
       
        private IGuiaRecepcionMateriaPrimaRepository _IGuiaRecepcionMateriaPrimaRepository;
       
        public GuiaRecepcionMateriaPrimaService(IGuiaRecepcionMateriaPrimaRepository guiaRecepcionMateriaPrima)
        {
            _IGuiaRecepcionMateriaPrimaRepository = guiaRecepcionMateriaPrima;          
        }
        public List<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO request)       
        {           
            if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.CodigoSocio) && string.IsNullOrEmpty(request.NombreRazonSocial)) 
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionSeleccioneMinimoUnFiltro.Label" });

          
            var timeSpan = request.FechaFin - request.FechaInicio;

            if(timeSpan.Days>730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionRangoFechaMayor2anios.Label" });


            if (string.IsNullOrEmpty(request.Numero) && string.IsNullOrEmpty(request.NumeroDocumento) && string.IsNullOrEmpty(request.CodigoSocio) && string.IsNullOrEmpty(request.NombreRazonSocial))
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.GuiaRecepcionMateriaPrima.ValidacionSeleccioneMinimoUnFiltro.Label" });



            var list = _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrima(request);
            
            return list.ToList();
        }

       
        public int AnularGuiaRecepcionMateriaPrima(AnularGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            int affected = _IGuiaRecepcionMateriaPrimaRepository.AnularGuiaRecepcionMateriaPrima(request.GuiaRecepcionMateriaPrimaId,DateTime.Now,request.Usuario, GuiaRecepcionMateriaPrimaEstados.Anulado);

            return affected;
        }


        public ConsultaGuiaRecepcionMateriaPrimaPorIdBE ConsultarGuiaRecepcionMateriaPrimaPorId(ConsultaGuiaRecepcionMateriaPrimaPorIdRequestDTO request)
        {
            return _IGuiaRecepcionMateriaPrimaRepository.ConsultarGuiaRecepcionMateriaPrimaPorId(request.GuiaRecepcionMateriaPrimaId);            
        }

        public int RegistrarGuiaRecepcionMateriaPrima(RegistrarGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima = new GuiaRecepcionMateriaPrima();
            
            guiaRecepcionMateriaPrima.EmpresaId = request.EmpresaId;
            guiaRecepcionMateriaPrima.Numero = request.Numero;
            guiaRecepcionMateriaPrima.TipoProvedorId = request.TipoProvedorId;
            guiaRecepcionMateriaPrima.SocioId = request.SocioId;
            guiaRecepcionMateriaPrima.TerceroId = request.TerceroId;
            guiaRecepcionMateriaPrima.IntermediarioId = request.IntermediarioId;
            guiaRecepcionMateriaPrima.ProductoId = request.ProductoId;
            guiaRecepcionMateriaPrima.SubProductoId = request.SubProductoId;
            guiaRecepcionMateriaPrima.FechaCosecha = request.FechaCosecha;
            guiaRecepcionMateriaPrima.FechaPesado = DateTime.Now;
            guiaRecepcionMateriaPrima.UsuarioPesado = request.UsuarioPesado;
            guiaRecepcionMateriaPrima.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            guiaRecepcionMateriaPrima.CantidadPesado = request.CantidadPesado;
            guiaRecepcionMateriaPrima.KilosBrutosPesado = request.KilosBrutosPesado;
            guiaRecepcionMateriaPrima.TaraPesado = request.TaraPesado;
            guiaRecepcionMateriaPrima.ObservacionPesado = request.ObservacionPesado;
            guiaRecepcionMateriaPrima.EstadoId = GuiaRecepcionMateriaPrimaEstados.Pesado;
            guiaRecepcionMateriaPrima.FechaRegistro = DateTime.Now;
            guiaRecepcionMateriaPrima.UsuarioRegistro = request.UsuarioPesado;  

            int affected = _IGuiaRecepcionMateriaPrimaRepository.Insert(guiaRecepcionMateriaPrima);

            return affected;
        }

    }
}
