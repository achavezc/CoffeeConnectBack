using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Domain.Model
{
    public class MetaRequest
    {
        public string Usuario { get; set; }
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public Guid Identificador { get; set; }
    }
}
