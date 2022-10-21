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
            parameters.Add("NumeroControlCalidad", request.NumeroControlCalidad);
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

        public int AnularControlCalidadPlanta(int ControlCalidadPlantaId, int notaIngresoId, string estadoNotaIngresoId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@NotaIngresoPlantaId", notaIngresoId);
            parameters.Add("@EstadoNotaIngresoId", estadoNotaIngresoId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoCalidadId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspControlCalidadPlantaAnular", parameters, commandType: CommandType.StoredProcedure);
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
                var list = db.Query<ConsultaControlCalidadPlantaPorIdBE>("uspControlCalidadPlantaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

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

        /// api nuevo de estados Porcesar////

        public int ControlCalidadPlantaActualizarProcesar(ControlCalidadPlanta ControlCalidadPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlanta.ControlCalidadPlantaId);
            parameters.Add("@EstadoCalidadId", ControlCalidadPlanta.EstadoCalidadId);
            parameters.Add("@NotaIngresoPlantaId", ControlCalidadPlanta.NotaIngresoPlantaId);
            parameters.Add("@CantidadControlCalidad", ControlCalidadPlanta.CantidadProcesada);
            parameters.Add("@FechaUltimaActualizacion", ControlCalidadPlanta.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", ControlCalidadPlanta.UsuarioUltimaActualizacion);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaActualizarProcesar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }



        public int ControlCalidadPlantaActualizarEstadoRechazado(ControlCalidadPlanta ControlCalidadPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlanta.ControlCalidadPlantaId);
            parameters.Add("@NotaIngresoPlantaId", ControlCalidadPlanta.NotaIngresoPlantaId);
            parameters.Add("@EstadoCalidadId", ControlCalidadPlanta.EstadoCalidadId);
            parameters.Add("@Fecha", ControlCalidadPlanta.FechaUltimaActualizacion);
            parameters.Add("@CantidadControlCalidad", ControlCalidadPlanta.CantidadControlCalidad);
            parameters.Add("@KilosNetosControlCalidad", ControlCalidadPlanta.KilosNetosControlCalidad);
            parameters.Add("@Usuario", ControlCalidadPlanta.UsuarioUltimaActualizacion);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaRechazado", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        ///////////



        public int InsertarPesadoControlCalidadPlanta(ControlCalidadPlanta NotaIngresoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", NotaIngresoPlanta.NotaIngresoPlantaId);
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
            parameters.Add("@EstadoCalidadId", NotaIngresoPlanta.EstadoCalidadId);
            parameters.Add("@FechaPesado", NotaIngresoPlanta.FechaPesado);
            parameters.Add("@UsuarioPesado", NotaIngresoPlanta.UsuarioPesado);
            parameters.Add("@FechaRegistro", NotaIngresoPlanta.FechaRegistro);
            parameters.Add("@UsuarioRegistro", NotaIngresoPlanta.UsuarioRegistro);
            parameters.Add("@Direccion", NotaIngresoPlanta.Direccion);
            parameters.Add("@Marca", NotaIngresoPlanta.Marca);
            parameters.Add("@CodigoCampania", NotaIngresoPlanta.CodigoCampania);
            parameters.Add("@CodigoTipoConcepto", NotaIngresoPlanta.CodigoTipoConcepto);
            parameters.Add("@NumeroCalidadPlanta", NotaIngresoPlanta.NumeroControlCalidad);
            parameters.Add("@ControlCalidadPlantaId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaPesadoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("ControlCalidadPlantaId");

            return id;
        }

        public int ActualizarAnalisisCalidad(ControlCalidadPlanta NotaIngresoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ControlCalidadPlantaId", NotaIngresoPlanta.ControlCalidadPlantaId);
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
                result = db.Execute("uspControlCalidadPlantaCalidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }



        public int ActualizarControlCalidad(ControlCalidadPlanta ControlCalidadPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaIngresoPlantaId", ControlCalidadPlanta.NotaIngresoPlantaId);
            parameters.Add("@ExportableGramosAnalisisFisico", ControlCalidadPlanta.ExportableGramosAnalisisFisico);
            parameters.Add("@ExportablePorcentajeAnalisisFisico", ControlCalidadPlanta.ExportablePorcentajeAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", ControlCalidadPlanta.DescarteGramosAnalisisFisico);
            parameters.Add("@DescartePorcentajeAnalisisFisico", ControlCalidadPlanta.DescartePorcentajeAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", ControlCalidadPlanta.CascarillaGramosAnalisisFisico);
            parameters.Add("@CascarillaPorcentajeAnalisisFisico", ControlCalidadPlanta.CascarillaPorcentajeAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", ControlCalidadPlanta.TotalGramosAnalisisFisico);
            parameters.Add("@TotalPorcentajeAnalisisFisico", ControlCalidadPlanta.TotalPorcentajeAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", ControlCalidadPlanta.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TotalAnalisisSensorial", ControlCalidadPlanta.TotalAnalisisSensorial);

            parameters.Add("@ObservacionAnalisisFisico", ControlCalidadPlanta.ObservacionAnalisisFisico);
            parameters.Add("@FechaCalidad", ControlCalidadPlanta.FechaCalidad);
            parameters.Add("@UsuarioCalidad", ControlCalidadPlanta.UsuarioCalidad);
            parameters.Add("@ObservacionRegistroTostado", ControlCalidadPlanta.ObservacionRegistroTostado);
            parameters.Add("@ObservacionAnalisisSensorial", ControlCalidadPlanta.ObservacionAnalisisSensorial);
            parameters.Add("@EstadoId", ControlCalidadPlanta.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", ControlCalidadPlanta.FechaCalidad);
            parameters.Add("@UsuarioUltimaActualizacion", ControlCalidadPlanta.UsuarioCalidad);
            parameters.Add("@Taza", ControlCalidadPlanta.Taza);
            parameters.Add("@Intensidad", ControlCalidadPlanta.Intensidad);
            parameters.Add("@TazaIntensidad", ControlCalidadPlanta.TazaIntensidad);
            parameters.Add("@PuntajeFinal", ControlCalidadPlanta.PuntajeFinal);

            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlanta.ControlCalidadPlantaId);
            parameters.Add("@CantidadControlCalidad", ControlCalidadPlanta.CantidadControlCalidad);
            parameters.Add("@PesoBrutoControlCalidad", ControlCalidadPlanta.PesoBrutoControlCalidad);
            parameters.Add("@TaraControlCalidad", ControlCalidadPlanta.TaraControlCalidad);
            parameters.Add("@KilosNetosControlCalidad", ControlCalidadPlanta.KilosNetosControlCalidad);
            parameters.Add("@ControlCalidadTipoId", ControlCalidadPlanta.ControlCalidadTipoId);
            parameters.Add("@ControlCalidadEmpaqueId", ControlCalidadPlanta.ControlCalidadEmpaqueId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspActualizarControlCalidad", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<ControlCalidadPlantaAnalisisFisicoColorDetalle> ConsultarControlCalidadPlantaAnalisisFisicoColorDetallePorId(int ControlCalidadPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisFisicoColorDetalle>("uspControlCalidadPlantaAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<ControlCalidadPlantaAnalisisFisicoOlorDetalle> ConsultarControlCalidadPlantaAnalisisFisicoOlorDetallePorId(int ControlCalidadPlantaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisFisicoOlorDetalle>("uspControlCalidadPlantaAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public IEnumerable<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle> ConsultarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetallePorId(int ControlCalidadPlantaId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle>("uspControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle> ConsultarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetallePorId(int ControlCalidadPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle>("uspControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<ControlCalidadPlantaAnalisisSensorialAtributoDetalle> ConsultarControlCalidadPlantaAnalisisSensorialAtributoDetallePorId(int ControlCalidadPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisSensorialAtributoDetalle>("uspControlCalidadPlantaAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ControlCalidadPlantaAnalisisSensorialDefectoDetalle> ConsultarControlCalidadPlantaAnalisisSensorialDefectoDetallePorId(int ControlCalidadPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaAnalisisSensorialDefectoDetalle>("uspControlCalidadPlantaAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ControlCalidadPlantaRegistroTostadoIndicadorDetalle> ConsultarControlCalidadPlantaRegistroTostadoIndicadorDetallePorId(int ControlCalidadPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ControlCalidadPlantaRegistroTostadoIndicadorDetalle>("uspControlCalidadPlantaRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarControlCalidadPlantaAnalisisFisicoColorDetalle(List<ControlCalidadPlantaAnalisisFisicoColorDetalleTipo> request, int ControlCalidadPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@ControlCalidadPlantaAnalisisFisicoColorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaAnalisisFisicoColorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalle(List<ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo> request, int ControlCalidadPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@ControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaAnalisisFisicoDefectoPrimarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalle(List<ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo> request, int ControlCalidadPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@ControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaAnalisisFisicoDefectoSecundarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar

        }
        public int ActualizarControlCalidadPlantaAnalisisFisicoOlorDetalle(List<ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo> request, int ControlCalidadPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@ControlCalidadPlantaAnalisisFisicoOlorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaAnalisisFisicoOlorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarControlCalidadPlantaAnalisisSensorialAtributoDetalle(List<ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo> request, int ControlCalidadPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@ControlCalidadPlantaAnalisisSensorialAtributoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaAnalisisSensorialAtributoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarControlCalidadPlantaAnalisisSensorialDefectoDetalle(List<ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo> request, int ControlCalidadPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@ControlCalidadPlantaAnalisisSensorialDefectoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaAnalisisSensorialDefectoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarControlCalidadPlantaRegistroTostadoIndicadorDetalle(List<ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo> request, int ControlCalidadPlantaId)
        {
            //uspNotaIngresoPlantaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@ControlCalidadPlantaRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspControlCalidadPlantaRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }


        public int ActualizarEstadoControlCalidad(int ControlCalidadPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", ControlCalidadPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspControlCalidadPlantaActualizarEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


        public int ActualizarCantidadProcesadaEstado(int controlCalidadPlantaId,decimal cantidadProcesada, decimal kilosNetosProcesado,  DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ControlCalidadPlantaId", controlCalidadPlantaId);
            parameters.Add("@CantidadProcesada", cantidadProcesada);
            parameters.Add("@KilosNetosProcesado", kilosNetosProcesado);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspControlCalidadPlantaActualizarCantidadProcesadaEstado", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }
    }

}
