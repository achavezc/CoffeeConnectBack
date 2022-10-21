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
    public class NotaIngresoAlmacenPlantaRepository : INotaIngresoAlmacenPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaIngresoAlmacenPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", NotaIngresoAlmacenPlanta.ControlCalidadPlantaId);
            parameters.Add("@EmpresaId", NotaIngresoAlmacenPlanta.EmpresaId);
            parameters.Add("@AlmacenId", NotaIngresoAlmacenPlanta.AlmacenId);           
            parameters.Add("@Numero", NotaIngresoAlmacenPlanta.Numero);
            parameters.Add("@TipoId", NotaIngresoAlmacenPlanta.TipoId);
            parameters.Add("@EmpaqueId", NotaIngresoAlmacenPlanta.EmpaqueId);
            parameters.Add("@Cantidad", NotaIngresoAlmacenPlanta.Cantidad);
            parameters.Add("@PesoBruto", NotaIngresoAlmacenPlanta.PesoBruto);
            parameters.Add("@Tara", NotaIngresoAlmacenPlanta.Tara);
            parameters.Add("@KilosNetos", NotaIngresoAlmacenPlanta.KilosNetos);
            parameters.Add("@CantidadDisponible", NotaIngresoAlmacenPlanta.CantidadDisponible);
            parameters.Add("@KilosNetosDisponibles", NotaIngresoAlmacenPlanta.KilosNetosDisponibles);
            parameters.Add("@CantidadOrdenProceso", NotaIngresoAlmacenPlanta.CantidadOrdenProceso);
            parameters.Add("@KilosNetosOrdenProceso", NotaIngresoAlmacenPlanta.KilosNetosOrdenProceso);
            parameters.Add("@EstadoId", NotaIngresoAlmacenPlanta.EstadoId);
            parameters.Add("@FechaRegistro", NotaIngresoAlmacenPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", NotaIngresoAlmacenPlanta.UsuarioRegistro);
            parameters.Add("@NotaIngresoAlmacenPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoAlmacenPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ConsultaNotaIngresoAlmacenPlantaBE> ConsultarNotaIngresoAlmacenPlanta(ConsultaNotaIngresoAlmacenPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroNotaIngresoPlanta", request.NumeroNotaIngresoPlanta);
            parameters.Add("NumeroControlCalidad", request.NumeroControlCalidad);
            parameters.Add("NumeroGuiaRemision", request.NumeroGuiaRemision);           
            parameters.Add("AlmacenId", request.AlmacenId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("RazonSocialEmpresaOrigen", request.RazonSocialEmpresaOrigen);
            parameters.Add("RucEmpresaOrigen", request.RucEmpresaOrigen);
            parameters.Add("FechaInicioGuiaRemision", request.FechaInicioGuiaRemision);
            parameters.Add("FechaFinGuiaRemision", request.FechaFinGuiaRemision);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);            
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("SubProductoId", request.SubProductoId);
            parameters.Add("MotivoIngresoId", request.MotivoIngresoId);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("RendimientoPorcentajeInicio", request.RendimientoPorcentajeInicio);
            parameters.Add("RendimientoPorcentajeFin", request.RendimientoPorcentajeFin);
            parameters.Add("PuntajeAnalisisSensorialInicio", request.PuntajeAnalisisSensorialInicio);
            parameters.Add("PuntajeAnalisisSensorialFin", request.PuntajeAnalisisSensorialFin);
            


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaIngresoAlmacenPlantaBE>("uspNotaIngresoAlmacenPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        //public IEnumerable<NotaIngresoAlmacenPlanta> ConsultarNotaIngresoPorIds(List<TablaIdsTipo> request)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@TablaIdsTipo", request.ToDataTable().AsTableValuedParameter());


        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        return db.Query<NotaIngresoAlmacenPlanta>("uspNotaIngresoAlmacenPlantaConsultarPorIds", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //}


        public int ActualizarEstado(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoAlmacenPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int Actualizar(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string almacenId)
        {
            int affected = 0;           

            //var parameters = new DynamicParameters();
            //parameters.Add("@ControlCalidadPlantaId", NotaIngresoAlmacenPlanta.ControlCalidadPlantaId);
            //parameters.Add("@EmpresaId", NotaIngresoAlmacenPlanta.EmpresaId);
            //parameters.Add("@AlmacenId", NotaIngresoAlmacenPlanta.AlmacenId);
            //parameters.Add("@Numero", NotaIngresoAlmacenPlanta.Numero);
            //parameters.Add("@TipoId", NotaIngresoAlmacenPlanta.TipoId);
            //parameters.Add("@EmpaqueId", NotaIngresoAlmacenPlanta.EmpaqueId);
            //parameters.Add("@Cantidad", NotaIngresoAlmacenPlanta.Cantidad);
            //parameters.Add("@PesoBruto", NotaIngresoAlmacenPlanta.PesoBruto);
            //parameters.Add("@Tara", NotaIngresoAlmacenPlanta.Tara);
            //parameters.Add("@KilosNetos", NotaIngresoAlmacenPlanta.KilosNetos);
            //parameters.Add("@CantidadDisponible", NotaIngresoAlmacenPlanta.CantidadDisponible);
            //parameters.Add("@KilosNetosDisponibles", NotaIngresoAlmacenPlanta.KilosNetosDisponibles);
            //parameters.Add("@CantidadOrdenProceso", NotaIngresoAlmacenPlanta.CantidadOrdenProceso);
            //parameters.Add("@KilosNetosOrdenProceso", NotaIngresoAlmacenPlanta.KilosNetosOrdenProceso);
            //parameters.Add("@EstadoId", NotaIngresoAlmacenPlanta.EstadoId);
            //parameters.Add("@FechaRegistro", NotaIngresoAlmacenPlanta.FechaRegistro);
            //parameters.Add("@UsuarioRegistro", NotaIngresoAlmacenPlanta.UsuarioRegistro);
            //parameters.Add("@NotaIngresoAlmacenPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            //using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            //{
            //    affected = db.Execute("uspNotaIngresoAlmacenPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            //}

            return affected;
        }

        public int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@TablaIdsTipo", ids.ToDataTable().AsTableValuedParameter());
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoAlmacenPlantaActualizarEstadoPorIds", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public ConsultaNotaIngresoAlmacenPlantaPorIdBE ConsultarNotaIngresoAlmacenPlantaPorId(int NotaIngresoAlmacenPlantaId)
        {
            ConsultaNotaIngresoAlmacenPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenIdPlanta", NotaIngresoAlmacenPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaIngresoAlmacenPlantaPorIdBE>("uspNotaIngresoAlmacenPlantaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public IEnumerable<NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoColorDetallePorId(int NotaIngresoAlmacenPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoAlmacenPlantaAnalisisFisicoColorDetalle>("uspNotaIngresoAlmacenPlantaAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoOlorDetallePorId(int NotaIngresoAlmacenPlantaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalle>("uspNotaIngresoAlmacenPlantaAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public IEnumerable<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetallePorId(int NotaIngresoAlmacenPlantaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalle>("uspNotaIngresoAlmacenPlantaAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetallePorId(int NotaIngresoAlmacenPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalle>("uspNotaIngresoAlmacenPlantaAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetallePorId(int NotaIngresoAlmacenPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalle>("uspNotaIngresoAlmacenPlantaAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalle> ConsultarNotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetallePorId(int NotaIngresoAlmacenPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalle>("uspNotaIngresoAlmacenPlantaAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalle> ConsultarNotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetallePorId(int NotaIngresoAlmacenPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalle>("uspNotaIngresoAlmacenPlantaRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
