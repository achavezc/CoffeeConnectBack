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
using Core.Utils;
using CoffeeConnect.DTO;
using Core.Common;

namespace CoffeeConnect.Repository
{
    public class NotaSalidaAlmacenRepository : INotaSalidaAlmacenRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public NotaSalidaAlmacenRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(NotaCompra notaCompra)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRecepcionMateriaPrimaId", notaCompra.GuiaRecepcionMateriaPrimaId);
            parameters.Add("@EmpresaId", notaCompra.EmpresaId);
            parameters.Add("@Numero", notaCompra.Numero);
            parameters.Add("@UnidadMedidaIdPesado", notaCompra.UnidadMedidaIdPesado);
            parameters.Add("@CantidadPesado", notaCompra.CantidadPesado);
            parameters.Add("@KilosBrutosPesado", notaCompra.KilosBrutosPesado);
            parameters.Add("@TaraPesado", notaCompra.TaraPesado);
            parameters.Add("@KilosNetosPesado", notaCompra.KilosNetosPesado);
            parameters.Add("@DescuentoPorHumedad", notaCompra.DescuentoPorHumedad);
            parameters.Add("@KilosNetosDescontar", notaCompra.KilosNetosDescontar);
            parameters.Add("@KilosNetosPagar", notaCompra.KilosNetosPagar);
            parameters.Add("@QQ55", notaCompra.QQ55);
            parameters.Add("@ExportableGramosAnalisisFisico", notaCompra.ExportableGramosAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", notaCompra.DescarteGramosAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", notaCompra.CascarillaGramosAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", notaCompra.TotalGramosAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", notaCompra.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TipoId", notaCompra.TipoId);
            parameters.Add("@PrecioGuardado", notaCompra.PrecioGuardado);
            parameters.Add("@Importe", notaCompra.Importe);
            parameters.Add("@EstadoId", notaCompra.EstadoId);
            parameters.Add("@FechaRegistro", notaCompra.FechaRegistro);
            parameters.Add("@UsuarioRegistro", notaCompra.UsuarioRegistro);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaCompraInsertar", parameters, commandType: CommandType.StoredProcedure);
            }



            return result;
        }


        public int Actualizar(NotaCompra notaCompra)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaCompraId", notaCompra.NotaCompraId);
            parameters.Add("@GuiaRecepcionMateriaPrimaId", notaCompra.GuiaRecepcionMateriaPrimaId);
            parameters.Add("@EmpresaId", notaCompra.EmpresaId);
            parameters.Add("@Numero", notaCompra.Numero);
            parameters.Add("@UnidadMedidaIdPesado", notaCompra.UnidadMedidaIdPesado);
            parameters.Add("@CantidadPesado", notaCompra.CantidadPesado);
            parameters.Add("@KilosBrutosPesado", notaCompra.KilosBrutosPesado);
            parameters.Add("@TaraPesado", notaCompra.TaraPesado);
            parameters.Add("@KilosNetosPesado", notaCompra.KilosNetosPesado);
            parameters.Add("@DescuentoPorHumedad", notaCompra.DescuentoPorHumedad);
            parameters.Add("@KilosNetosDescontar", notaCompra.KilosNetosDescontar);
            parameters.Add("@KilosNetosPagar", notaCompra.KilosNetosPagar);
            parameters.Add("@QQ55", notaCompra.QQ55);
            parameters.Add("@ExportableGramosAnalisisFisico", notaCompra.ExportableGramosAnalisisFisico);
            parameters.Add("@DescarteGramosAnalisisFisico", notaCompra.DescarteGramosAnalisisFisico);
            parameters.Add("@CascarillaGramosAnalisisFisico", notaCompra.CascarillaGramosAnalisisFisico);
            parameters.Add("@TotalGramosAnalisisFisico", notaCompra.TotalGramosAnalisisFisico);
            parameters.Add("@HumedadPorcentajeAnalisisFisico", notaCompra.HumedadPorcentajeAnalisisFisico);
            parameters.Add("@TipoId", notaCompra.TipoId);
            parameters.Add("@PrecioGuardado", notaCompra.PrecioGuardado);
            parameters.Add("@PrecioPagado", notaCompra.PrecioPagado);
            parameters.Add("@Importe", notaCompra.Importe);
            parameters.Add("@EstadoId", notaCompra.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", notaCompra.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", notaCompra.UsuarioUltimaActualizacion);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaCompraActualizar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public int Anular(int notaCompraId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaCompraId", notaCompraId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspNotaCompraAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<ConsultaNotaSalidaAlmacenBE> ConsultarNotaSalidaAlmacen(ConsultaNotaSalidaAlmacenRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@EmpresaIdDestino", request.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", request.EmpresaTransporteId);
            parameters.Add("@AlmacenId", request.AlmacenId);
            parameters.Add("@MotivoTrasladoId", request.MotivoTrasladoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaNotaSalidaAlmacenBE>("uspNotaSalidaAlmacenConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        public IEnumerable<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE> ConsultarImpresionListaProductoresPorNotaSalida(int notaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NotaSalidaAlmacenId", notaSalidaAlmacenId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaImpresionListaProductoresPorNotaSalidaAlmacenIdBE>("uspListaProductoresConsultaImpresionPorNotaSalidaAlmacenId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaNotaSalidaAlmacenPorIdBE ConsultarNotaSalidaAlmacenPorId(int notaSalidaAlmacenId)
        {
            ConsultaNotaSalidaAlmacenPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("NotaSalidaAlmacenId", notaSalidaAlmacenId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaNotaSalidaAlmacenPorIdBE>("uspNotaSalidaAlmacenObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


        public IEnumerable<NotaSalidaAlmacenAnalisisFisicoColorDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoColorDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisFisicoColorDetalle>("uspNotaSalidaAlmacenAnalisisFisicoColorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<NotaSalidaAlmacenAnalisisFisicoOlorDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoOlorDetallePorId(int NotaSalidaAlmacenId)
        {


            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisFisicoOlorDetalle>("uspNotaSalidaAlmacenAnalisisFisicoOlorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);






            }
        }

        public IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetallePorId(int NotaSalidaAlmacenId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle>("uspNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);


            }


        }

        public IEnumerable<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle> ConsultarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle>("uspNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

            }


        }

        public IEnumerable<NotaSalidaAlmacenAnalisisSensorialAtributoDetalle> ConsultarNotaSalidaAlmacenAnalisisSensorialAtributoDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisSensorialAtributoDetalle>("uspNotaSalidaAlmacenAnalisisSensorialAtributoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaSalidaAlmacenAnalisisSensorialDefectoDetalle> ConsultarNotaSalidaAlmacenAnalisisSensorialDefectoDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenAnalisisSensorialDefectoDetalle>("uspNotaSalidaAlmacenAnalisisSensorialDefectoDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NotaSalidaAlmacenRegistroTostadoIndicadorDetalle> ConsultarNotaSalidaAlmacenRegistroTostadoIndicadorDetallePorId(int NotaSalidaAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<NotaSalidaAlmacenRegistroTostadoIndicadorDetalle>("uspNotaSalidaAlmacenRegistroTostadoIndicadorDetalleConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int ActualizarNotaSalidaAlmacenAnalisisFisicoColorDetalle(List<NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisFisicoColorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public int ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalle(List<NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisFisicoDefectoPrimarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalle(List<NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisFisicoDefectoSecundarioDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar

        }
        public int ActualizarNotaSalidaAlmacenAnalisisFisicoOlorDetalle(List<NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisFisicoOlorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisFisicoOlorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarNotaSalidaAlmacenAnalisisSensorialAtributoDetalle(List<NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisSensorialAtributoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisSensorialAtributoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarNotaSalidaAlmacenAnalisisSensorialDefectoDetalle(List<NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenAnalisisSensorialDefectoDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenAnalisisSensorialDefectoDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
        public int ActualizarNotaSalidaAlmacenRegistroTostadoIndicadorDetalle(List<NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo> request, int NotaSalidaAlmacenId)
        {
            //uspNotaSalidaAlmacenAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@NotaSalidaAlmacenId", NotaSalidaAlmacenId);
            parameters.Add("@NotaSalidaAlmacenRegistroTostadoIndicadorDetalleTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspNotaSalidaAlmacenRegistroTostadoIndicadorDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }




    }



}
