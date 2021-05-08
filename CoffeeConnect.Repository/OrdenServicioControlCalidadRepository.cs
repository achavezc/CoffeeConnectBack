using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Core.Common;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class OrdenServicioControlCalidadRepository : IOrdenServicioControlCalidadRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public OrdenServicioControlCalidadRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public IEnumerable<ConsultaOrdenServicioControlCalidadBE> ConsultarOrdenServicioControlCalidad(ConsultaOrdenServicioControlCalidadRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("SubProductoId", request.SubProductoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaOrdenServicioControlCalidadBE>("uspOrdenServicioControlCalidadConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarEstado(int ordenServicioControlCalidadId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenServicioControlCalidadId", ordenServicioControlCalidadId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspOrdenServicioControlCalidadActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int Insertar(OrdenServicioControlCalidad OrdenServicioControlCalidad)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@EmpresaId", OrdenServicioControlCalidad.EmpresaId);
            parameters.Add("@EmpresaProcesadoraId", OrdenServicioControlCalidad.EmpresaProcesadoraId);
            parameters.Add("@Numero", OrdenServicioControlCalidad.Numero);
            parameters.Add("@UnidadMedidaId", OrdenServicioControlCalidad.UnidadMedidaId);
            parameters.Add("@CantidadPesado", OrdenServicioControlCalidad.CantidadPesado);
            parameters.Add("@ProductoId", OrdenServicioControlCalidad.ProductoId);
            parameters.Add("@SubProductoId", OrdenServicioControlCalidad.SubProductoId);
            parameters.Add("@TipoProduccionId", OrdenServicioControlCalidad.TipoProduccionId);
            parameters.Add("@RendimientoEsperadoPorcentaje", OrdenServicioControlCalidad.RendimientoEsperadoPorcentaje);
            parameters.Add("@EstadoId", OrdenServicioControlCalidad.EstadoId);
            parameters.Add("@FechaRegistro", OrdenServicioControlCalidad.FechaRegistro);
            parameters.Add("@UsuarioRegistro", OrdenServicioControlCalidad.UsuarioRegistro);


            parameters.Add("@OrdenServicioControlCalidadId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            result = parameters.Get<int>("OrdenServicioControlCalidadId");


            return result;
        }


        public int Actualizar(OrdenServicioControlCalidad OrdenServicioControlCalidad)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidad.OrdenServicioControlCalidadId);
            parameters.Add("@EmpresaId", OrdenServicioControlCalidad.EmpresaId);
            parameters.Add("@EmpresaProcesadoraId", OrdenServicioControlCalidad.EmpresaProcesadoraId);
            parameters.Add("@UnidadMedidaId", OrdenServicioControlCalidad.UnidadMedidaId);
            parameters.Add("@CantidadPesado", OrdenServicioControlCalidad.CantidadPesado);
            parameters.Add("@ProductoId", OrdenServicioControlCalidad.ProductoId);
            parameters.Add("@SubProductoId", OrdenServicioControlCalidad.SubProductoId);
            parameters.Add("@TipoProduccionId", OrdenServicioControlCalidad.TipoProduccionId);
            parameters.Add("@RendimientoEsperadoPorcentaje", OrdenServicioControlCalidad.RendimientoEsperadoPorcentaje);
            parameters.Add("@FechaUltimaActualizacion", OrdenServicioControlCalidad.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", OrdenServicioControlCalidad.UsuarioUltimaActualizacion);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }


        public int ActualizarAnalisisCalidad(OrdenServicioControlCalidad ordenServicioControlCalidad)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", ordenServicioControlCalidad.OrdenServicioControlCalidadId);
            parameters.Add("@ExportableGramosAnalisisFisico", ordenServicioControlCalidad.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", ordenServicioControlCalidad.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", ordenServicioControlCalidad.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", ordenServicioControlCalidad.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", ordenServicioControlCalidad.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", ordenServicioControlCalidad.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", ordenServicioControlCalidad.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", ordenServicioControlCalidad.TotalPorcentajeAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", ordenServicioControlCalidad.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", ordenServicioControlCalidad.TotalAnalisisSensorial);

            parameters.Add("@ObservacionAnalisisFisico", ordenServicioControlCalidad.ObservacionAnalisisFisico);
            parameters.Add("@FechaCalidad", ordenServicioControlCalidad.FechaCalidad);
            parameters.Add("@UsuarioCalidad", ordenServicioControlCalidad.UsuarioCalidad);
            parameters.Add("@ObservacionRegistroTostado", ordenServicioControlCalidad.ObservacionRegistroTostado);
            parameters.Add("@ObservacionAnalisisSensorial", ordenServicioControlCalidad.ObservacionAnalisisSensorial);
            parameters.Add("@EstadoId", ordenServicioControlCalidad.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", ordenServicioControlCalidad.FechaCalidad);
            parameters.Add("@UsuarioUltimaActualizacion", ordenServicioControlCalidad.UsuarioCalidad);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadActualizarCalidad", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }



        public ConsultaOrdenServicioControlCalidadPorIdBE ConsultarOrdenServicioControlCalidadPorId(int OrdenServicioControlCalidadId)
        {
            ConsultaOrdenServicioControlCalidadPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaOrdenServicioControlCalidadPorIdBE>("uspOrdenServicioControlCalidadObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        //public IEnumerable<OrdenServicioControlCalidadDetalle> ConsultarOrdenServicioControlCalidadDetallePorId(int OrdenServicioControlCalidadId)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);



        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        return db.Query<OrdenServicioControlCalidadDetalle>("uspOrdenServicioControlCalidadDetallePorId", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //}



        public IEnumerable<OrdenServicioControlCalidadAnalisisFisicoColorDetalle> ConsultarOrdenServicioControlCalidadAnalisisFisicoColorDetallePorId(int OrdenServicioControlCalidadId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenServicioControlCalidadAnalisisFisicoColorDetalle>("uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<OrdenServicioControlCalidadAnalisisFisicoOlorDetalle> ConsultarOrdenServicioControlCalidadAnalisisFisicoOlorDetallePorId(int OrdenServicioControlCalidadId)
        {


            var parameters = new DynamicParameters();
            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenServicioControlCalidadAnalisisFisicoOlorDetalle>("uspOrdenServicioControlCalidadAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);






            }
        }

        public IEnumerable<OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalle> ConsultarOrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetallePorId(int OrdenServicioControlCalidadId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalle>("uspOrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalle> ConsultarOrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetallePorId(int OrdenServicioControlCalidadId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalle>("uspOrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<OrdenServicioControlCalidadAnalisisSensorialAtributoDetalle> ConsultarOrdenServicioControlCalidadAnalisisSensorialAtributoDetallePorId(int OrdenServicioControlCalidadId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenServicioControlCalidadAnalisisSensorialAtributoDetalle>("uspOrdenServicioControlCalidadAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<OrdenServicioControlCalidadAnalisisSensorialDefectoDetalle> ConsultarOrdenServicioControlCalidadAnalisisSensorialDefectoDetallePorId(int OrdenServicioControlCalidadId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenServicioControlCalidadAnalisisSensorialDefectoDetalle>("uspOrdenServicioControlCalidadAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<OrdenServicioControlCalidadRegistroTostadoIndicadorDetalle> ConsultarOrdenServicioControlCalidadRegistroTostadoIndicadorDetallePorId(int OrdenServicioControlCalidadId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenServicioControlCalidadRegistroTostadoIndicadorDetalle>("uspOrdenServicioControlCalidadRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        public int ActualizarOrdenServicioControlCalidadAnalisisFisicoColorDetalle(List<OrdenServicioControlCalidadAnalisisFisicoColorDetalleTipo> request, int OrdenServicioControlCalidadId)
        {
            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);
            parameters.Add("@OrdenServicioControlCalidadAnalisisFisicoColorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarOrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalle(List<OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleTipo> request, int OrdenServicioControlCalidadId)
        {
            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);
            parameters.Add("@OrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadAnalisisFisicoDefectoPrimarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarOrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalle(List<OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleTipo> request, int OrdenServicioControlCalidadId)
        {
            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);
            parameters.Add("@OrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadAnalisisFisicoDefectoSecundarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar

        }
        public int ActualizarOrdenServicioControlCalidadAnalisisFisicoOlorDetalle(List<OrdenServicioControlCalidadAnalisisFisicoOlorDetalleTipo> request, int OrdenServicioControlCalidadId)
        {
            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);
            parameters.Add("@OrdenServicioControlCalidadAnalisisFisicoOlorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadAnalisisFisicoOlorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarOrdenServicioControlCalidadAnalisisSensorialAtributoDetalle(List<OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleTipo> request, int OrdenServicioControlCalidadId)
        {
            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);
            parameters.Add("@OrdenServicioControlCalidadAnalisisSensorialAtributoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadAnalisisSensorialAtributoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarOrdenServicioControlCalidadAnalisisSensorialDefectoDetalle(List<OrdenServicioControlCalidadAnalisisSensorialDefectoDetalleTipo> request, int OrdenServicioControlCalidadId)
        {
            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);
            parameters.Add("@OrdenServicioControlCalidadAnalisisSensorialDefectoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadAnalisisSensorialDefectoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarOrdenServicioControlCalidadRegistroTostadoIndicadorDetalle(List<OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleTipo> request, int OrdenServicioControlCalidadId)
        {
            //uspOrdenServicioControlCalidadAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@OrdenServicioControlCalidadId", OrdenServicioControlCalidadId);
            parameters.Add("@OrdenServicioControlCalidadRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenServicioControlCalidadRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }



    }
}
