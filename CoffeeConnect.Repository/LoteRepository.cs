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
using Core.Utils;
using CoffeeConnect.DTO;

namespace CoffeeConnect.Repository
{
    public class LoteRepository : ILoteRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public LoteRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(Lote lote)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@EmpresaId", lote.EmpresaId);
            parameters.Add("@Numero", lote.Numero);
            parameters.Add("@EstadoId", lote.EstadoId);
            parameters.Add("@ProductoId", lote.ProductoId);
            parameters.Add("@SubProductoId", lote.SubProductoId);
            parameters.Add("@TipoCertificacionId", lote.TipoCertificacionId);
            parameters.Add("@AlmacenId", lote.AlmacenId);
            parameters.Add("@TotalKilosNetosPesado", lote.TotalKilosNetosPesado);
            parameters.Add("@TotalKilosBrutosPesado", lote.TotalKilosBrutosPesado);

            parameters.Add("@UnidadMedidaId", lote.UnidadMedidaId);
            parameters.Add("@Cantidad", lote.Cantidad);
            parameters.Add("@PromedioRendimientoPorcentaje", lote.PromedioRendimientoPorcentaje);
            parameters.Add("@PromedioHumedadPorcentaje", lote.PromedioHumedadPorcentaje);
            parameters.Add("@PromedioTotalAnalisisSensorial", lote.PromedioTotalAnalisisSensorial);

            parameters.Add("@FechaRegistro", lote.FechaRegistro);
            parameters.Add("@UsuarioRegistro", lote.UsuarioRegistro);

            parameters.Add("@LoteId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("LoteId");

            return id;
        }


        public int InsertarLoteDetalle(List<LoteDetalle> request)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteDetalleTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ConsultaLoteBE> ConsultarLote(ConsultaLoteRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NombreRazonSocial", request.NombreRazonSocial);
            parameters.Add("TipoDocumentoId", request.TipoDocumentoId);
            parameters.Add("NumeroDocumento", request.NumeroDocumento);
            parameters.Add("CodigoSocio", request.CodigoSocio);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("TipoCertificacionId", request.TipoCertificacionId);
            parameters.Add("SubProductoId", request.SubProductoId);
            parameters.Add("AlmacenId", request.AlmacenId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaLoteBE>("uspLoteConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public IEnumerable<ConsultaImpresionLotePorIdBE> ConsultarImpresionLotePorId(int loteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("LoteId", loteId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaImpresionLotePorIdBE>("uspLotesDetalleConsultarImpresionPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<LoteDetalle> ConsultarLoteDetallePorId(int loteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("LoteId", loteId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteDetalle>("uspLoteDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarEstado(int loteId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", loteId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspLoteActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<LoteDetalleConsulta> ConsultarBandejaLoteDetallePorId(int loteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("LoteId", loteId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteDetalleConsulta>("uspLotesDetalleConsultarBandejaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public LotesBE ConsultarLotePorId(int loteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("LoteId", loteId);

            IEnumerable<LotesBE> result;
            LotesBE lote = new LotesBE();

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Query<LotesBE>("uspLotesConsultarPorId", parameters, commandType: CommandType.StoredProcedure);
                if (result.Any())
                {
                    lote = result.First();
                }
            }

            return lote;
        }

        public int Actualizar(int loteId, DateTime fecha, string usuario, string almacenId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", loteId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@AlmacenId", almacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspLoteActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int ActualizarLoteAnalisisCalidad(Lote Lote)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", Lote.LoteId);
            parameters.Add("@ExportableGramosAnalisisFisico", Lote.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", Lote.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", Lote.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", Lote.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", Lote.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", Lote.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", Lote.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", Lote.TotalPorcentajeAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", Lote.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", Lote.TotalAnalisisSensorial);
            parameters.Add("@ObservacionAnalisisFisico", Lote.ObservacionAnalisisFisico);
            parameters.Add("@FechaCalidad", Lote.FechaCalidad);
            parameters.Add("@UsuarioCalidad", Lote.UsuarioCalidad);
            parameters.Add("@ObservacionRegistroTostado", Lote.ObservacionRegistroTostado);
            parameters.Add("@ObservacionAnalisisSensorial", Lote.ObservacionAnalisisSensorial);
            parameters.Add("@EstadoId", Lote.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", Lote.FechaCalidad);
            parameters.Add("@UsuarioUltimaActualizacion", Lote.UsuarioCalidad);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteCalidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<LoteAnalisisFisicoColorDetalle> ConsultarLoteAnalisisFisicoColorDetallePorId(int LoteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", LoteId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteAnalisisFisicoColorDetalle>("uspLoteAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<LoteAnalisisFisicoOlorDetalle> ConsultarLoteAnalisisFisicoOlorDetallePorId(int LoteId)
        {


            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", LoteId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteAnalisisFisicoOlorDetalle>("uspLoteAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);






            }
        }

        public IEnumerable<LoteAnalisisFisicoDefectoPrimarioDetalle> ConsultarLoteAnalisisFisicoDefectoPrimarioDetallePorId(int LoteId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", LoteId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteAnalisisFisicoDefectoPrimarioDetalle>("uspLoteAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<LoteAnalisisFisicoDefectoSecundarioDetalle> ConsultarLoteAnalisisFisicoDefectoSecundarioDetallePorId(int LoteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", LoteId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteAnalisisFisicoDefectoSecundarioDetalle>("uspLoteAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<LoteAnalisisSensorialAtributoDetalle> ConsultarLoteAnalisisSensorialAtributoDetallePorId(int LoteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", LoteId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteAnalisisSensorialAtributoDetalle>("uspLoteAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<LoteAnalisisSensorialDefectoDetalle> ConsultarLoteAnalisisSensorialDefectoDetallePorId(int LoteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", LoteId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteAnalisisSensorialDefectoDetalle>("uspLoteAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<LoteRegistroTostadoIndicadorDetalle> ConsultarLoteRegistroTostadoIndicadorDetallePorId(int LoteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LoteId", LoteId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<LoteRegistroTostadoIndicadorDetalle>("uspLoteRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        public int ActualizarLoteAnalisisFisicoColorDetalle(List<LoteAnalisisFisicoColorDetalleTipo> request, int LoteId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", LoteId);
            parameters.Add("@LoteAnalisisFisicoColorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteAnalisisFisicoColorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarLoteAnalisisFisicoDefectoPrimarioDetalle(List<LoteAnalisisFisicoDefectoPrimarioDetalleTipo> request, int LoteId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", LoteId);
            parameters.Add("@LoteAnalisisFisicoDefectoPrimarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteAnalisisFisicoDefectoPrimarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspLoteAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarLoteAnalisisFisicoDefectoSecundarioDetalle(List<LoteAnalisisFisicoDefectoSecundarioDetalleTipo> request, int LoteId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", LoteId);
            parameters.Add("@LoteAnalisisFisicoDefectoSecundarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteAnalisisFisicoDefectoSecundarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspLoteAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarLoteAnalisisFisicoOlorDetalle(List<LoteAnalisisFisicoOlorDetalleTipo> request, int LoteId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", LoteId);
            parameters.Add("@LoteAnalisisFisicoOlorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteAnalisisFisicoOlorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarLoteAnalisisSensorialAtributoDetalle(List<LoteAnalisisSensorialAtributoDetalleTipo> request, int LoteId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", LoteId);
            parameters.Add("@LoteAnalisisSensorialAtributoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteAnalisisSensorialAtributoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarLoteAnalisisSensorialDefectoDetalle(List<LoteAnalisisSensorialDefectoDetalleTipo> request, int LoteId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", LoteId);
            parameters.Add("@LoteAnalisisSensorialDefectoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteAnalisisSensorialDefectoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarLoteRegistroTostadoIndicadorDetalle(List<LoteRegistroTostadoIndicadorDetalleTipo> request, int LoteId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@LoteId", LoteId);
            parameters.Add("@LoteRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }




    }



}
