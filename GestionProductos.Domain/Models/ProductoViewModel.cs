using System;

namespace GestionProductos.Domain.Models
{
    public class ProductoViewModel
    {      
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaValidez { get; set; }
        public int CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
    }
}
