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
    public class UbigeoRepository : IUbigeoRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public UbigeoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaUbigeoBE> ConsultarUbigeoPorCodigoPais(ConsultaUbigeoPorCodigoPaisRequestDTO request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaId", request.EmpresaId);  
            parameters.Add("CodigoPais", request.CodigoPais);
           


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaUbigeoBE>("uspUbigeoConsultaPorCodigoPais", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        public int Insertar(Ubigeo ubigeo)
        {
            int result = 0;            

            var parameters = new DynamicParameters();

            
            parameters.Add("@Codigo", ubigeo.Codigo);
            parameters.Add("@Descripcion", ubigeo.Descripcion);
            parameters.Add("@UsuarioCreacion", ubigeo.UsuarioCreacion);
            parameters.Add("@FechaHoraCreacion", ubigeo.FechaHoraCreacion);          
            
            parameters.Add("@CodigoPais", ubigeo.CodigoPais);
            parameters.Add("@EmpresaId", ubigeo.EmpresaId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspUbigeoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }
            

            return result;
        }

        public int Actualizar(Ubigeo ubigeo)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@IdUbigeo", ubigeo.IdUbigeo);
            parameters.Add("@Codigo", ubigeo.Codigo);
            parameters.Add("@Descripcion", ubigeo.Descripcion);           
            parameters.Add("@UsuarioActualizacion", ubigeo.UsuarioActualizacion);
            parameters.Add("@FechaHoraActualizacion", ubigeo.FechaHoraActualizacion);
            parameters.Add("@EstadoRegistro", ubigeo.EstadoRegistro);
            parameters.Add("@CodigoPais", ubigeo.CodigoPais);
            parameters.Add("@EmpresaId", ubigeo.EmpresaId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspUbigeoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaUbigeoPorIdBE ConsultarUbigeoPorId(int UbigeoId)
        {
            ConsultaUbigeoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@IdUbigeo", UbigeoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaUbigeoPorIdBE>("uspUbigeoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
