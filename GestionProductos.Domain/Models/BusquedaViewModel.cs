using System;
using System.Collections.Generic;
using System.Text;

namespace GestionProductos.Domain.Models
{
    public class BusquedaViewModel
    {
        public string buscar { get; set; }
        public string orden { get; set; }
        public string tipo_orden { get; set; }
        public int pagina { get; set; }
        public int registros_por_pagina { get; set; }
    }
}
