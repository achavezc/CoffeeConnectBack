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
    public class OrdenProcesoPlantaRepository : IOrdenProcesoPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;

        public OrdenProcesoPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public IEnumerable<ConsultaOrdenProcesoPlantaBE> ConsultarOrdenProcesoPlanta(ConsultaOrdenProcesoPlantaRequestDTO request)
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
                return db.Query<ConsultaOrdenProcesoPlantaBE>("uspOrdenProcesoPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(OrdenProcesoPlanta ordenProcesoPlanta)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@EmpresaId", ordenProcesoPlanta.EmpresaId);
            parameters.Add("@OrganizacionId", ordenProcesoPlanta.OrganizacionId);
            parameters.Add("@TipoProcesoId", ordenProcesoPlanta.TipoProcesoId);            
            parameters.Add("@Numero", ordenProcesoPlanta.Numero);            
            parameters.Add("@EmpaqueId", ordenProcesoPlanta.EmpaqueId);
            parameters.Add("@TipoId", ordenProcesoPlanta.TipoId);            
            parameters.Add("@CantidadDefectos", ordenProcesoPlanta.CantidadDefectos);
            parameters.Add("@NumeroContrato", ordenProcesoPlanta.NumeroContrato);
            
            parameters.Add("@NombreArchivo", ordenProcesoPlanta.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ordenProcesoPlanta.DescripcionArchivo);
            parameters.Add("@PathArchivo", ordenProcesoPlanta.PathArchivo);
            parameters.Add("@Observacion", ordenProcesoPlanta.Observacion);
            parameters.Add("@EstadoId", ordenProcesoPlanta.EstadoId);
            
            parameters.Add("@ProductoId", ordenProcesoPlanta.ProductoId);
            parameters.Add("@ProductoIdTerminado", ordenProcesoPlanta.ProductoIdTerminado);
            parameters.Add("@EntidadCertificadoraId", ordenProcesoPlanta.EntidadCertificadoraId);
            parameters.Add("@CertificacionId", ordenProcesoPlanta.CertificacionId);
            parameters.Add("@FechaInicioProceso", ordenProcesoPlanta.FechaInicioProceso);
           
       

            
            parameters.Add("@FechaRegistro", ordenProcesoPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", ordenProcesoPlanta.UsuarioRegistro);
            parameters.Add("@OrdenProcesoPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspOrdenProcesoPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("OrdenProcesoPlantaId");
            return id;
        }



        public int Actualizar(OrdenProcesoPlanta ordenProcesoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoPlantaId", ordenProcesoPlanta.OrdenProcesoPlantaId);
            parameters.Add("@EmpresaId", ordenProcesoPlanta.EmpresaId);
            parameters.Add("@OrganizacionId", ordenProcesoPlanta.OrganizacionId);
            parameters.Add("@TipoProcesoId", ordenProcesoPlanta.TipoProcesoId);           
            parameters.Add("@EmpaqueId", ordenProcesoPlanta.EmpaqueId);
            parameters.Add("@TipoId", ordenProcesoPlanta.TipoId);
            parameters.Add("@NumeroContrato", ordenProcesoPlanta.NumeroContrato);
            parameters.Add("@CantidadDefectos", ordenProcesoPlanta.CantidadDefectos);            
            parameters.Add("@NombreArchivo", ordenProcesoPlanta.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ordenProcesoPlanta.DescripcionArchivo);
            parameters.Add("@PathArchivo", ordenProcesoPlanta.PathArchivo);
            parameters.Add("@Observacion", ordenProcesoPlanta.Observacion);
            parameters.Add("@FechaUltimaActualizacion", ordenProcesoPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", ordenProcesoPlanta.UsuarioUltimaActualizacion);
            parameters.Add("@ProductoId", ordenProcesoPlanta.ProductoId);
            parameters.Add("@ProductoIdTerminado", ordenProcesoPlanta.ProductoIdTerminado);
            parameters.Add("@EntidadCertificadoraId", ordenProcesoPlanta.EntidadCertificadoraId);
            parameters.Add("@CertificacionId", ordenProcesoPlanta.CertificacionId);
            parameters.Add("@FechaInicioProceso", ordenProcesoPlanta.FechaInicioProceso);
            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenProcesoPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }


        public int ActualizarEstadoLiquidado(int ordenProcesoPlantaId, DateTime fecha, string usuario, string estadoId, DateTime fechaFinProceso)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoPlantaId", ordenProcesoPlantaId);
            parameters.Add("@FechaFinProceso", fechaFinProceso);
            parameters.Add("@UsuarioUltimaActualizacion", usuario);
            parameters.Add("@FechaUltimaActualizacion", fecha);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspOrdenProcesoPlantaActualizarEstadoLiquidado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }



        //public int Anular(int OrdenProcesoPlantaId, DateTime fecha, string usuario, string estadoId)
        //{
        //    int affected = 0;

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@OrdenProcesoPlantaId", OrdenProcesoPlantaId);
        //    parameters.Add("@Fecha", fecha);
        //    parameters.Add("@Usuario", usuario);
        //    parameters.Add("@EstadoId", estadoId);

        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        affected = db.Execute("uspOrdenProcesoPlantaAnular", parameters, commandType: CommandType.StoredProcedure);
        //    }

        //    return affected;
        //}



        public IEnumerable<OrdenProcesoPlantaDetalleBE> ConsultarOrdenProcesoPlantaDetallePorId(int OrdenProcesoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoPlantaId", OrdenProcesoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<OrdenProcesoPlantaDetalleBE>("uspOrdenProcesoPlantaDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        public int InsertarProcesoPlantaDetalle(OrdenProcesoPlantaDetalle ordenProcesoPlantaDetalle)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoPlantaId", ordenProcesoPlantaDetalle.OrdenProcesoPlantaId);
            parameters.Add("@NotaIngresoAlmacenPlantaId", ordenProcesoPlantaDetalle.NotaIngresoAlmacenPlantaId);
            parameters.Add("@NumeroIngresoAlmacenPlanta", ordenProcesoPlantaDetalle.NumeroIngresoAlmacenPlanta);


            parameters.Add("@FechaIngresoAlmacen", ordenProcesoPlantaDetalle.FechaIngresoAlmacen);
            parameters.Add("@Cantidad", ordenProcesoPlantaDetalle.Cantidad);
            parameters.Add("@KilosNetos", ordenProcesoPlantaDetalle.KilosNetos);
            parameters.Add("@CantidadNotaIngreso", ordenProcesoPlantaDetalle.CantidadNotaIngreso);
            parameters.Add("@KilosNetosNotaIngreso", ordenProcesoPlantaDetalle.KilosNetosNotaIngreso);
            parameters.Add("@PorcentajeHumedad", ordenProcesoPlantaDetalle.PorcentajeHumedad);
            parameters.Add("@PorcentajeExportable", ordenProcesoPlantaDetalle.PorcentajeExportable);
            parameters.Add("@PorcentajeDescarte", ordenProcesoPlantaDetalle.PorcentajeDescarte);
            parameters.Add("@PorcentajeCascarilla", ordenProcesoPlantaDetalle.PorcentajeCascarilla);       
            parameters.Add("@KilosExportables", ordenProcesoPlantaDetalle.KilosExportables);
            parameters.Add("@SacosCalculo", ordenProcesoPlantaDetalle.SacosCalculo);
            parameters.Add("@ProductoId", ordenProcesoPlantaDetalle.ProductoId);
            parameters.Add("@SubProductoId", ordenProcesoPlantaDetalle.SubProductoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspOrdenProcesoPlantaDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int EliminarProcesoPlantaDetalle(int ordenProcesoPlantaPlantaId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoPlantaId", ordenProcesoPlantaPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspOrdenProcesoPlantaDetalleEliminar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaPorId(int ordenProcesoPlantaId)
        {
            ConsultaOrdenProcesoPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoPlantaId", ordenProcesoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaOrdenProcesoPlantaPorIdBE>("uspOrdenProcesoPlantaConsultarPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();

            }
            return itemBE;
        }

        //public IEnumerable<OrdenProcesoPlantaDTO> ConsultarImpresionOrdenProcesoPlanta(int OrdenProcesoPlantaId)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@pOrdenProcesoPlantaId", OrdenProcesoPlantaId);

        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        return db.Query<OrdenProcesoPlantaDTO>("uspOrdenProcesoPlantaConsultaImpresionPorId", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //}
    }
}
