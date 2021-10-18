using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConnect.Service
{
    public class KardexProcesoService : IKardexProcesoService
    {
        private IKardexProcesoRepository _IKardexProcesoRepository;

        public List<ConsultaKardexProcesoBE> ConsultarKardexProceso(ConsultaKardexProcesoRequestDTO request)
        {
            if (request.FechaInicio == null || request.FechaInicio == DateTime.MinValue || request.FechaFin == null || request.FechaFin == DateTime.MinValue)
                throw new ResultException(new Result { ErrCode = "01", Message = "Acopio.KardexProceso.ValidacionSeleccioneMinimoUnFiltro.Label" });

            var list = _IKardexProcesoRepository.ConsultarKardexProceso(request);

            return list.ToList();
        }
    }
}
