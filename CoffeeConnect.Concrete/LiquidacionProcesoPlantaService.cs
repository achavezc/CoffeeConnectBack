﻿using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using CoffeeConnect.Service.Adjunto;
using Core.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class LiquidacionProcesoPlantaService : ILiquidacionProcesoPlantaService
    {
        private readonly IMapper _Mapper;
        private ILiquidacionProcesoPlantaRepository _ILiquidacionProcesoPlantaRepository;
        private INotaIngresoProductoTerminadoAlmacenPlantaRepository _INotaIngresoProductoTerminadoAlmacenPlantaRepository;
        private IOrdenProcesoPlantaRepository _IOrdenProcesoPlantaRepository;
        public IOptions<FileServerSettings> _fileServerSettings;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IMaestroRepository _IMaestroRepository;


        public LiquidacionProcesoPlantaService(ILiquidacionProcesoPlantaRepository LiquidacionProcesoPlantaRepository, INotaIngresoProductoTerminadoAlmacenPlantaRepository NotaIngresoProductoTerminadoAlmacenPlantaRepository, IOrdenProcesoPlantaRepository OrdenProcesoPlantaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings, IMaestroRepository maestroRepository)
        {
            _ILiquidacionProcesoPlantaRepository = LiquidacionProcesoPlantaRepository;
            _Mapper = mapper;
            _fileServerSettings = fileServerSettings;
            _IOrdenProcesoPlantaRepository = OrdenProcesoPlantaRepository;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = maestroRepository;
            _INotaIngresoProductoTerminadoAlmacenPlantaRepository = NotaIngresoProductoTerminadoAlmacenPlantaRepository;
        }

        public List<ConsultaLiquidacionProcesoPlantaBE> ConsultarLiquidacionProcesoPlanta(ConsultaLiquidacionProcesoPlantaRequestDTO request)
        {
            //var timeSpan = request.FechaFin - request.FechaInicio;

           /* if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Contrato.ValidacionRangoFechaMayor2anios.Label" });*/

            var list = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlanta(request);

            // obtener certificaciones
            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId, String.Empty).ToList();
            List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacionPlanta")).ToList();

            foreach (ConsultaLiquidacionProcesoPlantaBE obj in list)
            {
                

                string[] certificacionesIds = obj.CertificacionId.Split('|');
                string certificacionLabel = string.Empty;
                if (certificacionesIds.Length > 0)
                {                   
                    foreach (string certificacionId in certificacionesIds)
                    {
                        ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();
                        if (certificacion != null)
                        {
                            certificacionLabel = certificacionLabel + certificacion.Label + " ";
                        }
                    }
                }

                // obtener certificaciones
                obj.Certificacion = certificacionLabel;
            }



            return list.ToList();
        }

        public int RegistrarLiquidacionProcesoPlanta(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request)
        {
            string correlativo = "";
            string motivoIngresoAlmacenId = "";



            LiquidacionProcesoPlanta liquidacionProcesoPlanta = _Mapper.Map<LiquidacionProcesoPlanta>(request);
            liquidacionProcesoPlanta.FechaRegistro = DateTime.Now;
            liquidacionProcesoPlanta.UsuarioRegistro = request.Usuario;
            
            

            ConsultaOrdenProcesoPlantaPorIdBE consultaOrdenProcesoPlantaPorIdBE =_IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaPorId(request.OrdenProcesoPlantaId);

            if (consultaOrdenProcesoPlantaPorIdBE.TipoProcesoId == "01") //Transformacion
            {
                liquidacionProcesoPlanta.ProductoId = consultaOrdenProcesoPlantaPorIdBE.ProductoId;
                correlativo = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.LiquidacionProcesoPlanta);
                motivoIngresoAlmacenId = NotaIngresoAlmacenPlantaMotivos.LiquidacionOrdenProceso; // Liquidacion Proceso
            }
            else if (consultaOrdenProcesoPlantaPorIdBE.TipoProcesoId == "02") //Secado
            {
                liquidacionProcesoPlanta.ProductoId = consultaOrdenProcesoPlantaPorIdBE.ProductoId;
                correlativo = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.LiquidacionSecadoPlanta);
                motivoIngresoAlmacenId = NotaIngresoAlmacenPlantaMotivos.LiquidacionProcesoSecado; // Liquidación Proceso Secado
            }
            else if (consultaOrdenProcesoPlantaPorIdBE.TipoProcesoId == "03") //Reproceso
            {
                liquidacionProcesoPlanta.ProductoId = ProductoTipo.Exportacion;
                correlativo = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.LiquidacionReprocesoPlanta);
                motivoIngresoAlmacenId = NotaIngresoAlmacenPlantaMotivos.LiquidacionReproceso; // Liquidación Reproceso
            }

            liquidacionProcesoPlanta.Numero = correlativo;

            
            liquidacionProcesoPlanta.ProductoIdTerminado = consultaOrdenProcesoPlantaPorIdBE.ProductoIdTerminado;
            liquidacionProcesoPlanta.EntidadCertificadoraId = consultaOrdenProcesoPlantaPorIdBE.EntidadCertificadoraId;
            liquidacionProcesoPlanta.FechaInicioProceso = consultaOrdenProcesoPlantaPorIdBE.FechaInicioProceso.Value;
            //liquidacionProcesoPlanta.FechaFinProceso = DateTime.Now;
            liquidacionProcesoPlanta.FechaFinProceso = request.FechaFinProceso;
            liquidacionProcesoPlanta.TipoId = consultaOrdenProcesoPlantaPorIdBE.TipoId;
            liquidacionProcesoPlanta.EmpaqueId = consultaOrdenProcesoPlantaPorIdBE.EmpaqueId;
            liquidacionProcesoPlanta.CertificacionId = consultaOrdenProcesoPlantaPorIdBE.CertificacionId;

            int LiquidacionProcesoPlantaId = _ILiquidacionProcesoPlantaRepository.Insertar(liquidacionProcesoPlanta);

            _IOrdenProcesoPlantaRepository.ActualizarEstadoLiquidado(request.OrdenProcesoPlantaId, DateTime.Now, request.Usuario, OrdenProcesoPlantaEstados.Liquidado, request.FechaFinProceso);

            foreach (LiquidacionProcesoPlantaDetalle detalle in request.LiquidacionProcesoPlantaDetalle)
            {

                detalle.LiquidacionProcesoPlantaId = LiquidacionProcesoPlantaId;
                _ILiquidacionProcesoPlantaRepository.InsertarLiquidacionProcesoPlantaDetalle(detalle);
            }

            foreach (LiquidacionProcesoPlantaResultado detalle in request.LiquidacionProcesoPlantaResultado)
            {
                //if((detalle.CantidadSacos.HasValue && detalle.CantidadSacos.Value != 0) || (detalle.KilosNetos.HasValue && detalle.KilosNetos!=0))
                //if (detalle.KilosNetos.HasValue && detalle.KilosNetos.Value >0)
                //{
                    detalle.LiquidacionProcesoPlantaId = LiquidacionProcesoPlantaId;
                    _ILiquidacionProcesoPlantaRepository.InsertarLiquidacionProcesoPlantaResultado(detalle);

                

                if (detalle.KilosNetos.HasValue && detalle.KilosNetos.Value > 0)
                {
                    NotaIngresoProductoTerminadoAlmacenPlanta notaIngresoProductoTerminadoAlmacenPlanta = new NotaIngresoProductoTerminadoAlmacenPlanta();
                    notaIngresoProductoTerminadoAlmacenPlanta.LiquidacionProcesoPlantaId = LiquidacionProcesoPlantaId;
                    notaIngresoProductoTerminadoAlmacenPlanta.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.NotaIngresoProductoTerminadoAlmacenPlanta);

                    if (consultaOrdenProcesoPlantaPorIdBE.TipoProcesoId == "03") //Reproceso
                    {
                        notaIngresoProductoTerminadoAlmacenPlanta.ProductoId = ProductoTipo.Exportacion;
                    }
                    else
                    {
                        notaIngresoProductoTerminadoAlmacenPlanta.ProductoId = consultaOrdenProcesoPlantaPorIdBE.ProductoIdTerminado;
                    }
                    notaIngresoProductoTerminadoAlmacenPlanta.SubProductoId = detalle.ReferenciaId;
                    notaIngresoProductoTerminadoAlmacenPlanta.Cantidad = detalle.CantidadSacos.HasValue ? detalle.CantidadSacos.Value : 0;
                    notaIngresoProductoTerminadoAlmacenPlanta.KilosNetos = detalle.KilosNetos.HasValue ? detalle.KilosNetos.Value : 0;
                    notaIngresoProductoTerminadoAlmacenPlanta.KilosBrutos = detalle.KilosBrutos.HasValue ? detalle.KilosBrutos.Value : 0;

                    if (consultaOrdenProcesoPlantaPorIdBE.TipoProcesoId != "02") //Secado
                    {
                        notaIngresoProductoTerminadoAlmacenPlanta.KGN = detalle.KGN.HasValue ? detalle.KGN.Value : 0;
                    }
                    
                    string AlmacenId = "02"; // Almacen 2 (Productos Terminados);

                    if(detalle.ReferenciaId == "14") //CASCARILLA - MERMA
                    {
                        AlmacenId = "04"; //	Almacen 4 (Merma-cascarilla)
                    }

                    //TiposCafeProcesado	14	CASCARILLA - MERMA

                    notaIngresoProductoTerminadoAlmacenPlanta.MotivoIngresoId = motivoIngresoAlmacenId;  
                    notaIngresoProductoTerminadoAlmacenPlanta.TipoId = detalle.TipoId;
                    notaIngresoProductoTerminadoAlmacenPlanta.EmpaqueId = detalle.EmpaqueId;
                    notaIngresoProductoTerminadoAlmacenPlanta.EmpresaId = request.EmpresaId;
                    notaIngresoProductoTerminadoAlmacenPlanta.EstadoId = NotaIngresoProductoTerminadoAlmacenPlantaEstados.Ingresado;
                    notaIngresoProductoTerminadoAlmacenPlanta.FechaRegistro = DateTime.Now;
                    notaIngresoProductoTerminadoAlmacenPlanta.UsuarioRegistro = request.Usuario;
                    notaIngresoProductoTerminadoAlmacenPlanta.AlmacenId = AlmacenId; 

                    _INotaIngresoProductoTerminadoAlmacenPlantaRepository.Insertar(notaIngresoProductoTerminadoAlmacenPlanta);
                }
                //}

            }
            return LiquidacionProcesoPlantaId;
        }

        public int ActualizarLiquidacionProcesoPlanta(RegistrarActualizarLiquidacionProcesoPlantaRequestDTO request)
        {
            LiquidacionProcesoPlanta liquidacionProcesoPlanta = _Mapper.Map<LiquidacionProcesoPlanta>(request);



            liquidacionProcesoPlanta.FechaUltimaActualizacion = DateTime.Now;
            liquidacionProcesoPlanta.UsuarioUltimaActualizacion = request.Usuario;

            ConsultaOrdenProcesoPlantaPorIdBE consultaOrdenProcesoPlantaPorIdBE = _IOrdenProcesoPlantaRepository.ConsultarOrdenProcesoPlantaPorId(request.OrdenProcesoPlantaId);
            liquidacionProcesoPlanta.ProductoId = consultaOrdenProcesoPlantaPorIdBE.ProductoId;
            liquidacionProcesoPlanta.ProductoIdTerminado = consultaOrdenProcesoPlantaPorIdBE.ProductoIdTerminado;
            liquidacionProcesoPlanta.EntidadCertificadoraId = consultaOrdenProcesoPlantaPorIdBE.EntidadCertificadoraId;
            liquidacionProcesoPlanta.FechaInicioProceso = consultaOrdenProcesoPlantaPorIdBE.FechaInicioProceso.Value;
            //liquidacionProcesoPlanta.FechaFinProceso = DateTime.Now;
            liquidacionProcesoPlanta.FechaFinProceso = request.FechaFinProceso;
            liquidacionProcesoPlanta.EmpaqueId = consultaOrdenProcesoPlantaPorIdBE.EmpaqueId;
            liquidacionProcesoPlanta.TipoId = consultaOrdenProcesoPlantaPorIdBE.TipoId;

            int affected = _ILiquidacionProcesoPlantaRepository.Actualizar(liquidacionProcesoPlanta);

            _ILiquidacionProcesoPlantaRepository.EliminarLiquidacionProcesoPlantaDetalle(liquidacionProcesoPlanta.LiquidacionProcesoPlantaId);


            foreach (LiquidacionProcesoPlantaDetalle detalle in request.LiquidacionProcesoPlantaDetalle)
            {
                detalle.LiquidacionProcesoPlantaId = request.LiquidacionProcesoPlantaId;
                _ILiquidacionProcesoPlantaRepository.InsertarLiquidacionProcesoPlantaDetalle(detalle);
            }

            _ILiquidacionProcesoPlantaRepository.EliminarLiquidacionProcesoPlantaResultado(liquidacionProcesoPlanta.LiquidacionProcesoPlantaId);


            foreach (LiquidacionProcesoPlantaResultado detalle in request.LiquidacionProcesoPlantaResultado)
            {
                detalle.LiquidacionProcesoPlantaId = request.LiquidacionProcesoPlantaId;
                _ILiquidacionProcesoPlantaRepository.InsertarLiquidacionProcesoPlantaResultado(detalle);
            }

            return affected;
        }

        public ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        {
            ConsultaLiquidacionProcesoPlantaPorIdBE consultaLiquidacionProcesoPlantaPorIdBE = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaPorId(request.LiquidacionProcesoPlantaId);
            //consultaLiquidacionProcesoPlantaPorIdBE.Preparacion = consultaLiquidacionProcesoPlantaPorIdBE.ProductoTerminado + " - " + consultaLiquidacionProcesoPlantaPorIdBE.SubProductoTerminado + " - " + consultaLiquidacionProcesoPlantaPorIdBE.Calidad;

            string ProductoTerminado = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.ProductoTerminado) ? consultaLiquidacionProcesoPlantaPorIdBE.ProductoTerminado.Trim() : String.Empty;
            string SubProductoTerminado = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.SubProductoTerminado) ? consultaLiquidacionProcesoPlantaPorIdBE.SubProductoTerminado.Trim() : String.Empty;
            string Calidad = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.Calidad) ? consultaLiquidacionProcesoPlantaPorIdBE.Calidad.Trim() : String.Empty;

            consultaLiquidacionProcesoPlantaPorIdBE.Preparacion = ProductoTerminado + " - " + SubProductoTerminado + " - " + Calidad;


            string Departamento = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.Departamento) ? consultaLiquidacionProcesoPlantaPorIdBE.Departamento.Trim() : String.Empty;
            string Provincia = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.Provincia) ? consultaLiquidacionProcesoPlantaPorIdBE.Provincia.Trim() : String.Empty;
            string Distrito = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.Distrito) ? consultaLiquidacionProcesoPlantaPorIdBE.Distrito.Trim() : String.Empty;

            consultaLiquidacionProcesoPlantaPorIdBE.Ubigeo = Distrito + "-" + Provincia + "-" + Departamento;

            consultaLiquidacionProcesoPlantaPorIdBE.FechaInicioProcesoString = consultaLiquidacionProcesoPlantaPorIdBE.FechaInicioProceso.Value.ToString("dd/MM/yyyy");
            consultaLiquidacionProcesoPlantaPorIdBE.FechaFinProcesoString = consultaLiquidacionProcesoPlantaPorIdBE.FechaFinProceso.Value.ToString("dd/MM/yyyy");
            consultaLiquidacionProcesoPlantaPorIdBE.RazonSocialOrganizacion = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.RazonSocialOrganizacion) ? consultaLiquidacionProcesoPlantaPorIdBE.RazonSocialOrganizacion.Trim() : String.Empty;
            consultaLiquidacionProcesoPlantaPorIdBE.RazonSocial  = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.RazonSocial ) ? consultaLiquidacionProcesoPlantaPorIdBE.RazonSocial .Trim() : String.Empty;
            consultaLiquidacionProcesoPlantaPorIdBE.EntidadCertificadora = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.EntidadCertificadora) ? consultaLiquidacionProcesoPlantaPorIdBE.EntidadCertificadora.Trim() : String.Empty;
            consultaLiquidacionProcesoPlantaPorIdBE.Producto = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.Producto) ? consultaLiquidacionProcesoPlantaPorIdBE.Producto.Trim() : String.Empty;

            consultaLiquidacionProcesoPlantaPorIdBE.EnvasesProductos = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.EnvasesProductos) ? consultaLiquidacionProcesoPlantaPorIdBE.EnvasesProductos.Trim() : String.Empty;
            consultaLiquidacionProcesoPlantaPorIdBE.TrabajosRealizados = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.TrabajosRealizados) ? consultaLiquidacionProcesoPlantaPorIdBE.TrabajosRealizados.Trim() : String.Empty;
            consultaLiquidacionProcesoPlantaPorIdBE.Observacion = !string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.Observacion) ? consultaLiquidacionProcesoPlantaPorIdBE.Observacion.Trim() : String.Empty;


            if (consultaLiquidacionProcesoPlantaPorIdBE != null)
            {
                consultaLiquidacionProcesoPlantaPorIdBE.Detalle = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId).ToList();
                consultaLiquidacionProcesoPlantaPorIdBE.Resultado = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaResultadoPorId(request.LiquidacionProcesoPlantaId, request.EmpresaId).ToList();

                //decimal totalKilosNetos = 0;
                //foreach (ConsultaLiquidacionProcesoPlantaResultadoBE item in consultaLiquidacionProcesoPlantaPorIdBE.Resultado)
                //{
                //    totalKilosNetos = totalKilosNetos  + item.KilosNetos; 
                //}

                //foreach (ConsultaLiquidacionProcesoPlantaResultadoBE item in consultaLiquidacionProcesoPlantaPorIdBE.Resultado)
                //{
                //    item.Porcentaje = decimal.Round(((item.KilosNetos / totalKilosNetos) * 100), 2); 
                //}


                // obtener certificaciones
                List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId, String.Empty).ToList();
                List<ConsultaDetalleTablaBE> certificaciones = lista.Where(a => a.CodigoTabla.Trim().Equals("TipoCertificacionPlanta")).ToList();

                if (!string.IsNullOrEmpty(consultaLiquidacionProcesoPlantaPorIdBE.CertificacionId))
                    {

                    string[] certificacionesIds = consultaLiquidacionProcesoPlantaPorIdBE.CertificacionId.Split('|');
                    string certificacionLabel = string.Empty;
                    if (certificacionesIds.Length > 0)
                    {
                        foreach (string certificacionId in certificacionesIds)
                        {
                            ConsultaDetalleTablaBE certificacion = certificaciones.Where(a => a.Codigo == certificacionId).FirstOrDefault();
                            if (certificacion != null)
                            {
                                certificacionLabel = certificacionLabel + certificacion.Label + " ";
                            }
                        }
                    }

                    // obtener certificaciones
                    consultaLiquidacionProcesoPlantaPorIdBE.Certificacion = certificacionLabel;
                }
                
            }

            return consultaLiquidacionProcesoPlantaPorIdBE;
        }

        //public ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaDetallePorId(ConsultaLiquidacionProcesoPlantaPorIdRequestDTO request)
        //{
        //    ConsultaLiquidacionProcesoPlantaPorIdBE consultaLiquidacionProcesoPlantaPorIdBE = new ConsultaLiquidacionProcesoPlantaPorIdBE();


        //     consultaLiquidacionProcesoPlantaPorIdBE.detalle = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId).ToList();


        //    return consultaLiquidacionProcesoPlantaPorIdBE;
        //}

        ////public int AnularLiquidacionProcesoPlanta(AnularLiquidacionProcesoPlantaRequestDTO request)
        ////{
        ////    int result = 0;
        ////    if(request.LiquidacionProcesoPlantaId > 0)
        ////    {
        ////        result = _ILiquidacionProcesoPlantaRepository.Anular(request.LiquidacionProcesoPlantaId, DateTime.Now, request.Usuario, LiquidacionProcesoPlantaEstados.Anulado);
        ////    }
        ////    return result;
        ////}

        ////public ConsultarImpresionLiquidacionProcesoPlantaResponseDTO ConsultarImpresionLiquidacionProcesoPlanta(ConsultarImpresionLiquidacionProcesoPlantaRequestDTO request)
        ////{
        ////    ConsultarImpresionLiquidacionProcesoPlantaResponseDTO response = new ConsultarImpresionLiquidacionProcesoPlantaResponseDTO();
        ////    response.listLiquidacionProcesoPlanta = _ILiquidacionProcesoPlantaRepository.ConsultarImpresionLiquidacionProcesoPlanta(request.LiquidacionProcesoPlantaId);
        ////    response.listDetalleLiquidacionProcesoPlanta = _ILiquidacionProcesoPlantaRepository.ConsultarLiquidacionProcesoPlantaDetallePorId(request.LiquidacionProcesoPlantaId);
        ////    return response;
        ////}

        //private String getRutaFisica(string pathFile)
        //{
        //    return _fileServerSettings.Value.RutaPrincipal + pathFile;
        //}

        //public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        //{
        //    try
        //    {
        //        string rutaReal = Path.Combine(getRutaFisica(request.PathFile));

        //        if (File.Exists(rutaReal))
        //        {
        //            byte[] archivoBytes = File.ReadAllBytes(rutaReal);
        //            return new ResponseDescargarArchivoDTO()
        //            {
        //                archivoBytes = archivoBytes,
        //                errores = new Dictionary<string, string>(),
        //                ficheroVisual = request.ArchivoVisual
        //            };
        //        }
        //        else
        //        {
        //            var resp = new ResponseDescargarArchivoDTO()
        //            {
        //                archivoBytes = null,
        //                errores = new Dictionary<string, string>(),
        //                ficheroVisual = ""
        //            };
        //            resp.errores.Add("Error", "El Archivo solicitado no existe");
        //            return resp;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
