using CoffeeConnect.Models;
using System;
using System.Collections.Generic;

namespace CoffeeConnect.DTO
{
    public class AsociarAdelantoRequestDTO
    {
        public List<TablaIdsTipo> NotasCompraId { get; set; }

        public int AdelantoId { get; set; }

        public String Usuario { get; set; }
       
    }
}
