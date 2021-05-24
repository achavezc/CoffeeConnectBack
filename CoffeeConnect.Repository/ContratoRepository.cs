﻿using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class ContratoRepository : IContratoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ContratoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaContratoBE> ConsultarContrato(ConsultaContratoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("TipoProduccionId", request.TipoProduccionId);
            parameters.Add("ProductoId", request.ProductoId);
            parameters.Add("CalidadId", request.CalidadId);
            parameters.Add("NumeroCliente", request.NumeroCliente);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);
          

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaContratoBE>("uspContratoConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(Contrato contrato)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@Numero", contrato.Numero);
            parameters.Add("@ClienteId", contrato.ClienteId);
            parameters.Add("@FloId", contrato.FloId);
            parameters.Add("@CondicionEmbarqueId", contrato.CondicionEmbarqueId);
            parameters.Add("@FechaEmbarque", contrato.FechaEmbarque);
            parameters.Add("EmpresaId", contrato.EmpresaId);
            parameters.Add("@FechaContrato", contrato.FechaContrato);
            parameters.Add("@FechaFacturacion", contrato.FechaFacturacion);
            parameters.Add("@PaisDestinoId", contrato.PaisDestinoId);
            parameters.Add("@DepartamentoDestinoId", contrato.DepartamentoDestinoId);
            parameters.Add("@ProductoId", contrato.ProductoId);
            parameters.Add("@SubProductoId", contrato.SubProductoId);
            parameters.Add("@TipoProduccionId", contrato.TipoProduccionId);
            parameters.Add("@MonedadId", contrato.MonedadId);
            parameters.Add("@Monto", contrato.Monto);
            parameters.Add("@UnidadMedicionId", contrato.UnidadMedicionId);            
            parameters.Add("@CalculoContratoId", contrato.CalculoContratoId ?? string.Empty);
            parameters.Add("@EntidadCertificadoraId", contrato.EntidadCertificadoraId);
            parameters.Add("@TipoCertificacionId", contrato.TipoCertificacionId);
            parameters.Add("@CalidadId", contrato.CalidadId);
            parameters.Add("@GradoId", contrato.GradoId);
            parameters.Add("@PesoPorSaco", contrato.PesoPorSaco);
            parameters.Add("@PreparacionCantidadDefectos", contrato.PreparacionCantidadDefectos);
            parameters.Add("@LaboratorioId", contrato.LaboratorioId);
            parameters.Add("@FechaEnvioMuestra", contrato.FechaEnvioMuestra);
            parameters.Add("@NumeroSeguimientoMuestra", contrato.NumeroSeguimientoMuestra);
            parameters.Add("@EstadoMuestraId", contrato.EstadoMuestraId);
            parameters.Add("@ObservacionMuestra", contrato.ObservacionMuestra);
            parameters.Add("@NavieraId", contrato.NavieraId);
            parameters.Add("@FechaRecepcionMuestra", contrato.FechaRecepcionMuestra);
            parameters.Add("@ObservacionMuestra", contrato.ObservacionMuestra);
            parameters.Add("@NavieraId", contrato.NavieraId);
            parameters.Add("@NombreArchivo", contrato.NombreArchivo);
            parameters.Add("@DescripcionArchivo", contrato.DescripcionArchivo);
            parameters.Add("@PathArchivo", contrato.PathArchivo);
            parameters.Add("@FechaRegistro", contrato.FechaRegistro);
            parameters.Add("@UsuarioRegistro", contrato.UsuarioRegistro);
            parameters.Add("@EstadoId", contrato.EstadoId);
            parameters.Add("@EmpaqueId", contrato.EmpaqueId);
            parameters.Add("@TipoId", contrato.TipoId);
            parameters.Add("@TotalSacos", contrato.TotalSacos);
            parameters.Add("@PesoEnContrato", contrato.PesoEnContrato);
            parameters.Add("@PesoKilos", contrato.PesoKilos);
            parameters.Add("@ContratoId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspContratoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("ContratoId");

            return id;
        }

        public int Actualizar(Contrato contrato)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ContratoId", contrato.ContratoId);
            //parameters.Add("@Numero", contrato.Numero);
            parameters.Add("@ClienteId", contrato.ClienteId);
            parameters.Add("@FloId", contrato.FloId);
            parameters.Add("EmpresaId", contrato.EmpresaId);
            parameters.Add("@CondicionEmbarqueId", contrato.CondicionEmbarqueId);
            parameters.Add("@FechaEmbarque", contrato.FechaEmbarque);
            parameters.Add("@FechaContrato", contrato.FechaContrato);
            parameters.Add("@FechaFacturacion", contrato.FechaFacturacion);
            parameters.Add("@PaisDestinoId", contrato.PaisDestinoId);
            parameters.Add("@DepartamentoDestinoId", contrato.DepartamentoDestinoId);
            parameters.Add("@ProductoId", contrato.ProductoId);
            parameters.Add("@SubProductoId", contrato.SubProductoId);
            parameters.Add("@TipoProduccionId", contrato.TipoProduccionId);
            parameters.Add("@MonedadId", contrato.MonedadId);
            parameters.Add("@Monto", contrato.Monto);
            parameters.Add("@UnidadMedicionId", contrato.UnidadMedicionId);       
            parameters.Add("@EntidadCertificadoraId", contrato.EntidadCertificadoraId);
            parameters.Add("@TipoCertificacionId", contrato.TipoCertificacionId);
            parameters.Add("@CalculoContratoId", contrato.CalculoContratoId);
            parameters.Add("@CalidadId", contrato.CalidadId);
            parameters.Add("@GradoId", contrato.GradoId);
            parameters.Add("@TotalSacos", contrato.TotalSacos);
            parameters.Add("@PesoEnContrato", contrato.PesoEnContrato);
            parameters.Add("@PesoKilos", contrato.PesoKilos);
            parameters.Add("@PesoPorSaco", contrato.PesoPorSaco);
            parameters.Add("@PreparacionCantidadDefectos", contrato.PreparacionCantidadDefectos);
            parameters.Add("@LaboratorioId", contrato.LaboratorioId);
            parameters.Add("@FechaEnvioMuestra", contrato.FechaEnvioMuestra);
            parameters.Add("@NumeroSeguimientoMuestra", contrato.NumeroSeguimientoMuestra);
            parameters.Add("@EstadoMuestraId", contrato.EstadoMuestraId);
            parameters.Add("@ObservacionMuestra", contrato.ObservacionMuestra);
            parameters.Add("@NavieraId", contrato.NavieraId);
            parameters.Add("@FechaRecepcionMuestra", contrato.FechaRecepcionMuestra);
            parameters.Add("@ObservacionMuestra", contrato.ObservacionMuestra);
            parameters.Add("@NavieraId", contrato.NavieraId);
            parameters.Add("@NombreArchivo", contrato.NombreArchivo);
            parameters.Add("@DescripcionArchivo", contrato.DescripcionArchivo);
            parameters.Add("@PathArchivo", contrato.PathArchivo);
            parameters.Add("@FechaUltimaActualizacion", contrato.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", contrato.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", contrato.EstadoId);
            parameters.Add("@EmpaqueId", contrato.EmpaqueId);
            parameters.Add("@TipoId", contrato.TipoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspContratoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaContratoPorIdBE ConsultarContratoPorId(int contratoId)
        {
            ConsultaContratoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ContratoId", contratoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaContratoPorIdBE>("uspContratoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }
    }
}
