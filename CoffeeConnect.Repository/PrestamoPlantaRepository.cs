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
    public class PrestamoPlantaRepository  : IPrestamoPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public PrestamoPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int ActualizarPrestamoPlantaEstadoMontos(int PrestamoPlantaId, DateTime fecha, string usuario, string estadoId, decimal importe)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@PrestamoPlantaId", PrestamoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);
            parameters.Add("@TotalImporteProcesado", importe);
             

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspPrestamoPlantaActualizarEstadoMontos", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int ActualizarPrestamoPlantaEstado(int PrestamoPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@PrestamoPlantaId", PrestamoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspPrestamoPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public IEnumerable<ConsultaPrestamoPlantaBE> ConsultarPrestamoPlanta(ConsultaPrestamoPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@FondoPrestamoId", request.FondoPrestamoId);
            parameters.Add("@DetallePrestamo", request.DetallePrestamo);                      
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);
            parameters.Add("@EmpresaId", request.EmpresaId);           
            parameters.Add("@EstadoId", request.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaPrestamoPlantaBE>("uspPrestamoPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int InsertarPrestamoPlanta(PrestamoPlanta PrestamoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
             
            parameters.Add("@EmpresaId", PrestamoPlanta.EmpresaId);             
            parameters.Add("@Numero", PrestamoPlanta.Numero);
            parameters.Add("@DetallePrestamo", PrestamoPlanta.DetallePrestamo);
            parameters.Add("@FondoPrestamoId", PrestamoPlanta.FondoPrestamoId);
            parameters.Add("@Importe", PrestamoPlanta.Importe);
            parameters.Add("@ImporteCambio", PrestamoPlanta.ImporteCambio);
            parameters.Add("@MonedaId", PrestamoPlanta.MonedaId);            
            parameters.Add("@Observaciones", PrestamoPlanta.Observaciones);
            parameters.Add("@EstadoId", PrestamoPlanta.EstadoId);            
            parameters.Add("@FechaRegistro", PrestamoPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", PrestamoPlanta.UsuarioRegistro);           

            parameters.Add("@PrestamoPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspPrestamoPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("PrestamoPlantaId");

            return id;
        }

        public ConsultaPrestamoPlantaPorIdBE ConsultarPrestamoPlantaPorId(int PrestamoPlantaId)
        {
            ConsultaPrestamoPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@PrestamoPlantaId", PrestamoPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaPrestamoPlantaPorIdBE>("uspPrestamoPlantaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


        public int Actualizar(PrestamoPlanta PrestamoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@PrestamoPlantaId", PrestamoPlanta.PrestamoPlantaId);
            parameters.Add("@EmpresaId", PrestamoPlanta.EmpresaId);
            parameters.Add("@DetallePrestamo", PrestamoPlanta.DetallePrestamo);
            parameters.Add("@FondoPrestamoId", PrestamoPlanta.FondoPrestamoId);            
            parameters.Add("@MonedaId", PrestamoPlanta.MonedaId);
            parameters.Add("@Importe", PrestamoPlanta.Importe);
            parameters.Add("@ImporteCambio", PrestamoPlanta.ImporteCambio);
            parameters.Add("@Observaciones", PrestamoPlanta.Observaciones);            
            parameters.Add("@FechaUltimaActualizacion", PrestamoPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", PrestamoPlanta.UsuarioUltimaActualizacion);
           

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspPrestamoPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        //public int ServicioActualizarTotalImporteProcesado(ServicioActualizarTotalImporteProcesado PrestamoPlanta2)
        //{
        //    throw new NotImplementedException();
        //}
    }


}
