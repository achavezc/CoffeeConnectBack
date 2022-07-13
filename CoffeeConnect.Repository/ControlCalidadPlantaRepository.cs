using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using Core.Common;
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
   public  class ControlCalidadPlantaRepository : IControlCalidadPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ControlCalidadPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<ConsultaControlCalidadPlantaBE> ConsultarControlCalidadPlanta(ConsultaControlCalidadPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroGuiaRemision", request.NumeroGuiaRemision);
            parameters.Add("RazonSocialOrganizacion", request.RazonSocialOrganizacion);
            parameters.Add("RucOrganizacion", request.RucOrganizacion);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("MotivoIngresoId", request.MotivoIngresoId);
            parameters.Add("SubProductoId", request.SubProductoId);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);
            parameters.Add("FechaGuiaRemisionInicio", request.FechaInicio);
            parameters.Add("FechaGuiaRemisionFin", request.FechaFin);
            parameters.Add("CodigoCampania", request.CodigoCampania);
            parameters.Add("CodigoTipoConcepto", request.CodigoTipoConcepto);
            parameters.Add("CodigoTipo", request.CodigoTipo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaControlCalidadPlantaBE>("uspControlCalidadPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int AnularControlCalidadPlanta(int NotaIngresoPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoPlantaAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public ConsultaControlCalidadPlantaPorIdBE ConsultaControlCalidadPlantaPorId(int ControlCalidadPlantaId)
        {
            ConsultaControlCalidadPlantaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaControlCalidadPlantaPorIdBE>("[uspControlCalidadPlantaObtenerPorId]", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public int ActualizarPesadoControlCalidadPlanta(ControlCalidadPlanta NotaIngresoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", NotaIngresoPlanta.EmpresaId);
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlanta.NotaIngresoPlantaId);
            parameters.Add("@NumeroGuiaRemision", NotaIngresoPlanta.NumeroGuiaRemision);
            parameters.Add("@FechaGuiaRemision", NotaIngresoPlanta.FechaGuiaRemision);
            parameters.Add("@EmpresaOrigenId", NotaIngresoPlanta.EmpresaOrigenId);
            parameters.Add("@TipoProduccionId", NotaIngresoPlanta.TipoProduccionId);
            parameters.Add("@ProductoId", NotaIngresoPlanta.ProductoId);
            parameters.Add("@SubProductoId", NotaIngresoPlanta.SubProductoId);
            parameters.Add("@CertificacionId", NotaIngresoPlanta.CertificacionId);
            parameters.Add("@EntidadCertificadoraId", NotaIngresoPlanta.EntidadCertificadoraId);
            parameters.Add("@MotivoIngresoId", NotaIngresoPlanta.MotivoIngresoId);
            parameters.Add("@EmpaqueId", NotaIngresoPlanta.EmpaqueId);
            parameters.Add("@TipoId", NotaIngresoPlanta.TipoId);
            parameters.Add("@Cantidad", NotaIngresoPlanta.Cantidad);
            parameters.Add("@KilosBrutos", NotaIngresoPlanta.KilosBrutos);
            parameters.Add("@Tara", NotaIngresoPlanta.Tara);
            parameters.Add("@CalidadId", NotaIngresoPlanta.CalidadId);
            parameters.Add("@GradoId", NotaIngresoPlanta.GradoId);
            parameters.Add("@CantidadDefectos", NotaIngresoPlanta.CantidadDefectos);
            parameters.Add("@PesoPorSaco", NotaIngresoPlanta.PesoPorSaco);
            parameters.Add("@KilosNetos", NotaIngresoPlanta.KilosNetos);
            parameters.Add("@HumedadPorcentaje", NotaIngresoPlanta.HumedadPorcentaje);
            parameters.Add("@RendimientoPorcentaje", NotaIngresoPlanta.RendimientoPorcentaje);
            parameters.Add("@RucEmpresaTransporte", NotaIngresoPlanta.RucEmpresaTransporte);
            parameters.Add("@RazonEmpresaTransporte", NotaIngresoPlanta.RazonEmpresaTransporte);
            parameters.Add("@PlacaTractorEmpresaTransporte", NotaIngresoPlanta.PlacaTractorEmpresaTransporte);
            parameters.Add("@ConductorEmpresaTransporte", NotaIngresoPlanta.ConductorEmpresaTransporte);
            parameters.Add("@LicenciaConductorEmpresaTransporte", NotaIngresoPlanta.LicenciaConductorEmpresaTransporte);
            parameters.Add("@ObservacionPesado", NotaIngresoPlanta.ObservacionPesado);
            parameters.Add("@EstadoId", NotaIngresoPlanta.EstadoId);
            parameters.Add("@FechaPesado", NotaIngresoPlanta.FechaPesado);
            parameters.Add("@UsuarioPesado", NotaIngresoPlanta.UsuarioPesado);
            parameters.Add("@FechaUltimaActualizacion", NotaIngresoPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", NotaIngresoPlanta.UsuarioUltimaActualizacion);
            parameters.Add("@Direccion", NotaIngresoPlanta.Direccion);
            parameters.Add("@Marca", NotaIngresoPlanta.Marca);
            parameters.Add("@CodigoCampania", NotaIngresoPlanta.CodigoCampania);
            parameters.Add("@CodigoTipoConcepto", NotaIngresoPlanta.CodigoTipoConcepto);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaPesadoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }



            return result;
        }


        public int InsertarPesadoControlCalidadPlanta(ControlCalidadPlanta NotaIngresoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", NotaIngresoPlanta.EmpresaId);
            parameters.Add("@Numero", NotaIngresoPlanta.Numero);
            parameters.Add("@NumeroGuiaRemision", NotaIngresoPlanta.NumeroGuiaRemision);
            parameters.Add("@FechaGuiaRemision", NotaIngresoPlanta.FechaGuiaRemision);
            parameters.Add("@EmpresaOrigenId", NotaIngresoPlanta.EmpresaOrigenId);
            parameters.Add("@TipoProduccionId", NotaIngresoPlanta.TipoProduccionId);
            parameters.Add("@ProductoId", NotaIngresoPlanta.ProductoId);
            parameters.Add("@SubProductoId", NotaIngresoPlanta.SubProductoId);
            parameters.Add("@CertificacionId", NotaIngresoPlanta.CertificacionId);
            parameters.Add("@EntidadCertificadoraId", NotaIngresoPlanta.EntidadCertificadoraId);
            parameters.Add("@MotivoIngresoId", NotaIngresoPlanta.MotivoIngresoId);
            parameters.Add("@EmpaqueId", NotaIngresoPlanta.EmpaqueId);
            parameters.Add("@TipoId", NotaIngresoPlanta.TipoId);
            parameters.Add("@Cantidad", NotaIngresoPlanta.Cantidad);
            parameters.Add("@KilosBrutos", NotaIngresoPlanta.KilosBrutos);
            parameters.Add("@Tara", NotaIngresoPlanta.Tara);
            parameters.Add("@KilosNetos", NotaIngresoPlanta.KilosNetos);
            parameters.Add("@CalidadId", NotaIngresoPlanta.CalidadId);
            parameters.Add("@GradoId", NotaIngresoPlanta.GradoId);
            parameters.Add("@CantidadDefectos", NotaIngresoPlanta.CantidadDefectos);
            parameters.Add("@PesoPorSaco", NotaIngresoPlanta.PesoPorSaco);
            parameters.Add("@HumedadPorcentaje", NotaIngresoPlanta.HumedadPorcentaje);
            parameters.Add("@RendimientoPorcentaje", NotaIngresoPlanta.RendimientoPorcentaje);
            parameters.Add("@RucEmpresaTransporte", NotaIngresoPlanta.RucEmpresaTransporte);
            parameters.Add("@RazonEmpresaTransporte", NotaIngresoPlanta.RazonEmpresaTransporte);
            parameters.Add("@PlacaTractorEmpresaTransporte", NotaIngresoPlanta.PlacaTractorEmpresaTransporte);
            parameters.Add("@ConductorEmpresaTransporte", NotaIngresoPlanta.ConductorEmpresaTransporte);
            parameters.Add("@LicenciaConductorEmpresaTransporte", NotaIngresoPlanta.LicenciaConductorEmpresaTransporte);
            parameters.Add("@ObservacionPesado", NotaIngresoPlanta.ObservacionPesado);
            parameters.Add("@EstadoId", NotaIngresoPlanta.EstadoId);
            parameters.Add("@FechaPesado", NotaIngresoPlanta.FechaPesado);
            parameters.Add("@UsuarioPesado", NotaIngresoPlanta.UsuarioPesado);
            parameters.Add("@FechaRegistro", NotaIngresoPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", NotaIngresoPlanta.UsuarioRegistro);
            parameters.Add("@Direccion", NotaIngresoPlanta.Direccion);
            parameters.Add("@Marca", NotaIngresoPlanta.Marca);
            parameters.Add("@CodigoCampania", NotaIngresoPlanta.CodigoCampania);
            parameters.Add("@CodigoTipoConcepto", NotaIngresoPlanta.CodigoTipoConcepto);
            parameters.Add("@NotaIngresoPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaPesadoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("NotaIngresoPlantaId");

            return id;
        }

        public int ActualizarAnalisisCalidad(ControlCalidadPlanta NotaIngresoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlanta.NotaIngresoPlantaId);
            parameters.Add("@ExportableGramosAnalisisFisico", NotaIngresoPlanta.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", NotaIngresoPlanta.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", NotaIngresoPlanta.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", NotaIngresoPlanta.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", NotaIngresoPlanta.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", NotaIngresoPlanta.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", NotaIngresoPlanta.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", NotaIngresoPlanta.TotalPorcentajeAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", NotaIngresoPlanta.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", NotaIngresoPlanta.TotalAnalisisSensorial);

            parameters.Add("@ObservacionAnalisisFisico", NotaIngresoPlanta.ObservacionAnalisisFisico);
            parameters.Add("@FechaCalidad", NotaIngresoPlanta.FechaCalidad);
            parameters.Add("@UsuarioCalidad", NotaIngresoPlanta.UsuarioCalidad);
            parameters.Add("@ObservacionRegistroTostado", NotaIngresoPlanta.ObservacionRegistroTostado);
            parameters.Add("@ObservacionAnalisisSensorial", NotaIngresoPlanta.ObservacionAnalisisSensorial);
            parameters.Add("@EstadoId", NotaIngresoPlanta.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", NotaIngresoPlanta.FechaCalidad);
            parameters.Add("@UsuarioUltimaActualizacion", NotaIngresoPlanta.UsuarioCalidad);
            parameters.Add("@Taza", NotaIngresoPlanta.Taza);
            parameters.Add("@Intensidad", NotaIngresoPlanta.Intensidad);
            parameters.Add("@TazaIntensidad", NotaIngresoPlanta.TazaIntensidad);
            parameters.Add("@PuntajeFinal", NotaIngresoPlanta.PuntajeFinal);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaCalidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ControlCalidadPlantaAnalisisFisicoColorDetalle> ConsultarControlCalidadPlantaAnalisisFisicoColorDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisFisicoColorDetalle>("uspNotaIngresoPlantaAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<ControlCalidadPlantaAnalisisFisicoOlorDetalle> ConsultarControlCalidadPlantaAnalisisFisicoOlorDetallePorId(int NotaIngresoPlantaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisFisicoOlorDetalle>("uspNotaIngresoPlantaAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public IEnumerable<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle> ConsultarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetallePorId(int NotaIngresoPlantaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle>("uspNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle> ConsultarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle>("uspNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<ControlCalidadPlantaAnalisisSensorialAtributoDetalle> ConsultarControlCalidadPlantaAnalisisSensorialAtributoDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisSensorialAtributoDetalle>("uspNotaIngresoPlantaAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ControlCalidadPlantaAnalisisSensorialDefectoDetalle> ConsultarControlCalidadPlantaAnalisisSensorialDefectoDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisSensorialDefectoDetalle>("uspNotaIngresoPlantaAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ControlCalidadPlantaRegistroTostadoIndicadorDetalle> ConsultarControlCalidadPlantaRegistroTostadoIndicadorDetallePorId(int NotaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaRegistroTostadoIndicadorDetalle>("uspNotaIngresoPlantaRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarControlCalidadPlantaAnalisisFisicoColorDetalle(List<ControlCalidadPlantaAnalisisFisicoColorDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisFisicoColorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle(List<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisFisicoDefectoPrimarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle(List<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisFisicoDefectoSecundarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar

        }
        public int ActualizarControlCalidadPlantaAnalisisFisicoOlorDetalle(List<ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisFisicoOlorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisFisicoOlorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarControlCalidadPlantaAnalisisSensorialAtributoDetalle(List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisSensorialAtributoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisSensorialAtributoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarControlCalidadPlantaAnalisisSensorialDefectoDetalle(List<ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaAnalisisSensorialDefectoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaAnalisisSensorialDefectoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarControlCalidadPlantaRegistroTostadoIndicadorDetalle(List<ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo> request, int NotaIngresoPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@NotaIngresoPlantaRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaIngresoPlantaRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }


        public int ActualizarEstadoControlCalidad(int NotaIngresoPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaIngresoPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }
    }

}
