using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeConnect.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ProveedorRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public IEnumerable<ConsultaProveedoresBE> ConsultarProveedores(ConsultaProveedoresRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("TipoProveedorId", request.TipoProveedorId);
            parameters.Add("NombreRazonSocial", request.NombreRazonSocial);
            parameters.Add("TipoDocumentoId", request.TipoDocumentoId);
            parameters.Add("NumeroDocumento", request.NumeroDocumento);
            parameters.Add("CodigoSocio", request.CodigoSocio);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaProveedoresBE>("uspProveedorConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
