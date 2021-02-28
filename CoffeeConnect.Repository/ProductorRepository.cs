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
	public class ProductorRepository : IProductorRepository
	{
		public IOptions<ConnectionString> _connectionString;
		public ProductorRepository(IOptions<ConnectionString> connectionString)
		{
			_connectionString = connectionString;
		}

       

        public IEnumerable<ConsultaProductorBE> ConsultarProductor(ConsultaProductorRequestDTO request)
		{
			var parameters = new DynamicParameters();
			parameters.Add("Numero", request.Numero);		
			parameters.Add("NombreRazonSocial", request.NombreRazonSocial);
			parameters.Add("TipoDocumentoId", request.TipoDocumentoId);
			parameters.Add("NumeroDocumento", request.NumeroDocumento);			
			parameters.Add("EstadoId", request.EstadoId);			
			parameters.Add("FechaInicio", request.FechaInicio);
			parameters.Add("FechaFin", request.FechaFin);


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				return db.Query<ConsultaProductorBE>("uspProductorConsulta", parameters, commandType: CommandType.StoredProcedure);
			}
		}

        public int Insertar(Productor productor)
        {
            int result = 0;

			var parameters = new DynamicParameters();			
			parameters.Add("@Numero", productor.Numero);
			parameters.Add("@RazonSocial", productor.RazonSocial);
			parameters.Add("@TipoDocumentoId", productor.TipoDocumentoId);
			parameters.Add("@NumeroDocumento", productor.NumeroDocumento);
			parameters.Add("@Nombres", productor.Nombres);
			parameters.Add("@Apellidos", productor.Apellidos);
			parameters.Add("@Direccion", productor.Direccion);
			parameters.Add("@DepartamentoId", productor.DepartamentoId);
			parameters.Add("@ProvinciaId", productor.ProvinciaId);
			parameters.Add("@DistritoId", productor.DistritoId);
			parameters.Add("@ZonaId", productor.ZonaId);			
			parameters.Add("@NumeroTelefonoFijo", productor.NumeroTelefonoFijo);
			parameters.Add("@NumeroTelefonoCelular", productor.NumeroTelefonoCelular);
			parameters.Add("@CorreoElectronico", productor.CorreoElectronico);
			
			parameters.Add("@FechaNacimiento", productor.FechaNacimiento);
			parameters.Add("@LugarNacimiento", productor.LugarNacimiento);
			parameters.Add("@EstadoCivilId", productor.EstadoCivilId);
			parameters.Add("@ReligionId", productor.ReligionId);
			parameters.Add("@GeneroId", productor.GeneroId);
			parameters.Add("@GradoEstudiosId", productor.GradoEstudiosId);
			parameters.Add("@CantidadHijos", productor.CantidadHijos);
			parameters.Add("@Idiomas", productor.Idiomas);
			parameters.Add("@Dialecto", productor.Dialecto);
			parameters.Add("@AnioIngresoZona", productor.AnioIngresoZona);
			parameters.Add("@TipoDocumentoIdConyuge", productor.TipoDocumentoIdConyuge);
			parameters.Add("@NumeroDocumentoConyuge", productor.NumeroDocumentoConyuge);
			parameters.Add("@NombresConyuge", productor.NombresConyuge);
			parameters.Add("@ApellidosConyuge", productor.ApellidosConyuge);
			parameters.Add("@NumeroTelefonoCelularConyuge", productor.NumeroTelefonoCelularConyuge);
			parameters.Add("@FechaNacimientoConyuge", productor.FechaNacimientoConyuge);
			parameters.Add("@LugarNacimientoConyuge", productor.LugarNacimientoConyuge);
			parameters.Add("@FechaRegistro", productor.FechaRegistro);
			parameters.Add("@UsuarioRegistro", productor.UsuarioRegistro);
			parameters.Add("@EstadoId", productor.EstadoId);
			parameters.Add("@GradoEstudiosIdConyuge", productor.GradoEstudiosIdConyuge);
			

			parameters.Add("@ProductorId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspProductorInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("ProductorId");

            return id;
        }

		public int Actualizar(Productor productor)
		{
			int result = 0;

			var parameters = new DynamicParameters();
			parameters.Add("@ProductorId", productor.ProductorId);	
			parameters.Add("@TipoDocumentoId", productor.TipoDocumentoId);
			parameters.Add("@NumeroDocumento", productor.NumeroDocumento);
			parameters.Add("@RazonSocial", productor.RazonSocial);
			parameters.Add("@Nombres", productor.Nombres);
			parameters.Add("@Apellidos", productor.Apellidos);
			parameters.Add("@Direccion", productor.Direccion);
			parameters.Add("@DepartamentoId", productor.DepartamentoId);
			parameters.Add("@ProvinciaId", productor.ProvinciaId);
			parameters.Add("@DistritoId", productor.DistritoId);
			parameters.Add("@ZonaId", productor.ZonaId);			
			parameters.Add("@NumeroTelefonoFijo", productor.NumeroTelefonoFijo);
			parameters.Add("@NumeroTelefonoCelular", productor.NumeroTelefonoCelular);
			parameters.Add("@CorreoElectronico", productor.CorreoElectronico);
			parameters.Add("@FechaNacimiento", productor.FechaNacimiento);
			parameters.Add("@LugarNacimiento", productor.LugarNacimiento);
			parameters.Add("@EstadoCivilId", productor.EstadoCivilId);
			parameters.Add("@ReligionId", productor.ReligionId);
			parameters.Add("@GeneroId", productor.GeneroId);
			parameters.Add("@GradoEstudiosId", productor.GradoEstudiosId);
			parameters.Add("@CantidadHijos", productor.CantidadHijos);
			parameters.Add("@Idiomas", productor.Idiomas);
			parameters.Add("@Dialecto", productor.Dialecto);
			parameters.Add("@AnioIngresoZona", productor.AnioIngresoZona);
			parameters.Add("@TipoDocumentoIdConyuge", productor.TipoDocumentoIdConyuge);
			parameters.Add("@NumeroDocumentoConyuge", productor.NumeroDocumentoConyuge);
			parameters.Add("@NombresConyuge", productor.NombresConyuge);
			parameters.Add("@ApellidosConyuge", productor.ApellidosConyuge);
			parameters.Add("@NumeroTelefonoCelularConyuge", productor.NumeroTelefonoCelularConyuge);
			parameters.Add("@FechaNacimientoConyuge", productor.FechaNacimientoConyuge);
			parameters.Add("@LugarNacimientoConyuge", productor.LugarNacimientoConyuge);
			parameters.Add("@GradoEstudiosIdConyuge", productor.GradoEstudiosIdConyuge);
			parameters.Add("@FechaUltimaActualizacion", productor.FechaUltimaActualizacion);
			parameters.Add("@UsuarioUltimaActualizacion", productor.UsuarioUltimaActualizacion);

			parameters.Add("@EstadoId", productor.EstadoId);


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				result = db.Execute("uspProductorActualizar", parameters, commandType: CommandType.StoredProcedure);
			}



			return result;
		}
	}
}
