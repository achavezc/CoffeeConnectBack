using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using CoffeeConnect.Models.Kardex;
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
    public class KardexPlantaRepository : IKardexPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public KardexPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        IEnumerable<ConsultaKardexPlantaBE> IKardexPlantaRepository.ConsultarKardexPlanta(ConsultaKardexPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NumeroContrato", request.NumeroContrato);
            parameters.Add("@RucCliente", request.RucCliente);
            parameters.Add("@PlantaProcesoAlmacenId", request.PlantaProcesoAlmacenId);
            parameters.Add("@TipoDocumentoInternoId", request.TipoDocumentoInternoId);
            parameters.Add("@TipoOperacionId", request.TipoOperacionId);
            parameters.Add("@TipoRegistroId", request.TipoRegistroId);
            parameters.Add("@CalidadId", request.CalidadId);
            parameters.Add("@TipoCertificacionId", request.TipoCertificacionId);
            parameters.Add("@EstadoId", request.EstadoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaKardexPlantaBE>("uspKardexPlantaConsultar", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(KardexPlanta KardexPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ContratoId", KardexPlanta.ContratoId);
            parameters.Add("@TipoDocumentoInternoId", KardexPlanta.TipoDocumentoInternoId);
            parameters.Add("@TipoOperacionId", KardexPlanta.TipoOperacionId);
            parameters.Add("@TipoRegistroId", KardexPlanta.TipoRegistroId);
            parameters.Add("@EmpresaId", KardexPlanta.EmpresaId);
            parameters.Add("@Numero", KardexPlanta.Numero);
            parameters.Add("@NumeroComprobanteInterno", KardexPlanta.NumeroComprobanteInterno);
            parameters.Add("@NumeroGuiaRemision", KardexPlanta.NumeroGuiaRemision);
            parameters.Add("@NumeroContrato", KardexPlanta.NumeroContrato);
            parameters.Add("@FechaContrato", KardexPlanta.FechaContrato);
            parameters.Add("@RucCliente", KardexPlanta.RucCliente);
            parameters.Add("@TipoCertificacionId", KardexPlanta.TipoCertificacionId);
            parameters.Add("@CalidadId", KardexPlanta.CalidadId);
            parameters.Add("@CantidadSacosIngresados", KardexPlanta.CantidadSacosIngresados);
            parameters.Add("@CantidadSacosDespachados", KardexPlanta.CantidadSacosDespachados);
            parameters.Add("@KilosIngresados", KardexPlanta.KilosIngresados);
            parameters.Add("@KilosDespachados", KardexPlanta.KilosDespachados);
            parameters.Add("@QQIngresados", KardexPlanta.QQIngresados);
            parameters.Add("@QQDespachados", KardexPlanta.QQDespachados);
            parameters.Add("@FechaFactura", KardexPlanta.FechaFactura);
            parameters.Add("@NumeroFactura", KardexPlanta.NumeroFactura);
            parameters.Add("@PrecioUnitarioCP", KardexPlanta.PrecioUnitarioCP);
            parameters.Add("@PrecioUnitarioVenta", KardexPlanta.PrecioUnitarioVenta);
            parameters.Add("@TotalVenta", KardexPlanta.TotalVenta);
            parameters.Add("@TotalCP", KardexPlanta.TotalCP);
            parameters.Add("@PlantaProcesoAlmacenId", KardexPlanta.PlantaProcesoAlmacenId);
            parameters.Add("@FechaIngreso", KardexPlanta.FechaIngreso);
            parameters.Add("@FechaRegistro", KardexPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", KardexPlanta.UsuarioRegistro);

            parameters.Add("@CompraBruta", KardexPlanta.CompraBruta);
            parameters.Add("@Tara", KardexPlanta.Tara);
            parameters.Add("@PorcentajeRendimiento", KardexPlanta.PorcentajeRendimiento);
            parameters.Add("@PorcentajeHumedad", KardexPlanta.PorcentajeHumedad);
            parameters.Add("@Tasa", KardexPlanta.Tasa);
            parameters.Add("@AproxExp", KardexPlanta.AproxExp);
            parameters.Add("@AproxSacos", KardexPlanta.AproxSacos);
            parameters.Add("@AproxSeg", KardexPlanta.AproxSeg);


            parameters.Add("@KardexPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspKardexPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("KardexPlantaId");

            return id;
        }

        public int Actualizar(KardexPlanta KardexPlanta)
        {
            int result = 0;


            var parameters = new DynamicParameters();
            parameters.Add("@KardexPlantaId", KardexPlanta.KardexPlantaId);
            parameters.Add("@ContratoId", KardexPlanta.ContratoId);
            parameters.Add("@TipoDocumentoInternoId", KardexPlanta.TipoDocumentoInternoId);
            parameters.Add("@TipoOperacionId", KardexPlanta.TipoOperacionId);
            parameters.Add("@TipoRegistroId", KardexPlanta.TipoRegistroId);
            parameters.Add("@EmpresaId", KardexPlanta.EmpresaId);
            parameters.Add("@NumeroComprobanteInterno", KardexPlanta.NumeroComprobanteInterno);
            parameters.Add("@NumeroGuiaRemision", KardexPlanta.NumeroGuiaRemision);
            parameters.Add("@NumeroContrato", KardexPlanta.NumeroContrato);
            parameters.Add("@FechaContrato", KardexPlanta.FechaContrato);
            parameters.Add("@RucCliente", KardexPlanta.RucCliente);
            parameters.Add("@TipoCertificacionId", KardexPlanta.TipoCertificacionId);
            parameters.Add("@CalidadId", KardexPlanta.CalidadId);
            parameters.Add("@CantidadSacosIngresados", KardexPlanta.CantidadSacosIngresados);
            parameters.Add("@CantidadSacosDespachados", KardexPlanta.CantidadSacosDespachados);
            parameters.Add("@KilosIngresados", KardexPlanta.KilosIngresados);
            parameters.Add("@KilosDespachados", KardexPlanta.KilosDespachados);
            parameters.Add("@QQIngresados", KardexPlanta.QQIngresados);
            parameters.Add("@QQDespachados", KardexPlanta.QQDespachados);
            parameters.Add("@FechaFactura", KardexPlanta.FechaFactura);
            parameters.Add("@NumeroFactura", KardexPlanta.NumeroFactura);
            parameters.Add("@PrecioUnitarioCP", KardexPlanta.PrecioUnitarioCP);
            parameters.Add("@PrecioUnitarioVenta", KardexPlanta.PrecioUnitarioVenta);
            parameters.Add("@TotalVenta", KardexPlanta.TotalVenta);
            parameters.Add("@TotalCP", KardexPlanta.TotalCP);
            parameters.Add("@PlantaProcesoAlmacenId", KardexPlanta.PlantaProcesoAlmacenId);
            parameters.Add("@FechaIngreso", KardexPlanta.FechaIngreso);
            parameters.Add("@FechaUltimaActualizacion", KardexPlanta.FechaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", KardexPlanta.UsuarioActualizacion);
            parameters.Add("@EstadoId", KardexPlanta.UsuarioRegistro);
            parameters.Add("@CompraBruta", KardexPlanta.CompraBruta);
            parameters.Add("@Tara", KardexPlanta.Tara);
            parameters.Add("@PorcentajeRendimiento", KardexPlanta.PorcentajeRendimiento);
            parameters.Add("@PorcentajeHumedad", KardexPlanta.PorcentajeHumedad);
            parameters.Add("@Tasa", KardexPlanta.Tasa);
            parameters.Add("@AproxExp", KardexPlanta.AproxExp);
            parameters.Add("@AproxSacos", KardexPlanta.AproxSacos);
            parameters.Add("@AproxSeg", KardexPlanta.AproxSeg);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspKardexPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }


        public ConsultaKardexPlantaPorIdBE ConsultarKardexPlantaPorId(int KardexPlantaId)
        {
            ConsultaKardexPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@KardexPlantaId", KardexPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaKardexPlantaPorIdBE>("uspKardexPlantaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }

        public int Anular(int KardexPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@KardexPlantaId", KardexPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspKardexPlantaAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<KardexPergaminoIngresoConsultaResponse> KardexPergaminoIngresoConsulta(KardexPergaminoIngresoConsultaRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<KardexPergaminoIngresoConsultaResponse>("uspKardexPergaminoIngresoConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<KardexPergaminoSalidaConsultaResponse> KardexPergaminoSalidadConsulta(KardexPergaminoSalidaConsultaRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<KardexPergaminoSalidaConsultaResponse>("uspKardexPergaminoSalidaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
