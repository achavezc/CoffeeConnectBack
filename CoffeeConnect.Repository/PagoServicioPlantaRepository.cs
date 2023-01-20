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
    public class PagoServicioPlantaRepository : IPagoServicioPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public PagoServicioPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int AnularPagoServicioPlanta(int PagoServicioPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@PagoServicioPlantaId", PagoServicioPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspPagoServicioPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int Insertar(PagoServicioPlanta PagoServicioPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@PagoServicioPlantaId", PagoServicioPlanta.PagoServicioPlantaId);
            parameters.Add("@EmpresaId", PagoServicioPlanta.EmpresaId);
            parameters.Add("@ServicioPlantaId", PagoServicioPlanta.ServicioPlantaId);
            parameters.Add("@Numero", PagoServicioPlanta.Numero);
            parameters.Add("@NumeroOperacion", PagoServicioPlanta.NumeroOperacion);
            parameters.Add("@TipoOperacionPagoServicioId", PagoServicioPlanta.TipoOperacionPagoServicioId);
            parameters.Add("@BancoId", PagoServicioPlanta.BancoId);
            parameters.Add("@FechaOperacion", PagoServicioPlanta.FechaOperacion);
            parameters.Add("@Importe", PagoServicioPlanta.Importe);
            parameters.Add("@MonedaId", PagoServicioPlanta.MonedaId);
            parameters.Add("@Observaciones", PagoServicioPlanta.Observaciones);
            parameters.Add("@EstadoId", PagoServicioPlanta.EstadoId);
            parameters.Add("@FechaRegistro", PagoServicioPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", PagoServicioPlanta.UsuarioRegistro);
           

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspPagoServicioPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ConsultaPagoServicioPlantaBE> ConsultarPagoServicioPlanta(ConsultaPagoServicioPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroOperacion", request.NumeroOperacion);
            parameters.Add("TipoOperacionPagoServicioId", request.TipoOperacionPagoServicioId);
            parameters.Add("BancoId", request.BancoId);
            parameters.Add("MonedaId", request.MonedaId);
            parameters.Add("ServicioPlantaId", request.ServicioPlantaId);
            parameters.Add("EstadoId", request.EstadoId);            
            parameters.Add("EmpresaId", request.EmpresaId);           
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaPagoServicioPlantaBE>("uspPagoServicioPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public ConsultaPagoServicioPlantaPorIdBE ConsultarPagoServicioPlantaPorId(int PagoServicioPlantaId)
        {
            ConsultaPagoServicioPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@PagoServicioPlantaId", PagoServicioPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaPagoServicioPlantaPorIdBE>("uspPagoServicioPlantaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public int Actualizar(PagoServicioPlanta PagoServicioPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@PagoServicioPlantaId", PagoServicioPlanta.PagoServicioPlantaId);
            parameters.Add("@EmpresaId", PagoServicioPlanta.EmpresaId);
            parameters.Add("@ServicioPlantaId", PagoServicioPlanta.ServicioPlantaId);
            parameters.Add("@Numero", PagoServicioPlanta.Numero);
            parameters.Add("@NumeroOperacion", PagoServicioPlanta.NumeroOperacion);
            parameters.Add("@TipoOperacionPagoServicioId", PagoServicioPlanta.TipoOperacionPagoServicioId);
            parameters.Add("@BancoId", PagoServicioPlanta.BancoId);
            parameters.Add("@FechaOperacion", PagoServicioPlanta.FechaOperacion);
            parameters.Add("@Importe", PagoServicioPlanta.Importe);
            parameters.Add("@MonedaId", PagoServicioPlanta.MonedaId);
            parameters.Add("@Observaciones", PagoServicioPlanta.Observaciones);
            parameters.Add("@FechaUltimaActualizacion", PagoServicioPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", PagoServicioPlanta.UsuarioUltimaActualizacion);
             

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspPagoServicioPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }






    }
}
