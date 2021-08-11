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
using System.Text;

namespace CoffeeConnect.Repository
{
    public class PrecioDiaRendimientoRepository : IPrecioDiaRendimientoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public PrecioDiaRendimientoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaPrecioDiaRendimientoBE> ConsultaPrecioDiaRendimiento(ConsultarPrecioDiaRendimientoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaPrecioDiaRendimientoBE>("uspPrecioDiaRendimientoConsultar", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@MonedaId", request.MonedaId);
            parameters.Add("@TipoCambio", request.TipoCambio);
            parameters.Add("@PrecioPromedioContrato", request.PrecioPromedioContrato);
            parameters.Add("@PrecioDiaRendimientoTipo", request.Rendimientos.ToDataTable().AsTableValuedParameter());
            parameters.Add("@UsuarioRegistro", request.UsuarioRegistro);
            parameters.Add("@FechaRegistro", request.FechaRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspPrecioDiaRendimientoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int Anular(int precioDiaRendimientoId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@PrecioDiaRendimientoId", precioDiaRendimientoId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspPrecioDiaRendimientoAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


    }
}
