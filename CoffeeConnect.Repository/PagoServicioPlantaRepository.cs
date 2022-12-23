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
    public class PagoServicioPlantaRepository : IPagoServicioPlantaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public PagoServicioPlantaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        //public int Insertar(PagoServicioPlanta PagoServicioPlanta)
        //{
        //    int result = 0;

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@EmpresaId", PagoServicioPlanta.EmpresaId);
        //    parameters.Add("@AlmacenId", PagoServicioPlanta.AlmacenId);
        //    parameters.Add("@GuiaRecepcionMateriaPrimaId", PagoServicioPlanta.GuiaRecepcionMateriaPrimaId);
        //    parameters.Add("@Numero", PagoServicioPlanta.Numero);
        //    parameters.Add("@TipoProduccionId", PagoServicioPlanta.TipoProduccionId);
        //    parameters.Add("@TipoCertificacionId", PagoServicioPlanta.TipoCertificacionId);
        //    parameters.Add("@EntidadCertificadoraId", PagoServicioPlanta.EntidadCertificadoraId);
            
        //    parameters.Add("@TipoProvedorId", PagoServicioPlanta.TipoProvedorId);
        //    parameters.Add("@SocioId", PagoServicioPlanta.SocioId);
        //    parameters.Add("@TerceroId", PagoServicioPlanta.TerceroId);
        //    parameters.Add("@IntermediarioId", PagoServicioPlanta.IntermediarioId);
        //    parameters.Add("@ProductoId", PagoServicioPlanta.ProductoId);
        //    parameters.Add("@SubProductoId", PagoServicioPlanta.SubProductoId);
        //    parameters.Add("@UnidadMedidaIdPesado", PagoServicioPlanta.UnidadMedidaIdPesado);
        //    parameters.Add("@CantidadPesado", PagoServicioPlanta.CantidadPesado);
        //    parameters.Add("@KilosBrutosPesado", PagoServicioPlanta.KilosBrutosPesado);
        //    parameters.Add("@TaraPesado", PagoServicioPlanta.TaraPesado);
        //    parameters.Add("@KilosNetosPesado", PagoServicioPlanta.KilosNetosPesado);
        //    parameters.Add("@QQ55", PagoServicioPlanta.QQ55);
        //    parameters.Add("@ExportableGramosAnalisisFisico", PagoServicioPlanta.ExportableGramosAnalisisFisico);
        //    parameters.Add("@ExportablePorcentajeAnalisisFisico", PagoServicioPlanta.ExportablePorcentajeAnalisisFisico);
        //    parameters.Add("@DescarteGramosAnalisisFisico", PagoServicioPlanta.DescarteGramosAnalisisFisico);
        //    parameters.Add("@DescartePorcentajeAnalisisFisico", PagoServicioPlanta.DescartePorcentajeAnalisisFisico);
        //    parameters.Add("@CascarillaGramosAnalisisFisico", PagoServicioPlanta.CascarillaGramosAnalisisFisico);
        //    parameters.Add("@CascarillaPorcentajeAnalisisFisico", PagoServicioPlanta.CascarillaPorcentajeAnalisisFisico);
        //    parameters.Add("@TotalGramosAnalisisFisico", PagoServicioPlanta.TotalGramosAnalisisFisico);
        //    parameters.Add("@TotalPorcentajeAnalisisFisico", PagoServicioPlanta.TotalPorcentajeAnalisisFisico);
        //    parameters.Add("@TotalAnalisisSensorial", PagoServicioPlanta.TotalAnalisisSensorial);
        //    parameters.Add("@HumedadPorcentajeAnalisisFisico", PagoServicioPlanta.HumedadPorcentajeAnalisisFisico);
        //    parameters.Add("@Observacion", PagoServicioPlanta.Observacion);
        //    parameters.Add("@RendimientoPorcentaje", PagoServicioPlanta.RendimientoPorcentaje);
        //    parameters.Add("@EstadoId", PagoServicioPlanta.EstadoId);
        //    parameters.Add("@FechaRegistro", PagoServicioPlanta.FechaRegistro);
        //    parameters.Add("@UsuarioRegistro", PagoServicioPlanta.UsuarioRegistro);

        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        result = db.Execute("uspPagoServicioPlantaInsertar", parameters, commandType: CommandType.StoredProcedure);
        //    }

        //    return result;
        //}

        public IEnumerable<ConsultaPagoServicioPlantaBE> ConsultarPagoServicioPlanta(ConsultaPagoServicioPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroOperacion", request.NumeroOperacion);
            parameters.Add("TipoOperacionPagoServicioId", request.TipoOperacionPagoServicioId);
            parameters.Add("BancoId", request.BancoId);
            parameters.Add("MonedaId", request.MonedaId);
            parameters.Add("ServicioPlantaId", request.ServicioPlantaId);
            parameters.Add("EstadoId", request.EstadoId);            
            parameters.Add("EmpresaId", request.EmpresaId);           
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaPagoServicioPlantaBE>("uspPagoServicioPlantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        //public ConsultaPagoServicioPlantaPorIdBE ConsultarPagoServicioPlantaPorId(int PagoServicioPlantaId)
        //{
        //    ConsultaPagoServicioPlantaPorIdBE itemBE = null;

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@PagoServicioPlantaId", PagoServicioPlantaId);


        //    using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
        //    {
        //        var list = db.Query<ConsultaPagoServicioPlantaPorIdBE>("uspPagoServicioPlantaObtenerPorId", parameters, commandType: CommandType.StoredProcedure);

        //        if (list.Any())
        //            itemBE = list.First();
        //    }

        //    return itemBE;
        //}



    }
}
