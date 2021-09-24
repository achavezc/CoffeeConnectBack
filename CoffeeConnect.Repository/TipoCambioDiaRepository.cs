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
    public class TipoCambioDiaRepository : ITipoCambioDiaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public TipoCambioDiaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDia(ConsultaTipoCambioDiaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", request.EmpresaId);            
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaTipoCambioDiaBE>("uspTipoCambioDiaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDiaPorEmpresaId(int empresaID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", empresaID);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaTipoCambioDiaBE>("uspTipoCambioDiaConsultaPorEmpresaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaTipoCambioDiaBE> ConsultarTipoCambioDiaPorSubProductoIdPorEmpresaId(int empresaID, string subProductoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", empresaID);
            parameters.Add("SubProductoId", subProductoId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaTipoCambioDiaBE>("uspTipoCambioDiaConsultaPorSubProductoIdPorEmpresaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(TipoCambioDia TipoCambioDia)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", TipoCambioDia.EmpresaId);
            parameters.Add("@Fecha", TipoCambioDia.Fecha);
            parameters.Add("@Monto", TipoCambioDia.Monto);
            parameters.Add("@FechaRegistro", TipoCambioDia.FechaRegistro);
            parameters.Add("@UsuarioRegistro", TipoCambioDia.UsuarioRegistro);
            parameters.Add("@EstadoId", TipoCambioDia.EstadoId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspTipoCambioDiaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public int Actualizar(TipoCambioDia TipoCambioDia)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@TipoCambioDiaId", TipoCambioDia.TipoCambioDiaId);
            parameters.Add("@EmpresaId", TipoCambioDia.EmpresaId);           
            parameters.Add("@Fecha", TipoCambioDia.Fecha);
            parameters.Add("@Monto", TipoCambioDia.Monto);
            parameters.Add("@FechaUltimaActualizacion", TipoCambioDia.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", TipoCambioDia.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", TipoCambioDia.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspTipoCambioDiaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaTipoCambioDiaPorIdBE ConsultarTipoCambioDiaPorId(int TipoCambioDiaId)
        {
            ConsultaTipoCambioDiaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@TipoCambioDiaId", TipoCambioDiaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaTipoCambioDiaPorIdBE>("uspTipoCambioDiaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public int Anular(int TipoCambioDiaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@TipoCambioDiaId", TipoCambioDiaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspTipoCambioDiaAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public decimal ObtenerTipoCambioDia(int empresaId)
        {
            decimal tipoCambio = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", empresaId);            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                tipoCambio = db.ExecuteScalar<decimal>("uspTipoCambioDiaObtener", parameters, commandType: CommandType.StoredProcedure);
            }

            return tipoCambio;
        }
    }
}
