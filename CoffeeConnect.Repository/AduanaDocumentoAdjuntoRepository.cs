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
    public class AduanaDocumentoAdjuntoRepository : IAduanaDocumentoAdjuntoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public AduanaDocumentoAdjuntoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insertar(AduanaDocumentoAdjunto AduanaDocumentoAdjunto)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AduanaId", AduanaDocumentoAdjunto.AduanaId);
            parameters.Add("@Nombre", AduanaDocumentoAdjunto.Nombre);
            parameters.Add("@Descripcion", AduanaDocumentoAdjunto.Descripcion);
            parameters.Add("@Path", AduanaDocumentoAdjunto.Path);
            parameters.Add("@FechaRegistro", AduanaDocumentoAdjunto.FechaRegistro);
            parameters.Add("@UsuarioRegistro", AduanaDocumentoAdjunto.UsuarioRegistro);
            parameters.Add("@EstadoId", AduanaDocumentoAdjunto.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAduanaDocumentoAdjuntoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int Actualizar(AduanaDocumentoAdjunto AduanaDocumentoAdjunto)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AduanaDocumentoAdjuntoId", AduanaDocumentoAdjunto.AduanaDocumentoAdjuntoId);
            parameters.Add("@AduanaId", AduanaDocumentoAdjunto.AduanaId);
            parameters.Add("@Nombre", AduanaDocumentoAdjunto.Nombre);
            parameters.Add("@Descripcion", AduanaDocumentoAdjunto.Descripcion);
            parameters.Add("@Path", AduanaDocumentoAdjunto.Path);
            parameters.Add("@FechaUltimaActualizacion", AduanaDocumentoAdjunto.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", AduanaDocumentoAdjunto.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", AduanaDocumentoAdjunto.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAduanaDocumentoAdjuntoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<ConsultaAduanaDocumentoAdjuntoPorId> ConsultarAduanaDocumentoAdjuntoPorAduanaId(int AduanaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AduanaId", AduanaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaAduanaDocumentoAdjuntoPorId>("uspAduanaDocumentoAdjuntoConsultaPorAduanaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaAduanaDocumentoAdjuntoPorId ConsultarAduanaDocumentoAdjuntoPorId(int AduanaDocumentoAdjuntoId)
        {
            ConsultaAduanaDocumentoAdjuntoPorId itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@AduanaDocumentoAdjuntoId", AduanaDocumentoAdjuntoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaAduanaDocumentoAdjuntoPorId>("uspAduanaDocumentoAdjuntoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


        public int Eliminar(int AduanaDocumentoAdjuntoId)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AduanaDocumentoAdjuntoId", AduanaDocumentoAdjuntoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAduanaDocumentoAdjuntoEliminar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
