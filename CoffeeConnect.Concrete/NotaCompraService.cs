
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class NotaCompraService : INotaCompraService
    {
       
        private INotaCompraRepository _INotaCompraRepository;
       
        public NotaCompraService(INotaCompraRepository notaCompraRepository)
        {
            _INotaCompraRepository = notaCompraRepository;          
        }

       		
			
        
        public int RegistrarNotaCompra(RegistrarNotaCompraRequestDTO request)
        {
            NotaCompra notaCompra = new NotaCompra();

            notaCompra.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            notaCompra.EmpresaId = request.EmpresaId;
            notaCompra.Numero = request.Numero;
            notaCompra.UnidadMedidaIdPesado = request.UnidadMedidaIdPesado;
            notaCompra.CantidadPesado = request.CantidadPesado;
            notaCompra.KilosBrutosPesado = request.KilosBrutosPesado;
            notaCompra.TaraPesado = request.TaraPesado;
            notaCompra.KilosNetosPesado = request.KilosNetosPesado;
            notaCompra.DescuentoPorHumedad = request.DescuentoPorHumedad;
            notaCompra.KilosNetosDescontar = request.KilosNetosDescontar;
            notaCompra.KilosNetosPagar = request.KilosNetosPagar;
            notaCompra.QQ55 = request.QQ55;
            notaCompra.ExportableGramosAnalisisFisico = request.ExportableGramosAnalisisFisico;   
            notaCompra.DescarteGramosAnalisisFisico = request.DescarteGramosAnalisisFisico;
            notaCompra.CascarillaGramosAnalisisFisico = request.CascarillaGramosAnalisisFisico;
            notaCompra.TotalGramosAnalisisFisico = request.TotalGramosAnalisisFisico;
            notaCompra.HumedadPorcentajeAnalisisFisico = request.HumedadPorcentajeAnalisisFisico;
            notaCompra.TipoId = request.TipoId;
            notaCompra.PrecioDia = request.PrecioDia;
            notaCompra.Importe = request.Importe;
            notaCompra.EstadoId = NotaCompraEstados.PorLiquidar;          
            notaCompra.FechaRegistro = DateTime.Now;
            notaCompra.UsuarioRegistro = request.UsuarioNotaCompra;  

            int affected = _INotaCompraRepository.Insert(notaCompra);

            return affected;
        }


      
    }
}
