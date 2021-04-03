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
	public class ClienteRepository : IClienteRepository
	{
		public IOptions<ConnectionString> _connectionString;
		public ClienteRepository(IOptions<ConnectionString> connectionString)
		{
			_connectionString = connectionString;
		}

       

        public IEnumerable<ConsultaClienteBE> ConsultarCliente(ConsultaClienteRequestDTO request)
		{
			var parameters = new DynamicParameters();
			parameters.Add("Numero", request.Numero);		
			parameters.Add("RazonSocial", request.RazonSocial);
			parameters.Add("TipoClienteId", request.TipoClienteId);
			parameters.Add("PaisId", request.PaisId);
			parameters.Add("Ruc", request.Ruc);			
			parameters.Add("EstadoId", request.EstadoId);			
			parameters.Add("FechaInicio", request.FechaInicio);
			parameters.Add("FechaFin", request.FechaFin);


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				return db.Query<ConsultaClienteBE>("uspClienteConsulta", parameters, commandType: CommandType.StoredProcedure);
			}
		}

  //      public int Insertar(Productor productor)
  //      {
  //          int result = 0;

		//	var parameters = new DynamicParameters();			
		//	parameters.Add("@Numero", productor.Numero);
		//	parameters.Add("@RazonSocial", productor.RazonSocial);
		//	parameters.Add("@TipoDocumentoId", productor.TipoDocumentoId);
		//	parameters.Add("@NumeroDocumento", productor.NumeroDocumento);
		//	parameters.Add("@Nombres", productor.Nombres);
		//	parameters.Add("@Apellidos", productor.Apellidos);
		//	parameters.Add("@Direccion", productor.Direccion);
		//	parameters.Add("@DepartamentoId", productor.DepartamentoId);
		//	parameters.Add("@ProvinciaId", productor.ProvinciaId);
		//	parameters.Add("@DistritoId", productor.DistritoId);
		//	parameters.Add("@ZonaId", productor.ZonaId);			
		//	parameters.Add("@NumeroTelefonoFijo", productor.NumeroTelefonoFijo);
		//	parameters.Add("@NumeroTelefonoCelular", productor.NumeroTelefonoCelular);
		//	parameters.Add("@CorreoElectronico", productor.CorreoElectronico);
			
		//	parameters.Add("@FechaNacimiento", productor.FechaNacimiento);
		//	parameters.Add("@LugarNacimiento", productor.LugarNacimiento);
		//	parameters.Add("@EstadoCivilId", productor.EstadoCivilId);
		//	parameters.Add("@ReligionId", productor.ReligionId);
		//	parameters.Add("@GeneroId", productor.GeneroId);
		//	parameters.Add("@GradoEstudiosId", productor.GradoEstudiosId);
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
		//	parameters.Add("@FechaRegistro", productor.FechaRegistro);
		//	parameters.Add("@UsuarioRegistro", productor.UsuarioRegistro);
		//	parameters.Add("@EstadoId", productor.EstadoId);
		//	parameters.Add("@GradoEstudiosIdConyuge", productor.GradoEstudiosIdConyuge);
			

		//	parameters.Add("@ProductorId", dbType: DbType.Int32, direction: ParameterDirection.Output);


  //          using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
  //          {
  //              result = db.Execute("uspProductorInsertar", parameters, commandType: CommandType.StoredProcedure);
  //          }

  //          int id = parameters.Get<int>("ProductorId");

  //          return id;
  //      }

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
		//	parameters.Add("@CorreoElectronico", productor.CorreoElectronico);
		//	parameters.Add("@FechaNacimiento", productor.FechaNacimiento);
		//	parameters.Add("@LugarNacimiento", productor.LugarNacimiento);
		//	parameters.Add("@EstadoCivilId", productor.EstadoCivilId);
		//	parameters.Add("@ReligionId", productor.ReligionId);
		//	parameters.Add("@GeneroId", productor.GeneroId);
		//	parameters.Add("@GradoEstudiosId", productor.GradoEstudiosId);
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
		//	parameters.Add("@GradoEstudiosIdConyuge", productor.GradoEstudiosIdConyuge);
		//	parameters.Add("@FechaUltimaActualizacion", productor.FechaUltimaActualizacion);
		//	parameters.Add("@UsuarioUltimaActualizacion", productor.UsuarioUltimaActualizacion);

		//	parameters.Add("@EstadoId", productor.EstadoId);


		//	using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
		//	{
		//		result = db.Execute("uspProductorActualizar", parameters, commandType: CommandType.StoredProcedure);
		//	}
		//	return result;
		//}

		//public ConsultaProductorIdBE ConsultarProductorId(int productorId)
		//{
		//	ConsultaProductorIdBE itemBE = null;

		//	var parameters = new DynamicParameters();
		//	parameters.Add("@ProductorId", productorId);


		//	using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
		//	{
		//		var list = db.Query<ConsultaProductorIdBE>("uspProductorObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

		//		if (list.Any())
		//			itemBE = list.First();
		//	}

		//	return itemBE;
		//}


	}
}
