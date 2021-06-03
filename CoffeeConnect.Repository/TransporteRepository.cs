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
    public class TransporteRepository : ITransporteRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public TransporteRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ConsultaTransportePorEmpresaTransporteId> ConsultarTransportePorEmpresaTransporteId(int empresaTransporteId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmpresaTransporteId", empresaTransporteId);     

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaTransportePorEmpresaTransporteId>("uspTransporteConsultaPorEmpresaTransporteId", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        


        public int Insertar(Transporte transporte)
        {
            int result = 0;

            var parameters = new DynamicParameters();
           
            parameters.Add("@EmpresaTransporteId", transporte.EmpresaTransporteId);
            parameters.Add("@NumeroConstanciaMTC", transporte.NumeroConstanciaMTC);
            parameters.Add("@MarcaTractorId", transporte.MarcaTractorId);
            parameters.Add("@PlacaTractor", transporte.PlacaTractor);
            parameters.Add("@MarcaCarretaId", transporte.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", transporte.PlacaCarreta);
            parameters.Add("@ConfiguracionVehicularId", transporte.ConfiguracionVehicularId);
            parameters.Add("@Propietario", transporte.Propietario);
            parameters.Add("@Conductor", transporte.Conductor);
            parameters.Add("@Color", transporte.Color);
            parameters.Add("@Soat", transporte.Soat);
            parameters.Add("@Dni", transporte.Dni);
            parameters.Add("@Licencia", transporte.Licencia);
            parameters.Add("@NroCelular", transporte.NroCelular);
            parameters.Add("@PesoBruto", transporte.PesoBruto);
            parameters.Add("@PesoNeto", transporte.PesoNeto);
            parameters.Add("@CargaUtil", transporte.CargaUtil);
            parameters.Add("@Longitud", transporte.Longitud);
            parameters.Add("@Altura", transporte.Altura);
            parameters.Add("@Ancho", transporte.Ancho);
            parameters.Add("@EstadoId", transporte.EstadoId);           
            parameters.Add("@FechaRegistro", transporte.FechaRegistro);
            parameters.Add("@UsuarioRegistro", transporte.UsuarioRegistro);
           



            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspTransporteInsertar", parameters, commandType: CommandType.StoredProcedure);
            }


            return result;
        }

        public int Actualizar(Transporte transporte)
        {
            int result = 0;


            var parameters = new DynamicParameters();
            parameters.Add("@TransporteId", transporte.TransporteId);
            parameters.Add("@EmpresaTransporteId", transporte.EmpresaTransporteId);
            parameters.Add("@NumeroConstanciaMTC", transporte.NumeroConstanciaMTC);
            parameters.Add("@MarcaTractorId", transporte.MarcaTractorId);
            parameters.Add("@PlacaTractor", transporte.PlacaTractor);
            parameters.Add("@MarcaCarretaId", transporte.MarcaCarretaId);
            parameters.Add("@PlacaCarreta", transporte.PlacaCarreta);
            parameters.Add("@ConfiguracionVehicularId", transporte.ConfiguracionVehicularId);
            parameters.Add("@Propietario", transporte.Propietario);
            parameters.Add("@Conductor", transporte.Conductor);
            parameters.Add("@Color", transporte.Color);
            parameters.Add("@Soat", transporte.Soat);
            parameters.Add("@Dni", transporte.Dni);
            parameters.Add("@Licencia", transporte.Licencia);
            parameters.Add("@NroCelular", transporte.NroCelular);
            parameters.Add("@PesoBruto", transporte.PesoBruto);
            parameters.Add("@PesoNeto", transporte.PesoNeto);
            parameters.Add("@CargaUtil", transporte.CargaUtil);
            parameters.Add("@Longitud", transporte.Longitud);
            parameters.Add("@Altura", transporte.Altura);
            parameters.Add("@Ancho", transporte.Ancho);
            parameters.Add("@EstadoId", transporte.EstadoId);            
            parameters.Add("@FechaUltimaActualizacion", transporte.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", transporte.UsuarioUltimaActualizacion);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspTransporteActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public ConsultaTransportePorIdBE ConsultarTransportePorId(int transporteId)
        {
            ConsultaTransportePorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@TransporteId", transporteId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaTransportePorIdBE>("uspTransporteConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }


    }
}
