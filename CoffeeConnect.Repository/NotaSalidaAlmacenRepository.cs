using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Core.Common;
using Core.Utils;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class NotaSalidaAlmacenRepository : INotaSalidaAlmacenRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaSalidaAlmacenRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(NotaSalidaAlmacen notaSalidaAlmacen)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@EmpresaId", notaSalidaAlmacen.EmpresaId);
            parameters.Add("@AlmacenId", notaSalidaAlmacen.AlmacenId);
            parameters.Add("@Numero", notaSalidaAlmacen.Numero);
            parameters.Add("@MotivoTrasladoId", notaSalidaAlmacen.MotivoTrasladoId);
            parameters.Add("@MotivoTrasladoReferencia", notaSalidaAlmacen.MotivoTrasladoReferencia);
            parameters.Add("@EmpresaIdDestino", notaSalidaAlmacen.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", notaSalidaAlmacen.EmpresaTransporteId);
            parameters.Add("@TransporteId", notaSalidaAlmacen.TransporteId);
            parameters.Add("@NumeroConstanciaMTC", notaSalidaAlmacen.NumeroConstanciaMTC);
            parameters.Add("@MarcaTractorId", notaSalidaAlmacen.MarcaTractorId);
            parameters.Add("@PlacaTractor", notaSalidaAlmacen.PlacaTractor);
            parameters.Add("@MarcaCarretaId", notaSalidaAlmacen.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", notaSalidaAlmacen.PlacaCarreta);
            parameters.Add("@Conductor", notaSalidaAlmacen.Conductor);
            parameters.Add("@Licencia", notaSalidaAlmacen.Licencia);
            parameters.Add("@Observacion", notaSalidaAlmacen.Observacion);
            parameters.Add("@CantidadLotes", notaSalidaAlmacen.CantidadLotes);
            //parameters.Add("@PromedioPorcentajeRendimiento", notaSalidaAlmacen.PromedioPorcentajeRendimiento);
            parameters.Add("@CantidadTotal", notaSalidaAlmacen.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", notaSalidaAlmacen.PesoKilosBrutos);
            parameters.Add("@EstadoId", notaSalidaAlmacen.EstadoId);
            parameters.Add("@FechaRegistro", notaSalidaAlmacen.FechaRegistro);
            parameters.Add("@UsuarioRegistro", notaSalidaAlmacen.UsuarioRegistro);

            parameters.Add("@NotaSalidaAlmacenId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            result = parameters.Get<int>("NotaSalidaAlmacenId");


            return result;
        }

        public int Actualizar(NotaSalidaAlmacen notaSalidaAlmacen)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", notaSalidaAlmacen.NotaSalidaAlmacenId);
            parameters.Add("@EmpresaId", notaSalidaAlmacen.EmpresaId);
            parameters.Add("@AlmacenId", notaSalidaAlmacen.AlmacenId);
            parameters.Add("@Numero", notaSalidaAlmacen.Numero);
            parameters.Add("@MotivoTrasladoId", notaSalidaAlmacen.MotivoTrasladoId);
            parameters.Add("@MotivoTrasladoReferencia", notaSalidaAlmacen.MotivoTrasladoReferencia);
            parameters.Add("@EmpresaIdDestino", notaSalidaAlmacen.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", notaSalidaAlmacen.EmpresaTransporteId);
            parameters.Add("@TransporteId", notaSalidaAlmacen.TransporteId);
            parameters.Add("@NumeroConstanciaMTC", notaSalidaAlmacen.NumeroConstanciaMTC);
            parameters.Add("@MarcaTractorId", notaSalidaAlmacen.MarcaTractorId);
            parameters.Add("@PlacaTractor", notaSalidaAlmacen.PlacaTractor);
            parameters.Add("@MarcaCarretaId", notaSalidaAlmacen.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", notaSalidaAlmacen.PlacaCarreta);
            parameters.Add("@Conductor", notaSalidaAlmacen.Conductor);
            parameters.Add("@Licencia", notaSalidaAlmacen.Licencia);
            parameters.Add("@Observacion", notaSalidaAlmacen.Observacion);
            parameters.Add("@CantidadLotes", notaSalidaAlmacen.CantidadLotes);
            //parameters.Add("@PromedioPorcentajeRendimiento", notaSalidaAlmacen.PromedioPorcentajeRendimiento);
            parameters.Add("@CantidadTotal", notaSalidaAlmacen.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", notaSalidaAlmacen.PesoKilosBrutos);

            parameters.Add("@FechaUltimaActualizacion", notaSalidaAlmacen.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", notaSalidaAlmacen.UsuarioUltimaActualizacion);
            //parameters.Add("@Activo", notaSalidaAlmacen.Activo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenActualizar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }




        public int ActualizarEstado(int notaSalidaAlmacenId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", notaSalidaAlmacenId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaSalidaAlmacenActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<ConsultaNotaSalidaAlmacenBE> ConsultarNotaSalidaAlmacen(ConsultaNotaSalidaAlmacenRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@EmpresaIdDestino", request.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", request.EmpresaTransporteId);
            parameters.Add("@AlmacenId", request.AlmacenId);
            parameters.Add("@MotivoTrasladoId", request.MotivoTrasladoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaSalidaAlmacenBE>("uspNotaSalidaAlmacenConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE> ConsultarImpresionListaProductoresPorNotaSalida(int notaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NotaSalidaAlmacenId", notaSalidaAlmacenId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE>("uspListaProductoresConsultaImpresionPorNotaSalidaAlmacenId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaNotaSalidaAlmacenPorIdBE ConsultarNotaSalidaAlmacenPorId(int notaSalidaAlmacenId)
        {
            ConsultaNotaSalidaAlmacenPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("NotaSalidaAlmacenId", notaSalidaAlmacenId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaSalidaAlmacenPorIdBE>("uspNotaSalidaAlmacenObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public IEnumerable<NotaSalidaAlmacenDetalle> ConsultarNotaSalidaAlmacenDetallePorId(int notaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NotaSalidaAlmacenId", notaSalidaAlmacenId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenDetalle>("uspNotaSalidaAlmacenDetallePorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarNotaSalidaAlmacenAnalisisCalidad(NotaSalidaAlmacen notaSalidaAlmacen)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", notaSalidaAlmacen.NotaSalidaAlmacenId);
            parameters.Add("@ExportableGramosAnalisisFisico", notaSalidaAlmacen.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", notaSalidaAlmacen.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", notaSalidaAlmacen.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", notaSalidaAlmacen.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", notaSalidaAlmacen.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", notaSalidaAlmacen.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", notaSalidaAlmacen.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", notaSalidaAlmacen.TotalPorcentajeAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", notaSalidaAlmacen.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", notaSalidaAlmacen.TotalAnalisisSensorial);
            parameters.Add("@ObservacionAnalisisFisico", notaSalidaAlmacen.ObservacionAnalisisFisico);
            parameters.Add("@FechaCalidad", notaSalidaAlmacen.FechaCalidad);
            parameters.Add("@UsuarioCalidad", notaSalidaAlmacen.UsuarioCalidad);
            parameters.Add("@ObservacionRegistroTostado", notaSalidaAlmacen.ObservacionRegistroTostado);
            parameters.Add("@ObservacionAnalisisSensorial", notaSalidaAlmacen.ObservacionAnalisisSensorial);
            parameters.Add("@EstadoId", notaSalidaAlmacen.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", notaSalidaAlmacen.FechaCalidad);
            parameters.Add("@UsuarioUltimaActualizacion", notaSalidaAlmacen.UsuarioCalidad);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenCalidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<NotaSalidaAlmacenDetalleLotes> ConsultarNotaSalidaAlmacenDetalleLotesPorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenDetalleLotes>("uspNotaSalidaAlmacenDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaSalidaAlmacenAnalisisFisicoColorDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoColorDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisFisicoColorDetalle>("uspNotaSalidaAlmacenAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<NotaSalidaAlmacenAnalisisFisicoOlorDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoOlorDetallePorId(int NotaSalidaAlmacenId)
        {


            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisFisicoOlorDetalle>("uspNotaSalidaAlmacenAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);






            }
        }

        public IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetallePorId(int NotaSalidaAlmacenId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle>("uspNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle>("uspNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<NotaSalidaAlmacenAnalisisSensorialAtributoDetalle> ConsultarNotaSalidaAlmacenAnalisisSensorialAtributoDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisSensorialAtributoDetalle>("uspNotaSalidaAlmacenAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaSalidaAlmacenAnalisisSensorialDefectoDetalle> ConsultarNotaSalidaAlmacenAnalisisSensorialDefectoDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisSensorialDefectoDetalle>("uspNotaSalidaAlmacenAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaSalidaAlmacenRegistroTostadoIndicadorDetalle> ConsultarNotaSalidaAlmacenRegistroTostadoIndicadorDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenRegistroTostadoIndicadorDetalle>("uspNotaSalidaAlmacenRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        public int ActualizarNotaSalidaAlmacenAnalisisFisicoColorDetalle(List<NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle(List<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle(List<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarNotaSalidaAlmacenAnalisisFisicoOlorDetalle(List<NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisFisicoOlorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarNotaSalidaAlmacenAnalisisSensorialAtributoDetalle(List<NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisSensorialAtributoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarNotaSalidaAlmacenAnalisisSensorialDefectoDetalle(List<NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisSensorialDefectoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarNotaSalidaAlmacenRegistroTostadoIndicadorDetalle(List<NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarNotaSalidaAlmacenDetalle(List<NotaSalidaAlmacenDetalle> request, int? NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }


        public IEnumerable<ConsultaNotaSalidaAlmacenLotesDetallePorIdBE> ConsultarNotaSalidaAlmacenLotesDetallePorIdBE(int notaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NotaSalidaAlmacenId", notaSalidaAlmacenId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaSalidaAlmacenLotesDetallePorIdBE>("uspConsultaNotaSalidaAlmacenLotesDetallePorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }


    }



}
