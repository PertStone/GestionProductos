using GestionProductos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos.Domain.Servicios
{
    public interface IProductoService
    {
        public Task<RespuestaApi> RecuperarPorCodigoProducto(string CodigoProducto);
        public Task<RespuestaApi> ListaRegistrosProductos(string buscar, string orden, string tipo_orden, int pagina, int registros_por_pagina);
        public Task<RespuestaApi> InsertarProducto(ProductoEditarCrearViewModel producto);
        public Task<RespuestaApi> EditarProducto(ProductoEditarCrearViewModel producto, string CodigoProducto);
        public Task<RespuestaApi> EliminarProducto(string CodigoProducto);

    }
}
