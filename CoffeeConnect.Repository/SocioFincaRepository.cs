using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Core.Utils;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            parameters.Add("@AreaTotal", socioFinca.AreaTotal);
            parameters.Add("@AreaCafeEnProduccion", socioFinca.AreaCafeEnProduccion);
            parameters.Add("@Crecimiento", socioFinca.Crecimiento);
            parameters.Add("@Bosque", socioFinca.Bosque);
            parameters.Add("@Purma", socioFinca.Purma);
            parameters.Add("@PanLlevar", socioFinca.PanLlevar);
            parameters.Add("@Vivienda", socioFinca.Vivienda);

            parameters.Add("@SocioFincaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioFincaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("SocioFincaId");

            return id;
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
            parameters.Add("@AreaTotal", socioFinca.AreaTotal);
            parameters.Add("@AreaCafeEnProduccion", socioFinca.AreaCafeEnProduccion);
            parameters.Add("@Crecimiento", socioFinca.Crecimiento);
            parameters.Add("@Bosque", socioFinca.Bosque);
            parameters.Add("@Purma", socioFinca.Purma);
            parameters.Add("@PanLlevar", socioFinca.PanLlevar);
            parameters.Add("@Vivienda", socioFinca.Vivienda);



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

        public IEnumerable<ConsultaSocioFincaEstimadoPorSocioFincaIdBE> ConsultarSocioFincaEstimadoPorSocioFincaId(int socioId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SocioFincaId", socioId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaSocioFincaEstimadoPorSocioFincaIdBE>("uspSocioFincaEstimadoConsultaPorFincaId", parameters, commandType: CommandType.StoredProcedure);
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

        public int ActualizarSocioFincaEstimado(List<SocioFincaEstimadoTipo> request, int socioFincaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@SocioFincaId", socioFincaId);
            parameters.Add("@SocioFincaEstimadoTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioFincaEstimadoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarSocioFincaEstimadoConsumido(int socioFincaEstimadoId, decimal consumido)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@SocioFincaEstimadoId", socioFincaEstimadoId);
            parameters.Add("@Consumido", consumido);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioFincaEstimadoConsumidoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
    }
}
