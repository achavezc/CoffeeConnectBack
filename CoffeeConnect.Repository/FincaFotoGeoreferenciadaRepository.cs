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
    public class FincaFotoGeoreferenciadaRepository : IFincaFotoGeoreferenciadaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public FincaFotoGeoreferenciadaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }



        public int Insertar(FincaFotoGeoreferenciada fincaFotoGeoreferenciada)
        {
            int result = 0;    

            var parameters = new DynamicParameters();           
            parameters.Add("@FincaId", fincaFotoGeoreferenciada.FincaId);
            parameters.Add("@Nombre", fincaFotoGeoreferenciada.Nombre);
            parameters.Add("@Descripcion", fincaFotoGeoreferenciada.Descripcion);
            parameters.Add("@Path", fincaFotoGeoreferenciada.Path);
            parameters.Add("@FechaRegistro", fincaFotoGeoreferenciada.FechaRegistro);
            parameters.Add("@UsuarioRegistro", fincaFotoGeoreferenciada.UsuarioRegistro);
            parameters.Add("@EstadoId", fincaFotoGeoreferenciada.EstadoId);
         

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspFincaFotoGeoreferenciadaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int Actualizar(FincaFotoGeoreferenciada fincaFotoGeoreferenciada)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@FincaFotoGeoreferenciadaId", fincaFotoGeoreferenciada.FincaFotoGeoreferenciadaId);
            parameters.Add("@FincaId", fincaFotoGeoreferenciada.FincaId);
            parameters.Add("@Nombre", fincaFotoGeoreferenciada.Nombre);
            parameters.Add("@Descripcion", fincaFotoGeoreferenciada.Descripcion);
            parameters.Add("@Path", fincaFotoGeoreferenciada.Path);
            parameters.Add("@FechaRegistro", fincaFotoGeoreferenciada.FechaRegistro);
            parameters.Add("@UsuarioRegistro", fincaFotoGeoreferenciada.UsuarioRegistro);
            parameters.Add("@EstadoId", fincaFotoGeoreferenciada.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspFincaFotoGeoreferenciadaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<ConsultaFincaFotoGeoreferenciadaPorId> ConsultarFincaFotoGeoreferenciadaPorFincaId(int fincaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FincaId", fincaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaFincaFotoGeoreferenciadaPorId>("uspFincaFotoGeoreferenciadaConsultaPorFincaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaFincaFotoGeoreferenciadaPorId ConsultarFincaFotoGeoreferenciadaPorId(int FincaFotoGeoreferenciadaId)
        {
            ConsultaFincaFotoGeoreferenciadaPorId itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@FincaFotoGeoreferenciadaId", FincaFotoGeoreferenciadaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaFincaFotoGeoreferenciadaPorId>("uspFincaFotoGeoreferenciadaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
