using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeConnect.Repository
{
    public class OrganizacionRepository : IOrganizacionRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public OrganizacionRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }




        public IEnumerable<ConsultaOrganizacionBE> ConsultarOrganizacion(ConsultaOrganizacionRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("ClasificacionId", request.ClasificacionId);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaOrganizacionBE>("uspOrganizacionConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
