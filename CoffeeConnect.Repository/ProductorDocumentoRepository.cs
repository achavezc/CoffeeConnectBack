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
    public class ProductorDocumentoRepository : IProductorDocumentoRepository
    {
        private IOptions<ConnectionString> _connectionString;

        public ProductorDocumentoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Actualizar(ProductorDocumento ProductorDocumento)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ProductorDocumentoId", ProductorDocumento.ProductorDocumentoId);
            parameters.Add("@ProductorId", ProductorDocumento.ProductorId);
            parameters.Add("@Nombre", ProductorDocumento.Nombre);
            parameters.Add("@Descripcion", ProductorDocumento.Descripcion);
            parameters.Add("@Path", ProductorDocumento.Path);
            parameters.Add("@FechaUltimaActualizacion", ProductorDocumento.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", ProductorDocumento.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", ProductorDocumento.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspProductorDocumentoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<ConsultarProductorDocumentoPorProductorId> ConsultarProductorDocumentoPorProductorId(int ProductorId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductorId", ProductorId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultarProductorDocumentoPorProductorId>("uspProductorDocumentoConsultaPorProductorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(ProductorDocumento ProductorDocumento)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ProductorId", ProductorDocumento.ProductorId);
            parameters.Add("@Nombre", ProductorDocumento.Nombre);
            parameters.Add("@Descripcion", ProductorDocumento.Descripcion);
            parameters.Add("@Path", ProductorDocumento.Path);
            parameters.Add("@FechaRegistro", ProductorDocumento.FechaRegistro);
            parameters.Add("@UsuarioRegistro", ProductorDocumento.UsuarioRegistro);
            parameters.Add("@EstadoId", ProductorDocumento.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspProductorDocumentoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }


        public int Eliminar(int productorDocumentoId)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ProductorDocumentoId", productorDocumentoId);
            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspProductorDocumentoEliminar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }


        public ProductorDocumento ConsultarProductorDocumentoPorId(int productorDocumentoId)
        {
            ProductorDocumento itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ProductorDocumentoId", productorDocumentoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ProductorDocumento>("uspProductorDocumentoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
