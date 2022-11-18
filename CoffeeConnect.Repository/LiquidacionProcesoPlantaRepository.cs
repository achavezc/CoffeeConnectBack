using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Repository
{
    public class LiquidacionProcesoPlantaRepository : ILiquidacionProcesoPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public LiquidacionProcesoPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaLiquidacionProcesoPlantaBE> ConsultarLiquidacionProcesoPlanta(ConsultaLiquidacionProcesoPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);            
            parameters.Add("@RazonSocialOrganizacion", request.RazonSocialOrganizacion);
            parameters.Add("@RucOrganizacion", request.RucOrganizacion);
            parameters.Add("@TipoProcesoId", request.TipoProcesoId);
            parameters.Add("@EstadoId", request.EstadoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaLiquidacionProcesoPlantaBE>("uspLiquidacionProcesoPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(LiquidacionProcesoPlanta liquidacionProcesoPlanta)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@OrdenProcesoPlantaId", liquidacionProcesoPlanta.OrdenProcesoPlantaId);
            parameters.Add("@Numero", liquidacionProcesoPlanta.Numero);
            parameters.Add("@EmpresaId", liquidacionProcesoPlanta.EmpresaId);
            parameters.Add("@Observacion", liquidacionProcesoPlanta.Observacion);
            parameters.Add("@EnvasesProductos", liquidacionProcesoPlanta.EnvasesProductos);
            parameters.Add("@TrabajosRealizados", liquidacionProcesoPlanta.TrabajosRealizados);
            parameters.Add("@NumeroDefectos", liquidacionProcesoPlanta.NumeroDefectos);
            parameters.Add("@EstadoId", liquidacionProcesoPlanta.EstadoId);
            parameters.Add("@FechaRegistro", liquidacionProcesoPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", liquidacionProcesoPlanta.UsuarioRegistro);
            parameters.Add("@ProductoId", liquidacionProcesoPlanta.ProductoId);
            parameters.Add("@ProductoIdTerminado", liquidacionProcesoPlanta.ProductoIdTerminado);
            parameters.Add("@EntidadCertificadoraId", liquidacionProcesoPlanta.EntidadCertificadoraId);
            parameters.Add("@FechaInicioProceso", liquidacionProcesoPlanta.FechaInicioProceso);
            parameters.Add("@FechaFinProceso", liquidacionProcesoPlanta.FechaFinProceso);
            parameters.Add("@EstadoId", liquidacionProcesoPlanta.EstadoId);
            parameters.Add("@EmpaqueId", liquidacionProcesoPlanta.EmpaqueId);
            parameters.Add("@TipoId", liquidacionProcesoPlanta.TipoId);


            parameters.Add("@LiquidacionProcesoPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspLiquidacionProcesoPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("LiquidacionProcesoPlantaId");
            return id;
        }

        public int Actualizar(LiquidacionProcesoPlanta liquidacionProcesoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@LiquidacionProcesoPlantaId", liquidacionProcesoPlanta.LiquidacionProcesoPlantaId);
            parameters.Add("@OrdenProcesoPlantaId", liquidacionProcesoPlanta.OrdenProcesoPlantaId);
            parameters.Add("@EmpresaId", liquidacionProcesoPlanta.EmpresaId);
            parameters.Add("@Observacion", liquidacionProcesoPlanta.Observacion);
            parameters.Add("@EnvasesProductos", liquidacionProcesoPlanta.EnvasesProductos);
            parameters.Add("@TrabajosRealizados", liquidacionProcesoPlanta.TrabajosRealizados);
            parameters.Add("@FechaUltimaActualizacion", liquidacionProcesoPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", liquidacionProcesoPlanta.UsuarioUltimaActualizacion);
            parameters.Add("@NumeroDefectos", liquidacionProcesoPlanta.NumeroDefectos);
            parameters.Add("@ProductoId", liquidacionProcesoPlanta.ProductoId);
            parameters.Add("@ProductoIdTerminado", liquidacionProcesoPlanta.ProductoIdTerminado);
            parameters.Add("@EntidadCertificadoraId", liquidacionProcesoPlanta.EntidadCertificadoraId);
            parameters.Add("@FechaInicioProceso", liquidacionProcesoPlanta.FechaInicioProceso);
            parameters.Add("@FechaFinProceso", liquidacionProcesoPlanta.FechaInicioProceso);
            parameters.Add("@EmpaqueId", liquidacionProcesoPlanta.EmpaqueId);
            parameters.Add("@TipoId", liquidacionProcesoPlanta.TipoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLiquidacionProcesoPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        //        //public int Anular(int LiquidacionProcesoPlantaId, DateTime fecha, string usuario, string estadoId)
        //        //{
        //        //    int affected = 0;

        //        //    var parameters = new DynamicParameters();
        //        //    parameters.Add("@LiquidacionProcesoPlantaId", LiquidacionProcesoPlantaId);
        //        //    parameters.Add("@Fecha", fecha);
        //        //    parameters.Add("@Usuario", usuario);
        //        //    parameters.Add("@EstadoId", estadoId);

        //        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //        //    {
        //        //        affected = db.Execute("uspLiquidacionProcesoPlantaAnular", parameters, commandType: CommandType.StoredProcedure);
        //        //    }

        //        //    return affected;
        //        //}



        //        public IEnumerable<LiquidacionProcesoPlantaDetalleBE> ConsultarLiquidacionProcesoPlantaDetallePorId(int LiquidacionProcesoPlantaId)
        //        {
        //            var parameters = new DynamicParameters();
        //            parameters.Add("@LiquidacionProcesoPlantaId", LiquidacionProcesoPlantaId);

        //            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //            {
        //                return db.Query<LiquidacionProcesoPlantaDetalleBE>("uspLiquidacionProcesoPlantaDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
        //            }
        //        }

        public int InsertarLiquidacionProcesoPlantaResultado(LiquidacionProcesoPlantaResultado liquidacionProcesoPlantaResultado)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@LiquidacionProcesoPlantaId", liquidacionProcesoPlantaResultado.LiquidacionProcesoPlantaId);
            parameters.Add("@ReferenciaId", liquidacionProcesoPlantaResultado.ReferenciaId);
            parameters.Add("@CantidadSacos", liquidacionProcesoPlantaResultado.CantidadSacos);
            parameters.Add("@KGN", liquidacionProcesoPlantaResultado.KGN);
            parameters.Add("@KilosNetos", liquidacionProcesoPlantaResultado.KilosNetos);
            parameters.Add("@KilosBrutos", liquidacionProcesoPlantaResultado.KilosBrutos);
            parameters.Add("@Tara", liquidacionProcesoPlantaResultado.Tara);
            parameters.Add("@TipoId", liquidacionProcesoPlantaResultado.TipoId);
            parameters.Add("@EmpaqueId", liquidacionProcesoPlantaResultado.EmpaqueId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspLiquidacionProcesoPlantaResultadoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int EliminarLiquidacionProcesoPlantaDetalle(int liquidacionProcesoPlantaPlantaId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@LiquidacionProcesoPlantaId", liquidacionProcesoPlantaPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspLiquidacionProcesoPlantaDetalleEliminar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int EliminarLiquidacionProcesoPlantaResultado(int liquidacionProcesoPlantaPlantaId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@LiquidacionProcesoPlantaId", liquidacionProcesoPlantaPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspLiquidacionProcesoPlantaResultadoEliminar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int InsertarLiquidacionProcesoPlantaDetalle(LiquidacionProcesoPlantaDetalle liquidacionProcesoPlantaDetalle)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@LiquidacionProcesoPlantaId", liquidacionProcesoPlantaDetalle.LiquidacionProcesoPlantaId);
            parameters.Add("@NotaIngresoAlmacenPlantaId", liquidacionProcesoPlantaDetalle.NotaIngresoAlmacenPlantaId);
            parameters.Add("@Cantidad", liquidacionProcesoPlantaDetalle.Cantidad);
            parameters.Add("@KilosNetos", liquidacionProcesoPlantaDetalle.KilosNetos);
            parameters.Add("@PorcentajeHumedad", liquidacionProcesoPlantaDetalle.PorcentajeHumedad);
            parameters.Add("@Descripcion", liquidacionProcesoPlantaDetalle.Descripcion);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspLiquidacionProcesoPlantaDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(int liquidacionProcesoPlantaId)
        {
            ConsultaLiquidacionProcesoPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@LiquidacionProcesoPlantaId", liquidacionProcesoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaLiquidacionProcesoPlantaPorIdBE>("uspLiquidacionProcesoPlantaConsultarPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();

            }
            return itemBE;
        }

        public IEnumerable<ConsultaLiquidacionProcesoPlantaDetalleBE> ConsultarLiquidacionProcesoPlantaDetallePorId(int liquidacionProcesoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LiquidacionProcesoPlantaId", liquidacionProcesoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaLiquidacionProcesoPlantaDetalleBE>("uspLiquidacionProcesoPlantaDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaLiquidacionProcesoPlantaResultadoBE> ConsultarLiquidacionProcesoPlantaResultadoPorId(int liquidacionProcesoPlantaId, int EmpresaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LiquidacionProcesoPlantaId", liquidacionProcesoPlantaId);
            parameters.Add("@EmpresaId", EmpresaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaLiquidacionProcesoPlantaResultadoBE>("uspLiquidacionProcesoPlantaResultadoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //        //public IEnumerable<LiquidacionProcesoPlantaDTO> ConsultarImpresionLiquidacionProcesoPlanta(int LiquidacionProcesoPlantaId)
        //        //{
        //        //    var parameters = new DynamicParameters();
        //        //    parameters.Add("@pLiquidacionProcesoPlantaId", LiquidacionProcesoPlantaId);

        //        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //        //    {
        //        //        return db.Query<LiquidacionProcesoPlantaDTO>("uspLiquidacionProcesoPlantaConsultaImpresionPorId", parameters, commandType: CommandType.StoredProcedure);
        //        //    }
        //        //}
    }
}
