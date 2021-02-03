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
