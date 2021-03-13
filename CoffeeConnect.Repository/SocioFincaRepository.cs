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

       

  //      public int Insertar(SocioFinca productorFinca)
  //      {
  //          int result = 0;

		//	var parameters = new DynamicParameters();
			
		//	parameters.Add("@ProductorId", productorFinca.ProductorId);
		//	parameters.Add("@Nombre", productorFinca.Nombre);
		//	parameters.Add("@Direccion", productorFinca.Direccion);
		//	parameters.Add("@DepartamentoId", productorFinca.DepartamentoId);
		//	parameters.Add("@ProvinciaId", productorFinca.ProvinciaId);
		//	parameters.Add("@DistritoId", productorFinca.DistritoId);
		//	parameters.Add("@ZonaId", productorFinca.ZonaId);
		//	parameters.Add("@Latitud", productorFinca.Latitud);
		//	parameters.Add("@Longuitud", productorFinca.Longuitud);
		//	parameters.Add("@Altitud", productorFinca.Altitud);
		//	parameters.Add("@FuenteEnergiaId", productorFinca.FuenteEnergiaId);
		//	parameters.Add("@FuenteAguaId", productorFinca.FuenteAguaId);
		//	parameters.Add("@InternetId", productorFinca.InternetId);
		//	parameters.Add("@SenialTelefonicaId", productorFinca.SenialTelefonicaId);
		//	parameters.Add("@EstablecimientoSaludId", productorFinca.EstablecimientoSaludId);
		//	parameters.Add("@CentroEducativoId", productorFinca.CentroEducativoId);
		//	parameters.Add("@CentroEducativoNivel", productorFinca.CentroEducativoNivel);
		//	parameters.Add("@TiempoTotalEstablecimientoSalud", productorFinca.TiempoTotalEstablecimientoSalud);
		//	parameters.Add("@CantidadAnimalesMenores", productorFinca.CantidadAnimalesMenores);
		//	parameters.Add("@MaterialVivienda", productorFinca.MaterialVivienda);
		//	parameters.Add("@Suelo", productorFinca.Suelo);
		//	parameters.Add("@FechaRegistro", productorFinca.FechaRegistro);
		//	parameters.Add("@UsuarioRegistro", productorFinca.UsuarioRegistro);
		//	parameters.Add("@EstadoId", productorFinca.EstadoId);
	


		//	using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
  //          {
  //              result = db.Execute("uspProductorFincaInsertar", parameters, commandType: CommandType.StoredProcedure);
  //          }

           

  //          return result;
  //      }

		//public int Actualizar(ProductorFinca productorFinca)
		//{
		//	int result = 0;

		//	var parameters = new DynamicParameters();
		//	parameters.Add("@ProductorFincaId", productorFinca.ProductorFincaId);
		//	parameters.Add("@ProductorId", productorFinca.ProductorId);
		//	parameters.Add("@Direccion", productorFinca.Direccion);
		//	parameters.Add("@Nombre", productorFinca.Nombre);
		//	parameters.Add("@DepartamentoId", productorFinca.DepartamentoId);
		//	parameters.Add("@ProvinciaId", productorFinca.ProvinciaId);
		//	parameters.Add("@DistritoId", productorFinca.DistritoId);
		//	parameters.Add("@ZonaId", productorFinca.ZonaId);
		//	parameters.Add("@Latitud", productorFinca.Latitud);
		//	parameters.Add("@Longuitud", productorFinca.Longuitud);
		//	parameters.Add("@Altitud", productorFinca.Altitud);
		//	parameters.Add("@FuenteEnergiaId", productorFinca.FuenteEnergiaId);
		//	parameters.Add("@FuenteAguaId", productorFinca.FuenteAguaId);
		//	parameters.Add("@InternetId", productorFinca.InternetId);
		//	parameters.Add("@SenialTelefonicaId", productorFinca.SenialTelefonicaId);
		//	parameters.Add("@EstablecimientoSaludId", productorFinca.EstablecimientoSaludId);
		//	parameters.Add("@CentroEducativoId", productorFinca.CentroEducativoId);
		//	parameters.Add("@CentroEducativoNivel", productorFinca.CentroEducativoNivel);
		//	parameters.Add("@TiempoTotalEstablecimientoSalud", productorFinca.TiempoTotalEstablecimientoSalud);
		//	parameters.Add("@CantidadAnimalesMenores", productorFinca.CantidadAnimalesMenores);
		//	parameters.Add("@MaterialVivienda", productorFinca.MaterialVivienda);
		//	parameters.Add("@Suelo", productorFinca.Suelo);
		//	parameters.Add("@FechaUltimaActualizacion", productorFinca.FechaUltimaActualizacion);
		//	parameters.Add("@UsuarioUltimaActualizacion", productorFinca.UsuarioUltimaActualizacion);
		//	parameters.Add("@EstadoId", productorFinca.EstadoId);
			


		//	using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
		//	{
		//		result = db.Execute("uspProductorFincaActualizar", parameters, commandType: CommandType.StoredProcedure);
		//	}
		//	return result;
		//}


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
