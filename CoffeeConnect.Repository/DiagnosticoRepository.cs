using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
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
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public DiagnosticoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaDiagnosticoBE> ConsultarDiagnostico(ConsultaDiagnosticoRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", request.Numero);           
            parameters.Add("EstadoId", request.EstadoId);
            parameters.Add("EmpresaId", request.EmpresaId);
            parameters.Add("FechaInicio", request.FechaInicio);
            parameters.Add("FechaFin", request.FechaFin);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaDiagnosticoBE>("uspDiagnosticoConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insertar(Diagnostico diagnostico)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            
            parameters.Add("@Numero", diagnostico.Numero);
            parameters.Add("@SocioFincaId", diagnostico.SocioFincaId);
            parameters.Add("@ObservacionInfraestructura", diagnostico.ObservacionInfraestructura);
            parameters.Add("@ObservacionDatosCampo", diagnostico.ObservacionDatosCampo);
            parameters.Add("@Responsable", diagnostico.Responsable);
            parameters.Add("@TecnicoCampo", diagnostico.TecnicoCampo);
            parameters.Add("@EmpresaId", diagnostico.EmpresaId);
            parameters.Add("@AreaTotal", diagnostico.AreaTotal);
            parameters.Add("@AreaCafeEnProduccion", diagnostico.AreaCafeEnProduccion);
            parameters.Add("@Crecimiento", diagnostico.Crecimiento);
            parameters.Add("@Bosque", diagnostico.Bosque);
            parameters.Add("@Purma", diagnostico.Purma);
            parameters.Add("@PanLlevar", diagnostico.PanLlevar);
            parameters.Add("@Vivienda", diagnostico.Vivienda);
            parameters.Add("@IngresoPromedioMensual", diagnostico.IngresoPromedioMensual);
            parameters.Add("@IngresoAgricultura", diagnostico.IngresoAgricultura);
            parameters.Add("@IngresoBodega", diagnostico.IngresoBodega);
            parameters.Add("@IngresoTransporte", diagnostico.IngresoTransporte);
            parameters.Add("@IngresoOtro", diagnostico.IngresoOtro);
            parameters.Add("@PrestamoEntidades", diagnostico.PrestamoEntidades);
            parameters.Add("@EstadoId", diagnostico.EstadoId);
            parameters.Add("@FechaRegistro", diagnostico.FechaRegistro);
            parameters.Add("@UsuarioRegistro", diagnostico.UsuarioRegistro);
          

            parameters.Add("@DiagnosticoId", dbType: DbType.Int32, direction: ParameterDirection.Output);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDiagnosticoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("DiagnosticoId");

            return id;
        }

      

        public int Actualizar(Diagnostico diagnostico)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@DiagnosticoId", diagnostico.DiagnosticoId);           
            parameters.Add("@SocioFincaId", diagnostico.SocioFincaId);
            parameters.Add("@ObservacionInfraestructura", diagnostico.ObservacionInfraestructura);
            parameters.Add("@ObservacionDatosCampo", diagnostico.ObservacionDatosCampo);
            parameters.Add("@Responsable", diagnostico.Responsable);
            parameters.Add("@TecnicoCampo", diagnostico.TecnicoCampo);
            parameters.Add("@EmpresaId", diagnostico.EmpresaId);
            parameters.Add("@AreaTotal", diagnostico.AreaTotal);
            parameters.Add("@AreaCafeEnProduccion", diagnostico.AreaCafeEnProduccion);
            parameters.Add("@Crecimiento", diagnostico.Crecimiento);
            parameters.Add("@Bosque", diagnostico.Bosque);
            parameters.Add("@Purma", diagnostico.Purma);
            parameters.Add("@PanLlevar", diagnostico.PanLlevar);
            parameters.Add("@Vivienda", diagnostico.Vivienda);
            parameters.Add("@IngresoPromedioMensual", diagnostico.IngresoPromedioMensual);
            parameters.Add("@IngresoAgricultura", diagnostico.IngresoAgricultura);
            parameters.Add("@IngresoBodega", diagnostico.IngresoBodega);
            parameters.Add("@IngresoTransporte", diagnostico.IngresoTransporte);
            parameters.Add("@IngresoOtro", diagnostico.IngresoOtro);
            parameters.Add("@PrestamoEntidades", diagnostico.PrestamoEntidades);
            parameters.Add("@EstadoId", diagnostico.EstadoId);           
            parameters.Add("@FechaUltimaActualizacion", diagnostico.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", diagnostico.UsuarioUltimaActualizacion);
           
            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDiagnosticoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaDiagnosticoPorIdBE ConsultarDiagnosticoPorId(int diagnosticoId)
        {
            ConsultaDiagnosticoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@DiagnosticoId", diagnosticoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaDiagnosticoPorIdBE>("uspDiagnosticoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


        public int ActualizarDiagnosticoCostoProduccion(List<DiagnosticoCostoProduccionTipo> request, int diagnosticoId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@DiagnosticoId", diagnosticoId);
            parameters.Add("@DiagnosticoCostoProduccionTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDiagnosticoCostoProduccionActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspLoteAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarDiagnosticoDatosCampo(List<DiagnosticoDatosCampoTipo> request, int diagnosticoId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@DiagnosticoId", diagnosticoId);
            parameters.Add("@DiagnosticoDatosCampoTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDiagnosticoDatosCampoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;


            //uspLoteAnalisisFisicoColorDetalleActualizar

        }

        public int ActualizarDiagnosticoInfraestructura(List<DiagnosticoInfraestructuraTipo> request, int diagnosticoId)
        {
            //uspLoteAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@DiagnosticoId", diagnosticoId);
            parameters.Add("@DiagnosticoInfraestructuraTipo", request.ToDataTable().AsTableValuedParameter());



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspDiagnosticoInfraestructuraActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;          

        }       

        public IEnumerable<DiagnosticoCostoProduccion> ConsultarDiagnosticoCostoProduccionPorId(int diagnosticoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DiagnosticoId", diagnosticoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<DiagnosticoCostoProduccion>("uspDiagnosticoCostoProduccionConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<DiagnosticoDatosCampo> ConsultarDiagnosticoDatosCampoPorId(int diagnosticoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DiagnosticoId", diagnosticoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<DiagnosticoDatosCampo>("uspDiagnosticoDatosCampoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        

        public IEnumerable<DiagnosticoInfraestructura> ConsultarDiagnosticoInfraestructuraPorId(int diagnosticoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DiagnosticoId", diagnosticoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<DiagnosticoInfraestructura>("uspDiagnosticoInfraestructuraConsultaPorId", parameters, commandType: CommandType.StoredProcedure);
            }
        }




    }
}
