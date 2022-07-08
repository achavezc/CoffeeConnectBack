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
    public class CorrelativoRepository : ICorrelativoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public CorrelativoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public string Obtener(int? empresaId, string documento)
        {
            string result = String.Empty;

            var parameters = new DynamicParameters();

            parameters.Add("@Documento", documento);
            parameters.Add("@EmpresaId", empresaId);
            parameters.Add("@Numero", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspCorrelativoGenerar", parameters, commandType: CommandType.StoredProcedure);
            }

            result = parameters.Get<string>("Numero");

            return result;
        }

        public string ObtenerCorrelativoNotaIngreso(string Campaña,string CodigoTipo,string CodigoTipoConcepto)
        {
            string result = String.Empty;

            var parameters = new DynamicParameters();

            parameters.Add("@Campanha", Campaña );
            parameters.Add("@CodigoTipo", CodigoTipo);
            parameters.Add("@CodigoTipoConcepto", CodigoTipoConcepto);
            parameters.Add("@Numero", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                db.Execute("uspCorrelativoPlantaGenerar", parameters, commandType: CommandType.StoredProcedure);
            }

            result = parameters.Get<string>("Numero");

            return result;
        }


        public IEnumerable<CorrelativoPlanta> ObtenerCorrelativoPlanta(string codigoTipo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CodigoTipo", codigoTipo);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<CorrelativoPlanta>("uspObtenerCorrelativoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<CorrelativoPlanta> ObtenerTipoCorrelativoPlanta()
        {
            var parameters = new DynamicParameters();
       


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<CorrelativoPlanta>("uspObtenerTipoCorrelativoPlanta", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        ////metodo de  maestro correlativo//////////////////////////////////////

        public IEnumerable<CorrelativoPlantaBE> ConsultarCorrelativo(ConsultaCorrelativoPlantaRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("campanhnia", request.campanhnia);
            parameters.Add("Codigotipo", request.Codigotipo);
            parameters.Add("CodigoConcepto", request.CodigoConcepto);
            parameters.Add("Activo", request.Activo);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<CorrelativoPlantaBE>("uspCorrelativoplantaConsulta", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        public int InsertarCorrelativo(CorrelativoPlanta correlativoPlanta)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@Campanha", correlativoPlanta.Campanha);
            parameters.Add("@CodigoTipo", correlativoPlanta.CodigoTipo);
            parameters.Add("@CodigoTipoConcepto", correlativoPlanta.CodigoTipoConcepto);
            parameters.Add("@CantidadDigitosPlanta", correlativoPlanta.CantidadDigitosPlanta);
            parameters.Add("@Prefijo", correlativoPlanta.Prefijo);
            parameters.Add("@Contador", correlativoPlanta.Contador);
            parameters.Add("@Tipo", correlativoPlanta.Tipo);
            parameters.Add("@Concepto", correlativoPlanta.Concepto);
            parameters.Add("@Activo", true);




            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspCorrelativoplantaInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }


        public int ActualizarCorrelativo(CorrelativoPlanta correlativoPlanta)
        {
            int result = 0;


            var parameters = new DynamicParameters();
            parameters.Add("@CorrelativoPlantaId", correlativoPlanta.CorrelativoPlantaId);
            parameters.Add("@Campanha", correlativoPlanta.Campanha);
            parameters.Add("@CodigoTipo", correlativoPlanta.CodigoTipo);
            parameters.Add("@CodigoTipoConcepto", correlativoPlanta.CodigoTipoConcepto);
            parameters.Add("@CantidadDigitosPlanta", correlativoPlanta.CantidadDigitosPlanta);
            parameters.Add("@Prefijo", correlativoPlanta.Prefijo);
            parameters.Add("@Contador", correlativoPlanta.Contador);
            parameters.Add("@Tipo", correlativoPlanta.Tipo);
            parameters.Add("@Concepto", correlativoPlanta.Concepto);
            parameters.Add("@Activo", correlativoPlanta.Activo);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspCorrelativoplantaActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }


        public CorrelativoPlantaBE ConsultarCorrelativoPlantaPorId(int CorrelativoPlantaId)
        {
            CorrelativoPlantaBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@CorrelativoPlantaId ", CorrelativoPlantaId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<CorrelativoPlantaBE>("uspCorrelativoplantaConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

    }
}
