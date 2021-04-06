using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class GuiaRemisionAlmacenService : IGuiaRemisionAlmacenService
    {
        private readonly IMapper _Mapper;
     

        private IGuiaRemisionAlmacenRepository _IGuiaRemisionAlmacenRepository;


        public GuiaRemisionAlmacenService(IGuiaRemisionAlmacenRepository IGuiaRemisionAlmacenRepository,
            IMapper mapper)
        {       
            _IGuiaRemisionAlmacenRepository = IGuiaRemisionAlmacenRepository;

            _Mapper = mapper;
        }




        public GenerarPDFGuiaRemisionResponseDTO GenerarPDFGuiaRemisionPorNotaSalidaAlmacenId(int notaSalidaAlmacenIdId)
        {
            GenerarPDFGuiaRemisionResponseDTO generarPDFGuiaRemisionResponseDTO = new GenerarPDFGuiaRemisionResponseDTO();

            ConsultaGuiaRemisionAlmacen consultaImpresionGuiaRemision = new ConsultaGuiaRemisionAlmacen();
            consultaImpresionGuiaRemision = _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenPorNotaSalidaAlmacenId(notaSalidaAlmacenIdId);

            List<ConsultaGuiaRemisionAlmacenDetalle> detalleGuiaRemision =  _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(consultaImpresionGuiaRemision.GuiaRemisionAlmacenId).ToList();

            detalleGuiaRemision.ForEach(z => {
                GuiaRemisionListaDetalle guiaRemisionListaDetalle = new GuiaRemisionListaDetalle();
                guiaRemisionListaDetalle.correlativo = 1;
                guiaRemisionListaDetalle.NumeroLote = z.NumeroLote;
                guiaRemisionListaDetalle.NotaIngreso = z.NumeroNotaIngreso;
                guiaRemisionListaDetalle.TipoProducto = z.Producto;
                guiaRemisionListaDetalle.UnidadMedida = z.UnidadMedida;
                guiaRemisionListaDetalle.Cantidad = z.CantidadPesado;
                guiaRemisionListaDetalle.PesoBruto = z.KilosNetosPesado;

                generarPDFGuiaRemisionResponseDTO.listaDetalleGM.Add(guiaRemisionListaDetalle);

            });

            CabeceraGuiaRemision cabeceraGuiaRemision = new CabeceraGuiaRemision();
            cabeceraGuiaRemision.RazonSocial = consultaImpresionGuiaRemision.RazonSocialEmpresa;
            cabeceraGuiaRemision.Direccion = consultaImpresionGuiaRemision.DireccionPartida;
            cabeceraGuiaRemision.Fecha = consultaImpresionGuiaRemision.FechaRegistro;
            cabeceraGuiaRemision.Ruc = consultaImpresionGuiaRemision.RucEmpresa;
            cabeceraGuiaRemision.Almacen = consultaImpresionGuiaRemision.Almacen;
            cabeceraGuiaRemision.Destinatario = consultaImpresionGuiaRemision.Destinatario;
            cabeceraGuiaRemision.RucDestinatario = consultaImpresionGuiaRemision.RucDestinatario;
            cabeceraGuiaRemision.DireccionPartida = consultaImpresionGuiaRemision.DireccionPartida;
            cabeceraGuiaRemision.DireccionDestino = consultaImpresionGuiaRemision.DireccionDestino;


            generarPDFGuiaRemisionResponseDTO.Cabecera.Add(cabeceraGuiaRemision);


            GuiaRemisionDetalle guiaRemisionDetalle = new GuiaRemisionDetalle();
            guiaRemisionDetalle.TotalLotes = consultaImpresionGuiaRemision.CantidadLotes;
            guiaRemisionDetalle.Rendimiento = consultaImpresionGuiaRemision.PromedioPorcentajeRendimiento;
            guiaRemisionDetalle.PorcentajeHumedad = consultaImpresionGuiaRemision.PromedioHumedadPorcentaje;
            guiaRemisionDetalle.CantidadTotal = consultaImpresionGuiaRemision.CantidadTotal;
            guiaRemisionDetalle.TotalKGBrutos = consultaImpresionGuiaRemision.PesoKilosBrutos;

            generarPDFGuiaRemisionResponseDTO.detalleGM.Add(guiaRemisionDetalle);

            GuiaRemisionListaDetalle guiaRemisionListaDetalle = new GuiaRemisionListaDetalle();



            if (consultaImpresionGuiaRemision != null)
            {
                consultaImpresionGuiaRemision.lstConsultaGuiaRemisionAlmacenDetalle = _IGuiaRemisionAlmacenRepository.ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(consultaImpresionGuiaRemision.GuiaRemisionAlmacenId);
            }

            return generarPDFGuiaRemisionResponseDTO;
        }
    }
}
