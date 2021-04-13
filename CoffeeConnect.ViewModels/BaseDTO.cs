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
	public class BaseDTO
	{
		/// <summary>
		/// <br/><b>Nombre:</b> 'errores'
		/// <br/><b>Tipo:</b> Dictionary<string, string>
		///</summary>
		public Dictionary<string, string> errores
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'estadoOperacion'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string estadoOperacion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'codigoEstadoOperacion'
		/// <br/><b>Tipo:</b> string
		///</summary>
		public string codigoEstadoOperacion
		{
			get;
			set;
		}

		/// <summary>
		/// <br/><b>Nombre:</b> 'mensajes'
		/// <br/><b>Tipo:</b> Dictionary<string, string>
		///</summary>
		public Dictionary<string, string> mensajes
		{
			get;
			set;
		}

		
	}
}