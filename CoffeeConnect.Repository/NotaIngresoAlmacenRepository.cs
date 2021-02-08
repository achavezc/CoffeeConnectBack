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
using CoffeeConnect.DTO;

namespace CoffeeConnect.Repository
{
	public class NotaIngresoAlmacenRepository : INotaIngresoAlmacenRepository
	{
		public IOptions<ConnectionString> _connectionString;
		public NotaIngresoAlmacenRepository(IOptions<ConnectionString> connectionString)
		{
			_connectionString = connectionString;
		}


		public int Insertar(NotaIngresoAlmacen notaIngresoAlmacen)
		{
			int result = 0;

			var parameters = new DynamicParameters();
			parameters.Add("@EmpresaId", notaIngresoAlmacen.EmpresaId);
			parameters.Add("@AlmacenId", notaIngresoAlmacen.AlmacenId);
			parameters.Add("@GuiaRecepcionMateriaPrimaId", notaIngresoAlmacen.GuiaRecepcionMateriaPrimaId);
			parameters.Add("@Numero", notaIngresoAlmacen.Numero);
			parameters.Add("@TipoProvedorId", notaIngresoAlmacen.TipoProvedorId);
			parameters.Add("@SocioId", notaIngresoAlmacen.SocioId);
			parameters.Add("@TerceroId", notaIngresoAlmacen.TerceroId);
			parameters.Add("@IntermediarioId", notaIngresoAlmacen.IntermediarioId);
			parameters.Add("@ProductoId", notaIngresoAlmacen.ProductoId);
			parameters.Add("@SubProductoId", notaIngresoAlmacen.SubProductoId);
			parameters.Add("@UnidadMedidaIdPesado", notaIngresoAlmacen.UnidadMedidaIdPesado);
			parameters.Add("@CantidadPesado", notaIngresoAlmacen.CantidadPesado);
			parameters.Add("@KilosBrutosPesado", notaIngresoAlmacen.KilosBrutosPesado);
			parameters.Add("@TaraPesado", notaIngresoAlmacen.TaraPesado);
			parameters.Add("@KilosNetosPesado", notaIngresoAlmacen.KilosNetosPesado);
			parameters.Add("@QQ55", notaIngresoAlmacen.QQ55);
			parameters.Add("@ExportableGramosAnalisisFisico", notaIngresoAlmacen.ExportableGramosAnalisisFisico);
			parameters.Add("@ExportablePorcentajeAnalisisFisico", notaIngresoAlmacen.ExportablePorcentajeAnalisisFisico);
			parameters.Add("@DescarteGramosAnalisisFisico", notaIngresoAlmacen.DescarteGramosAnalisisFisico);
			parameters.Add("@DescartePorcentajeAnalisisFisico", notaIngresoAlmacen.DescartePorcentajeAnalisisFisico);
			parameters.Add("@CascarillaGramosAnalisisFisico", notaIngresoAlmacen.CascarillaGramosAnalisisFisico);
			parameters.Add("@CascarillaPorcentajeAnalisisFisico", notaIngresoAlmacen.CascarillaPorcentajeAnalisisFisico);
			parameters.Add("@TotalGramosAnalisisFisico", notaIngresoAlmacen.TotalGramosAnalisisFisico);
			parameters.Add("@TotalPorcentajeAnalisisFisico", notaIngresoAlmacen.TotalPorcentajeAnalisisFisico);
			parameters.Add("@HumedadPorcentajeAnalisisFisico", notaIngresoAlmacen.HumedadPorcentajeAnalisisFisico);
			parameters.Add("@Observacion", notaIngresoAlmacen.Observacion);
			parameters.Add("@EstadoId", notaIngresoAlmacen.EstadoId);
			parameters.Add("@FechaRegistro", notaIngresoAlmacen.FechaRegistro);
			parameters.Add("@UsuarioRegistro", notaIngresoAlmacen.UsuarioRegistro);
			parameters.Add("@FechaUltimaActualizacion", notaIngresoAlmacen.FechaUltimaActualizacion);
			parameters.Add("@UsuarioUltimaActualizacion", notaIngresoAlmacen.UsuarioUltimaActualizacion);
			parameters.Add("@Activo", notaIngresoAlmacen.Activo);



			using (IDbConnection db = new SqlConnection(_connectionString.Value.CoffeeConnectDB))
			{
				result = db.Execute("NotaIngresoAlmacenInsertar", parameters, commandType: CommandType.StoredProcedure);
			}

			return result;
		}
	}
}
