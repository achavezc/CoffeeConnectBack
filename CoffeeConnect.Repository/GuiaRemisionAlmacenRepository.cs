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
using Core.Common;

namespace CoffeeConnect.Repository
{
    public class GuiaRemisionAlmacenRepository : IGuiaRemisionAlmacenRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public GuiaRemisionAlmacenRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }


        public int ActualizarGuiaRemisionAlmacen(GuiaRemisionAlmacen guiaRemisionAlmacen)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            
            parameters.Add("@NotaSalidaAlmacenId", guiaRemisionAlmacen.NotaSalidaAlmacenId);
            parameters.Add("@Numero", guiaRemisionAlmacen.Numero);
            parameters.Add("@EmpresaId", guiaRemisionAlmacen.EmpresaId);
            parameters.Add("@AlmacenId", guiaRemisionAlmacen.AlmacenId);
            parameters.Add("@MotivoTrasladoId", guiaRemisionAlmacen.MotivoTrasladoId);
            parameters.Add("@MotivoTrasladoReferencia", guiaRemisionAlmacen.MotivoTrasladoReferencia);
            parameters.Add("@EmpresaIdDestino", guiaRemisionAlmacen.EmpresaIdDestino);
            parameters.Add("@EmpresaTransporteId", guiaRemisionAlmacen.EmpresaTransporteId);
            parameters.Add("@TransporteId", guiaRemisionAlmacen.TransporteId);
            parameters.Add("@MarcaTractorId", guiaRemisionAlmacen.MarcaTractorId);
            parameters.Add("@PlacaTractor", guiaRemisionAlmacen.PlacaTractor);
            parameters.Add("@MarcaCarretaId", guiaRemisionAlmacen.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", guiaRemisionAlmacen.PlacaCarreta);
            parameters.Add("@Conductor", guiaRemisionAlmacen.Conductor);
            parameters.Add("@Licencia", guiaRemisionAlmacen.Licencia);
            parameters.Add("@CantidadLotes", guiaRemisionAlmacen.CantidadLotes);
            parameters.Add("@PromedioPorcentajeRendimiento", guiaRemisionAlmacen.PromedioPorcentajeRendimiento);
            parameters.Add("@CantidadTotal", guiaRemisionAlmacen.CantidadTotal);
            parameters.Add("@PesoKilosBrutos", guiaRemisionAlmacen.PesoKilosBrutos);
            parameters.Add("@EstadoId", guiaRemisionAlmacen.EstadoId);
            parameters.Add("@FechaRegistro", guiaRemisionAlmacen.FechaRegistro);
            parameters.Add("@UsuarioRegistro", guiaRemisionAlmacen.UsuarioRegistro);
            
            parameters.Add("@GuiaRemisionId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRemisionAlmacenInsertarActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            result = parameters.Get<int>("GuiaRemisionId");


            return result;
        }

        public int ActualizarGuiaRemisionAlmacenDetalle(List<GuiaRemisionAlmacenDetalleTipo> guiaRemisionAlmacenDetalle)
        {
            int result = 0;

            var parameters = new DynamicParameters();

            parameters.Add("@GuiaRemisionAlmacenDetalle", guiaRemisionAlmacenDetalle.ToDataTable().AsTableValuedParameter());

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspGuiaRemisionAlmacenDetalleActualizar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public ConsultaGuiaRemisionAlmacen ConsultaGuiaRemisionAlmacenPorNotaSalidaAlmacenId(int notaSalidaAlmacenId)
        {
            ConsultaGuiaRemisionAlmacen itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@NotaSalidaAlmacenId", notaSalidaAlmacenId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaGuiaRemisionAlmacen>("uspGuiaRemisionAlacenConsultaIdNotaSalida", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public IEnumerable<ConsultaGuiaRemisionAlmacenDetalle> ConsultaGuiaRemisionAlmacenDetallePorGuiaRemisionAlmacenId(int guiaRemisionAlmacenId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GuiaRemisionAlmacenId", guiaRemisionAlmacenId);



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaGuiaRemisionAlmacenDetalle>("uspGuiaAlmacenDetalleConsultaPorIdGuia", parameters, commandType: CommandType.StoredProcedure);
            }
        }



    }



}
