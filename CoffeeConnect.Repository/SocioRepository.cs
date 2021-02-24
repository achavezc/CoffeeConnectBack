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
using Core.Common;

namespace CoffeeConnect.Repository
{
	public class SocioRepository : ISocioRepository
	{
		public IOptions<ConnectionString> _connectionString;
		public SocioRepository(IOptions<ConnectionString> connectionString)
		{
			_connectionString = connectionString;
		}

        public int Actualizar(Socio socio)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioId", socio.SocioId);
            parameters.Add("@ProductorId", socio.ProductorId);
            parameters.Add("@UsuarioUltimaActualizacion", socio.UsuarioUltimaActualizacion);
            parameters.Add("@FechaUltimaActualizacion", socio.FechaUltimaActualizacion);
            parameters.Add("@Activo", socio.Activo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioActualizar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public IEnumerable<ConsultaSocioBE> ConsultarSocio(ConsultaSocioRequestDTO request)
		{
			var parameters = new DynamicParameters();
			parameters.Add("Codigo", request.Codigo);		
			parameters.Add("NombreRazonSocial", request.NombreRazonSocial);
			parameters.Add("TipoDocumentoId", request.TipoDocumentoId);
			parameters.Add("NumeroDocumento", request.NumeroDocumento);			
			parameters.Add("EstadoId", request.EstadoId);			
			parameters.Add("FechaInicio", request.FechaInicio);
			parameters.Add("FechaFin", request.FechaFin);


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				return db.Query<ConsultaSocioBE>("uspSocioConsulta", parameters, commandType: CommandType.StoredProcedure);
			}
		}

        public int Insertar(Socio socio)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@Codigo", socio.Codigo);
            parameters.Add("@ProductorId", socio.ProductorId);
            parameters.Add("@UsuarioRegistro", socio.UsuarioRegistro);
            parameters.Add("@FechaRegistro", socio.FechaRegistro);         


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        //public int Actualizar(Productor productor)
        //{
        //	int result = 0;

        //	var parameters = new DynamicParameters();
        //	parameters.Add("@ProductorId", productor.ProductorId);	
        //	parameters.Add("@TipoDocumentoId", productor.TipoDocumentoId);
        //	parameters.Add("@NumeroDocumento", productor.NumeroDocumento);
        //	parameters.Add("@RazonSocial", productor.RazonSocial);
        //	parameters.Add("@Nombres", productor.Nombres);
        //	parameters.Add("@Apellidos", productor.Apellidos);
        //	parameters.Add("@Direccion", productor.Direccion);
        //	parameters.Add("@DepartamentoId", productor.DepartamentoId);
        //	parameters.Add("@ProvinciaId", productor.ProvinciaId);
        //	parameters.Add("@DistritoId", productor.DistritoId);
        //	parameters.Add("@ZonaId", productor.ZonaId);			
        //	parameters.Add("@NumeroTelefonoFijo", productor.NumeroTelefonoFijo);
        //	parameters.Add("@NumeroTelefonoCelular", productor.NumeroTelefonoCelular);
        //	parameters.Add("@FechaNacimiento", productor.FechaNacimiento);
        //	parameters.Add("@LugarNacimiento", productor.LugarNacimiento);
        //	parameters.Add("@EstadoCivilId", productor.EstadoCivilId);
        //	parameters.Add("@ReligionId", productor.ReligionId);
        //	parameters.Add("@GeneroId", productor.GeneroId);
        //	parameters.Add("@GradoEstudios", productor.GradoEstudios);
        //	parameters.Add("@CantidadHijos", productor.CantidadHijos);
        //	parameters.Add("@Idiomas", productor.Idiomas);
        //	parameters.Add("@Dialecto", productor.Dialecto);
        //	parameters.Add("@AnioIngresoZona", productor.AnioIngresoZona);
        //	parameters.Add("@TipoDocumentoIdConyuge", productor.TipoDocumentoIdConyuge);
        //	parameters.Add("@NumeroDocumentoConyuge", productor.NumeroDocumentoConyuge);
        //	parameters.Add("@NombresConyuge", productor.NombresConyuge);
        //	parameters.Add("@ApellidosConyuge", productor.ApellidosConyuge);
        //	parameters.Add("@NumeroTelefonoCelularConyuge", productor.NumeroTelefonoCelularConyuge);
        //	parameters.Add("@FechaNacimientoConyuge", productor.FechaNacimientoConyuge);
        //	parameters.Add("@LugarNacimientoConyuge", productor.LugarNacimientoConyuge);			
        //	parameters.Add("@FechaUltimaActualizacion", productor.FechaUltimaActualizacion);
        //	parameters.Add("@UsuarioUltimaActualizacion", productor.UsuarioUltimaActualizacion);
        //	parameters.Add("@Activo", productor.Activo);


        //	using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //	{
        //		result = db.Execute("uspProductorActualizar", parameters, commandType: CommandType.StoredProcedure);
        //	}



        //	return result;
        //}
    }
}
