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
    public class EmpresaTransporteRepository : IEmpresaTransporteRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public EmpresaTransporteRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }
        

        public IEnumerable<EmpresaTransporteBE> ConsultarEmpresaTransporte(int empresaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", empresaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<EmpresaTransporteBE>("uspEmpresaTransporteConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaTransportistaBE> ConsultarTransportista(ConsultaTransportistaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("EmpresaId", request.EmpresaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaTransportistaBE>("uspTransportistaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
