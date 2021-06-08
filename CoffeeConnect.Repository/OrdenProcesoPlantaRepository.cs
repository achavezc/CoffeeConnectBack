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
                return db.Query<ConsultaOrdenProcesoPlantaBE>("uspOrdenProcesoPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(OrdenProcesoPlanta ordenProcesoPlanta)
        {
            var parameters = new DynamicParameters();
            
            parameters.Add("@EmpresaId", ordenProcesoPlanta.EmpresaId);
            parameters.Add("@OrganizacionId", ordenProcesoPlanta.OrganizacionId);
            parameters.Add("@TipoProcesoId", ordenProcesoPlanta.TipoProcesoId);
            parameters.Add("@OrdenProcesoId", ordenProcesoPlanta.OrdenProcesoId);
            parameters.Add("@Numero", ordenProcesoPlanta.Numero);
            parameters.Add("@TipoCertificacionId", ordenProcesoPlanta.TipoCertificacionId);
            parameters.Add("@EntidadCertificadoraId", ordenProcesoPlanta.EntidadCertificadoraId);
            parameters.Add("@ProductoId", ordenProcesoPlanta.ProductoId);
            parameters.Add("@SubProductoId", ordenProcesoPlanta.SubProductoId);
            parameters.Add("@TipoProduccionId", ordenProcesoPlanta.TipoProduccionId);
            parameters.Add("@EmpaqueId", ordenProcesoPlanta.EmpaqueId);
            parameters.Add("@TipoId", ordenProcesoPlanta.TipoId);
            parameters.Add("@CalidadId", ordenProcesoPlanta.CalidadId);
            parameters.Add("@GradoId", ordenProcesoPlanta.GradoId);
            parameters.Add("@TotalSacos", ordenProcesoPlanta.TotalSacos);
            parameters.Add("@PesoPorSaco", ordenProcesoPlanta.PesoPorSaco);
            parameters.Add("@PesoKilos", ordenProcesoPlanta.PesoKilos);
            parameters.Add("@CantidadContenedores", ordenProcesoPlanta.CantidadContenedores);
            parameters.Add("@CantidadDefectos", ordenProcesoPlanta.CantidadDefectos);
            parameters.Add("@FechaInicioProceso", ordenProcesoPlanta.FechaInicioProceso);
            parameters.Add("@FechaFinProceso", ordenProcesoPlanta.FechaFinProceso);
            parameters.Add("@NombreArchivo", ordenProcesoPlanta.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ordenProcesoPlanta.DescripcionArchivo);
            parameters.Add("@PathArchivo", ordenProcesoPlanta.PathArchivo);
            parameters.Add("@Observacion", ordenProcesoPlanta.Observacion);
            parameters.Add("@EstadoId", ordenProcesoPlanta.EstadoId);
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
            parameters.Add("@OrdenProcesoId", ordenProcesoPlanta.OrdenProcesoId);            
            parameters.Add("@TipoCertificacionId", ordenProcesoPlanta.TipoCertificacionId);
            parameters.Add("@EntidadCertificadoraId", ordenProcesoPlanta.EntidadCertificadoraId);
            parameters.Add("@ProductoId", ordenProcesoPlanta.ProductoId);
            parameters.Add("@SubProductoId", ordenProcesoPlanta.SubProductoId);
            parameters.Add("@TipoProduccionId", ordenProcesoPlanta.TipoProduccionId);
            parameters.Add("@EmpaqueId", ordenProcesoPlanta.EmpaqueId);
            parameters.Add("@TipoId", ordenProcesoPlanta.TipoId);
            parameters.Add("@CalidadId", ordenProcesoPlanta.CalidadId);
            parameters.Add("@GradoId", ordenProcesoPlanta.GradoId);
            parameters.Add("@TotalSacos", ordenProcesoPlanta.TotalSacos);
            parameters.Add("@PesoPorSaco", ordenProcesoPlanta.PesoPorSaco);
            parameters.Add("@PesoKilos", ordenProcesoPlanta.PesoKilos);
            parameters.Add("@CantidadContenedores", ordenProcesoPlanta.CantidadContenedores);
            parameters.Add("@CantidadDefectos", ordenProcesoPlanta.CantidadDefectos);
            parameters.Add("@FechaInicioProceso", ordenProcesoPlanta.FechaInicioProceso);
            parameters.Add("@FechaFinProceso", ordenProcesoPlanta.FechaFinProceso);
            parameters.Add("@NombreArchivo", ordenProcesoPlanta.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ordenProcesoPlanta.DescripcionArchivo);
            parameters.Add("@PathArchivo", ordenProcesoPlanta.PathArchivo);
            parameters.Add("@Observacion", ordenProcesoPlanta.Observacion);            
            parameters.Add("@FechaUltimaActualizacion", ordenProcesoPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", ordenProcesoPlanta.UsuarioUltimaActualizacion);
           

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenProcesoPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
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



        //public IEnumerable<OrdenProcesoPlantaDetalle> ConsultarOrdenProcesoPlantaDetallePorId(int OrdenProcesoPlantaId)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@OrdenProcesoPlantaId", OrdenProcesoPlantaId);

        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        return db.Query<OrdenProcesoPlantaDetalle>("uspOrdenProcesoPlantaDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //}



        //public int InsertarProcesoDetalle(OrdenProcesoPlantaDetalle OrdenProcesoPlantaDetalle)
        //{
        //    int result = 0;
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@FechaNotaIngresoPlanta", OrdenProcesoPlantaDetalle.FechaNotaIngresoPlanta);
        //    parameters.Add("@OrdenProcesoPlantaId", OrdenProcesoPlantaDetalle.OrdenProcesoPlantaId);
        //    parameters.Add("@NroNotaIngresoPlanta", OrdenProcesoPlantaDetalle.NroNotaIngresoPlanta);
        //    parameters.Add("@RendimientoPorcentaje", OrdenProcesoPlantaDetalle.RendimientoPorcentaje);
        //    parameters.Add("@HumedadPorcentaje", OrdenProcesoPlantaDetalle.HumedadPorcentaje);
        //    parameters.Add("@CantidadSacos", OrdenProcesoPlantaDetalle.CantidadSacos);
        //    parameters.Add("@KilosBrutos", OrdenProcesoPlantaDetalle.KilosBrutos);
        //    parameters.Add("@Tara", OrdenProcesoPlantaDetalle.Tara);
        //    parameters.Add("@KilosNetos", OrdenProcesoPlantaDetalle.KilosNetos);

        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        db.Execute("uspOrdenProcesoPlantaDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
        //    }

        //    return result;
        //}

        //public int EliminarProcesoDetalle(int OrdenProcesoPlantaId)
        //{
        //    int affected = 0;

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@OrdenProcesoPlantaId", OrdenProcesoPlantaId);


        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        affected = db.Execute("uspOrdenProcesoPlantaDetalleEliminar", parameters, commandType: CommandType.StoredProcedure);
        //    }

        //    return affected;
        //}

        //public ConsultaOrdenProcesoPlantaPorIdBE ConsultarOrdenProcesoPlantaPorId(int OrdenProcesoPlantaId)
        //{
        //    ConsultaOrdenProcesoPlantaPorIdBE itemBE = null;

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@pOrdenProcesoPlantaId", OrdenProcesoPlantaId);

        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        var list = db.Query<ConsultaOrdenProcesoPlantaPorIdBE>("uspOrdenProcesoPlantaConsultarPorId", parameters, commandType: CommandType.StoredProcedure);

        //        if (list.Any())
        //            itemBE = list.First();
        //        itemBE.detalle = ConsultarOrdenProcesoPlantaDetallePorId(OrdenProcesoPlantaId);
        //    }
        //    return itemBE;
        //}

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
