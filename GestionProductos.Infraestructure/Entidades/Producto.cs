using System;
using System.ComponentModel.DataAnnotations;

namespace GestionProductos.Infraestructure.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string CodigoProducto { get; set; }
        [Required]
        public string DescripcionProducto { get; set; }
        public string EstadoProducto { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaValidez { get; set; }
        public int CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }

    }
}
