using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using CoffeeConnect.DTO;
using Core.Common;

namespace CoffeeConnect.Repository
{
	public class ContratoRepository : IContratoRepository
    {
		public IOptions<ConnectionString> _connectionString;
		public ContratoRepository(IOptions<ConnectionString> connectionString)
		{
			_connectionString = connectionString;
		}

       

        public IEnumerable<ConsultaContratoBE> ConsultarContrato(ConsultaContratoRequestDTO request)
		{
			var parameters = new DynamicParameters();
			parameters.Add("Numero", request.Numero);		
			parameters.Add("RazonSocial", request.RazonSocial);
			parameters.Add("TipoProduccionId", request.TipoProduccionId);
			parameters.Add("ProductoId", request.ProductoId);
			parameters.Add("CalidadId", request.CalidadId);
            parameters.Add("NumeroCliente", request.NumeroCliente);
            parameters.Add("EstadoId", request.EstadoId);			
			parameters.Add("FechaInicio", request.FechaInicio);
			parameters.Add("FechaFin", request.FechaFin);


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				return db.Query<ConsultaContratoBE>("uspContratoConsulta", parameters, commandType: CommandType.StoredProcedure);
			}
		}

        public int Insertar(Contrato contrato)
        {
            int result = 0;

            var parameters = new DynamicParameters();           
            parameters.Add("@Numero", contrato.Numero);
            parameters.Add("@ClienteId", contrato.ClienteId);
            parameters.Add("@FloId", contrato.FloId);
            parameters.Add("@CondicionEmbarqueId", contrato.CondicionEmbarqueId);
            parameters.Add("@FechaEmbarque", contrato.FechaEmbarque);
            parameters.Add("@Fechcontrato", contrato.FechaContrato);
            parameters.Add("@FechaFacturacion", contrato.FechaFacturacion);
            parameters.Add("@PaisDestinoId", contrato.PaisDestinoId);
            parameters.Add("@DepartamentoDestinoId", contrato.DepartamentoDestinoId);
            parameters.Add("@ProductoId", contrato.ProductoId);
            parameters.Add("@TipoProduccionId", contrato.TipoProduccionId);
            parameters.Add("@MonedadId", contrato.MonedadId);
            parameters.Add("@Monto", contrato.Monto);
            parameters.Add("@UnidadMedicionId", contrato.UnidadMedicionId);
            parameters.Add("@UnidadMedidaId", contrato.UnidadMedidaId);
            parameters.Add("@EntidadCertificadoraId", contrato.EntidadCertificadoraId);
            parameters.Add("@TipoCertificacionId", contrato.TipoCertificacionId);
            parameters.Add("@CalidadId", contrato.CalidadId);
            parameters.Add("@GradoId", contrato.GradoId);
            parameters.Add("@Cantidad", contrato.Cantidad);
            parameters.Add("@PesoPorSaco", contrato.PesoPorSaco);
            parameters.Add("@PreparacionCantidadDefectos", contrato.PreparacionCantidadDefectos);
            parameters.Add("@RequiereAprobacionMuestra", contrato.RequiereAprobacionMuestra);
            parameters.Add("@MuestraEnviadaCliente", contrato.MuestraEnviadaCliente);
            parameters.Add("@MuestraEnviadaAnalisisGlifosato", contrato.MuestraEnviadaAnalisisGlifosato);
            parameters.Add("@NombreArchivo", contrato.NombreArchivo);
            parameters.Add("@PathArchivo", contrato.PathArchivo);
            parameters.Add("@FechaRegistro", contrato.FechaRegistro);
            parameters.Add("@UsuarioRegistro", contrato.UsuarioRegistro);           
            parameters.Add("@EstadoId", contrato.EstadoId);          

            parameters.Add("@ContratoId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspContratoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("ContratoId");

            return id;
        }

        public int Actualizar(Contrato contrato)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ContratoId", contrato.ContratoId);
            parameters.Add("@Numero", contrato.Numero);
            parameters.Add("@ClienteId", contrato.ClienteId);
            parameters.Add("@FloId", contrato.FloId);
            parameters.Add("@CondicionEmbarqueId", contrato.CondicionEmbarqueId);
            parameters.Add("@FechaEmbarque", contrato.FechaEmbarque);
            parameters.Add("@Fechcontrato", contrato.FechaContrato);
            parameters.Add("@FechaFacturacion", contrato.FechaFacturacion);
            parameters.Add("@PaisDestinoId", contrato.PaisDestinoId);
            parameters.Add("@DepartamentoDestinoId", contrato.DepartamentoDestinoId);
            parameters.Add("@ProductoId", contrato.ProductoId);
            parameters.Add("@TipoProduccionId", contrato.TipoProduccionId);
            parameters.Add("@MonedadId", contrato.MonedadId);
            parameters.Add("@Monto", contrato.Monto);
            parameters.Add("@UnidadMedicionId", contrato.UnidadMedicionId);
            parameters.Add("@UnidadMedidaId", contrato.UnidadMedidaId);
            parameters.Add("@EntidadCertificadoraId", contrato.EntidadCertificadoraId);
            parameters.Add("@TipoCertificacionId", contrato.TipoCertificacionId);
            parameters.Add("@CalidadId", contrato.CalidadId);
            parameters.Add("@GradoId", contrato.GradoId);
            parameters.Add("@Cantidad", contrato.Cantidad);
            parameters.Add("@PesoPorSaco", contrato.PesoPorSaco);
            parameters.Add("@PreparacionCantidadDefectos", contrato.PreparacionCantidadDefectos);
            parameters.Add("@RequiereAprobacionMuestra", contrato.RequiereAprobacionMuestra);
            parameters.Add("@MuestraEnviadaCliente", contrato.MuestraEnviadaCliente);
            parameters.Add("@MuestraEnviadaAnalisisGlifosato", contrato.MuestraEnviadaAnalisisGlifosato);
            parameters.Add("@NombreArchivo", contrato.NombreArchivo);
            parameters.Add("@PathArchivo", contrato.PathArchivo);           
            parameters.Add("@FechaUltimaActualizacion", contrato.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", contrato.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", contrato.EstadoId);  


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspContratoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaContratoPorIdBE ConsultarContratoPorId(int contratoId)
        {
            ConsultaContratoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ContratoId", contratoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaContratoPorIdBE>("uspContratoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


    }
}
