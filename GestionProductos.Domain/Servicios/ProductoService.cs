using AutoMapper;
using GestionProductos.Domain.Models;
using GestionProductos.Domain.Utiles;
using GestionProductos.Infraestructure.Entidades;
using GestionProductos.Infraestructure.GestionDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos.Domain.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly ICrudProductos _repositorio;
        private readonly IMapper _mapper;
        public static RespuestaApi Retorno { get; set; } = new RespuestaApi();
        public Util util = new Util();
        public ProductoService(ICrudProductos repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaApi> RecuperarPorCodigoProducto(string CodigoProducto)
        {
            Retorno.Resultado = null;
            Retorno.Estado = false;
            Retorno.TotalItems = 0;

            var Producto = await _repositorio.RecuperarPorCodigoProducto(CodigoProducto);
            if (Producto.Id == 0)
            {
                Retorno.Errores = "El Producto " + CodigoProducto + " no se encuentra registrado";
                return Retorno;
            }

            Retorno.Errores = string.Empty;
            Retorno.Resultado = _mapper.Map<ProductoViewModel>(Producto); 
            Retorno.Estado = true;
            Retorno.TotalItems = 1;
            return Retorno;
            
        }

        public async Task<RespuestaApi> EditarProducto(ProductoEditarCrearViewModel producto, string CodigoProducto)
        {
            Retorno.Resultado = null;
            Retorno.Estado = false;
            Retorno.TotalItems = 0;

            if (producto.FechaFabricacion >= producto.FechaValidez)
            {
                Retorno.Errores = "La fecha de fabricación no puede ser mayor o igual a la fecha de vencimiento.";                
                return Retorno;
            }
            var IdProducto = await _repositorio.RecuperarPorCodigoProducto(CodigoProducto);
            if (IdProducto.Id == 0)
            {
                Retorno.Errores = "El Producto " + CodigoProducto + " no se encuentra registrado";
                return Retorno;
            }
            var resultado = await _repositorio.EditarProducto(_mapper.Map<Producto>(producto), IdProducto.Id, CodigoProducto);

            if (resultado != true)
            {
                Retorno.Errores = "Falla al actualizar el producto " + CodigoProducto;
                return Retorno;
            }

            Retorno.Errores = string.Empty;
            Retorno.Resultado = "El producto " + CodigoProducto + ", Se actualizo correctamente";
            Retorno.Estado = true;
            Retorno.TotalItems = 1;
            return Retorno;
        }

        public async Task<RespuestaApi> InsertarProducto(ProductoEditarCrearViewModel producto)
        {
            Retorno.Resultado = null;
            Retorno.Estado = false;
            Retorno.TotalItems = 0;

            if (producto.FechaFabricacion >= producto.FechaValidez)
            {
                Retorno.Errores = "La fecha de fabricación no puede ser mayor o igual a la fecha de vencimiento.";                
                return Retorno;
            }

            var codigo = await _repositorio.RecuperarUltimoCodigoProducto();
            string NuevoCodigo = util.GenerarNuevoCodigo(codigo);

            var resultado = await  _repositorio.InsertarProducto(_mapper.Map<Producto>(producto), NuevoCodigo);

            if (resultado != true)
            {
                Retorno.Errores = "Falla al crear el producto ";                
                return Retorno;
            }

            Retorno.Errores = string.Empty;
            Retorno.Resultado = "El producto " + NuevoCodigo + ", Se agrego correctamente";
            Retorno.Estado = true;
            Retorno.TotalItems = 1;
            return Retorno;
        }        

        public async Task<RespuestaApi> EliminarProducto(string CodigoProducto)
        {
            Retorno.Resultado = null;
            Retorno.Estado = false;
            Retorno.TotalItems = 0;
            
            var IdProducto = await _repositorio.RecuperarPorCodigoProducto(CodigoProducto);
            if (IdProducto.Id == 0)
            {
                Retorno.Errores = "El Producto " + CodigoProducto + " no se encuentra registrado";
                return Retorno;
            }
            IdProducto.EstadoProducto = "Inactivo";
            var resultado = await _repositorio.EliminarProducto(IdProducto);

            if (resultado != true)
            {
                Retorno.Errores = "Falla al eliminar el producto " + CodigoProducto;
                return Retorno;
            }

            Retorno.Errores = string.Empty;
            Retorno.Resultado = "El producto " + CodigoProducto + ", Se elimino correctamente";
            Retorno.Estado = true;
            Retorno.TotalItems = 1;
            return Retorno;
        }

        public async Task<RespuestaApi> ListaRegistrosProductos(string buscar, string orden, string tipo_orden, int pagina, int registros_por_pagina)
        {
            var producto = await _repositorio.ListaRegistrosProductos();
            if (producto.Count <= 0)
            {
                Retorno.Errores = "Falla al consultar los productos";
                return Retorno;
            }
            var Producto = _mapper.Map<List<ProductoViewModel>>(producto);

            var busqueda = new BusquedaViewModel
            {
                buscar = buscar,
                orden = orden,
                tipo_orden = tipo_orden,
                pagina = pagina,
                registros_por_pagina = registros_por_pagina
            };

            Retorno.Errores = string.Empty;
            Retorno.Resultado =  util.GeneradorPaginador(busqueda, Producto);
            Retorno.Estado = true;
            Retorno.TotalItems = 1;
            return Retorno;
        }
    }
}
