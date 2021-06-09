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
            parameters.Add("@NumeroContrato", request.NumeroContrato);
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

        //        public int Insertar(LiquidacionProcesoPlanta LiquidacionProcesoPlanta)
        //        {
        //            var parameters = new DynamicParameters();

        //            parameters.Add("@EmpresaId", LiquidacionProcesoPlanta.EmpresaId);
        //            parameters.Add("@OrganizacionId", LiquidacionProcesoPlanta.OrganizacionId);
        //            parameters.Add("@TipoProcesoId", LiquidacionProcesoPlanta.TipoProcesoId);
        //            parameters.Add("@OrdenProcesoId", LiquidacionProcesoPlanta.OrdenProcesoId);
        //            parameters.Add("@Numero", LiquidacionProcesoPlanta.Numero);
        //            parameters.Add("@TipoCertificacionId", LiquidacionProcesoPlanta.TipoCertificacionId);
        //            parameters.Add("@EntidadCertificadoraId", LiquidacionProcesoPlanta.EntidadCertificadoraId);
        //            parameters.Add("@ProductoId", LiquidacionProcesoPlanta.ProductoId);
        //            parameters.Add("@SubProductoId", LiquidacionProcesoPlanta.SubProductoId);
        //            parameters.Add("@TipoProduccionId", LiquidacionProcesoPlanta.TipoProduccionId);
        //            parameters.Add("@EmpaqueId", LiquidacionProcesoPlanta.EmpaqueId);
        //            parameters.Add("@TipoId", LiquidacionProcesoPlanta.TipoId);
        //            parameters.Add("@CalidadId", LiquidacionProcesoPlanta.CalidadId);
        //            parameters.Add("@GradoId", LiquidacionProcesoPlanta.GradoId);
        //            parameters.Add("@TotalSacos", LiquidacionProcesoPlanta.TotalSacos);
        //            parameters.Add("@PesoPorSaco", LiquidacionProcesoPlanta.PesoPorSaco);
        //            parameters.Add("@PesoKilos", LiquidacionProcesoPlanta.PesoKilos);
        //            parameters.Add("@CantidadContenedores", LiquidacionProcesoPlanta.CantidadContenedores);
        //            parameters.Add("@CantidadDefectos", LiquidacionProcesoPlanta.CantidadDefectos);
        //            parameters.Add("@FechaInicioProceso", LiquidacionProcesoPlanta.FechaInicioProceso);
        //            parameters.Add("@FechaFinProceso", LiquidacionProcesoPlanta.FechaFinProceso);
        //            parameters.Add("@NombreArchivo", LiquidacionProcesoPlanta.NombreArchivo);
        //            parameters.Add("@DescripcionArchivo", LiquidacionProcesoPlanta.DescripcionArchivo);
        //            parameters.Add("@PathArchivo", LiquidacionProcesoPlanta.PathArchivo);
        //            parameters.Add("@Observacion", LiquidacionProcesoPlanta.Observacion);
        //            parameters.Add("@EstadoId", LiquidacionProcesoPlanta.EstadoId);
        //            parameters.Add("@FechaRegistro", LiquidacionProcesoPlanta.FechaRegistro);
        //            parameters.Add("@UsuarioRegistro", LiquidacionProcesoPlanta.UsuarioRegistro);
        //            parameters.Add("@LiquidacionProcesoPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);

        //            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //            {
        //                db.Execute("uspLiquidacionProcesoPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
        //            }

        //            int id = parameters.Get<int>("LiquidacionProcesoPlantaId");
        //            return id;
        //        }



        //        public int Actualizar(LiquidacionProcesoPlanta LiquidacionProcesoPlanta)
        //        {
        //            int result = 0;

        //            var parameters = new DynamicParameters();
        //            parameters.Add("@LiquidacionProcesoPlantaId", LiquidacionProcesoPlanta.LiquidacionProcesoPlantaId);
        //            parameters.Add("@EmpresaId", LiquidacionProcesoPlanta.EmpresaId);
        //            parameters.Add("@OrganizacionId", LiquidacionProcesoPlanta.OrganizacionId);
        //            parameters.Add("@TipoProcesoId", LiquidacionProcesoPlanta.TipoProcesoId);
        //            parameters.Add("@OrdenProcesoId", LiquidacionProcesoPlanta.OrdenProcesoId);            
        //            parameters.Add("@TipoCertificacionId", LiquidacionProcesoPlanta.TipoCertificacionId);
        //            parameters.Add("@EntidadCertificadoraId", LiquidacionProcesoPlanta.EntidadCertificadoraId);
        //            parameters.Add("@ProductoId", LiquidacionProcesoPlanta.ProductoId);
        //            parameters.Add("@SubProductoId", LiquidacionProcesoPlanta.SubProductoId);
        //            parameters.Add("@TipoProduccionId", LiquidacionProcesoPlanta.TipoProduccionId);
        //            parameters.Add("@EmpaqueId", LiquidacionProcesoPlanta.EmpaqueId);
        //            parameters.Add("@TipoId", LiquidacionProcesoPlanta.TipoId);
        //            parameters.Add("@CalidadId", LiquidacionProcesoPlanta.CalidadId);
        //            parameters.Add("@GradoId", LiquidacionProcesoPlanta.GradoId);
        //            parameters.Add("@TotalSacos", LiquidacionProcesoPlanta.TotalSacos);
        //            parameters.Add("@PesoPorSaco", LiquidacionProcesoPlanta.PesoPorSaco);
        //            parameters.Add("@PesoKilos", LiquidacionProcesoPlanta.PesoKilos);
        //            parameters.Add("@CantidadContenedores", LiquidacionProcesoPlanta.CantidadContenedores);
        //            parameters.Add("@CantidadDefectos", LiquidacionProcesoPlanta.CantidadDefectos);
        //            parameters.Add("@FechaInicioProceso", LiquidacionProcesoPlanta.FechaInicioProceso);
        //            parameters.Add("@FechaFinProceso", LiquidacionProcesoPlanta.FechaFinProceso);
        //            parameters.Add("@NombreArchivo", LiquidacionProcesoPlanta.NombreArchivo);
        //            parameters.Add("@DescripcionArchivo", LiquidacionProcesoPlanta.DescripcionArchivo);
        //            parameters.Add("@PathArchivo", LiquidacionProcesoPlanta.PathArchivo);
        //            parameters.Add("@Observacion", LiquidacionProcesoPlanta.Observacion);            
        //            parameters.Add("@FechaUltimaActualizacion", LiquidacionProcesoPlanta.FechaUltimaActualizacion);
        //            parameters.Add("@UsuarioUltimaActualizacion", LiquidacionProcesoPlanta.UsuarioUltimaActualizacion);


        //            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //            {
        //                result = db.Execute("uspLiquidacionProcesoPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
        //            }
        //            return result;
        //        }

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



        //        public int InsertarProcesoPlantaDetalle(LiquidacionProcesoPlantaDetalle LiquidacionProcesoPlantaDetalle)
        //        {
        //            int result = 0;
        //            var parameters = new DynamicParameters();
        //            parameters.Add("@LiquidacionProcesoPlantaId", LiquidacionProcesoPlantaDetalle.LiquidacionProcesoPlantaId);
        //            parameters.Add("@NotaIngresoPlantaId", LiquidacionProcesoPlantaDetalle.NotaIngresoPlantaId);


        //            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //            {
        //                db.Execute("uspLiquidacionProcesoPlantaDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
        //            }

        //            return result;
        //        }

        //        public int EliminarProcesoPlantaDetalle(int LiquidacionProcesoPlantaPlantaId)
        //        {
        //            int affected = 0;

        //            var parameters = new DynamicParameters();
        //            parameters.Add("@LiquidacionProcesoPlantaId", LiquidacionProcesoPlantaPlantaId);


        //            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //            {
        //                affected = db.Execute("uspLiquidacionProcesoPlantaDetalleEliminar", parameters, commandType: CommandType.StoredProcedure);
        //            }

        //            return affected;
        //        }

        //        public ConsultaLiquidacionProcesoPlantaPorIdBE ConsultarLiquidacionProcesoPlantaPorId(int LiquidacionProcesoPlantaId)
        //        {
        //            ConsultaLiquidacionProcesoPlantaPorIdBE itemBE = null;

        //            var parameters = new DynamicParameters();
        //            parameters.Add("@LiquidacionProcesoPlantaId", LiquidacionProcesoPlantaId);

        //            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //            {
        //                var list = db.Query<ConsultaLiquidacionProcesoPlantaPorIdBE>("uspLiquidacionProcesoPlantaConsultarPorId", parameters, commandType: CommandType.StoredProcedure);

        //                if (list.Any())
        //                    itemBE = list.First();

        //            }
        //            return itemBE;
        //        }

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
