/*
PROYECTO: 
AUTOR: 
FECHA: 05/05/2014 05:36:43 p.m.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeConnect.DTO
{
	public class RequestBaseDTO
	{
        public RequestBaseDTO()
        {
            this.ObjetoTrazabilidad = new ObjetoTrazabilidad();
        }

        public void SetRequestBaseDTO(RequestBaseDTO requestBaseDTO)
        {
            string eventoGuid = "";
            string origenGuid = "";

            if (requestBaseDTO == null)
                return;


            if (requestBaseDTO.ObjetoTrazabilidad != null)
            {
                eventoGuid = !string.IsNullOrEmpty(requestBaseDTO.ObjetoTrazabilidad.GuidEvento) ? requestBaseDTO.ObjetoTrazabilidad.GuidEvento : "";
                origenGuid = !string.IsNullOrEmpty(requestBaseDTO.ObjetoTrazabilidad.GuidFormulario) ? requestBaseDTO.ObjetoTrazabilidad.GuidFormulario : "";
            }


            ObjetoTrazabilidad = new ObjetoTrazabilidad()
            {
                GuidEvento = eventoGuid,
                GuidFormulario = origenGuid,
                ValorReferencial = ""
            };
        }


        public ObjetoTrazabilidad ObjetoTrazabilidad { get; set; }
	}

    public class ObjetoTrazabilidad
    {
        public ObjetoTrazabilidad()
        {
            this.GuidFormulario = "";
            this.GuidEvento = "";
            this.ValorReferencial = "";
        }

        public string GuidFormulario { get; set; }
        public string GuidEvento { get; set; }
        public string ValorReferencial { get; set; }
    }
}