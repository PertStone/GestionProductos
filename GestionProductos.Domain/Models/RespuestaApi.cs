using System;
using System.Collections.Generic;
using System.Text;

namespace GestionProductos.Domain.Models
{
    public class RespuestaApi
    {
        public string Errores { get; set; }

        public dynamic Resultado { get; set; }

        public bool Estado { get; set; }

        public dynamic TotalItems { get; set; }
    }
}
