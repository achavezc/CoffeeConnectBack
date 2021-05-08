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
    public class SocioProyectoRepository : ISocioProyectoRepository
    {
        private IOptions<ConnectionString> _connectionString;

        public SocioProyectoRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public int Actualizar(SocioProyecto socioProyecto)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioProyectoId", socioProyecto.SocioProyectoId);
            parameters.Add("@SocioId", socioProyecto.SocioId);
            parameters.Add("@EmpresaId", socioProyecto.EmpresaId);
            parameters.Add("@OrganizacionProyectoAnterior", socioProyecto.OrganizacionProyectoAnterior);
            parameters.Add("@ProyectoId", socioProyecto.ProyectoId);
            parameters.Add("@MonedaId", socioProyecto.MonedaId);
            parameters.Add("@Monto", socioProyecto.Monto);
            parameters.Add("@PeriodoDesde", socioProyecto.PeriodoDesde);
            parameters.Add("@PeriodoHasta", socioProyecto.PeriodoHasta);
            parameters.Add("@CantidadHectareas", socioProyecto.CantidadHectareas);
            parameters.Add("@MontoPrimerDesembolso", socioProyecto.MontoPrimerDesembolso);
            parameters.Add("@FechaInicioPrimerDesembolso", socioProyecto.FechaInicioPrimerDesembolso);
            parameters.Add("@FechaFinPrimerDesembolso", socioProyecto.FechaFinPrimerDesembolso);
            parameters.Add("@MontoSegundoDesembolso", socioProyecto.MontoSegundoDesembolso);
            parameters.Add("@FechaInicioSegundoDesembolso", socioProyecto.FechaInicioSegundoDesembolso);
            parameters.Add("@FechaFinSegundoDesembolso", socioProyecto.FechaFinSegundoDesembolso);
            parameters.Add("@Cobrado", socioProyecto.CobradoPrimerDesembolso);
            parameters.Add("@FechaCobro", socioProyecto.FechaCobroPrimerDesembolso);
            parameters.Add("@Cobrado2", socioProyecto.CobradoSegundoDesembolso);
            parameters.Add("@FechaCobro2", socioProyecto.FechaCobroSegundoDesembolso);
            parameters.Add("@UnidadMedidaId", socioProyecto.UnidadMedidaId);
            parameters.Add("@TipoInsumoId", socioProyecto.TipoInsumoId);
            parameters.Add("@CantidadInsumo", socioProyecto.CantidadInsumo);
            parameters.Add("@CantidadInsumoEntregado", socioProyecto.CantidadInsumoEntregado);
            parameters.Add("@CantidadInsumoPedidoFinal", socioProyecto.CantidadInsumoPedidoFinal);
            parameters.Add("@ObservacionCapacitacion", socioProyecto.ObservacionCapacitacion);
            parameters.Add("@FechaInicioCapacitacion", socioProyecto.FechaInicioCapacitacion);
            parameters.Add("@FechaFinCapacitacion", socioProyecto.FechaFinCapacitacion);
            parameters.Add("@AdopcionTecnologias", socioProyecto.AdopcionTecnologias);
            parameters.Add("@Requisitos", socioProyecto.Requisitos);
            parameters.Add("@EstadoId", socioProyecto.EstadoId);
            parameters.Add("@FechaUltimaActualizacion", socioProyecto.FechaUltimaActualizacion);
            parameters.Add("@UsuarioUltimaActualizacion", socioProyecto.UsuarioUltimaActualizacion);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioProyectoActualizar", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public IEnumerable<ConsultaSocioProyectoPorSocioIdBE> ConsultarSocioProyectoPorSocioId(int socioId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SocioId", socioId);

            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                return db.Query<ConsultaSocioProyectoPorSocioIdBE>("uspSocioProyectoConsultaPorSocioId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultaSocioProyectoPorIdBE ConsultarSocioProyectoPorId(int socioProyectoId)
        {
            ConsultaSocioProyectoPorIdBE itemBE = null;

            var parameters = new DynamicParameters();
            parameters.Add("@SocioProyectoId", socioProyectoId);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                var list = db.Query<ConsultaSocioProyectoPorIdBE>("uspSocioProyectoConsultaPorId", parameters, commandType: CommandType.StoredProcedure);

                if (list.Any())
                    itemBE = list.First();
            }

            return itemBE;
        }

        public int Insertar(SocioProyecto socioProyecto)
        {
            int result = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@EmpresaId", socioProyecto.EmpresaId);
            parameters.Add("@OrganizacionProyectoAnterior", socioProyecto.OrganizacionProyectoAnterior);
            parameters.Add("@ProyectoId", socioProyecto.ProyectoId);
            parameters.Add("@SocioId", socioProyecto.SocioId);
            parameters.Add("@MonedaId", socioProyecto.MonedaId);
            parameters.Add("@Monto", socioProyecto.Monto);
            parameters.Add("@PeriodoDesde", socioProyecto.PeriodoDesde);
            parameters.Add("@PeriodoHasta", socioProyecto.PeriodoHasta);
            parameters.Add("@CantidadHectareas", socioProyecto.CantidadHectareas);
            parameters.Add("@MontoPrimerDesembolso", socioProyecto.MontoPrimerDesembolso);
            parameters.Add("@FechaInicioPrimerDesembolso", socioProyecto.FechaInicioPrimerDesembolso);
            parameters.Add("@FechaFinPrimerDesembolso", socioProyecto.FechaFinPrimerDesembolso);
            parameters.Add("@MontoSegundoDesembolso", socioProyecto.MontoSegundoDesembolso);
            parameters.Add("@FechaInicioSegundoDesembolso", socioProyecto.FechaInicioSegundoDesembolso);
            parameters.Add("@FechaFinSegundoDesembolso", socioProyecto.FechaFinSegundoDesembolso);
            parameters.Add("@Cobrado", socioProyecto.CobradoPrimerDesembolso);
            parameters.Add("@FechaCobro", socioProyecto.FechaCobroPrimerDesembolso);
            parameters.Add("@Cobrado2", socioProyecto.CobradoSegundoDesembolso);
            parameters.Add("@FechaCobro2", socioProyecto.FechaCobroSegundoDesembolso);
            parameters.Add("@UnidadMedidaId", socioProyecto.UnidadMedidaId);
            parameters.Add("@TipoInsumoId", socioProyecto.TipoInsumoId);
            parameters.Add("@CantidadInsumo", socioProyecto.CantidadInsumo);
            parameters.Add("@CantidadInsumoEntregado", socioProyecto.CantidadInsumoEntregado);
            parameters.Add("@CantidadInsumoPedidoFinal", socioProyecto.CantidadInsumoPedidoFinal);
            parameters.Add("@ObservacionCapacitacion", socioProyecto.ObservacionCapacitacion);
            parameters.Add("@FechaInicioCapacitacion", socioProyecto.FechaInicioCapacitacion);
            parameters.Add("@FechaFinCapacitacion", socioProyecto.FechaFinCapacitacion);
            parameters.Add("@AdopcionTecnologias", socioProyecto.AdopcionTecnologias);
            parameters.Add("@Requisitos", socioProyecto.Requisitos);
            parameters.Add("@EstadoId", socioProyecto.EstadoId);
            parameters.Add("@FechaRegistro", socioProyecto.FechaRegistro);
            parameters.Add("@UsuarioRegistro", socioProyecto.UsuarioRegistro);


            using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
            {
                result = db.Execute("uspSocioProyectoInsertar", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
