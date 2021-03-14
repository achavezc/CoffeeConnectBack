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
	public class SocioFincaRepository : ISocioFincaRepository
	{
		public IOptions<ConnectionString> _connectionString;
		public SocioFincaRepository(IOptions<ConnectionString> connectionString)
		{
			_connectionString = connectionString;
		}



        public int Insertar(SocioFinca socioFinca)
        {
            int result = 0;

			var parameters = new DynamicParameters();
			
			parameters.Add("@SocioId", socioFinca.SocioId);
			parameters.Add("@ProductorFincaId", socioFinca.ProductorFincaId);
			parameters.Add("@ViasAccesoCentroAcopio", socioFinca.ViasAccesoCentroAcopio);
			parameters.Add("@DistanciaKilometrosCentroAcopio", socioFinca.DistanciaKilometrosCentroAcopio);
			parameters.Add("@TiempoTotalFincaCentroAcopio", socioFinca.TiempoTotalFincaCentroAcopio);
			parameters.Add("@MedioTransporte", socioFinca.MedioTransporte);
			parameters.Add("@Cultivo", socioFinca.Cultivo);
			parameters.Add("@Precipitacion", socioFinca.Precipitacion);
			parameters.Add("@CantidadPersonalCosecha", socioFinca.CantidadPersonalCosecha);
			parameters.Add("@FechaRegistro", socioFinca.FechaRegistro);
			parameters.Add("@UsuarioRegistro", socioFinca.UsuarioRegistro);			
			parameters.Add("@EstadoId", socioFinca.EstadoId);
			



			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioFincaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }



            return result;
        }

        public int Actualizar(SocioFinca socioFinca)
        {
            int result = 0;

			var parameters = new DynamicParameters();
			parameters.Add("@SocioFincaId", socioFinca.SocioFincaId);
			parameters.Add("@SocioId", socioFinca.SocioId);
			parameters.Add("@ProductorFincaId", socioFinca.ProductorFincaId);
			parameters.Add("@ViasAccesoCentroAcopio", socioFinca.ViasAccesoCentroAcopio);
			parameters.Add("@DistanciaKilometrosCentroAcopio", socioFinca.DistanciaKilometrosCentroAcopio);
			parameters.Add("@TiempoTotalFincaCentroAcopio", socioFinca.TiempoTotalFincaCentroAcopio);
			parameters.Add("@MedioTransporte", socioFinca.MedioTransporte);
			parameters.Add("@Cultivo", socioFinca.Cultivo);
			parameters.Add("@Precipitacion", socioFinca.Precipitacion);
			parameters.Add("@CantidadPersonalCosecha", socioFinca.CantidadPersonalCosecha);
			parameters.Add("@FechaUltimaActualizacion", socioFinca.FechaUltimaActualizacion);
			parameters.Add("@UsuarioUltimaActualizacion", socioFinca.UsuarioUltimaActualizacion);
			parameters.Add("@EstadoId", socioFinca.EstadoId);
	



			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioFincaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }


        public IEnumerable<ConsultaSocioFincaPorSocioIdBE> ConsultarSocioFincaPorSocioId(int socioId)
		{
			
			var parameters = new DynamicParameters();
			parameters.Add("@SocioId", socioId);


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				return db.Query<ConsultaSocioFincaPorSocioIdBE>("uspSocioFincaConsultaPorSocioId", parameters, commandType: CommandType.StoredProcedure);

				
			}

			
		}

		public ConsultaSocioFincaPorIdBE ConsultarSocioFincaPorId(int socioFincaId)
		{
			ConsultaSocioFincaPorIdBE itemBE = null;

			var parameters = new DynamicParameters();
			parameters.Add("@SocioFincaId", socioFincaId);


			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				var list = db.Query<ConsultaSocioFincaPorIdBE>("uspSocioFincaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

				if (list.Any())
					itemBE = list.First();
			}

			return itemBE;
		}
	}
}
