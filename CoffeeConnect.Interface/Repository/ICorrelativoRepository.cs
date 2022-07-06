using CoffeeConnect.DTO;
using CoffeeConnect.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeConnect.Interface.Repository
{
    public interface ICorrelativoRepository
    {
        string Obtener(int? empresaId, string documento);
        string ObtenerCorrelativoNotaIngreso(string Campaña, string CodigoTipo, string CodigoTipoConcepto);
    }
}