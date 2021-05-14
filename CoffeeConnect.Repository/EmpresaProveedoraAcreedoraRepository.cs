using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeConnect.Repository
{
    public class EmpresaProveedoraAcreedoraRepository : IEmpresaProveedoraAcreedoraRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public EmpresaProveedoraAcreedoraRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaEmpresaProveedoraAcreedoraBE> ConsultarEmpresaProveedoraAcreedora(ConsultaEmpresaProveedoraAcreedoraRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("ClasificacionId", request.ClasificacionId);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaEmpresaProveedoraAcreedoraBE>("uspEmpresaProveedoraAcreedoraConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
