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
    public class AduanaRepository : IAduanaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public AduanaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaAduanaBE> ConsultarAduana(ConsultaAduanaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("NumeroContrato", request.NumeroContrato);
            parameters.Add("RazonSocialCliente", request.RazonSocialCliente);
            parameters.Add("RucEmpresaExportadora", request.RucEmpresaExportadora);
            parameters.Add("RazonSocialEmpresaExportadora", request.RazonSocialEmpresaExportadora);           
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaAduanaBE>("uspAduanaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(Aduana aduana)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            
            parameters.Add("@ContratoId", aduana.ContratoId);
            parameters.Add("@EmpresaAgenciaAduaneraId", aduana.EmpresaAgenciaAduaneraId);
            parameters.Add("@EmpresaExportadoraId", aduana.EmpresaExportadoraId);
            parameters.Add("@EmpresaProductoraId", aduana.EmpresaProductoraId);
            parameters.Add("@EmpresaId", aduana.EmpresaId);
            parameters.Add("@Numero", aduana.Numero);
            parameters.Add("@Marca", aduana.Marca);
            parameters.Add("@FechaEmbarque", aduana.FechaEmbarque);
            parameters.Add("@FechaFacturacion", aduana.FechaFacturacion);

          
        parameters.Add("@PO", aduana.PO);
            parameters.Add("@LaboratorioId", aduana.LaboratorioId);
            parameters.Add("@FechaEnvioMuestra", aduana.FechaEnvioMuestra);
            parameters.Add("@NumeroSeguimientoMuestra", aduana.NumeroSeguimientoMuestra);
            parameters.Add("@EstadoMuestraId", aduana.EstadoMuestraId);
            parameters.Add("@FechaRecepcionMuestra", aduana.FechaRecepcionMuestra);
            parameters.Add("@ObservacionMuestra", aduana.ObservacionMuestra);
            parameters.Add("@NavieraId", aduana.NavieraId);
            parameters.Add("@Observacion", aduana.Observacion);
            parameters.Add("@NombreArchivo", aduana.NombreArchivo);
            parameters.Add("@DescripcionArchivo", aduana.DescripcionArchivo);
            parameters.Add("@PathArchivo", aduana.PathArchivo);
            parameters.Add("@FechaRegistro", aduana.FechaRegistro);
            parameters.Add("@UsuarioRegistro", aduana.UsuarioRegistro);                    
      

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAduanaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("AduanaId");

            return id;
        }

        public int Actualizar(Aduana aduana)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AduanaId", aduana.AduanaId);
            parameters.Add("@ContratoId", aduana.ContratoId);
            parameters.Add("@EmpresaAgenciaAduaneraId", aduana.EmpresaAgenciaAduaneraId);
            parameters.Add("@EmpresaExportadoraId", aduana.EmpresaExportadoraId);
            parameters.Add("@EmpresaProductoraId", aduana.EmpresaProductoraId);
            parameters.Add("@EmpresaId", aduana.EmpresaId);
            parameters.Add("@Numero", aduana.Numero);
            parameters.Add("@FechaEmbarque", aduana.FechaEmbarque);
            parameters.Add("@FechaFacturacion", aduana.FechaFacturacion);
            parameters.Add("@Marca", aduana.Marca);
            parameters.Add("@PO", aduana.PO);
            parameters.Add("@LaboratorioId", aduana.LaboratorioId);
            parameters.Add("@FechaEnvioMuestra", aduana.FechaEnvioMuestra);
            parameters.Add("@NumeroSeguimientoMuestra", aduana.NumeroSeguimientoMuestra);
            parameters.Add("@EstadoMuestraId", aduana.EstadoMuestraId);
            parameters.Add("@FechaRecepcionMuestra", aduana.FechaRecepcionMuestra);
            parameters.Add("@ObservacionMuestra", aduana.ObservacionMuestra);
            parameters.Add("@NavieraId", aduana.NavieraId);
            parameters.Add("@Observacion", aduana.Observacion);
            parameters.Add("@NombreArchivo", aduana.NombreArchivo);
            parameters.Add("@DescripcionArchivo", aduana.DescripcionArchivo);
            parameters.Add("@PathArchivo", aduana.PathArchivo);            
            parameters.Add("@FechaUltimaActualizacion", aduana.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", aduana.UsuarioUltimaActualizacion);     
            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAduanaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public int Anular(int AduanaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AduanaId", AduanaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspAduanaAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public ConsultaAduanaPorIdBE ConsultarAduanaPorId(int aduanaId)
        {
            ConsultaAduanaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@AduanaId", aduanaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaAduanaPorIdBE>("uspAduanaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }


        public int ActualizarAduanaCertificacion(List<AduanaCertificacionTipo> request, int aduanaId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@AduanaId", aduanaId);
            parameters.Add("@AduanaCertificacionTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAduanaCertificacionActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public IEnumerable<ConsultaAduanaCertificacionPorIdBE> ConsultarAduanaCertificacionPorId(int aduanaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AduanaId", aduanaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaAduanaCertificacionPorIdBE>("uspAduanaCertificacionConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
