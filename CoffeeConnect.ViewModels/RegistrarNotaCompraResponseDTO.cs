﻿using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeConnect.DTO
{
   public class RegistrarNotaCompraResponseDTO
	{

		public RegistrarNotaCompraResponseDTO()
		{
			this.Result = new Result();
		}
		public Result Result { get; set; }


	}
}