
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoffeeConnect.Service
{
    public partial class AduanaService : IAduanaService
    {
        private readonly IMapper _Mapper;
        private IAduanaRepository _IAduanaRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public AduanaService(IAduanaRepository AduanaRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IAduanaRepository = AduanaRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }

        public List<ConsultaAduanaBE> ConsultarAduana(ConsultaAduanaRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue || string.IsNullOrEmpty(request.EstadoId))
                throw new ResultException(new Result { ErrCode = "01", Message = "Comercial.Cliente.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var timeSpan = request.FechaFin - request.FechaInicio;

            if (timeSpan.Days > 730)
                throw new ResultException(new Result { ErrCode = "02", Message = "Comercial.Aduana.ValidacionRangoFechaMayor2anios.Label" });

            var list = _IAduanaRepository.ConsultarAduana(request);
            return list.ToList();
        }

        public int RegistrarAduana(RegistrarActualizarAduanaRequestDTO request)
        {
            Aduana Aduana = _Mapper.Map<Aduana>(request);
            Aduana.FechaRegistro = DateTime.Now;
            //Aduana.NombreArchivo = file.FileName;
            Aduana.UsuarioRegistro = request.Usuario;
            Aduana.Numero = _ICorrelativoRepository.Obtener(request.EmpresaId, Documentos.Aduana);

            int id = _IAduanaRepository.Insertar(Aduana);

            List<AduanaCertificacionTipo> aduanaCertificacionTipoList = new List<AduanaCertificacionTipo>();

            request.Certificaciones.ForEach(z =>
            {
                AduanaCertificacionTipo item = new AduanaCertificacionTipo();
                item.AduanaId = id;
                item.CodigoCertificacion = z.CodigoCertificacion;
                item.TipoCertificacionId = z.TipoCertificacionId;
                item.EmpresaProveedoraAcreedoraId = z.EmpresaProveedoraAcreedoraId;
                item.TipoId = z.TipoId;

                aduanaCertificacionTipoList.Add(item);
            });

            _IAduanaRepository.ActualizarAduanaCertificacion(aduanaCertificacionTipoList, id);

            foreach (AduanaDetalle detalle in request.Detalle)
            {
                detalle.AduanaId = id;
                _IAduanaRepository.InsertarAduanaDetalle(detalle);
            }

            return id;
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                String rutaReal = Path.Combine(getRutaFisica(request.PathFile));

                if (File.Exists(rutaReal))
                {

                    Byte[] archivoBytes = System.IO.File.ReadAllBytes(rutaReal);
                    return new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = archivoBytes,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = request.ArchivoVisual
                    };
                }
                else
                {
                    var resp = new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = null,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = ""
                    };
                    resp.errores.Add("Error", "El Archivo solicitado no existe");
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarAduana(RegistrarActualizarAduanaRequestDTO request)
        {
            Aduana Aduana = _Mapper.Map<Aduana>(request);


            Aduana.FechaUltimaActualizacion = DateTime.Now;
            Aduana.UsuarioUltimaActualizacion = request.Usuario;
            ////Adjuntos
            //if (file != null)
            //{
            //    if (file.Length > 0)
            //    {
            //        Aduana.NombreArchivo = file.FileName;
            //        ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            //        {
            //            filtros = new AdjuntarArchivosDTO()
            //            {
            //                archivoStream = fileBytes,
            //                filename = file.FileName,
            //            },
            //            pathFile = _fileServerSettings.Value.FincasCertificacion

            //        });

            //        Aduana.PathArchivo = _fileServerSettings.Value.FincasCertificacion + "\\" + response.ficheroReal;
            //    }
            //}
            int affected = _IAduanaRepository.Actualizar(Aduana);

            List<AduanaCertificacionTipo> aduanaCertificacionTipoList = new List<AduanaCertificacionTipo>();

            request.Certificaciones.ForEach(z =>
            {
                AduanaCertificacionTipo item = new AduanaCertificacionTipo();
                item.AduanaId = request.AduanaId;
                item.CodigoCertificacion = z.CodigoCertificacion;
                item.TipoCertificacionId = z.TipoCertificacionId;
                item.EmpresaProveedoraAcreedoraId = z.EmpresaProveedoraAcreedoraId;

                aduanaCertificacionTipoList.Add(item);
            });


            _IAduanaRepository.ActualizarAduanaCertificacion(aduanaCertificacionTipoList, request.AduanaId);

            _IAduanaRepository.EliminarAduanaDetalle(request.AduanaId);

            foreach (AduanaDetalle detalle in request.Detalle)
            {
                detalle.AduanaId = request.AduanaId;
                _IAduanaRepository.InsertarAduanaDetalle(detalle);
            }


            return affected;
        }

        public ConsultaAduanaPorIdBE ConsultarAduanaPorId(ConsultaAduanaPorIdRequestDTO request)
        {
            ConsultaAduanaPorIdBE consultaAduanaPorIdBE = _IAduanaRepository.ConsultarAduanaPorId(request.AduanaId);

            consultaAduanaPorIdBE.Certificaciones = _IAduanaRepository.ConsultarAduanaCertificacionPorId(request.AduanaId).ToList();

            consultaAduanaPorIdBE.Detalle = _IAduanaRepository.ConsultarAduanaDetallePorId(request.AduanaId).ToList();

            return consultaAduanaPorIdBE;
        }

        public int AnularAduana(AnularAduanaRequestDTO request)
        {
            int result = 0;
            if (request.AduanaId > 0)
            {
                result = _IAduanaRepository.Anular(request.AduanaId, DateTime.Now, request.Usuario, AduanaEstados.Anulado);
            }
            return result;
        }
    }
}
