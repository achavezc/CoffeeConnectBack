
using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adjunto;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using CoffeeConnect.Service.Adjunto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoffeeConnect.Service
{
    public partial class SocioFincaCertificacionService : ISocioFincaCertificacionService
    {
        private readonly IMapper _Mapper;

        private ISocioFincaCertificacionRepository _ISocioFincaRepository;




        public SocioFincaCertificacionService(ISocioFincaCertificacionRepository socioFincaRepository, IMapper mapper)
        {
            _ISocioFincaRepository = socioFincaRepository;


            _Mapper = mapper;



        }



        public int RegistrarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request, IFormFile file)
        {
            var AdjuntoBl = new AdjuntarArchivosBL();
            byte[] fileBytes = null ;
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
            }


            SocioFincaCertificacion socioFinca = _Mapper.Map<SocioFincaCertificacion>(request);
            socioFinca.NombreArchivo = file.FileName;
            socioFinca.FechaRegistro = DateTime.Now;
            socioFinca.UsuarioRegistro = request.Usuario;

            //Adjuntos
            ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO()
            {
                filtros = new AdjuntarArchivosDTO()
                {
                    archivoStream = fileBytes,
                    filename = file.FileName,
                }
            });
            socioFinca.PathArchivo = response.ficheroReal;

            int affected = _ISocioFincaRepository.Insertar(socioFinca);

            return affected;
        }

        public int ActualizarSocioFincaCertificacion(RegistrarActualizarSocioFincaCertificacionRequestDTO request)
        {
            SocioFincaCertificacion socioFinca = _Mapper.Map<SocioFincaCertificacion>(request);
            socioFinca.FechaUltimaActualizacion = DateTime.Now;
            socioFinca.UsuarioUltimaActualizacion = request.Usuario;

            int affected = _ISocioFincaRepository.Actualizar(socioFinca);

            return affected;
        }

        public IEnumerable<ConsultaSocioFincaCertificacionPorSocioFincaId> ConsultarSocioFincaCertificacionPorSocioFincaId(ConsultaSocioFincaCertificacionPorSocioFincaIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaCertificacionPorSocioFincaId(request.SocioFincaId);
        }

        public ConsultaSocioFincaCertificacionPorId ConsultarSocioFincaCertificacionPorId(ConsultaSocioFincaCertificacionPorIdRequestDTO request)
        {
            return _ISocioFincaRepository.ConsultarSocioFincaCertificacionPorId(request.SocioFincaCertificacionId);
        }

    }
}
