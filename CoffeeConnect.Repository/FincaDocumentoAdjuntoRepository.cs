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
    public class FincaDocumentoAdjuntoRepository : IFincaDocumentoAdjuntoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public FincaDocumentoAdjuntoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insertar(FincaDocumentoAdjunto fincaDocumentoAdjunto)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@FincaId", fincaDocumentoAdjunto.FincaId);
            parameters.Add("@Nombre", fincaDocumentoAdjunto.Nombre);
            parameters.Add("@Descripcion", fincaDocumentoAdjunto.Descripcion);
            parameters.Add("@Path", fincaDocumentoAdjunto.Path);
            parameters.Add("@FechaRegistro", fincaDocumentoAdjunto.FechaRegistro);
            parameters.Add("@UsuarioRegistro", fincaDocumentoAdjunto.UsuarioRegistro);
            parameters.Add("@EstadoId", fincaDocumentoAdjunto.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspFincaDocumentoAdjuntoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int Actualizar(FincaDocumentoAdjunto fincaDocumentoAdjunto)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@FincaDocumentoAdjuntoId", fincaDocumentoAdjunto.FincaDocumentoAdjuntoId);
            parameters.Add("@FincaId", fincaDocumentoAdjunto.FincaId);
            parameters.Add("@Nombre", fincaDocumentoAdjunto.Nombre);
            parameters.Add("@Descripcion", fincaDocumentoAdjunto.Descripcion);
            parameters.Add("@Path", fincaDocumentoAdjunto.Path);
            parameters.Add("@FechaRegistro", fincaDocumentoAdjunto.FechaRegistro);
            parameters.Add("@UsuarioRegistro", fincaDocumentoAdjunto.UsuarioRegistro);
            parameters.Add("@EstadoId", fincaDocumentoAdjunto.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspFincaDocumentoAdjuntoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<ConsultaFincaDocumentoAdjuntoPorId> ConsultarFincaDocumentoAdjuntoPorFincaId(int fincaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FincaId", fincaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaFincaDocumentoAdjuntoPorId>("uspFincaDocumentoAdjuntoConsultaPorFincaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaFincaDocumentoAdjuntoPorId ConsultarFincaDocumentoAdjuntoPorId(int FincaDocumentoAdjuntoId)
        {
            ConsultaFincaDocumentoAdjuntoPorId itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@FincaDocumentoAdjuntoId", FincaDocumentoAdjuntoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaFincaDocumentoAdjuntoPorId>("uspFincaDocumentoAdjuntoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
