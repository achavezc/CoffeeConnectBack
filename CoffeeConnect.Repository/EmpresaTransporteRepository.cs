using CoffeeConnect.DTO;
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
    public class EmpresaTransporteRepository : IEmpresaTransporteRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public EmpresaTransporteRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<EmpresaTransporteBE> ConsultarEmpresaTransporte(ConsultaEmpresaTransporteRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("EstadoId", request.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<EmpresaTransporteBE>("uspEmpresaTransporteConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaTransportistaBE> ConsultarTransportista(ConsultaTransportistaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RazonSocial", request.RazonSocial);
            parameters.Add("Ruc", request.Ruc);
            parameters.Add("EmpresaId", request.EstadoId);
            parameters.Add("EstadoId", request.EmpresaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaTransportistaBE>("uspTransportistaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public int Insertar(EmpresaTransporte empresaTransporte)
        {
            int result = 0;

            var parameters = new DynamicParameters();           
            parameters.Add("@RazonSocial", empresaTransporte.RazonSocial);
            parameters.Add("@Ruc", empresaTransporte.Ruc);
            parameters.Add("@Direccion", empresaTransporte.Direccion);
            parameters.Add("@DepartamentoId", empresaTransporte.DepartamentoId);
            parameters.Add("@ProvinciaId", empresaTransporte.ProvinciaId);
            parameters.Add("@DistritoId", empresaTransporte.DistritoId);
            parameters.Add("@EstadoId", empresaTransporte.EstadoId);
            parameters.Add("@EmpresaId", empresaTransporte.EmpresaId);       
            parameters.Add("@FechaRegistro", empresaTransporte.FechaRegistro);
            parameters.Add("@UsuarioRegistro", empresaTransporte.UsuarioRegistro);
            parameters.Add("@Activo", true);




            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspEmpresaTransporteInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public int Actualizar(EmpresaTransporte empresaTransporte)
        {
            int result = 0;

         
            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaTransporteId", empresaTransporte.EmpresaTransporteId);
            parameters.Add("@RazonSocial", empresaTransporte.RazonSocial);
            parameters.Add("@Ruc", empresaTransporte.Ruc);
            parameters.Add("@Direccion", empresaTransporte.Direccion);
            parameters.Add("@DepartamentoId", empresaTransporte.DepartamentoId);
            parameters.Add("@ProvinciaId", empresaTransporte.ProvinciaId);
            parameters.Add("@DistritoId", empresaTransporte.DistritoId);
            parameters.Add("@EstadoId", empresaTransporte.EstadoId);
            parameters.Add("@EmpresaId", empresaTransporte.EmpresaId);      
            parameters.Add("@FechaUltimaActualizacion", empresaTransporte.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", empresaTransporte.UsuarioUltimaActualizacion);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspEmpresaTransporteActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaEmpresaTransportePorIdBE ConsultarEmpresaTransportePorId(int empresaTransporteId)
        {
            ConsultaEmpresaTransportePorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaTransporteId", empresaTransporteId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaEmpresaTransportePorIdBE>("uspEmpresaTransporteConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public IEnumerable<ConsultaProductoPrecioDiaBE> ConsultarEmpresaTransporte(ConsultaEmpresaTransporteDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@Ruc", request.Ruc);
            parameters.Add("@RazonSocial", request.RazonSocial);
            parameters.Add("@EstadoId", request.EstadoId);         


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaProductoPrecioDiaBE>("uspEmpresaTransporteConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
