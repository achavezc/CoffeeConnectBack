
using CoffeeConnect.DTO;
using CoffeeConnect.Interface.Repository;
using CoffeeConnect.Interface.Service;
using CoffeeConnect.Models;
using Core.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeConnect.Service
{
    public partial class NotaIngresoAlmacenService : INotaIngresoAlmacenService
    {
       
        private INotaIngresoAlmacenRepository _INotaIngresoAlmacenRepository;
       
        public NotaIngresoAlmacenService(INotaIngresoAlmacenRepository notaIngresoAlmacenRepository)
        {
            _INotaIngresoAlmacenRepository = notaIngresoAlmacenRepository;          
        }
       
              

        public int Registrar(EnviarAlmacenGuiaRecepcionMateriaPrimaRequestDTO request)
        {
            NotaIngresoAlmacen notaIngresoAlmacen = new NotaIngresoAlmacen();
            notaIngresoAlmacen.GuiaRecepcionMateriaPrimaId = request.GuiaRecepcionMateriaPrimaId;
            notaIngresoAlmacen.UsuarioRegistro = request.Usuario;
            notaIngresoAlmacen.FechaRegistro = DateTime.Now;
            notaIngresoAlmacen.EstadoId = NotaIngresoAlmacenEstados.Ingresado;

            int affected = _INotaIngresoAlmacenRepository.Insertar(notaIngresoAlmacen);

            return affected;
        }



    }
}
