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
	public class NotaSalidaAlmacenRepository : INotaSalidaAlmacenRepository
	{
		public IOptions<ConnectionString> _connectionString;
		public NotaSalidaAlmacenRepository(IOptions<ConnectionString> connectionString)
		{
			_connectionString = connectionString;
		}



		public IEnumerable<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE> ConsultarImpresionListaProductoresPorNotaSalida(int notaSalidaAlmacenId)
		{
			var parameters = new DynamicParameters();
			parameters.Add("NotaSalidaAlmacenId", notaSalidaAlmacenId);		
			


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				return db.Query<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE>("uspListaProductoresConsultaImpresionPorNotaSalidaAlmacenId", parameters, commandType: CommandType.StoredProcedure);
			}
		}

	}
}
