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
        private IContratoRepository _IContratoRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public PrecioDiaRendimientoService(IPrecioDiaRendimientoRepository PrecioDiaRendimientoRepository, IContratoRepository ContratoRepository, ICorrelativoRepository correlativoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IPrecioDiaRendimientoRepository = PrecioDiaRendimientoRepository;
            _IContratoRepository = ContratoRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _Mapper = mapper;
        }

        public int RegistrarPrecioDiaRendimiento(RegistrarActualizarPrecioDiaRendimientoRequestDTO request)
        {
            int id = 0;
            request.FechaRegistro = DateTime.Now;
            id = _IPrecioDiaRendimientoRepository.RegistrarPrecioDiaRendimiento(request);
            return id;
        }

        public List<ConsultaPrecioDiaRendimientoBE> ConsultaPrecioDiaRendimiento(ConsultarPrecioDiaRendimientoRequestDTO request)
        {
            var list = _IPrecioDiaRendimientoRepository.ConsultaPrecioDiaRendimiento(request);
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
                        
            double precioPromedio = _IContratoRepository.CalcularPrecioDiaContrato(request.EmpresaId);

            calculoPrecioDiaRendimientoDTO.PrecioPromedioContrato = precioPromedio;

            calculoPrecioDiaRendimientoDTO.TipoCambio = 4.1;

            List<CalculoPrecioDiaRendimientoBE> precios = new List<CalculoPrecioDiaRendimientoBE>();

            int valorConstante = 46;

            CalculoPrecioDiaRendimientoBE precio1 = new CalculoPrecioDiaRendimientoBE();                 
            precio1.RendimientoInicio = 64;
            precio1.RendimientoFin = 65.99;
            precio1.KGPergamino = valorConstante/(precio1.RendimientoInicio/100);
            precio1.PrecioDia = precioPromedio / precio1.KGPergamino;

            CalculoPrecioDiaRendimientoBE precio2 = new CalculoPrecioDiaRendimientoBE();
            precio2.RendimientoInicio = 66;
            precio2.RendimientoFin = 67.99;
            precio2.KGPergamino = valorConstante / (precio2.RendimientoInicio / 100);
            precio2.PrecioDia = precioPromedio / precio2.KGPergamino;

            CalculoPrecioDiaRendimientoBE precio3 = new CalculoPrecioDiaRendimientoBE();           
            precio3.RendimientoInicio = 68;
            precio3.RendimientoFin = 69.99;
            precio3.KGPergamino = valorConstante / (precio3.RendimientoInicio / 100);
            precio3.PrecioDia = precioPromedio / precio3.KGPergamino;



            CalculoPrecioDiaRendimientoBE precio4 = new CalculoPrecioDiaRendimientoBE();         
            precio4.RendimientoInicio = 70;
            precio4.RendimientoFin = 71.99;
            precio4.KGPergamino = valorConstante / (precio4.RendimientoInicio / 100);
            precio4.PrecioDia = precioPromedio / precio4.KGPergamino;


            CalculoPrecioDiaRendimientoBE precio5 = new CalculoPrecioDiaRendimientoBE();
            precio5.RendimientoInicio = 72;
            precio5.RendimientoFin = 73.99;
            precio5.KGPergamino = valorConstante / (precio5.RendimientoInicio / 100);
            precio5.PrecioDia = precioPromedio / precio5.KGPergamino;

            CalculoPrecioDiaRendimientoBE precio6 = new CalculoPrecioDiaRendimientoBE();        
            precio6.RendimientoInicio = 74;
            precio6.RendimientoFin = 75.99;
            precio6.KGPergamino = valorConstante / (precio6.RendimientoInicio / 100);
            precio6.PrecioDia = precioPromedio / precio6.KGPergamino;



            CalculoPrecioDiaRendimientoBE precio7 = new CalculoPrecioDiaRendimientoBE();         
            precio7.RendimientoInicio = 76;
            precio7.RendimientoFin = 77.99;
            precio7.KGPergamino = valorConstante / (precio7.RendimientoInicio / 100);
            precio7.PrecioDia = precioPromedio / precio7.KGPergamino;

            CalculoPrecioDiaRendimientoBE precio8 = new CalculoPrecioDiaRendimientoBE();     
            precio8.RendimientoInicio = 78;
            precio8.RendimientoFin = 79.99;
            precio8.KGPergamino = valorConstante / (precio8.RendimientoInicio / 100);
            precio8.PrecioDia = precioPromedio / precio8.KGPergamino;

            CalculoPrecioDiaRendimientoBE precio9 = new CalculoPrecioDiaRendimientoBE();
      
            precio9.RendimientoInicio = 80;
            precio9.RendimientoFin = 80;
            precio9.KGPergamino = valorConstante / (precio9.RendimientoInicio / 100);
            precio9.PrecioDia = precioPromedio / precio9.KGPergamino;



            precios.Add(precio1);
            precios.Add(precio2);
            precios.Add(precio3);
            precios.Add(precio4);
            precios.Add(precio5);
            precios.Add(precio6);
            precios.Add(precio7);
            precios.Add(precio8);
            precios.Add(precio9);

            calculoPrecioDiaRendimientoDTO.CalculoPrecioDiaRendimiento = precios;
          

            return calculoPrecioDiaRendimientoDTO;
        }

    }
}
