using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class SocioRepository : ISocioRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public SocioRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Actualizar(Socio socio)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioId", socio.SocioId);
            parameters.Add("@ProductorId", socio.ProductorId);
            parameters.Add("@UsuarioUltimaActualizacion", socio.UsuarioUltimaActualizacion);
            parameters.Add("@FechaUltimaActualizacion", socio.FechaUltimaActualizacion);
            parameters.Add("@EstadoId", socio.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioActualizar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public IEnumerable<ConsultaSocioBE> ConsultarSocio(ConsultaSocioRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Codigo", request.Codigo);
            parameters.Add("NombreRazonSocial", request.NombreRazonSocial);
            parameters.Add("TipoDocumentoId", request.TipoDocumentoId);
            parameters.Add("NumeroDocumento", request.NumeroDocumento);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaSocioBE>("uspSocioConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(Socio socio)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@Codigo", socio.Codigo);
            parameters.Add("@ProductorId", socio.ProductorId);
            parameters.Add("@UsuarioRegistro", socio.UsuarioRegistro);
            parameters.Add("@EstadoId", socio.EstadoId);
            parameters.Add("@FechaRegistro", socio.FechaRegistro);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }


        public ConsultaSocioPorIdBE ConsultarSocioPorId(int socioId)
        {
            ConsultaSocioPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioId", socioId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaSocioPorIdBE>("uspSocioObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public ConsultarSocioProductorPorSocioFincaId ConsultarSocioProductorPorSocioFincaId(int socioFincaId)
        {
            ConsultarSocioProductorPorSocioFincaId itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioFincaId", socioFincaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultarSocioProductorPorSocioFincaId>("uspSocioProductorPorSocioFincaId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


    }
}
