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
    public class DevolucionPrestamoPlantaRepository : IDevolucionPrestamoPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public DevolucionPrestamoPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int AnularDevolucionPrestamoPlanta(int DevolucionPrestamoPlantaId, DateTime fecha, string usuario, string estadoId,string Observacion)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@DevolucionPrestamoPlantaId", DevolucionPrestamoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);
            parameters.Add("@ObservacionAnulacion", Observacion);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspDevolucionPrestamoPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int Insertar(DevolucionPrestamoPlanta DevolucionPrestamoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
                         
            parameters.Add("@EmpresaId", DevolucionPrestamoPlanta.EmpresaId);
            parameters.Add("@PrestamoPlantaId", DevolucionPrestamoPlanta.PrestamoPlantaId);
            parameters.Add("@Numero", DevolucionPrestamoPlanta.Numero);
            parameters.Add("@DestinoDevolucionId", DevolucionPrestamoPlanta.DestinoDevolucionId);
            parameters.Add("@BancoId", DevolucionPrestamoPlanta.BancoId);
            parameters.Add("@FechaDevolucion", DevolucionPrestamoPlanta.FechaDevolucion);
            parameters.Add("@MonedaId", DevolucionPrestamoPlanta.MonedaId);
            parameters.Add("@Importe", DevolucionPrestamoPlanta.Importe);
            parameters.Add("@ImporteCambio", DevolucionPrestamoPlanta.ImporteCambio);
            parameters.Add("@Observaciones", DevolucionPrestamoPlanta.Observaciones);
            parameters.Add("@EstadoId", DevolucionPrestamoPlanta.EstadoId);
            parameters.Add("@FechaRegistro", DevolucionPrestamoPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", DevolucionPrestamoPlanta.UsuarioRegistro);
            parameters.Add("@DevolucionPrestamoPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDevolucionPrestamoPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ConsultaDevolucionPrestamoPlantaBE> ConsultarDevolucionPrestamoPlanta(ConsultaDevolucionPrestamoPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("PrestamoPlantaId", request.PrestamoPlantaId);

            parameters.Add("DestinoDevolucionId", request.DestinoDevolucionId);
            parameters.Add("BancoId", request.BancoId);
            parameters.Add("MonedaId", request.MonedaId);            
            parameters.Add("EstadoId", request.EstadoId);            
            parameters.Add("EmpresaId", request.EmpresaId);           
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {

                return db.Query<ConsultaDevolucionPrestamoPlantaBE>("uspDevolucionPrestamoPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public ConsultaDevolucionPrestamoPlantaPorIdBE ConsultarDevolucionPrestamoPlantaPorId(int DevolucionPrestamoPlantaId)
        {
            ConsultaDevolucionPrestamoPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@DevolucionPrestamoPlantaId", DevolucionPrestamoPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaDevolucionPrestamoPlantaPorIdBE>("uspDevolucionPrestamoPlantaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public int Actualizar(DevolucionPrestamoPlanta DevolucionPrestamoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@DevolucionPrestamoPlantaId", DevolucionPrestamoPlanta.DevolucionPrestamoPlantaId);
            parameters.Add("@EmpresaId", DevolucionPrestamoPlanta.EmpresaId);
            parameters.Add("@PrestamoPlantaId", DevolucionPrestamoPlanta.PrestamoPlantaId);
            parameters.Add("@DestinoDevolucionId", DevolucionPrestamoPlanta.DestinoDevolucionId);
            parameters.Add("@BancoId", DevolucionPrestamoPlanta.BancoId);
            parameters.Add("@FechaDevolucion", DevolucionPrestamoPlanta.FechaDevolucion);
            parameters.Add("@MonedaId", DevolucionPrestamoPlanta.MonedaId);
            parameters.Add("@Importe", DevolucionPrestamoPlanta.Importe);
            parameters.Add("@ImporteCambio", DevolucionPrestamoPlanta.ImporteCambio);
            parameters.Add("@Observaciones", DevolucionPrestamoPlanta.Observaciones);             
            parameters.Add("@FechaUltimaActualizacion", DevolucionPrestamoPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", DevolucionPrestamoPlanta.UsuarioUltimaActualizacion);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDevolucionPrestamoPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }






    }
}
