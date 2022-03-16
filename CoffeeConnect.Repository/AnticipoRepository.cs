using CoffeeConnect.DTO;
using CoffeeConnect.DTO.Anticipo;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
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
    public class AnticipoRepository : IAnticipoRepository
    {

        public IOptions<ConnectionString> _connectionString;
        public AnticipoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ResultadoPDFAnticipo> GenerarPDF(int idAnticipo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AnticipoId", idAnticipo);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ResultadoPDFAnticipo>("uspAnticipoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        IEnumerable<ConsultaAnticipoBE> IAnticipoRepository.ConsultarAnticipo(ConsultaAnticipoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Numero", request.Numero);
            parameters.Add("@NumeroNotaIngresoPlanta", request.NumeroNotaIngresoPlanta);
            parameters.Add("@RucProveedor", request.RucProveedor);
            parameters.Add("@RazonSocialProveedor", request.RazonSocialProveedor);           
            parameters.Add("@EstadoId", request.EstadoId);
            parameters.Add("@EmpresaId", request.EmpresaId);
            parameters.Add("@FechaInicio", request.FechaInicio);
            parameters.Add("@FechaFin", request.FechaFin);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaAnticipoBE>("uspAnticipoConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ConsultaAnticipoBE> ConsultarAnticiposPorNotaIngresoPlanta(int notaIngresoPlantaId, string estadoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", notaIngresoPlantaId);
            parameters.Add("@EstadoId", estadoId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaAnticipoBE>("uspAnticipoConsultaPorNotaCompra", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public IEnumerable<ConsultaImpresionAnticipoBE> ConsultarImpresionAnticiposPorNotaIngresoPlanta(int notaIngresoPlantaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", notaIngresoPlantaId);          



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaImpresionAnticipoBE>("uspAnticipoConsultaImpresionPorNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(Anticipo anticipo)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@ProveedorId", anticipo.ProveedorId);
            parameters.Add("@EmpresaId", anticipo.EmpresaId);
            parameters.Add("@Numero", anticipo.Numero);           
            parameters.Add("@MonedaId", anticipo.MonedaId);
            parameters.Add("@Monto", anticipo.Monto);
            parameters.Add("@FechaPago", anticipo.FechaPago);
            parameters.Add("@Motivo", anticipo.Motivo);
            parameters.Add("@FechaEntregaProducto", anticipo.FechaEntregaProducto);      
            parameters.Add("@EstadoId", anticipo.EstadoId);
            parameters.Add("@FechaRegistro", anticipo.FechaRegistro);
            parameters.Add("@UsuarioRegistro", anticipo.UsuarioRegistro);
            parameters.Add("@AnticipoId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAnticipoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("AnticipoId");

            return id;
        }
        public int Actualizar(Anticipo anticipo)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@AnticipoId", anticipo.AnticipoId);
            parameters.Add("@ProveedorId", anticipo.ProveedorId);
            parameters.Add("@EmpresaId", anticipo.EmpresaId);
            //parameters.Add("@Numero", Anticipo.Numero);     
            parameters.Add("@MonedaId", anticipo.MonedaId);
            parameters.Add("@Monto", anticipo.Monto);
            parameters.Add("@FechaPago", anticipo.FechaPago);
            parameters.Add("@Motivo", anticipo.Motivo);
            parameters.Add("@FechaEntregaProducto", anticipo.FechaEntregaProducto);
          //  parameters.Add("@NotaCompraId", Anticipo.NotaCompraId);
            parameters.Add("@FechaUltimaActualizacion", anticipo.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", anticipo.UsuarioUltimaActualizacion);
            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspAnticipoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public ConsultaAnticipoPorIdBE ConsultarAnticipoPorId(int anticipoId)
        {
            ConsultaAnticipoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@AnticipoId", anticipoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {

                var list = db.Query<ConsultaAnticipoPorIdBE>("uspAnticipoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }
            return itemBE;
        }


        public int Anular(int anticipoId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AnticipoId", anticipoId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspAnticipoAnular", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }

        public int ActualizarEstadoPorNotaIngresoPlanta(int notaIngresoPlantaId, DateTime fecha, string usuario, string estadoId)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaIngresoPlantaId", notaIngresoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);
            parameters.Add("@EstadoId", estadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspAnticipoActualizarEstadoPorNotaIngresoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }




        public int AsociarNotaIngresoPlanta(int anticipoId, int notaIngresoPlantaId, DateTime fecha, string usuario)
        {
            int affected = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@AnticipoId", anticipoId);
            parameters.Add("@NotaIngresoPlantaId", notaIngresoPlantaId);
            parameters.Add("@Fecha", fecha);
            parameters.Add("@Usuario", usuario);            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                affected = db.Execute("uspAnticipoAsociarNotaCompra", parameters, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }


    }
}
