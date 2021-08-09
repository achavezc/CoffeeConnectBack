using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adelanto;
using CoffeeConnect.Interface.Repository;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CoffeeConnect.Repository
{
    public class AdelantoRepository : IAdelantoRepository
    {

        public IOptions<ConnectionString> _connectionString;
        public AdelantoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ResultadoPDFAdelanto> GenerarPDF(int idAdelanto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AdelantoId", idAdelanto);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ResultadoPDFAdelanto>("uspAdelantoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        IEnumerable<ConsultaAdelantoBE> IAdelantoRepository.ConsultarAdelanto(ConsultaAdelantoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@NumeroNotaCompra", request.NumeroNotaCompra);
            parameters.Add("@CodigoSocio", request.CodigoSocio);
            parameters.Add("@NombreRazonSocial", request.NombreRazonSocial);
            parameters.Add("@TipoDocumentoId", request.TipoDocumentoId);
            parameters.Add("@NumeroDocumento", request.NumeroDocumento);
            parameters.Add("@EstadoId", request.EstadoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaAdelantoBE>("uspAdelantoConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
