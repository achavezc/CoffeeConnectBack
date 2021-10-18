using CoffeeConnect.DTO;
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
    }
}
