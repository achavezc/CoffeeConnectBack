using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Core.Common;
using Core.Utils;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class NotaSalidaAlmacenPlantaRepository : INotaSalidaAlmacenPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaSalidaAlmacenPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(NotaSalidaAlmacenPlanta NotaSalidaAlmacenPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@EmpresaId", NotaSalidaAlmacenPlanta.EmpresaId);
            parameters.Add("@AlmacenId", NotaSalidaAlmacenPlanta.AlmacenId);
            parameters.Add("@Numero", NotaSalidaAlmacenPlanta.Numero);
            parameters.Add("@MotivoSalidaId", NotaSalidaAlmacenPlanta.MotivoSalidaId);
            parameters.Add("@MotivoSalidaReferencia", NotaSalidaAlmacenPlanta.MotivoSalidaReferencia);
            parameters.Add("@EmpresaIdDestino", NotaSalidaAlmacenPlanta.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", NotaSalidaAlmacenPlanta.EmpresaTransporteId);
            parameters.Add("@TransporteId", NotaSalidaAlmacenPlanta.TransporteId);
            parameters.Add("@NumeroConstanciaMTC", NotaSalidaAlmacenPlanta.NumeroConstanciaMTC);
            parameters.Add("@MarcaTractorId", NotaSalidaAlmacenPlanta.MarcaTractorId);
            parameters.Add("@PlacaTractor", NotaSalidaAlmacenPlanta.PlacaTractor);
            parameters.Add("@MarcaCarretaId", NotaSalidaAlmacenPlanta.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", NotaSalidaAlmacenPlanta.PlacaCarreta);
            parameters.Add("@Conductor", NotaSalidaAlmacenPlanta.Conductor);
            parameters.Add("@Licencia", NotaSalidaAlmacenPlanta.Licencia);
            parameters.Add("@Observacion", NotaSalidaAlmacenPlanta.Observacion);    
            parameters.Add("@CantidadTotal", NotaSalidaAlmacenPlanta.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", NotaSalidaAlmacenPlanta.PesoKilosBrutos);
            parameters.Add("@PesoKilosNetos", NotaSalidaAlmacenPlanta.PesoKilosNetos);
            parameters.Add("@Tara", NotaSalidaAlmacenPlanta.Tara);
            parameters.Add("@ProductoId", NotaSalidaAlmacenPlanta.ProductoId);
            parameters.Add("@SubProductoId", NotaSalidaAlmacenPlanta.SubProductoId);


            parameters.Add("@EstadoId", NotaSalidaAlmacenPlanta.EstadoId);
            parameters.Add("@FechaRegistro", NotaSalidaAlmacenPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", NotaSalidaAlmacenPlanta.UsuarioRegistro);

            parameters.Add("@NotaSalidaAlmacenPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            result = parameters.Get<int>("NotaSalidaAlmacenPlantaId");


            return result;
        }

        public int Actualizar(NotaSalidaAlmacenPlanta NotaSalidaAlmacenPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenPlantaId", NotaSalidaAlmacenPlanta.NotaSalidaAlmacenPlantaId);
            parameters.Add("@EmpresaId", NotaSalidaAlmacenPlanta.EmpresaId);
            parameters.Add("@AlmacenId", NotaSalidaAlmacenPlanta.AlmacenId);
          
            parameters.Add("@MotivoSalidaId", NotaSalidaAlmacenPlanta.MotivoSalidaId);
            parameters.Add("@MotivoSalidaReferencia", NotaSalidaAlmacenPlanta.MotivoSalidaReferencia);
            parameters.Add("@EmpresaIdDestino", NotaSalidaAlmacenPlanta.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", NotaSalidaAlmacenPlanta.EmpresaTransporteId);
            parameters.Add("@TransporteId", NotaSalidaAlmacenPlanta.TransporteId);
            parameters.Add("@NumeroConstanciaMTC", NotaSalidaAlmacenPlanta.NumeroConstanciaMTC);
            parameters.Add("@MarcaTractorId", NotaSalidaAlmacenPlanta.MarcaTractorId);
            parameters.Add("@PlacaTractor", NotaSalidaAlmacenPlanta.PlacaTractor);
            parameters.Add("@MarcaCarretaId", NotaSalidaAlmacenPlanta.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", NotaSalidaAlmacenPlanta.PlacaCarreta);
            parameters.Add("@Conductor", NotaSalidaAlmacenPlanta.Conductor);
            parameters.Add("@Licencia", NotaSalidaAlmacenPlanta.Licencia);
            parameters.Add("@Observacion", NotaSalidaAlmacenPlanta.Observacion);    
            parameters.Add("@CantidadTotal", NotaSalidaAlmacenPlanta.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", NotaSalidaAlmacenPlanta.PesoKilosBrutos);
            parameters.Add("@PesoKilosNetos", NotaSalidaAlmacenPlanta.PesoKilosNetos);
            parameters.Add("@Tara", NotaSalidaAlmacenPlanta.Tara);

            parameters.Add("@FechaUltimaActualizacion", NotaSalidaAlmacenPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", NotaSalidaAlmacenPlanta.UsuarioUltimaActualizacion);
            //parameters.Add("@Activo", NotaSalidaAlmacenPlanta.Activo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }


        public int ActualizarEstado(int NotaSalidaAlmacenPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenPlantaId", NotaSalidaAlmacenPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaSalidaAlmacenPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<ConsultaNotaSalidaAlmacenPlantaBE> ConsultarNotaSalidaAlmacenPlanta(ConsultaNotaSalidaAlmacenPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@EmpresaIdDestino", request.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", request.EmpresaTransporteId);
            parameters.Add("@AlmacenId", request.AlmacenId);
            parameters.Add("@MotivoSalidaId", request.MotivoSalidaId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaSalidaAlmacenPlantaBE>("uspNotaSalidaAlmacenPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaNotaSalidaAlmacenPlantaPorIdBE ConsultarNotaSalidaAlmacenPlantaPorId(int notaSalidaAlmacenPlantaId)
        {
            ConsultaNotaSalidaAlmacenPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("NotaSalidaAlmacenPlantaId", notaSalidaAlmacenPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaSalidaAlmacenPlantaPorIdBE>("uspNotaSalidaAlmacenPlantaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


        public int ActualizarNotaSalidaAlmacenPlantaDetalle(List<NotaSalidaAlmacenPlantaDetalle> request, int? NotaSalidaAlmacenPlantaId)
        {
            //uspNotaSalidaAlmacenPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenPlantaId", NotaSalidaAlmacenPlantaId);
            parameters.Add("@NotaSalidaAlmacenPlantaDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenPlantaDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }


        public IEnumerable<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE> ConsultarNotaSalidaAlmacenPlantaDetallePorIdBE(int notaSalidaAlmacenPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NotaSalidaAlmacenPlantaId", notaSalidaAlmacenPlantaId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaSalidaAlmacenPlantaDetallePorIdBE>("uspConsultaNotaSalidaAlmacenPlantaDetallePorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        


    }



}
