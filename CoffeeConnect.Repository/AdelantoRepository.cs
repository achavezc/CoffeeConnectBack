using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Adelanto;
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


        public int Insertar(Adelanto adelanto)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@SocioId", adelanto.SocioId);
            parameters.Add("@EmpresaId", adelanto.EmpresaId);
            parameters.Add("@Numero", adelanto.Numero);
            parameters.Add("@TipoDocumentoId", adelanto.TipoDocumentoId);
            parameters.Add("@NumeroDocumento", adelanto.NumeroDocumento);
            parameters.Add("@NombreRazonSocial", adelanto.NombreRazonSocial);
            parameters.Add("@MonedaId", adelanto.MonedaId);
            parameters.Add("@Monto", adelanto.Monto);
            parameters.Add("@FechaPago", adelanto.FechaPago);
            parameters.Add("@Motivo", adelanto.Motivo);
            parameters.Add("@FechaEntregaProducto", adelanto.FechaEntregaProducto);
            parameters.Add("@NotaCompraId", adelanto.NotaCompraId);
            parameters.Add("@EstadoId", adelanto.EstadoId);
            parameters.Add("@FechaRegistro", adelanto.FechaRegistro);
            parameters.Add("@UsuarioRegistro", adelanto.UsuarioRegistro);
            parameters.Add("@AdelantoId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAdelantoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("AdelantoId");

            return id;
        }
        public int Actualizar(Adelanto adelanto)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@AdelantoId", adelanto.AdelantoId);
            parameters.Add("@SocioId", adelanto.SocioId);
            parameters.Add("@EmpresaId", adelanto.EmpresaId);
            //parameters.Add("@Numero", adelanto.Numero);
            parameters.Add("@TipoDocumentoId", adelanto.TipoDocumentoId);
            parameters.Add("@NumeroDocumento", adelanto.NumeroDocumento);
            parameters.Add("@NombreRazonSocial", adelanto.NombreRazonSocial);
            parameters.Add("@MonedaId", adelanto.MonedaId);
            parameters.Add("@Monto", adelanto.Monto);
            parameters.Add("@FechaPago", adelanto.FechaPago);
            parameters.Add("@Motivo", adelanto.Motivo);
            parameters.Add("@FechaEntregaProducto", adelanto.FechaEntregaProducto);
          //  parameters.Add("@NotaCompraId", adelanto.NotaCompraId);
            parameters.Add("@FechaUltimaActualizacion", adelanto.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", adelanto.UsuarioUltimaActualizacion);
            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAdelantoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public ConsultaAdelantoPorIdBE ConsultarAdelantoPorId(int adelantoId)
        {
            ConsultaAdelantoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@AdelantoId", adelantoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {

                var list = db.Query<ConsultaAdelantoPorIdBE>("uspAdelantoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }


        public int Anular(int adelantoId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AdelantoId", adelantoId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspAdelantoAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int AsociarNotaCompra(int adelantoId, int notaCompraId, DateTime fecha, string usuario)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AdelantoId", adelantoId);
            parameters.Add("@NotaCompraId", notaCompraId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspAdelantoAsociarNotaCompra", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


    }
}
