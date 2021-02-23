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

	}
}
