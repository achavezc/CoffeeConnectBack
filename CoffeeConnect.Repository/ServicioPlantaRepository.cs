using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
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
    public class ServicioPlantaRepository  : IServicioPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ServicioPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaServicioPlantaBE> ConsultarServicioPlanta(ConsultaServicioPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroOperacionRelacionada", request.NumeroOperacionRelacionada);
            parameters.Add("TipoServicioId", request.TipoServicioId);
            parameters.Add("TipoComprobanteId", request.TipoComprobanteId);
            parameters.Add("SerieComprobante", request.SerieComprobante);
            parameters.Add("NumeroComprobante", request.NumeroComprobante);
            parameters.Add("RazonSocialEmpresaCliente", request.RazonSocialEmpresaCliente);
            parameters.Add("RucEmpresaCliente", request.RucEmpresaCliente);           
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("EstadoId", request.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaServicioPlantaBE>("uspServicioPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int InsertarServicioPlanta(ServicioPlanta ServicioPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
             
            parameters.Add("@EmpresaId", ServicioPlanta.EmpresaId);
            parameters.Add("@EmpresaClienteId", ServicioPlanta.EmpresaClienteId);
            parameters.Add("@Numero", ServicioPlanta.Numero);
            parameters.Add("@NumeroOperacionRelacionada", ServicioPlanta.NumeroOperacionRelacionada);
            parameters.Add("@TipoServicioId", ServicioPlanta.TipoServicioId);
            parameters.Add("@TipoComprobanteId", ServicioPlanta.TipoComprobanteId);
            parameters.Add("@SerieComprobante", ServicioPlanta.SerieComprobante);
            parameters.Add("@NumeroComprobante", ServicioPlanta.NumeroComprobante);
            parameters.Add("@FechaDocumento", ServicioPlanta.FechaDocumento);
            parameters.Add("@SerieDocumento", ServicioPlanta.SerieDocumento);
            parameters.Add("@NumeroDocumento", ServicioPlanta.NumeroDocumento);
            parameters.Add("@UnidadMedidaId", ServicioPlanta.UnidadMedidaId);
            parameters.Add("@Cantidad", ServicioPlanta.Cantidad);
            parameters.Add("@PrecioUnitario", ServicioPlanta.PrecioUnitario);
            parameters.Add("@Importe", ServicioPlanta.Importe);
            parameters.Add("@PorcentajeTIRB", ServicioPlanta.PorcentajeTIRB);
            parameters.Add("@MonedaId", ServicioPlanta.MonedaId);
            parameters.Add("@TotalImporte", ServicioPlanta.TotalImporte);
            parameters.Add("@Observaciones", ServicioPlanta.Observaciones);
            parameters.Add("@EstadoId", ServicioPlanta.EstadoId);
            parameters.Add("@FechaRegistro", ServicioPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", ServicioPlanta.UsuarioRegistro);
             
            parameters.Add("@ServicioPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspServicioPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("ServicioPlantaId");

            return id;
        }

        public ConsultaServicioPlantaPorIdBE ConsultarServicioPlantaPorId(int ServicioPlantaId)
        {
            ConsultaServicioPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ServicioPlantaId", ServicioPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaServicioPlantaPorIdBE>("uspServicioPlantaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        /*

        public int AnularServicioPlanta(int ServicioPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ServicioPlantaId", ServicioPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspServicioPlantaAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        

        public int ActualizarPesado(ServicioPlanta ServicioPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", ServicioPlanta.EmpresaId);
            parameters.Add("@ServicioPlantaId", ServicioPlanta.ServicioPlantaId);
            parameters.Add("@NumeroGuiaRemision", ServicioPlanta.NumeroGuiaRemision);
            parameters.Add("@FechaGuiaRemision", ServicioPlanta.FechaGuiaRemision);
            parameters.Add("@EmpresaOrigenId", ServicioPlanta.EmpresaOrigenId);
            parameters.Add("@TipoProduccionId", ServicioPlanta.TipoProduccionId);
            parameters.Add("@ProductoId", ServicioPlanta.ProductoId);
            parameters.Add("@SubProductoId", ServicioPlanta.SubProductoId);
            parameters.Add("@CertificacionId", ServicioPlanta.CertificacionId);
            parameters.Add("@EntidadCertificadoraId", ServicioPlanta.EntidadCertificadoraId);
            parameters.Add("@MotivoIngresoId", ServicioPlanta.MotivoIngresoId);
            parameters.Add("@EmpaqueId", ServicioPlanta.EmpaqueId);
            parameters.Add("@TipoId", ServicioPlanta.TipoId);
            parameters.Add("@Cantidad", ServicioPlanta.Cantidad);
            parameters.Add("@KilosBrutos", ServicioPlanta.KilosBrutos);
            parameters.Add("@Tara", ServicioPlanta.Tara);
            parameters.Add("@CalidadId", ServicioPlanta.CalidadId);
            parameters.Add("@GradoId", ServicioPlanta.GradoId);
            parameters.Add("@CantidadDefectos", ServicioPlanta.CantidadDefectos);
            parameters.Add("@PesoPorSaco", ServicioPlanta.PesoPorSaco);
            parameters.Add("@KilosNetos", ServicioPlanta.KilosNetos);
            parameters.Add("@HumedadPorcentaje", ServicioPlanta.HumedadPorcentaje);
            parameters.Add("@RendimientoPorcentaje", ServicioPlanta.RendimientoPorcentaje);
            parameters.Add("@RucEmpresaTransporte", ServicioPlanta.RucEmpresaTransporte);
            parameters.Add("@RazonEmpresaTransporte", ServicioPlanta.RazonEmpresaTransporte);
            parameters.Add("@PlacaTractorEmpresaTransporte", ServicioPlanta.PlacaTractorEmpresaTransporte);
            parameters.Add("@ConductorEmpresaTransporte", ServicioPlanta.ConductorEmpresaTransporte);
            parameters.Add("@LicenciaConductorEmpresaTransporte", ServicioPlanta.LicenciaConductorEmpresaTransporte);
            parameters.Add("@ObservacionPesado", ServicioPlanta.ObservacionPesado);
            parameters.Add("@EstadoId", ServicioPlanta.EstadoId);
            parameters.Add("@FechaPesado", ServicioPlanta.FechaPesado);
            parameters.Add("@UsuarioPesado", ServicioPlanta.UsuarioPesado);
            parameters.Add("@FechaUltimaActualizacion", ServicioPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", ServicioPlanta.UsuarioUltimaActualizacion);
            parameters.Add("@Direccion", ServicioPlanta.Direccion);
            parameters.Add("@Marca", ServicioPlanta.Marca);
            parameters.Add("@CodigoCampania", ServicioPlanta.CodigoCampania);
            parameters.Add("@CodigoTipoConcepto", ServicioPlanta.CodigoTipoConcepto);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspServicioPlantaPesadoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }



            return result;
        }
      

        public int InsertarServicioPlantaDetalle(ServicioPlantaDetalle ServicioPlantaDetalle)
        {
            int result = 0;

            var parameters = new DynamicParameters();


            parameters.Add("@ServicioPlantaId", ServicioPlantaDetalle.ServicioPlantaId);
            parameters.Add("@EmpaqueId", ServicioPlantaDetalle.EmpaqueId);
            parameters.Add("@TipoId", ServicioPlantaDetalle.TipoId);
            parameters.Add("@Cantidad", ServicioPlantaDetalle.Cantidad);
            parameters.Add("@SubProductoId", ServicioPlantaDetalle.SubProductoId);
            parameters.Add("@KilosBrutos", ServicioPlantaDetalle.KilosBrutos);
            parameters.Add("@KilosNetos", ServicioPlantaDetalle.KilosNetos);
            parameters.Add("@Tara", ServicioPlantaDetalle.Tara);





            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspServicioPlantaDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ConsultaServicioPlantaDetalle> ConsultarServicioPlantaDetallePorId(int ServicioPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ServicioPlantaId", ServicioPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaServicioPlantaDetalle>("uspServicioPlantaDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }
        }            

        public int ActualizarEstado(int ServicioPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ServicioPlantaId", ServicioPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspServicioPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int EliminarServicioPlantaDetalle(int ServicioPlantaId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ServicioPlantaId", ServicioPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspServicioPlantaDetalleEliminar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }
        */

    }


}
