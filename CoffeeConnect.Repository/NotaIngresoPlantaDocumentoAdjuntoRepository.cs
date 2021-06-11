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
    public class NotaIngresoPlantaDocumentoAdjuntoRepository : INotaIngresoPlantaDocumentoAdjuntoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaIngresoPlantaDocumentoAdjuntoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insertar(NotaIngresoPlantaDocumentoAdjunto NotaIngresoPlantaDocumentoAdjunto)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaDocumentoAdjunto.NotaIngresoPlantaId);
            parameters.Add("@Nombre", NotaIngresoPlantaDocumentoAdjunto.Nombre);
            parameters.Add("@Descripcion", NotaIngresoPlantaDocumentoAdjunto.Descripcion);
            parameters.Add("@Path", NotaIngresoPlantaDocumentoAdjunto.Path);
            parameters.Add("@FechaRegistro", NotaIngresoPlantaDocumentoAdjunto.FechaRegistro);
            parameters.Add("@UsuarioRegistro", NotaIngresoPlantaDocumentoAdjunto.UsuarioRegistro);
            parameters.Add("@EstadoId", NotaIngresoPlantaDocumentoAdjunto.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaDocumentoAdjuntoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int Actualizar(NotaIngresoPlantaDocumentoAdjunto NotaIngresoPlantaDocumentoAdjunto)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaDocumentoAdjuntoId", NotaIngresoPlantaDocumentoAdjunto.NotaIngresoPlantaDocumentoAdjuntoId);
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaDocumentoAdjunto.NotaIngresoPlantaId);
            parameters.Add("@Nombre", NotaIngresoPlantaDocumentoAdjunto.Nombre);
            parameters.Add("@Descripcion", NotaIngresoPlantaDocumentoAdjunto.Descripcion);
            parameters.Add("@Path", NotaIngresoPlantaDocumentoAdjunto.Path);
            parameters.Add("@FechaUltimaActualizacion", NotaIngresoPlantaDocumentoAdjunto.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", NotaIngresoPlantaDocumentoAdjunto.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", NotaIngresoPlantaDocumentoAdjunto.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaDocumentoAdjuntoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId> ConsultarNotaIngresoPlantaDocumentoAdjuntoPorNotaIngresoPlantaId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId>("uspNotaIngresoPlantaDocumentoAdjuntoConsultaPorNotaIngresoPlantaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId ConsultarNotaIngresoPlantaDocumentoAdjuntoPorId(int NotaIngresoPlantaDocumentoAdjuntoId)
        {
            ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaDocumentoAdjuntoId", NotaIngresoPlantaDocumentoAdjuntoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaIngresoPlantaDocumentoAdjuntoPorId>("uspNotaIngresoPlantaDocumentoAdjuntoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


        public int Eliminar(int NotaIngresoPlantaDocumentoAdjuntoId)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaDocumentoAdjuntoId", NotaIngresoPlantaDocumentoAdjuntoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaDocumentoAdjuntoEliminar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
