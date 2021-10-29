using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeConnect.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public ClienteRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaClienteBE> ConsultarCliente(ConsultaClienteRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@RazonSocial", request.RazonSocial);
            parameters.Add("@TipoClienteId", request.TipoClienteId);
            parameters.Add("@PaisId", request.PaisId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@Ruc", request.Ruc);
            parameters.Add("@EstadoId", request.EstadoId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaClienteBE>("uspClienteConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(Cliente cliente)
        {
            int result = 0;


            var parameters = new DynamicParameters();

            parameters.Add("@Numero", cliente.Numero);
            parameters.Add("@TipoClienteId", cliente.TipoClienteId);
            parameters.Add("@Ruc", cliente.Ruc);
            parameters.Add("@FloId", cliente.FloId);
            parameters.Add("@EmpresaId", cliente.EmpresaId);
            parameters.Add("@RazonSocial", cliente.RazonSocial);
            parameters.Add("@Direccion", cliente.Direccion);
            parameters.Add("@PaisId", cliente.PaisId);
            parameters.Add("@DepartamentoId", cliente.DepartamentoId);
            parameters.Add("@ProvinciaId", cliente.ProvinciaId);
            parameters.Add("@DistritoId", cliente.DistritoId);
            parameters.Add("@NumeroTelefono", cliente.NumeroTelefono);
            parameters.Add("@CorreoElectronico", cliente.CorreoElectronico);
            parameters.Add("@GerenteGeneral", cliente.GerenteGeneral);
            parameters.Add("@GerenteGeneralNumero", cliente.GerenteGeneralNumero);
            parameters.Add("@Presidente", cliente.Presidente);
            parameters.Add("@PresidenteNumero", cliente.PresidenteNumero);
            parameters.Add("@FechaRegistro", cliente.FechaRegistro);
            parameters.Add("@UsuarioRegistro", cliente.UsuarioRegistro);
            parameters.Add("@EstadoId", cliente.EstadoId);



            parameters.Add("@ClienteId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspClienteInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("ClienteId");

            return id;
        }

        public int Anular(int clienteId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ClienteId", clienteId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspClienteAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int Actualizar(Cliente cliente)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@ClienteId", cliente.ClienteId);
            parameters.Add("@TipoClienteId", cliente.TipoClienteId);
            parameters.Add("@Ruc", cliente.Ruc);
            parameters.Add("@FloId", cliente.FloId);
            parameters.Add("@RazonSocial", cliente.RazonSocial);
            parameters.Add("@Direccion", cliente.Direccion);
            parameters.Add("@EmpresaId", cliente.EmpresaId);
            parameters.Add("@PaisId", cliente.PaisId);
            parameters.Add("@DepartamentoId", cliente.DepartamentoId);
            parameters.Add("@ProvinciaId", cliente.ProvinciaId);
            parameters.Add("@DistritoId", cliente.DistritoId);
            parameters.Add("@NumeroTelefono", cliente.NumeroTelefono);
            parameters.Add("@CorreoElectronico", cliente.CorreoElectronico);
            parameters.Add("@GerenteGeneral", cliente.GerenteGeneral);
            parameters.Add("@GerenteGeneralNumero", cliente.GerenteGeneralNumero);
            parameters.Add("@Presidente", cliente.Presidente);
            parameters.Add("@PresidenteNumero", cliente.PresidenteNumero);
            parameters.Add("@FechaUltimaActualizacion", cliente.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", cliente.UsuarioUltimaActualizacion);
            parameters.Add("@EstadoId", cliente.EstadoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspClienteActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaClientePorIdBE ConsultarClientePorId(int clienteId)
        {
            ConsultaClientePorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@ClienteId", clienteId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaClientePorIdBE>("uspClienteConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


        
    }
}
