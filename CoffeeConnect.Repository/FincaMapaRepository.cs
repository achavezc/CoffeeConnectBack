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
    public class FincaMapaRepository : IFincaMapaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public FincaMapaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }



        public int Insertar(FincaMapa fincaMapa)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@FincaId", fincaMapa.FincaId);
            parameters.Add("@Nombre", fincaMapa.Nombre);
            parameters.Add("@Descripcion", fincaMapa.Descripcion);
            parameters.Add("@Path", fincaMapa.Path);
            parameters.Add("@FechaRegistro", fincaMapa.FechaRegistro);
            parameters.Add("@UsuarioRegistro", fincaMapa.UsuarioRegistro);
            parameters.Add("@EstadoId", fincaMapa.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspFincaMapaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int Actualizar(FincaMapa fincaMapa)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@FincaMapaId", fincaMapa.FincaMapaId);
            parameters.Add("@FincaId", fincaMapa.FincaId);
            parameters.Add("@Nombre", fincaMapa.Nombre);
            parameters.Add("@Descripcion", fincaMapa.Descripcion);
            parameters.Add("@Path", fincaMapa.Path);
            parameters.Add("@FechaRegistro", fincaMapa.FechaRegistro);
            parameters.Add("@UsuarioRegistro", fincaMapa.UsuarioRegistro);
            parameters.Add("@EstadoId", fincaMapa.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspFincaMapaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<ConsultaFincaMapaPorId> ConsultarFincaMapaPorFincaId(int fincaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FincaId", fincaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaFincaMapaPorId>("uspFincaMapaConsultaPorFincaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaFincaMapaPorId ConsultarFincaMapaPorId(int fincaMapaId)
        {
            ConsultaFincaMapaPorId itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@FincaMapaId", fincaMapaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaFincaMapaPorId>("uspFincaMapaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
