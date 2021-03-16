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
