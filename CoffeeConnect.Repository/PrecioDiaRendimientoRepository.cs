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
    }
}
