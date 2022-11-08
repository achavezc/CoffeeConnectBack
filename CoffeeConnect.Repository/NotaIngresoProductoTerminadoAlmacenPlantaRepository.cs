using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
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
    public class NotaIngresoProductoTerminadoAlmacenPlantaRepository : INotaIngresoProductoTerminadoAlmacenPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaIngresoProductoTerminadoAlmacenPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaNotaIngresoProductoTerminadoAlmacenPlantaBE> ConsultarNotaIngresoProductoTerminadoAlmacenPlanta(ConsultaNotaIngresoProductoTerminadoAlmacenPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroNotaIngresoPlanta", request.NumeroNotaIngresoPlanta);            
            parameters.Add("NumeroGuiaRemision", request.NumeroGuiaRemision);
            parameters.Add("AlmacenId", request.AlmacenId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("RazonSocialEmpresaOrigen", request.RazonSocialEmpresaOrigen);
            parameters.Add("RucEmpresaOrigen", request.RucEmpresaOrigen);
            parameters.Add("FechaInicioGuiaRemision", request.FechaInicioGuiaRemision);
            parameters.Add("FechaFinGuiaRemision", request.FechaFinGuiaRemision);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);
            parameters.Add("ProductoId", request.ProductoId);            
            parameters.Add("SubProductoId", request.SubProductoId);
            parameters.Add("MotivoIngresoId", request.MotivoIngresoId);
            parameters.Add("EstadoId", request.EstadoId);            


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaIngresoProductoTerminadoAlmacenPlantaBE>("uspNotaIngresoProductoTerminadoAlmacenPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        //public int AnularNotaIngresoProductoTerminadoAlmacenPlanta(int NotaIngresoProductoTerminadoAlmacenPlantaId, DateTime fecha, string usuario, string estadoId)
        //{
        //    int affected = 0;

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@NotaIngresoProductoTerminadoAlmacenPlantaId", NotaIngresoProductoTerminadoAlmacenPlantaId);
        //    parameters.Add("@Fecha", fecha);
        //    parameters.Add("@Usuario", usuario);
        //    parameters.Add("@EstadoId", estadoId);

        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        affected = db.Execute("uspNotaIngresoProductoTerminadoAlmacenPlantaAnular", parameters, commandType: CommandType.StoredProcedure);
        //    }

        //    return affected;
        //}

        public ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE ConsultarNotaIngresoProductoTerminadoAlmacenPlantaPorId(int NotaIngresoProductoTerminadoAlmacenPlantaId)
        {
            ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoProductoTerminadoAlmacenPlantaId", NotaIngresoProductoTerminadoAlmacenPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaIngresoProductoTerminadoAlmacenPlantaPorIdBE>("uspNotaIngresoProductoTerminadoAlmacenPlantaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public int Actualizar(int NotaIngresoProductoTerminadoAlmacenPlantaId, string almacenId, DateTime fecha, string usuario)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoProductoTerminadoAlmacenPlantaId", NotaIngresoProductoTerminadoAlmacenPlantaId);            
            parameters.Add("@AlmacenId", almacenId);
            parameters.Add("@FechaUltimaActualizacion", fecha);
            parameters.Add("@UsuarioUltimaActualizacion", usuario);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoProductoTerminadoAlmacenPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }



            return result;
        }


        public int Insertar(NotaIngresoProductoTerminadoAlmacenPlanta NotaIngresoProductoTerminadoAlmacenPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", NotaIngresoProductoTerminadoAlmacenPlanta.EmpresaId);
            parameters.Add("@Numero", NotaIngresoProductoTerminadoAlmacenPlanta.Numero);
            parameters.Add("@AlmacenId", NotaIngresoProductoTerminadoAlmacenPlanta.AlmacenId);
            parameters.Add("@EstadoId", NotaIngresoProductoTerminadoAlmacenPlanta.EstadoId);
            parameters.Add("@FechaRegistro", NotaIngresoProductoTerminadoAlmacenPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", NotaIngresoProductoTerminadoAlmacenPlanta.UsuarioRegistro);
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoProductoTerminadoAlmacenPlanta.NotaIngresoPlantaId);
            
            parameters.Add("@MotivoIngresoId", NotaIngresoProductoTerminadoAlmacenPlanta.MotivoIngresoId);
            parameters.Add("@ProductoId", NotaIngresoProductoTerminadoAlmacenPlanta.ProductoId);
            parameters.Add("@SubProductoId", NotaIngresoProductoTerminadoAlmacenPlanta.SubProductoId);
            parameters.Add("@EmpaqueId", NotaIngresoProductoTerminadoAlmacenPlanta.EmpaqueId);
            parameters.Add("@TipoId", NotaIngresoProductoTerminadoAlmacenPlanta.TipoId);
            parameters.Add("@Cantidad", NotaIngresoProductoTerminadoAlmacenPlanta.Cantidad);
            parameters.Add("@KGN", NotaIngresoProductoTerminadoAlmacenPlanta.KGN);
            parameters.Add("@KilosNetos", NotaIngresoProductoTerminadoAlmacenPlanta.KilosNetos);
            parameters.Add("@Observacion", NotaIngresoProductoTerminadoAlmacenPlanta.Observacion);
            parameters.Add("@LiquidacionProcesoPlantaId", NotaIngresoProductoTerminadoAlmacenPlanta.LiquidacionProcesoPlantaId);
            parameters.Add("@NotaIngresoProductoTerminadoAlmacenPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoProductoTerminadoAlmacenPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("NotaIngresoProductoTerminadoAlmacenPlantaId");

            return id;
        }

      

        public int ActualizarEstado(int NotaIngresoProductoTerminadoAlmacenPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoProductoTerminadoAlmacenPlantaId", NotaIngresoProductoTerminadoAlmacenPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoProductoTerminadoAlmacenPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int ActualizarCantidadSalidaAlmacenEstado(int notaIngresoProductoTerminadoAlmacenPlantaId, decimal cantidadSalidaAlmacen, decimal kilosNetosSalidaAlmacen, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoProductoTerminadoAlmacenPlantaId", notaIngresoProductoTerminadoAlmacenPlantaId);
            parameters.Add("@CantidadSalidaAlmacen", cantidadSalidaAlmacen);
            parameters.Add("@KilosNetosSalidaAlmacen", kilosNetosSalidaAlmacen);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                
                   affected = db.Execute("uspNotaIngresoProductoTerminadoAlmacenPlantaActualizarCantidadSalidaAlmacenEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

    }


}
