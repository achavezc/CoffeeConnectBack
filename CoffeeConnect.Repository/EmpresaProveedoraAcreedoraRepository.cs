using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
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
    public class EmpresaProveedoraAcreedoraRepository : IEmpresaProveedoraAcreedoraRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public EmpresaProveedoraAcreedoraRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaEmpresaProveedoraAcreedoraBE> ConsultarEmpresaProveedoraAcreedora(ConsultaEmpresaProveedoraAcreedoraRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("ClasificacionId", request.ClasificacionId);
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaEmpresaProveedoraAcreedoraBE>("uspEmpresaProveedoraAcreedoraConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(EmpresaProveedoraAcreedora EmpresaProveedoraAcreedora)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@RazonSocial", EmpresaProveedoraAcreedora.RazonSocial);
            parameters.Add("@Ruc", EmpresaProveedoraAcreedora.Ruc);
            parameters.Add("@Direccion", EmpresaProveedoraAcreedora.Direccion);
            parameters.Add("@DepartamentoId", EmpresaProveedoraAcreedora.DepartamentoId);
            parameters.Add("@ProvinciaId", EmpresaProveedoraAcreedora.ProvinciaId);
            parameters.Add("@DistritoId", EmpresaProveedoraAcreedora.DistritoId);
            parameters.Add("@EstadoId", EmpresaProveedoraAcreedora.EstadoId);
            parameters.Add("@EmpresaId", EmpresaProveedoraAcreedora.EmpresaId);
            parameters.Add("@ClasificacionId", EmpresaProveedoraAcreedora.ClasificacionId);
            parameters.Add("@FechaRegistro", EmpresaProveedoraAcreedora.FechaRegistro);
            parameters.Add("@UsuarioRegistro", EmpresaProveedoraAcreedora.UsuarioRegistro);

            parameters.Add("@EmpresaProveedoraAcreedoraId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspEmpresaProveedoraAcreedoraInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("GuiaRecepcionMateriaPrimaId");

            return id;
        }

        public int Actualizar(EmpresaProveedoraAcreedora EmpresaProveedoraAcreedora)
        {
            int result = 0;


            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaProveedoraAcreedoraId", EmpresaProveedoraAcreedora.EmpresaProveedoraAcreedoraId);
            parameters.Add("@RazonSocial", EmpresaProveedoraAcreedora.RazonSocial);
            parameters.Add("@Ruc", EmpresaProveedoraAcreedora.Ruc);
            parameters.Add("@Direccion", EmpresaProveedoraAcreedora.Direccion);
            parameters.Add("@ClasificacionId", EmpresaProveedoraAcreedora.ClasificacionId);
            parameters.Add("@DepartamentoId", EmpresaProveedoraAcreedora.DepartamentoId);
            parameters.Add("@ProvinciaId", EmpresaProveedoraAcreedora.ProvinciaId);
            parameters.Add("@DistritoId", EmpresaProveedoraAcreedora.DistritoId);
            parameters.Add("@EstadoId", EmpresaProveedoraAcreedora.EstadoId);
            parameters.Add("@EmpresaId", EmpresaProveedoraAcreedora.EmpresaId);
            parameters.Add("@FechaUltimaActualizacion", EmpresaProveedoraAcreedora.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", EmpresaProveedoraAcreedora.UsuarioUltimaActualizacion);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspEmpresaProveedoraAcreedoraActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaEmpresaProveedoraAcreedoraPorIdBE ConsultarEmpresaProveedoraAcreedoraPorId(int EmpresaProveedoraAcreedoraId)
        {
            ConsultaEmpresaProveedoraAcreedoraPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaProveedoraAcreedoraId", EmpresaProveedoraAcreedoraId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaEmpresaProveedoraAcreedoraPorIdBE>("uspEmpresaProveedoraAcreedoraConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


        public int ActualizarEmpresaProveedoraAcreedoraCertificacion(List<EmpresaProveedoraAcreedoraCertificacionTipo> request, int empresaProveedoraAcreedoraCertificacionId)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@EmpresaProveedoraAcreedoraCertificacionId", empresaProveedoraAcreedoraCertificacionId);
            parameters.Add("@EmpresaProveedoraAcreedoraCertificacionTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspEmpresaProveedoraAcreedoraCertificacionActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;

        }

        public IEnumerable<ConsultaEmpresaProveedoraAcreedoraCertificacionPorIdBE> ConsultarEmpresaProveedoraAcreedoraCertificacionPorId(int empresaProveedoraAcreedoraId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaProveedoraAcreedoraId", empresaProveedoraAcreedoraId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaEmpresaProveedoraAcreedoraCertificacionPorIdBE>("uspEmpresaProveedoraAcreedoraCertificacionPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
