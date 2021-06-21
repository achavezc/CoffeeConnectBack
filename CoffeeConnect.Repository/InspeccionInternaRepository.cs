using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class InspeccionInternaRepository : IInspeccionInternaRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public InspeccionInternaRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaInspeccionInternaBE> ConsultarInspeccionInterna(ConsultaInspeccionInternaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaInspeccionInternaBE>("uspInspeccionInternaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(InspeccionInterna inspeccionInterna)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInterna.InspeccionInternaId);
            parameters.Add("@Numero", inspeccionInterna.Numero);
            parameters.Add("@SocioFincaId", inspeccionInterna.SocioFincaId);
            parameters.Add("@Certificaciones", inspeccionInterna.Certificaciones);
            parameters.Add("@ExclusionPrograma", inspeccionInterna.ExclusionPrograma);
            parameters.Add("@SuspencionTiempo", inspeccionInterna.SuspencionTiempo);
            parameters.Add("@DuracionSuspencionTiempo", inspeccionInterna.DuracionSuspencionTiempo);
            parameters.Add("@NoConformidadObservacionLevantada", inspeccionInterna.NoConformidadObservacionLevantada);
            parameters.Add("@ApruebaSinCondicion", inspeccionInterna.ApruebaSinCondicion);
            parameters.Add("@EmpresaId", inspeccionInterna.EmpresaId);
            parameters.Add("@Inspector", inspeccionInterna.Inspector);
            parameters.Add("@FechaInspeccion", inspeccionInterna.FechaInspeccion);
            parameters.Add("@EstadoId", inspeccionInterna.EstadoId);
            parameters.Add("@FechaRegistro", inspeccionInterna.FechaRegistro);
            parameters.Add("@UsuarioRegistro", inspeccionInterna.UsuarioRegistro);
            parameters.Add("@NombreArchivo", inspeccionInterna.NombreArchivo);
            parameters.Add("@PathArchivo", inspeccionInterna.PathArchivo);

            parameters.Add("@InspeccionInternaId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("InspeccionInternaId");

            return id;
        }

        public int Actualizar(InspeccionInterna inspeccionInterna)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInterna.InspeccionInternaId);
            parameters.Add("@SocioFincaId", inspeccionInterna.SocioFincaId);
            parameters.Add("@Certificaciones", inspeccionInterna.Certificaciones);
            parameters.Add("@ExclusionPrograma", inspeccionInterna.ExclusionPrograma);
            parameters.Add("@SuspencionTiempo", inspeccionInterna.SuspencionTiempo);
            parameters.Add("@DuracionSuspencionTiempo", inspeccionInterna.DuracionSuspencionTiempo);
            parameters.Add("@NoConformidadObservacionLevantada", inspeccionInterna.NoConformidadObservacionLevantada);
            parameters.Add("@ApruebaSinCondicion", inspeccionInterna.ApruebaSinCondicion);
            parameters.Add("@EmpresaId", inspeccionInterna.EmpresaId);
            parameters.Add("@Inspector", inspeccionInterna.Inspector);
            parameters.Add("@FechaInspeccion", inspeccionInterna.FechaInspeccion);
            parameters.Add("@EstadoId", inspeccionInterna.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", inspeccionInterna.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", inspeccionInterna.UsuarioUltimaActualizacion);
            parameters.Add("@NombreArchivo", inspeccionInterna.NombreArchivo);
            parameters.Add("@PathArchivo", inspeccionInterna.PathArchivo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaInspeccionInternaPorIdBE ConsultarInspeccionInternaPorId(int inspeccionInternaId)
        {
            ConsultaInspeccionInternaPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaInspeccionInternaPorIdBE>("uspInspeccionInternaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public int ActualizarInspeccionInternaParcela(List<InspeccionInternaParcelaTipo> request, int inspeccionInternaId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@InspeccionInternaId", inspeccionInternaId);
            parameters.Add("@InspeccionInternaParcelaTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaParcelaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int ActualizarInspeccionInternaNormas(List<InspeccionInternaNormasTipo> request, int inspeccionInternaId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@InspeccionInternaId", inspeccionInternaId);
            parameters.Add("@InspeccionInternaNormasTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaNormasActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
            //uspLoteAnalisisFisicoColorDetalleActualizar
        }

        public int ActualizarInspeccionInternaLevantamientoNoConformidad(List<InspeccionInternaLevantamientoNoConformidadTipo> request, int inspeccionInternaId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@InspeccionInternaId", inspeccionInternaId);
            parameters.Add("@InspeccionInternaLevantamientoNoConformidadTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaLevantamientoNoConformidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int ActualizarInspeccionInternaNoConformidad(List<InspeccionInternaNoConformidadTipo> request, int inspeccionInternaId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@InspeccionInternaId", inspeccionInternaId);
            parameters.Add("@InspeccionInternaNoConformidadTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspInspeccionInternaNoConformidadActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public IEnumerable<InspeccionInternaLevantamientoNoConformidad> ConsultarInspeccionInternaLevantamientoNoConformidadPorId(int inspeccionInternaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<InspeccionInternaLevantamientoNoConformidad>("uspInspeccionInternaLevantamientoNoConformidadConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<InspeccionInternaNoConformidad> ConsultarInspeccionInternaNoConformidadPorId(int inspeccionInternaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<InspeccionInternaNoConformidad>("uspInspeccionInternaNoConformidadConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<InspeccionInternaNorma> ConsultarInspeccionInternaNormasPorId(int inspeccionInternaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<InspeccionInternaNorma>("uspInspeccionInternaNormasConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<InspeccionInternaParcela> ConsultarInspeccionInternaParcelaPorId(int inspeccionInternaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InspeccionInternaId", inspeccionInternaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<InspeccionInternaParcela>("uspInspeccionInternaParcelaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
