using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoffeeConnect.DTO
{
    public class ExportarKardexResponseDTO
    {
        public ExportarKardexResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
        public byte[] content { get; set; }
    }
}
