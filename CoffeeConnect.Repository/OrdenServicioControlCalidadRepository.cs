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
	public class OrdenServicioControlCalidadRepository : IOrdenServicioControlCalidadRepository
	{
		public IOptions<ConnectionString> _connectionString;
		public OrdenServicioControlCalidadRepository(IOptions<ConnectionString> connectionString)
		{
			_connectionString = connectionString;
		}


		public IEnumerable<ConsultaOrdenServicioControlCalidadBE> ConsultarOrdenServicioControlCalidad(ConsultaOrdenServicioControlCalidadRequestDTO request)
		{
			var parameters = new DynamicParameters();
			parameters.Add("Numero", request.Numero);
			parameters.Add("Ruc", request.Ruc);
			parameters.Add("RazonSocial", request.RazonSocial);
			parameters.Add("EstadoId", request.EstadoId);
			parameters.Add("ProductoId", request.ProductoId);
			parameters.Add("SubProductoId", request.SubProductoId);
			parameters.Add("EmpresaId", request.EmpresaId);
			parameters.Add("FechaInicio", request.FechaInicio);
			parameters.Add("FechaFin", request.FechaFin);


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				return db.Query<ConsultaOrdenServicioControlCalidadBE>("uspOrdenServicioControlCalidadConsulta", parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public int ActualizarEstado(int ordenServicioControlCalidadId, DateTime fecha, string usuario, string estadoId)
		{
			int affected = 0;

			var parameters = new DynamicParameters();
			parameters.Add("@OrdenServicioControlCalidadId", ordenServicioControlCalidadId);
			parameters.Add("@Fecha", fecha);
			parameters.Add("@Usuario", usuario);
			parameters.Add("@EstadoId", estadoId);

			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				affected = db.Execute("uspOrdenServicioControlCalidadActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
			}

			return affected;
		}


	}
}
