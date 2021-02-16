using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Models;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using Core.Utils;
using CoffeeConnect.DTO;

namespace CoffeeConnect.Repository
{
    public class LoteRepository : ILoteRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public LoteRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int Insertar(Lote lote)
        {
            int result = 0;

            var parameters = new DynamicParameters();       
           
            parameters.Add("@EmpresaId", lote.EmpresaId);
            parameters.Add("@Numero", lote.Numero);
            parameters.Add("@EstadoId", lote.EstadoId);
            parameters.Add("@AlmacenId", lote.AlmacenId);
            parameters.Add("@TotalKilosNetosPesado", lote.TotalKilosNetosPesado);
            parameters.Add("@PromedioRendimientoPorcentaje", lote.PromedioRendimientoPorcentaje);
            parameters.Add("@PromedioHumedadPorcentaje", lote.PromedioHumedadPorcentaje);
            parameters.Add("@FechaRegistro", lote.FechaRegistro);
            parameters.Add("@UsuarioRegistro", lote.UsuarioRegistro);        

            parameters.Add("@LoteId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            int id = parameters.Get<int>("LoteId");

            return id;
        }


        public int InsertarLoteDetalle(List<LoteDetalle> request)
        {
            //uspGuiaRecepcionMateriaPrimaAnalisisFisicoColorDetalleActualizar
            int result = 0;

            var parameters = new DynamicParameters();
                        
            parameters.Add("@LoteDetalleTipo", request.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspLoteDetalleInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }


}
