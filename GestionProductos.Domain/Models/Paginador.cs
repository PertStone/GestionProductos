using System;
using System.Collections.Generic;
using System.Text;

namespace GestionProductos.Domain.Models
{
    public class Paginador<T> where T : class
    {        
        public int PaginaActual { get; set; }       
        public int RegistrosPorPagina { get; set; }       
        public int TotalRegistros { get; set; }       
        public int TotalPaginas { get; set; }     
        public string BusquedaActual { get; set; }     
        public string OrdenActual { get; set; }      
        public string TipoOrdenActual { get; set; }    
        public IEnumerable<T> Resultado { get; set; }
    }
}
