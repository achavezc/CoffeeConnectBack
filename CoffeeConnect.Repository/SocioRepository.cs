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
            parameters.Add("@Activo", socio.Activo);

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
            parameters.Add("@FechaRegistro", socio.FechaRegistro);         


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

     
    }
}
