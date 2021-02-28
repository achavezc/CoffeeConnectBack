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
    public class MaestroRepository : IMaestroRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public MaestroRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public IEnumerable<ConsultaDetalleTablaBE> ConsultarDetalleTablaDeTablas(int empresaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", empresaId);
            
            


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaDetalleTablaBE>("uspDetalleCatalogoObtenerPorEmpresaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaUbigeoBE> ConsultaUbibeo()
        {

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaUbigeoBE>("uspUbigeoConsulta", null, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Zona> ConsultarZona(string codigoDistrito)
        {
            var parameters = new DynamicParameters();
            parameters.Add("DistritoId", codigoDistrito);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<Zona>("uspZonaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
