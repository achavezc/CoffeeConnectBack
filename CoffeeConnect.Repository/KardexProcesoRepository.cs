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
    public class KardexProcesoRepository : IKardexProcesoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public KardexProcesoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        IEnumerable<ConsultaKardexProcesoBE> IKardexProcesoRepository.ConsultarKardexProceso(ConsultaKardexProcesoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NumeroContrato", request.NumeroContrato);
            parameters.Add("@NumeroCliente", request.NumeroCliente);
            parameters.Add("@RazonSocial", request.RazonSocial);
            parameters.Add("@PlantaProcesoAlmacenId", request.PlantaProcesoAlmacenId);
            parameters.Add("@TipoDocumentoInternoId", request.TipoDocumentoInternoId);
            parameters.Add("@TipoOperacionId", request.TipoOperacionId);
            parameters.Add("@CalidadId", request.CalidadId);
            parameters.Add("@TipoCertificacionId", request.TipoCertificacionId);
            parameters.Add("@EstadoId", request.EstadoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaKardexProcesoBE>("uspKardexProcesoConsultar", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(KardexProceso kardexProceso)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ContratoId", kardexProceso.ContratoId);
            parameters.Add("@TipoDocumentoInternoId", kardexProceso.TipoDocumentoInternoId);
            parameters.Add("@TipoOperacionId", kardexProceso.TipoOperacionId);
            parameters.Add("@EmpresaId", kardexProceso.EmpresaId);
            parameters.Add("@Numero", kardexProceso.Numero);
            parameters.Add("@NumeroGuiaRemision", kardexProceso.NumeroGuiaRemision);
            parameters.Add("@NumeroContrato", kardexProceso.NumeroContrato);
            parameters.Add("@FechaContrato", kardexProceso.FechaContrato);
            parameters.Add("@ClienteId", kardexProceso.ClienteId);
            parameters.Add("@TipoCertificacionId", kardexProceso.TipoCertificacionId);
            parameters.Add("@CalidadId", kardexProceso.CalidadId);
            parameters.Add("@CantidadSacosIngresados", kardexProceso.CantidadSacosIngresados);
            parameters.Add("@CantidadSacosDespachados", kardexProceso.CantidadSacosDespachados);
            parameters.Add("@KilosIngresados", kardexProceso.KilosIngresados);
            parameters.Add("@KilosDespachados", kardexProceso.KilosDespachados);
            parameters.Add("@QQIngresados", kardexProceso.QQIngresados);
            parameters.Add("@QQDespachados", kardexProceso.QQDespachados);
            parameters.Add("@FechaFactura", kardexProceso.FechaFactura);
            parameters.Add("@NumeroFactura", kardexProceso.NumeroFactura);
            parameters.Add("@PrecioUnitarioCP", kardexProceso.PrecioUnitarioCP);
            parameters.Add("@PrecioUnitarioVenta", kardexProceso.PrecioUnitarioVenta);
            parameters.Add("@TotalVenta", kardexProceso.TotalVenta);
            parameters.Add("@TotalCP", kardexProceso.TotalCP);
            parameters.Add("@PlantaProcesoAlmacenId", kardexProceso.PlantaProcesoAlmacenId);
            parameters.Add("@FechaIngreso", kardexProceso.FechaIngreso);
            parameters.Add("@FechaRegistro", kardexProceso.FechaRegistro);
            parameters.Add("@UsuarioRegistro", kardexProceso.UsuarioRegistro);
            parameters.Add("@KardexProcesoId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspKardexProcesoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("KardexProcesoId");

            return id;
        }

        public int Actualizar(KardexProceso kardexProceso)
        {
            int result = 0;


            var parameters = new DynamicParameters();
            parameters.Add("@KardexProcesoId", kardexProceso.KardexProcesoId);
            parameters.Add("@ContratoId", kardexProceso.ContratoId);
            parameters.Add("@TipoDocumentoInternoId", kardexProceso.TipoDocumentoInternoId);
            parameters.Add("@TipoOperacionId", kardexProceso.TipoOperacionId);
            parameters.Add("@EmpresaId", kardexProceso.EmpresaId);
            parameters.Add("@Numero", kardexProceso.Numero);
            parameters.Add("@NumeroGuiaRemision", kardexProceso.NumeroGuiaRemision);
            parameters.Add("@NumeroContrato", kardexProceso.NumeroContrato);
            parameters.Add("@FechaContrato", kardexProceso.FechaContrato);
            parameters.Add("@ClienteId", kardexProceso.ClienteId);
            parameters.Add("@TipoCertificacionId", kardexProceso.TipoCertificacionId);
            parameters.Add("@CalidadId", kardexProceso.CalidadId);
            parameters.Add("@CantidadSacosIngresados", kardexProceso.CantidadSacosIngresados);
            parameters.Add("@CantidadSacosDespachados", kardexProceso.CantidadSacosDespachados);
            parameters.Add("@KilosIngresados", kardexProceso.KilosIngresados);
            parameters.Add("@KilosDespachados", kardexProceso.KilosDespachados);
            parameters.Add("@QQIngresados", kardexProceso.QQIngresados);
            parameters.Add("@QQDespachados", kardexProceso.QQDespachados);
            parameters.Add("@FechaFactura", kardexProceso.FechaFactura);
            parameters.Add("@NumeroFactura", kardexProceso.NumeroFactura);
            parameters.Add("@PrecioUnitarioCP", kardexProceso.PrecioUnitarioCP);
            parameters.Add("@PrecioUnitarioVenta", kardexProceso.PrecioUnitarioVenta);
            parameters.Add("@TotalVenta", kardexProceso.TotalVenta);
            parameters.Add("@TotalCP", kardexProceso.TotalCP);
            parameters.Add("@PlantaProcesoAlmacenId", kardexProceso.PlantaProcesoAlmacenId);
            parameters.Add("@FechaIngreso", kardexProceso.FechaIngreso);
            parameters.Add("@FechaUltimaActualizacion", kardexProceso.FechaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", kardexProceso.UsuarioActualizacion);
            parameters.Add("@EstadoId", kardexProceso.UsuarioRegistro);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspKardexProcesoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }


        public ConsultaKardexProcesoPorIdBE ConsultarKardexProcesoPorId(int KardexProcesoId)
        {
            ConsultaKardexProcesoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@KardexProcesoId", KardexProcesoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaKardexProcesoPorIdBE>("uspKardexProcesoObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }

        public int Anular(int KardexProcesoId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@KardexProcesoId", KardexProcesoId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspKardexProcesoAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }
    }
}
