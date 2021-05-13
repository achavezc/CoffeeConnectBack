using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CoffeeConnect.Repository
{
    public class OrdenProcesoRepository : IOrdenProcesoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        
        public OrdenProcesoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Actualizar(OrdenProceso ordenProceso)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoId", ordenProceso.OrdenProcesoId);
            parameters.Add("@EmpresaId", ordenProceso.EmpresaId);
            parameters.Add("@EmpresaProcesadoraId", ordenProceso.EmpresaProcesadoraId);
            parameters.Add("@ContratoId", ordenProceso.ContratoId);
            parameters.Add("@Numero", ordenProceso.Numero);
            parameters.Add("@TipoProcesoId", ordenProceso.TipoProcesoId);
            parameters.Add("@CantidadSacosUtilizar", ordenProceso.CantidadSacosUtilizar);
            parameters.Add("@RendimientoEsperadoPorcentaje", ordenProceso.RendimientoEsperadoPorcentaje);
            parameters.Add("@NombreArchivo", ordenProceso.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ordenProceso.DescripcionArchivo);
            parameters.Add("@PathArchivo", ordenProceso.PathArchivo);
            parameters.Add("@FechaFinProceso", ordenProceso.FechaFinProceso);
            parameters.Add("@CantidadContenedores", ordenProceso.CantidadContenedores);
            parameters.Add("@FechaUltimaActualizacion", ordenProceso.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", ordenProceso.UsuarioUltimaActualizacion);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspOrdenProcesoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public int Anular(int ordenProcesoId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@OrdenProcesoId", ordenProcesoId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspOrdenProcesoAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public IEnumerable<ConsultaOrdenProcesoBE> ConsultarOrdenProceso(ConsultaOrdenProcesoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@NumeroContrato", request.NumeroContrato);
            parameters.Add("@NumeroCliente", request.NumeroCliente);
            parameters.Add("@RazonSocialCliente", request.RazonSocialCliente);
            parameters.Add("@RucEmpresaProcesadora", request.RucEmpresaProcesadora);
            parameters.Add("@RazonSocialEmpresaProcesadora", request.RazonSocialEmpresaProcesadora);
            parameters.Add("@TipoProcesoId", request.TipoProcesoId);
            parameters.Add("@EstadoId", request.EstadoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFinal);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaOrdenProcesoBE>("uspOrdenProcesoConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(OrdenProceso ordenProceso)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", ordenProceso.EmpresaId);
            parameters.Add("@EmpresaProcesadoraId", ordenProceso.EmpresaProcesadoraId);
            parameters.Add("@ContratoId", ordenProceso.ContratoId);
            parameters.Add("@Numero", ordenProceso.Numero);
            parameters.Add("@CantidadSacosUtilizar", ordenProceso.CantidadSacosUtilizar);
            parameters.Add("@RendimientoEsperadoPorcentaje", ordenProceso.RendimientoEsperadoPorcentaje);
            parameters.Add("@FechaFinProceso", ordenProceso.FechaFinProceso);
            parameters.Add("@CantidadContenedores", ordenProceso.CantidadContenedores);
            parameters.Add("@TipoProcesoId", ordenProceso.TipoProcesoId);
            parameters.Add("@NombreArchivo", ordenProceso.NombreArchivo);
            parameters.Add("@DescripcionArchivo", ordenProceso.DescripcionArchivo);
            parameters.Add("@PathArchivo", ordenProceso.PathArchivo);
            parameters.Add("@EstadoId", ordenProceso.EstadoId);
            parameters.Add("@FechaRegistro", ordenProceso.FechaRegistro);
            parameters.Add("@UsuarioRegistro", ordenProceso.UsuarioRegistro);
            parameters.Add("@OrdenProcesoId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspOrdenProcesoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("ContratoId");
            return id;
        }
    }
}
