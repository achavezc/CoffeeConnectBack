﻿using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{   

    public class ActualizarNotaIngresoAlmacenPlantaResponseDTO
    {
        public ActualizarNotaIngresoAlmacenPlantaResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}