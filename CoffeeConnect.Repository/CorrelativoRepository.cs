﻿using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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


    }
}
