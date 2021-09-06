using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Core.Common;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class NotaIngresoAlmacenPlantaRepository : INotaIngresoAlmacenPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaIngresoAlmacenPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(NotaIngresoAlmacenPlanta NotaIngresoAlmacenPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", NotaIngresoAlmacenPlanta.EmpresaId);
            parameters.Add("@AlmacenId", NotaIngresoAlmacenPlanta.AlmacenId);
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoAlmacenPlanta.NotaIngresoPlantaId);
            parameters.Add("@Numero", NotaIngresoAlmacenPlanta.Numero);
            parameters.Add("@ProductoId", NotaIngresoAlmacenPlanta.ProductoId);
            parameters.Add("@SubProductoId", NotaIngresoAlmacenPlanta.SubProductoId);
            parameters.Add("@TipoProduccionId", NotaIngresoAlmacenPlanta.TipoProduccionId);
            parameters.Add("@CertificacionId", NotaIngresoAlmacenPlanta.CertificacionId);
            parameters.Add("@EntidadCertificadoraId", NotaIngresoAlmacenPlanta.EntidadCertificadoraId);            
           
            parameters.Add("@UnidadMedidaIdPesado", NotaIngresoAlmacenPlanta.UnidadMedidaIdPesado);
            parameters.Add("@CalidadId", NotaIngresoAlmacenPlanta.CalidadId);
            parameters.Add("@GradoId", NotaIngresoAlmacenPlanta.GradoId);
            parameters.Add("@CantidadDefectos", NotaIngresoAlmacenPlanta.CantidadDefectos);
            parameters.Add("@CantidadPesado", NotaIngresoAlmacenPlanta.CantidadPesado);
            parameters.Add("@PesoPorSaco", NotaIngresoAlmacenPlanta.PesoporSaco);
            parameters.Add("@KilosBrutosPesado", NotaIngresoAlmacenPlanta.KilosBrutosPesado);
            parameters.Add("@TaraPesado", NotaIngresoAlmacenPlanta.TaraPesado);
            parameters.Add("@KilosNetosPesado", NotaIngresoAlmacenPlanta.KilosNetosPesado);
            parameters.Add("@ExportableGramosAnalisisFisico", NotaIngresoAlmacenPlanta.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", NotaIngresoAlmacenPlanta.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", NotaIngresoAlmacenPlanta.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", NotaIngresoAlmacenPlanta.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", NotaIngresoAlmacenPlanta.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", NotaIngresoAlmacenPlanta.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", NotaIngresoAlmacenPlanta.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", NotaIngresoAlmacenPlanta.TotalPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", NotaIngresoAlmacenPlanta.TotalAnalisisSensorial);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", NotaIngresoAlmacenPlanta.HumedadPorcentajeAnalisisFisico);     
            parameters.Add("@RendimientoPorcentaje", NotaIngresoAlmacenPlanta.RendimientoPorcentaje);
            //parameters.Add("@RendimientoPorcentajePesado", NotaIngresoAlmacenPlanta.RendimientoPorcentajePesado);
            //parameters.Add("@HumedadPorcentajePesado", NotaIngresoAlmacenPlanta.HumedadPorcentajePesado);
            
            parameters.Add("@EstadoId", NotaIngresoAlmacenPlanta.EstadoId);
            parameters.Add("@FechaRegistro", NotaIngresoAlmacenPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", NotaIngresoAlmacenPlanta.UsuarioRegistro);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoAlmacenPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ConsultaNotaIngresoAlmacenPlantaBE> ConsultarNotaIngresoAlmacenPlanta(ConsultaNotaIngresoAlmacenPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroNotaIngresoPlanta", request.NumeroNotaIngresoPlanta);
            parameters.Add("NumeroOrganizacion", request.NumeroOrganizacion);
            parameters.Add("RazonSocialOrganizacion", request.RazonSocialOrganizacion);
            parameters.Add("RucOrganizacion", request.RucOrganizacion);
            parameters.Add("CertificacionId", request.CertificacionId);
            parameters.Add("EstadoId", request.CertificacionId);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("SubProductoId", request.SubProductoId); 
            parameters.Add("AlmacenId", request.AlmacenId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("RendimientoPorcentajeInicio", request.RendimientoPorcentajeInicio);
            parameters.Add("RendimientoPorcentajeFin", request.RendimientoPorcentajeFin);
            parameters.Add("PuntajeAnalisisSensorialInicio", request.PuntajeAnalisisSensorialInicio);
            parameters.Add("PuntajeAnalisisSensorialFin", request.PuntajeAnalisisSensorialFin);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaIngresoAlmacenPlantaBE>("uspNotaIngresoAlmacenPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        //public IEnumerable<NotaIngresoAlmacenPlanta> ConsultarNotaIngresoPorIds(List<TablaIdsTipo> request)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@TablaIdsTipo", request.ToDataTable().AsTableValuedParameter());


        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        return db.Query<NotaIngresoAlmacenPlanta>("uspNotaIngresoAlmacenPlantaConsultarPorIds", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //}


        public int ActualizarEstado(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoAlmacenPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int Actualizar(int NotaIngresoAlmacenPlantaId, DateTime fecha, string usuario, string almacenId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenPlantaId", NotaIngresoAlmacenPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@AlmacenId", almacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoAlmacenPlantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int ActualizarEstadoPorIds(List<TablaIdsTipo> ids, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@TablaIdsTipo", ids.ToDataTable().AsTableValuedParameter());
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoAlmacenPlantaActualizarEstadoPorIds", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public ConsultaNotaIngresoAlmacenPlantaPorIdBE ConsultarNotaIngresoAlmacenPlantaPorId(int NotaIngresoAlmacenPlantaId)
        {
            ConsultaNotaIngresoAlmacenPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoAlmacenIdPlanta", NotaIngresoAlmacenPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaIngresoAlmacenPlantaPorIdBE>("uspNotaIngresoAlmacenPlantaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }



    }
}
