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
    public class DetalleCatalogoRepository : IDetalleCatalogoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public DetalleCatalogoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaDetalleCatalogoBE> ConsultarDetalleCatalogo(ConsultaDetalleCatalogoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", request.EmpresaId);         
            parameters.Add("IdCatalogo", request.IdCatalogo);           
            parameters.Add("EstadoId", request.EstadoId);
           


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaDetalleCatalogoBE>("uspDetalleCatalogoConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaCatalogoTablasBE> ConsultarCatalogoTablas()
        {            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaCatalogoTablasBE>("uspCatalogoTablasConsulta", commandType: CommandType.StoredProcedure);
            }
        }



        public int Insertar(DetalleCatalogo detalleCatalogo)
        {
            int result = 0;            

            var parameters = new DynamicParameters();
           
            parameters.Add("@IdCatalogo", detalleCatalogo.IdCatalogo);
            parameters.Add("@Codigo", detalleCatalogo.Codigo);
            parameters.Add("@Label", detalleCatalogo.Label);
            parameters.Add("@Descripcion", detalleCatalogo.Descripcion);
            parameters.Add("@Mnemonico", detalleCatalogo.Mnemonico);
            parameters.Add("@Val1", detalleCatalogo.Val1);
            parameters.Add("@Val2", detalleCatalogo.Val2);
            parameters.Add("@EmpresaID", detalleCatalogo.EmpresaID);
            parameters.Add("@UsuarioCreacion", detalleCatalogo.UsuarioCreacion);
            parameters.Add("@FechaHoraCreacion", detalleCatalogo.FechaHoraCreacion);
            parameters.Add("@CodigoPadre", detalleCatalogo.CodigoPadre);
            parameters.Add("@EstadoId", detalleCatalogo.EstadoId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDetalleCatalogoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }
            

            return result;
        }

        public int Actualizar(DetalleCatalogo detalleCatalogo)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@IdDetalleCatalogo", detalleCatalogo.IdDetalleCatalogo);
            parameters.Add("@IdCatalogo", detalleCatalogo.IdCatalogo);
            parameters.Add("@Codigo", detalleCatalogo.Codigo);
            parameters.Add("@Label", detalleCatalogo.Label);
            parameters.Add("@Descripcion", detalleCatalogo.Descripcion);
            parameters.Add("@Mnemonico", detalleCatalogo.Mnemonico);
            parameters.Add("@Val1", detalleCatalogo.Val1);
            parameters.Add("@Val2", detalleCatalogo.Val2);
            parameters.Add("@EmpresaID", detalleCatalogo.EmpresaID);            
            parameters.Add("@UsuarioActualizacion", detalleCatalogo.UsuarioActualizacion);
            parameters.Add("@FechaHoraActualizacion", detalleCatalogo.FechaHoraActualizacion);       
            parameters.Add("@CodigoPadre", detalleCatalogo.CodigoPadre);
            parameters.Add("@EstadoId", detalleCatalogo.EstadoId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDetalleCatalogoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaDetalleCatalogoPorIdBE ConsultarDetalleCatalogoPorId(int DetalleCatalogoId)
        {
            ConsultaDetalleCatalogoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@IdDetalleCatalogo", DetalleCatalogoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaDetalleCatalogoPorIdBE>("uspDetalleCatalogoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
