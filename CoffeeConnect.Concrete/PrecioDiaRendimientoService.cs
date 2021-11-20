using AutoMapper;
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Service
{
    public class PrecioDiaRendimientoService: IPrecioDiaRendimientoService
    {
        private readonly IMapper _Mapper;
        private IPrecioDiaRendimientoRepository _IPrecioDiaRendimientoRepository;
        private ITipoCambioDiaRepository _ITipoCambioDiaRepository;
        private IMaestroRepository _IMaestroRepository;

        

        private IContratoRepository _IContratoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public PrecioDiaRendimientoService(IPrecioDiaRendimientoRepository PrecioDiaRendimientoRepository, IMaestroRepository MaestroRepository,  IContratoRepository ContratoRepository, ICorrelativoRepository correlativoRepository, ITipoCambioDiaRepository TipoCambioDiaRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IPrecioDiaRendimientoRepository = PrecioDiaRendimientoRepository;
            _IContratoRepository = ContratoRepository;
            _ITipoCambioDiaRepository = TipoCambioDiaRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _IMaestroRepository = MaestroRepository;
            _Mapper = mapper;
        }

        public int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request)
        {
            int id = 0;
            request.FechaRegistro = DateTime.Now;
            id = _IPrecioDiaRendimientoRepository.RegistrarPrecioDiaRendimiento(request);

            request.PrecioDiaRendimientoId = id;
            _IPrecioDiaRendimientoRepository.RegistrarPrecioDiaRendimientoDetalle(request);

            return id;
        }

        public int ActualizarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request)
        {
            int id = 0;
            request.FechaRegistro = DateTime.Now;
            _IPrecioDiaRendimientoRepository.ActualizarPrecioDiaRendimiento(request);


            id = _IPrecioDiaRendimientoRepository.RegistrarPrecioDiaRendimientoDetalle(request);

            return id;
        }

        public List<ConsultaPrecioDiaRendimientoBE> ConsultarPrecioDiaRendimiento(ConsultarPrecioDiaRendimientoRequestDTO request)
        {
            var list = _IPrecioDiaRendimientoRepository.ConsultarPrecioDiaRendimiento(request);
            return list.ToList();
        }

        public int AnularPrecioDiaRendimiento(AnularPrecioDiaRendimientoRequestDTO request)
        {
            int result = 0;
            if (request.PrecioDiaRendimientoId > 0)
            {

                result = _IPrecioDiaRendimientoRepository.Anular(request.PrecioDiaRendimientoId, DateTime.Now, request.Usuario, PrecioDiaRendimientoEstados.Anulado);
            }
            return result;
        }

        public CalculoPrecioDiaRendimientoDTO CalcularPrecioDiaRendimiento(CalcularPrecioDiaRendimientoRequestDTO request)
        {
            CalculoPrecioDiaRendimientoDTO calculoPrecioDiaRendimientoDTO = new CalculoPrecioDiaRendimientoDTO();
                        
            decimal precioPromedio = _IContratoRepository.CalcularPrecioDiaContrato(request.EmpresaId);

            calculoPrecioDiaRendimientoDTO.PrecioPromedioContrato = Math.Round(precioPromedio,2);

            decimal tipoCambio = _ITipoCambioDiaRepository.ObtenerTipoCambioDia(request.EmpresaId);


            calculoPrecioDiaRendimientoDTO.TipoCambio = tipoCambio;

            List<CalculoPrecioDiaRendimientoBE> precios = new List<CalculoPrecioDiaRendimientoBE>();

            int valorConstante = 46;

            string monedaId = "01"; 
            

            if (monedaId!="01")
            {
                tipoCambio = 1;

            }

            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId,"ES").ToList();

            lista = lista.Where(a => a.CodigoTabla.Equals("RangoPreciosCafePergamino")).ToList();

            foreach(ConsultaDetalleTablaBE rangoPrecio in lista)
            {
                if(!string.IsNullOrEmpty(rangoPrecio.Val1) && !string.IsNullOrEmpty(rangoPrecio.Val2))
                {
                    CalculoPrecioDiaRendimientoBE precio = new CalculoPrecioDiaRendimientoBE();
                    precio.RendimientoInicio = Convert.ToDecimal(rangoPrecio.Val1);
                    precio.RendimientoFin = Convert.ToDecimal(rangoPrecio.Val2);
                    precio.KGPergamino = Math.Round(valorConstante / (precio.RendimientoInicio / 100), 2);
                    precio.PrecioDia = Math.Round((precioPromedio / precio.KGPergamino) * tipoCambio, 2);
                    precio.MonedaId = monedaId;
                    
                    precios.Add(precio);

                }
            }



            //CalculoPrecioDiaRendimientoBE precio1 = new CalculoPrecioDiaRendimientoBE();                 
            //precio1.RendimientoInicio = 64.00M;
            //precio1.RendimientoFin = 65.99M;
            //precio1.KGPergamino = Math.Round(valorConstante /(precio1.RendimientoInicio/100), 2);
            //precio1.PrecioDia = Math.Round((precioPromedio / precio1.KGPergamino)*tipoCambio, 2);
            //precio1.MonedaId = monedaId;

            //CalculoPrecioDiaRendimientoBE precio2 = new CalculoPrecioDiaRendimientoBE();
            //precio2.RendimientoInicio = 66.00M;
            //precio2.RendimientoFin = 67.99M;     
            //precio2.KGPergamino = Math.Round(valorConstante / (precio2.RendimientoInicio / 100),2);
            //precio2.PrecioDia = Math.Round((precioPromedio / precio2.KGPergamino)* tipoCambio, 2);
            //precio2.MonedaId = monedaId;



            //CalculoPrecioDiaRendimientoBE precio3 = new CalculoPrecioDiaRendimientoBE();           
            //precio3.RendimientoInicio = 68.00M;
            //precio3.RendimientoFin = 69.99M;
            //precio3.KGPergamino = Math.Round(valorConstante / (precio3.RendimientoInicio / 100), 2);
            //precio3.PrecioDia = Math.Round((precioPromedio / precio3.KGPergamino) * tipoCambio, 2);
            //precio3.MonedaId = monedaId;


            //CalculoPrecioDiaRendimientoBE precio4 = new CalculoPrecioDiaRendimientoBE();         
            //precio4.RendimientoInicio = 70.00M;
            //precio4.RendimientoFin = 71.99M;
            //precio4.KGPergamino = Math.Round(valorConstante / (precio4.RendimientoInicio / 100), 2);
            //precio4.PrecioDia = Math.Round((precioPromedio / precio4.KGPergamino) * tipoCambio, 2);
            //precio4.MonedaId = monedaId;

            //CalculoPrecioDiaRendimientoBE precio5 = new CalculoPrecioDiaRendimientoBE();
            //precio5.RendimientoInicio = 72.00M;
            //precio5.RendimientoFin = 73.99M;
            //precio5.KGPergamino = Math.Round(valorConstante / (precio5.RendimientoInicio / 100), 2);
            //precio5.PrecioDia = Math.Round((precioPromedio / precio5.KGPergamino) * tipoCambio, 2);
            //precio5.MonedaId = monedaId;



            //CalculoPrecioDiaRendimientoBE precio6 = new CalculoPrecioDiaRendimientoBE();        
            //precio6.RendimientoInicio = 74.00M;
            //precio6.RendimientoFin = 75.99M;
            //precio6.KGPergamino = Math.Round(valorConstante / (precio6.RendimientoInicio / 100), 2);
            //precio6.PrecioDia = Math.Round((precioPromedio / precio6.KGPergamino) * tipoCambio, 2);
            //precio6.MonedaId = monedaId;


            //CalculoPrecioDiaRendimientoBE precio7 = new CalculoPrecioDiaRendimientoBE();         
            //precio7.RendimientoInicio = 76.00M;
            //precio7.RendimientoFin = 77.99M;
            //precio7.KGPergamino = Math.Round(valorConstante / (precio7.RendimientoInicio / 100), 2);
            //precio7.PrecioDia = Math.Round((precioPromedio / precio7.KGPergamino) * tipoCambio, 2);
            //precio7.MonedaId = monedaId;


            //CalculoPrecioDiaRendimientoBE precio8 = new CalculoPrecioDiaRendimientoBE();     
            //precio8.RendimientoInicio = 78.00M;
            //precio8.RendimientoFin = 79.99M;
            //precio8.KGPergamino = Math.Round(valorConstante / (precio8.RendimientoInicio / 100), 2);
            //precio8.PrecioDia = Math.Round((precioPromedio / precio8.KGPergamino) * tipoCambio, 2);
            //precio8.MonedaId = monedaId;


            //CalculoPrecioDiaRendimientoBE precio9 = new CalculoPrecioDiaRendimientoBE();
      
            //precio9.RendimientoInicio = 80.00M;
            //precio9.RendimientoFin = 80.00M;
            //precio9.KGPergamino = Math.Round(valorConstante / (precio9.RendimientoInicio / 100), 2);
            //precio9.PrecioDia = Math.Round((precioPromedio / precio9.KGPergamino) * tipoCambio, 2);
            //precio9.MonedaId = monedaId;


            //precios.Add(precio1);
            //precios.Add(precio2);
            //precios.Add(precio3);
            //precios.Add(precio4);
            //precios.Add(precio5);
            //precios.Add(precio6);
            //precios.Add(precio7);
            //precios.Add(precio8);
            //precios.Add(precio9);

            calculoPrecioDiaRendimientoDTO.CalculoPrecioDiaRendimiento = precios;
          

            return calculoPrecioDiaRendimientoDTO;
        }

        public List<PorcentajeRendimientoBE> ConsultarPorcentajeRendimiento(CalcularPrecioDiaRendimientoRequestDTO request)
        {    
            List<PorcentajeRendimientoBE> rendimientos = new List<PorcentajeRendimientoBE>();

            int valorConstante = 46;


            List<ConsultaDetalleTablaBE> lista = _IMaestroRepository.ConsultarDetalleTablaDeTablas(request.EmpresaId, String.Empty).ToList();

            lista = lista.Where(a => a.CodigoTabla.Equals("RangoPreciosCafePergamino")).ToList();

            foreach (ConsultaDetalleTablaBE rangoPrecio in lista)
            {
                if (!string.IsNullOrEmpty(rangoPrecio.Val1) && !string.IsNullOrEmpty(rangoPrecio.Val2))
                {
                    PorcentajeRendimientoBE rendimiento = new PorcentajeRendimientoBE();
                    rendimiento.RendimientoInicio = Convert.ToDecimal(rangoPrecio.Val1);
                    rendimiento.RendimientoFin = Convert.ToDecimal(rangoPrecio.Val2);
                    rendimiento.KGPergamino = Math.Round(valorConstante / (rendimiento.RendimientoInicio / 100), 2);

                    rendimientos.Add(rendimiento);
                }
            }


            //PorcentajeRendimientoBE rendimiento1 = new PorcentajeRendimientoBE();
            //rendimiento1.RendimientoInicio = 64.00M;
            //rendimiento1.RendimientoFin = 65.99M;
            //rendimiento1.KGPergamino = Math.Round(valorConstante / (rendimiento1.RendimientoInicio / 100), 2);


            //PorcentajeRendimientoBE rendimiento2 = new PorcentajeRendimientoBE();
            //rendimiento2.RendimientoInicio = 66.00M;
            //rendimiento2.RendimientoFin = 67.99M;          
            //rendimiento2.KGPergamino = Math.Round(valorConstante / (rendimiento2.RendimientoInicio / 100), 2);

            //PorcentajeRendimientoBE rendimiento3 = new PorcentajeRendimientoBE();
            //rendimiento3.RendimientoInicio = 68.00M;
            //rendimiento3.RendimientoFin = 69.99M;
            //rendimiento3.KGPergamino = Math.Round(valorConstante / (rendimiento3.RendimientoInicio / 100), 2);

            //PorcentajeRendimientoBE rendimiento4 = new PorcentajeRendimientoBE();
            //rendimiento4.RendimientoInicio = 70.00M;
            //rendimiento4.RendimientoFin = 71.99M;
            //rendimiento4.KGPergamino = Math.Round(valorConstante / (rendimiento4.RendimientoInicio / 100), 2);


            //PorcentajeRendimientoBE rendimiento5 = new PorcentajeRendimientoBE();
            //rendimiento5.RendimientoInicio = 72.00M;
            //rendimiento5.RendimientoFin = 73.99M;
            //rendimiento5.KGPergamino = Math.Round(valorConstante / (rendimiento5.RendimientoInicio / 100), 2);


            //PorcentajeRendimientoBE rendimiento6 = new PorcentajeRendimientoBE();
            //rendimiento6.RendimientoInicio = 74.00M;
            //rendimiento6.RendimientoFin = 75.99M;
            //rendimiento6.KGPergamino = Math.Round(valorConstante / (rendimiento6.RendimientoInicio / 100), 2);




            //PorcentajeRendimientoBE rendimiento7 = new PorcentajeRendimientoBE();
            //rendimiento7.RendimientoInicio = 76.00M;
            //rendimiento7.RendimientoFin = 77.99M;
            //rendimiento7.KGPergamino = Math.Round(valorConstante / (rendimiento7.RendimientoInicio / 100), 2);


            //PorcentajeRendimientoBE rendimiento8 = new PorcentajeRendimientoBE();
            //rendimiento8.RendimientoInicio = 78.00M;
            //rendimiento8.RendimientoFin = 79.99M;
            //rendimiento8.KGPergamino = Math.Round(valorConstante / (rendimiento8.RendimientoInicio / 100), 2);

            //PorcentajeRendimientoBE rendimiento9 = new PorcentajeRendimientoBE();

            //rendimiento9.RendimientoInicio = 80.00M;
            //rendimiento9.RendimientoFin = 80.00M;
            //rendimiento9.KGPergamino = Math.Round(valorConstante / (rendimiento9.RendimientoInicio / 100), 2);



            //rendimientos.Add(rendimiento1);
            //rendimientos.Add(rendimiento2);
            //rendimientos.Add(rendimiento3);
            //rendimientos.Add(rendimiento4);
            //rendimientos.Add(rendimiento5);
            //rendimientos.Add(rendimiento6);
            //rendimientos.Add(rendimiento7);
            //rendimientos.Add(rendimiento8);
            //rendimientos.Add(rendimiento9);

        


            return rendimientos;
        }


        public ConsultaPrecioDiaRendimientoBE ConsultarPrecioDiaRendimientoPorId(ConsultaPrecioDiaRendimientoPorIdRequestDTO request)
        {
            ConsultaPrecioDiaRendimientoBE consultaPrecioDiaRendimientoBE = new ConsultaPrecioDiaRendimientoBE();

            consultaPrecioDiaRendimientoBE = _IPrecioDiaRendimientoRepository.ConsultarPrecioDiaRendimientoPorId(request.PrecioDiaRendimientoId);


            consultaPrecioDiaRendimientoBE.PrecioDiaRendimientoDetalle =_IPrecioDiaRendimientoRepository.ConsultarPrecioDiaRendimientoDetallePorId(request.PrecioDiaRendimientoId).ToList();
                    

            return consultaPrecioDiaRendimientoBE;
        }

    }
}
