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
            parameters.Add("ProductoId", request.ProductoId);
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

        public int Insert(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", guiaRecepcionMateriaPrima.EmpresaId);
            parameters.Add("@Numero", guiaRecepcionMateriaPrima.Numero);
            parameters.Add("@TipoProvedorId", guiaRecepcionMateriaPrima.TipoProvedorId);
            parameters.Add("@SocioId", guiaRecepcionMateriaPrima.SocioId);
            parameters.Add("@TerceroId", guiaRecepcionMateriaPrima.TerceroId);
            parameters.Add("@IntermediarioId", guiaRecepcionMateriaPrima.IntermediarioId);
            parameters.Add("@ProductoId", guiaRecepcionMateriaPrima.ProductoId);
            parameters.Add("@SubProductoId", guiaRecepcionMateriaPrima.SubProductoId);
            parameters.Add("@FechaCosecha", guiaRecepcionMateriaPrima.FechaCosecha);
            parameters.Add("@FechaPesado", guiaRecepcionMateriaPrima.FechaPesado);
            parameters.Add("@UsuarioPesado", guiaRecepcionMateriaPrima.UsuarioPesado);
            parameters.Add("@UnidadMedidaIdPesado", guiaRecepcionMateriaPrima.UnidadMedidaIdPesado);
            parameters.Add("@CantidadPesado", guiaRecepcionMateriaPrima.CantidadPesado);
            parameters.Add("@KilosBrutosPesado", guiaRecepcionMateriaPrima.KilosBrutosPesado);
            parameters.Add("@TaraPesado", guiaRecepcionMateriaPrima.TaraPesado);
            parameters.Add("@ObservacionPesado", guiaRecepcionMateriaPrima.ObservacionPesado);            
            parameters.Add("@EstadoId", guiaRecepcionMateriaPrima.EstadoId);
            parameters.Add("@FechaRegistro", guiaRecepcionMateriaPrima.FechaRegistro);
            parameters.Add("@UsuarioRegistro", guiaRecepcionMateriaPrima.UsuarioRegistro);            
            
            parameters.Add("@GuiaRecepcionMateriaPrimaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("GuiaRecepcionMateriaPrimaId");

            return id;
        }

        public int ActualizarAnalisisCalidad(GuiaRecepcionMateriaPrima guiaRecepcionMateriaPrima)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrima.GuiaRecepcionMateriaPrimaId);
            parameters.Add("@ExportableGramosAnalisisFisico", guiaRecepcionMateriaPrima.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", guiaRecepcionMateriaPrima.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", guiaRecepcionMateriaPrima.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", guiaRecepcionMateriaPrima.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.TotalPorcentajeAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", guiaRecepcionMateriaPrima.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", guiaRecepcionMateriaPrima.TotalAnalisisSensorial);

            parameters.Add("@ObservacionAnalisisFisico", guiaRecepcionMateriaPrima.ObservacionAnalisisFisico);
            parameters.Add("@FechaCalidad", guiaRecepcionMateriaPrima.FechaCalidad);
            parameters.Add("@UsuarioCalidad", guiaRecepcionMateriaPrima.UsuarioCalidad);
            parameters.Add("@ObservacionRegistroTostado", guiaRecepcionMateriaPrima.ObservacionRegistroTostado);
            parameters.Add("@ObservacionAnalisisSensorial", guiaRecepcionMateriaPrima.ObservacionAnalisisSensorial);
            parameters.Add("@EstadoId", guiaRecepcionMateriaPrima.EstadoId);            
            parameters.Add("@FechaUltimaActualizacion", guiaRecepcionMateriaPrima.FechaCalidad);
            parameters.Add("@UsuarioUltimaActualizacion", guiaRecepcionMateriaPrima.UsuarioCalidad);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRecepcionMateriaPrimaCalidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }            

            return result;
        }


        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetallePorId(int guiaRecepcionMateriaPrimaId)
        {     
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);
          
            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
              
            }

            
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetallePorId(int guiaRecepcionMateriaPrimaId)
        {          

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
                                
            }           
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetallePorId(int guiaRecepcionMateriaPrimaId)
        {            

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

               
            }

          
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetallePorId(int guiaRecepcionMateriaPrimaId)
        {   
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            
            }

            
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetallePorId(int guiaRecepcionMateriaPrimaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle> ConsultarGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetallePorId(int guiaRecepcionMateriaPrimaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalle>("uspGuiaRecepcionMateriaPrimaAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle> ConsultarGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetallePorId(int guiaRecepcionMateriaPrimaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", guiaRecepcionMateriaPrimaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<GuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalle>("uspGuiaRecepcionMateriaPrimaRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }


}
