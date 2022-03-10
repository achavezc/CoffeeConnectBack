using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO.Anticipo
{
    public class AsociarAnticipoRequestDTO
    {
        public List<TablaIdsTipo> NotasIngresoPlantaId { get; set; }

        public int AnticipoId { get; set; }

        public String Usuario { get; set; }
       
    }
}
