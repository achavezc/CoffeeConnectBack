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
    public class GuiaRecepcionMateriaPrimaRepository : IGuiaRecepcionMateriaPrimaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public GuiaRecepcionMateriaPrimaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public IEnumerable<ConsultaGuiaRecepcionMateriaPrimaBE> ConsultarGuiaRecepcionMateriaPrima(ConsultaGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NombreRazonSocial", request.NombreRazonSocial);
            parameters.Add("TipoDocumentoId", request.TipoDocumentoId);
            parameters.Add("NumeroDocumento", request.NumeroDocumento);
            parameters.Add("CodigoSocio", request.CodigoSocio);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaGuiaRecepcionMateriaPrimaBE>("uspGuiaRecepcionMateriaPrimaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int AnularGuiaRecepcionMateriaPrima(int guiaRecepcionMateriaPrimaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspGuiaRecepcionMateriaPrimaAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public ConsultaGuiaRecepcionMateriaPrimaPorIdBE ConsultarGuiaRecepcionMateriaPrimaPorId(int guiaRecepcionMateriaPrimaId)
        {
            ConsultaGuiaRecepcionMateriaPrimaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);    
            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaGuiaRecepcionMateriaPrimaPorIdBE>("uspGuiaRecepcionMateriaPrimaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);
                
                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

    }
}
