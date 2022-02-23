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

namespace CoffeeConnect.Repository
{
    public class ContratoCompraRepository : IContratoCompraRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ContratoCompraRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaContratoCompraBE> ConsultarContratoCompra(ConsultaContratoCompraRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("TipoProduccionId", request.TipoProduccionId);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("CalidadId", request.CalidadId);
            parameters.Add("RucProductor", request.RucProductor);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("CondicionEntregaId", request.CondicionEntregaId);
            parameters.Add("EstadoFijacionId", request.EstadoFijacionId);
            parameters.Add("TipoContratoId", request.TipoContratoId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);
            parameters.Add("EstadoPagoFacturaId", request.EstadoPagoFacturaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaContratoCompraBE>("uspContratoCompraConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(ContratoCompra ContratoCompra)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@Numero", ContratoCompra.Numero);
            parameters.Add("@ProductorId", ContratoCompra.ProductorId);
            parameters.Add("@ContratoVentaId", ContratoCompra.ContratoVentaId);
            parameters.Add("@FloId", ContratoCompra.FloId);
            parameters.Add("@CondicionEntregaId", ContratoCompra.CondicionEntregaId);
            parameters.Add("@FechaEntrega", ContratoCompra.FechaEntrega);
            parameters.Add("EmpresaId", ContratoCompra.EmpresaId);
            parameters.Add("@FechaContrato", ContratoCompra.FechaContrato);
            parameters.Add("@TipoContratoId", ContratoCompra.TipoContratoId);
            parameters.Add("@PeriodosCosecha", ContratoCompra.PeriodosCosecha);
            parameters.Add("@FechaFacturacion", ContratoCompra.FechaFacturacion);            
            parameters.Add("@ProductoId", ContratoCompra.ProductoId);
            parameters.Add("@SubProductoId", ContratoCompra.SubProductoId);
            parameters.Add("@TipoProduccionId", ContratoCompra.TipoProduccionId);
            parameters.Add("@MonedadId", ContratoCompra.MonedadId);
            parameters.Add("@Monto", ContratoCompra.Monto);
            parameters.Add("@UnidadMedicionId", ContratoCompra.UnidadMedicionId);
            parameters.Add("@CalculoContratoId", ContratoCompra.CalculoContratoId ?? string.Empty);
            parameters.Add("@EntidadCertificadoraId", ContratoCompra.EntidadCertificadoraId);
            parameters.Add("@TipoCertificacionId", ContratoCompra.TipoCertificacionId);
            parameters.Add("@CalidadId", ContratoCompra.CalidadId);
            parameters.Add("@GradoId", ContratoCompra.GradoId);
            parameters.Add("@PesoPorSaco", ContratoCompra.PesoPorSaco);
            parameters.Add("@PreparacionCantidadDefectos", ContratoCompra.PreparacionCantidadDefectos);
            parameters.Add("@LaboratorioId", ContratoCompra.LaboratorioId);
            parameters.Add("@FechaEnvioMuestra", ContratoCompra.FechaEnvioMuestra);
            parameters.Add("@NumeroSeguimientoMuestra", ContratoCompra.NumeroSeguimientoMuestra);
            parameters.Add("@EstadoMuestraId", ContratoCompra.EstadoMuestraId);
            parameters.Add("@ObservacionMuestra", ContratoCompra.ObservacionMuestra);
            parameters.Add("@NavieraId", ContratoCompra.NavieraId);
            parameters.Add("@FechaRecepcionMuestra", ContratoCompra.FechaRecepcionMuestra);
            parameters.Add("@ObservacionMuestra", ContratoCompra.ObservacionMuestra);
            parameters.Add("@NavieraId", ContratoCompra.NavieraId);
            parameters.Add("@NombreArchivo", ContratoCompra.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ContratoCompra.DescripcionArchivo);
            parameters.Add("@PathArchivo", ContratoCompra.PathArchivo);
            parameters.Add("@FechaRegistro", ContratoCompra.FechaRegistro);
            parameters.Add("@UsuarioRegistro", ContratoCompra.UsuarioRegistro);
            parameters.Add("@EstadoId", ContratoCompra.EstadoId);
            parameters.Add("@EmpaqueId", ContratoCompra.EmpaqueId);
            parameters.Add("@TipoId", ContratoCompra.TipoId);
            parameters.Add("@TotalSacos", ContratoCompra.TotalSacos);
            parameters.Add("@PesoEnContrato", ContratoCompra.PesoEnContrato);
            parameters.Add("@PesoKilos", ContratoCompra.PesoKilos);
            parameters.Add("@ContratoId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@pFacturarEnId", ContratoCompra.FacturarEnId);
            parameters.Add("@pFechaFijacionContrato", ContratoCompra.FechaFijacionContrato);
            parameters.Add("@pKilosNetosQQ", ContratoCompra.KilosNetosQQ);
            parameters.Add("@pEstadoFijacionId", ContratoCompra.EstadoFijacionId);
            parameters.Add("@pKilosNetosLB", ContratoCompra.KilosNetosLB);
            parameters.Add("@pPrecioNivelFijacion", ContratoCompra.PrecioNivelFijacion);
            parameters.Add("@pDiferencial", ContratoCompra.Diferencial);
            parameters.Add("@pPUTotalA", ContratoCompra.PUTotalA);
            parameters.Add("@pPUTotalB", ContratoCompra.PUTotalB);
            parameters.Add("@pPUTotalC", ContratoCompra.PUTotalC);
            parameters.Add("@pNotaCreditoComision", ContratoCompra.NotaCreditoComision);
            parameters.Add("@pGastosExpCostos", ContratoCompra.GastosExpCostos);
            parameters.Add("@pTotalFacturar1", ContratoCompra.TotalFacturar1);
            parameters.Add("@pTotalFacturar2", ContratoCompra.TotalFacturar2);
            parameters.Add("@pTotalFacturar3", ContratoCompra.TotalFacturar3);
            parameters.Add("@EstadoPagoFacturaId", ContratoCompra.EstadoPagoFacturaId);
            parameters.Add("@FechaPagoFactura", ContratoCompra.FechaPagoFactura);
            parameters.Add("@CantidadContenedores", ContratoCompra.CantidadContenedores);
            parameters.Add("@NumeroFactura", ContratoCompra.NumeroFactura);
            parameters.Add("@FechaFactura", ContratoCompra.FechaFactura);
            parameters.Add("@FechaEntregaProducto", ContratoCompra.FechaEntregaProducto);
            parameters.Add("@MonedaFacturaId", ContratoCompra.MonedaFacturaId);
            parameters.Add("@MontoFactura", ContratoCompra.MontoFactura);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspContratoCompraInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("ContratoId");

            return id;
        }

        public int Actualizar(ContratoCompra ContratoCompra)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ContratoCompraId", ContratoCompra.ContratoCompraId);
            parameters.Add("@ContratoVentaId", ContratoCompra.ContratoVentaId);
            parameters.Add("@Numero", ContratoCompra.Numero);
            parameters.Add("@ProductorId", ContratoCompra.ProductorId);
            parameters.Add("@FloId", ContratoCompra.FloId);
            parameters.Add("EmpresaId", ContratoCompra.EmpresaId);
            parameters.Add("@CondicionEntregaId", ContratoCompra.CondicionEntregaId);
            parameters.Add("@FechaEntrega", ContratoCompra.FechaEntrega);
            parameters.Add("@TipoContratoId", ContratoCompra.TipoContratoId);
            parameters.Add("@FechaContrato", ContratoCompra.FechaContrato);
            parameters.Add("@FechaFacturacion", ContratoCompra.FechaFacturacion);           
            parameters.Add("@ProductoId", ContratoCompra.ProductoId);
            parameters.Add("@SubProductoId", ContratoCompra.SubProductoId);
            parameters.Add("@TipoProduccionId", ContratoCompra.TipoProduccionId);
            parameters.Add("@PeriodosCosecha", ContratoCompra.PeriodosCosecha);
            parameters.Add("@MonedadId", ContratoCompra.MonedadId);
            parameters.Add("@Monto", ContratoCompra.Monto);
            parameters.Add("@UnidadMedicionId", ContratoCompra.UnidadMedicionId);
            parameters.Add("@EntidadCertificadoraId", ContratoCompra.EntidadCertificadoraId);
            parameters.Add("@TipoCertificacionId", ContratoCompra.TipoCertificacionId);
            parameters.Add("@CalculoContratoId", ContratoCompra.CalculoContratoId);
            parameters.Add("@CalidadId", ContratoCompra.CalidadId);
            parameters.Add("@GradoId", ContratoCompra.GradoId);
            parameters.Add("@TotalSacos", ContratoCompra.TotalSacos);
            parameters.Add("@CantidadContenedores", ContratoCompra.CantidadContenedores);
            parameters.Add("@PesoEnContrato", ContratoCompra.PesoEnContrato);
          
            parameters.Add("@PesoKilos", ContratoCompra.PesoKilos);
            parameters.Add("@PesoPorSaco", ContratoCompra.PesoPorSaco);
            parameters.Add("@PreparacionCantidadDefectos", ContratoCompra.PreparacionCantidadDefectos);
            parameters.Add("@LaboratorioId", ContratoCompra.LaboratorioId);
            parameters.Add("@FechaEnvioMuestra", ContratoCompra.FechaEnvioMuestra);
            parameters.Add("@NumeroSeguimientoMuestra", ContratoCompra.NumeroSeguimientoMuestra);
            parameters.Add("@EstadoMuestraId", ContratoCompra.EstadoMuestraId);
            parameters.Add("@ObservacionMuestra", ContratoCompra.ObservacionMuestra);
            parameters.Add("@NavieraId", ContratoCompra.NavieraId);
            parameters.Add("@FechaRecepcionMuestra", ContratoCompra.FechaRecepcionMuestra);
            parameters.Add("@ObservacionMuestra", ContratoCompra.ObservacionMuestra);
            parameters.Add("@NavieraId", ContratoCompra.NavieraId);
            parameters.Add("@NombreArchivo", ContratoCompra.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ContratoCompra.DescripcionArchivo);
            parameters.Add("@PathArchivo", ContratoCompra.PathArchivo);
            parameters.Add("@FechaUltimaActualizacion", ContratoCompra.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", ContratoCompra.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", ContratoCompra.EstadoId);
            parameters.Add("@EmpaqueId", ContratoCompra.EmpaqueId);
            parameters.Add("@TipoId", ContratoCompra.TipoId);
            parameters.Add("@pFacturarEnId", ContratoCompra.FacturarEnId);
            parameters.Add("@pFechaFijacionContrato", ContratoCompra.FechaFijacionContrato);
            parameters.Add("@pKilosNetosQQ", ContratoCompra.KilosNetosQQ);
            parameters.Add("@pEstadoFijacionId", ContratoCompra.EstadoFijacionId);
            parameters.Add("@pKilosNetosLB", ContratoCompra.KilosNetosLB);
            parameters.Add("@pPrecioNivelFijacion", ContratoCompra.PrecioNivelFijacion);
            parameters.Add("@pDiferencial", ContratoCompra.Diferencial);
            parameters.Add("@pPUTotalA", ContratoCompra.PUTotalA);
            parameters.Add("@pPUTotalB", ContratoCompra.PUTotalB);
            parameters.Add("@pPUTotalC", ContratoCompra.PUTotalC);
            parameters.Add("@pNotaCreditoComision", ContratoCompra.NotaCreditoComision);
            parameters.Add("@pGastosExpCostos", ContratoCompra.GastosExpCostos);
            parameters.Add("@pTotalFacturar1", ContratoCompra.TotalFacturar1);
            parameters.Add("@pTotalFacturar2", ContratoCompra.TotalFacturar2);
            parameters.Add("@pTotalFacturar3", ContratoCompra.TotalFacturar3);
            parameters.Add("@EstadoPagoFacturaId", ContratoCompra.EstadoPagoFacturaId);
            parameters.Add("@FechaPagoFactura", ContratoCompra.FechaPagoFactura);
            parameters.Add("@NumeroFactura", ContratoCompra.NumeroFactura);
            parameters.Add("@FechaFactura", ContratoCompra.FechaFactura);
            parameters.Add("@FechaEntregaProducto", ContratoCompra.FechaEntregaProducto);
            parameters.Add("@MonedaFacturaId", ContratoCompra.MonedaFacturaId);
            parameters.Add("@MontoFactura", ContratoCompra.MontoFactura);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspContratoCompraActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public int ActualizarEstado(int ContratoCompraId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ContratoCompraId", ContratoCompraId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspContratoCompraActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

       


        





        public ConsultaContratoCompraPorIdBE ConsultarContratoCompraPorId(int ContratoCompraId)
        {
            ConsultaContratoCompraPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ContratoId", ContratoCompraId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaContratoCompraPorIdBE>("uspContratoCompraConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }


        public int ValidadContratoCompraExistente(int empresaId, string numero)
        {
            int cantidadContratos = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", empresaId);
            parameters.Add("@Numero", numero);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                cantidadContratos = db.ExecuteScalar<int>("uspContratoCompraValidarExistente", parameters, commandType: CommandType.StoredProcedure);
            }

            return cantidadContratos;
        }




        public int AsignarContratoCompra(int contratoVentaId , int contratoCompraId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ContratoCompraId", contratoCompraId);
            parameters.Add("@ContratoVentaId", contratoVentaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);
           



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("usContratoCompraAsignarContratoVenta", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }







    }
}
