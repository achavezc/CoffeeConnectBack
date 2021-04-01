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
    public class SocioFincaCertificacionRepository : ISocioFincaCertificacionRepository
    {
        public IOptions<ConnectionString> _connectionString;
        public SocioFincaCertificacionRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }



        public int Insertar(SocioFincaCertificacion socioFincaCertificacion)
        {
            int result = 0;           

            var parameters = new DynamicParameters();
            
            parameters.Add("@SocioFincaId", socioFincaCertificacion.SocioFincaId);
            parameters.Add("@EntidadCertificadoraId", socioFincaCertificacion.EntidadCertificadoraId);
            parameters.Add("@TipoCertificacionId", socioFincaCertificacion.TipoCertificacionId);
            parameters.Add("@FechaCaducidad", socioFincaCertificacion.FechaCaducidad);
            parameters.Add("@FechaRegistro", socioFincaCertificacion.FechaRegistro);
            parameters.Add("@UsuarioRegistro", socioFincaCertificacion.UsuarioRegistro);           
            parameters.Add("@NombreArchivo", socioFincaCertificacion.NombreArchivo);
            parameters.Add("@DescripcionArchivo", socioFincaCertificacion.DescripcionArchivo);
            parameters.Add("@PathArchivo", socioFincaCertificacion.PathArchivo);
            parameters.Add("@EstadoId", socioFincaCertificacion.EstadoId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioFincaCertificacionInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public int Actualizar(SocioFincaCertificacion socioFincaCertificacion)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioFincaCertificacionId", socioFincaCertificacion.SocioFincaCertificacionId);
            parameters.Add("@SocioFincaId", socioFincaCertificacion.SocioFincaId);
            parameters.Add("@EntidadCertificadoraId", socioFincaCertificacion.EntidadCertificadoraId);
            parameters.Add("@TipoCertificacionId", socioFincaCertificacion.TipoCertificacionId);         
            parameters.Add("@FechaCaducidad", socioFincaCertificacion.FechaCaducidad);         
            parameters.Add("@FechaUltimaActualizacion", socioFincaCertificacion.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", socioFincaCertificacion.UsuarioUltimaActualizacion);
            parameters.Add("@NombreArchivo", socioFincaCertificacion.NombreArchivo);
            parameters.Add("@DescripcionArchivo", socioFincaCertificacion.DescripcionArchivo);
            parameters.Add("@PathArchivo", socioFincaCertificacion.PathArchivo);
            parameters.Add("@EstadoId", socioFincaCertificacion.EstadoId);      


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioFincaCertificacionActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }


        public IEnumerable<ConsultaSocioFincaCertificacionPorSocioFincaId> ConsultarSocioFincaCertificacionPorSocioFincaId(int socioFincaId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SocioFincaId", socioFincaId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaSocioFincaCertificacionPorSocioFincaId>("uspSocioFincaCertificacionConsultaPorSocioFincaId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaSocioFincaCertificacionPorId ConsultarSocioFincaCertificacionPorId(int socioFincaCertificacionId)
        {
            ConsultaSocioFincaCertificacionPorId itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioFincaCertificacionId", socioFincaCertificacionId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaSocioFincaCertificacionPorId>("uspSocioFincaCertificacionConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }
    }
}
