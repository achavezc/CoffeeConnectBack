using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class ZonaRepository : IZonaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ZonaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaZonaBE> ConsultarZona(ConsultaZonaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", request.EmpresaId);         
            parameters.Add("DistritoId", request.CodigoDistrito);           
            parameters.Add("EstadoId", request.EstadoId);
           


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaZonaBE>("uspZonaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

       

        public int Insertar(Zona zona)
        {
            int result = 0;            

            var parameters = new DynamicParameters();            
            parameters.Add("@EmpresaId", zona.EmpresaId);
            parameters.Add("@Nombre", zona.Nombre);
            parameters.Add("@DistritoId", zona.DistritoId);            
            parameters.Add("@FechaRegistro", zona.FechaRegistro);
            parameters.Add("@UsuarioRegistro", zona.UsuarioRegistro);           
            parameters.Add("@EstadoId", zona.EstadoId);          



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspZonaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }
            

            return result;
        }

        public int Actualizar(Zona zona)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ZonaId", zona.ZonaId);
            parameters.Add("@Nombre", zona.Nombre);
            parameters.Add("@DistritoId", zona.DistritoId);
            parameters.Add("@EmpresaId", zona.EmpresaId);
            parameters.Add("@FechaUltimaActualizacion", zona.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", zona.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", zona.EstadoId);
      


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspZonaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaZonaPorIdBE ConsultarZonaPorId(int ZonaId)
        {
            ConsultaZonaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ZonaId", ZonaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaZonaPorIdBE>("uspZonaConsultaPorIdZona", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
