using System;
using System.Collections.Generic;
using System.Text;

namespace GestionProductos.Domain.Models
{
    public class ProductoEditarCrearViewModel
    {
        public string DescripcionProducto { get; set; }
        public string EstadoProducto { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaValidez { get; set; }
        public int CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
    }
}
