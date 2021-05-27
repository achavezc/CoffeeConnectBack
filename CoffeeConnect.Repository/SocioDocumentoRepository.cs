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
    public class SocioDocumentoRepository : ISocioDocumentoRepository
    {
        private IOptions<ConnectionString> _connectionString;

        public SocioDocumentoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Actualizar(SocioDocumento socioDocumento)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioDocumentoId", socioDocumento.SocioDocumentoId);
            parameters.Add("@SocioId", socioDocumento.SocioId);
            parameters.Add("@Nombre", socioDocumento.Nombre);
            parameters.Add("@Descripcion", socioDocumento.Descripcion);
            parameters.Add("@Path", socioDocumento.Path);
            parameters.Add("@FechaUltimaActualizacion", socioDocumento.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", socioDocumento.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", socioDocumento.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioDocumentoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<ConsultarSocioDocumentoPorSocioId> ConsultarSocioDocumentoPorSocioId(int socioId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SocioId", socioId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarSocioDocumentoPorSocioId>("uspSocioDocumentoConsultaPorSocioId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(SocioDocumento socioDocumento)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioId", socioDocumento.SocioId);
            parameters.Add("@Nombre", socioDocumento.Nombre);
            parameters.Add("@Descripcion", socioDocumento.Descripcion);
            parameters.Add("@Path", socioDocumento.Path);
            parameters.Add("@FechaRegistro", socioDocumento.FechaRegistro);
            parameters.Add("@UsuarioRegistro", socioDocumento.UsuarioRegistro);
            parameters.Add("@EstadoId", socioDocumento.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioDocumentoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }


        public int Eliminar(int socioDocumentoId)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioDocumentoId", socioDocumentoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioDocumentoEliminar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }


        public SocioDocumento ConsultarSocioDocumentoPorId(int socioDocumentoId)
        {
            SocioDocumento itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioDocumentoId", socioDocumentoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<SocioDocumento>("uspSocioDocumentoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
