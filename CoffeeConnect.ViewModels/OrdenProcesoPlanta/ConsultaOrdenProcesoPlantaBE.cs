﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ConsultaOrdenProcesoPlantaBE
    {
        public ConsultaOrdenProcesoPlantaBE()
        {

        }

        public int? OrdenProcesoPlantaId { get; set; }
       
        public int EmpresaId { get; set; }
        public int OrganizacionId { get; set; }
        public string TipoProcesoId { get; set; }
        
        public string Numero { get; set; }
     

        public string RucOrganizacion { get; set; }

        public string RazonSocialOrganizacion { get; set; }
        public string TipoProceso { get; set; }
        public string EstadoId { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        /// <summary>
		/// Gets or sets the CantidadDefectos value.
		/// </summary>
		public decimal CantidadDefectos
        { get; set; }

        public DateTime? FechaOrdenProceso { get; set; }

        public string UsuarioRegistro { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public string UsuarioUltimaActualizacion { get; set; }

        public string TipoId { get; set; }
        public string Tipo { get; set; }

        public string EmpaqueId { get; set; }

        public string Empaque { get; set; }

    }
}
