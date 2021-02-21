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
    public class EmpresaRepository : IEmpresaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public EmpresaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        
       


        public Empresa ObtenerEmpresaPorId(int empresaId)
        {
            Empresa itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", empresaId);           

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<Empresa>("uspEmpresaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();

            }

            return itemBE;
        }

        public IEnumerable<EmpresaBE> ConsultarEmpresa(int empresaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", empresaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<EmpresaBE>("uspEmpresaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
