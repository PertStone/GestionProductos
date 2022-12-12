using FluentValidation.Results;
using GestionProductos.Api.Validaciones;
using GestionProductos.Domain.Models;
using GestionProductos.Domain.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProductos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _Servicio;

        public ProductoController(IProductoService servicio)
        {
            _Servicio = servicio;
        }

        // GET: api/Customers
        /// <summary>
        /// Obtiene un resultado paginado de los productos activos, para consultar un producto inactivo se debe hacer una consulta por id.
        /// </summary>
        /// <param name="buscar">Texto de búsqueda.</param>
        /// <param name="orden">Nombre de campo por el cual ordenar (distingue mayúsculas).</param>
        /// <param name="tipo_orden">Tipo de orden: ASC (ascendente) / DESC (descendente).</param>
        /// <param name="pagina">Número de página a obtener.</param>
        /// <param name="registros_por_pagina">Número de registros por página.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get(string buscar,string orden = "CodigoProducto", string tipo_orden = "ASC",int pagina = 1,int registros_por_pagina = 10)
        {
            
                var response = await _Servicio.ListaRegistrosProductos(buscar, orden, tipo_orden, pagina,registros_por_pagina);
                if (response.Estado) return Ok(response);
                ModelState.AddModelError("Error", string.Join(",", response));
                return BadRequest(ModelState);
            
        }

        // GET api/<ProductoController>/5
        [HttpGet("{CodigoProducto}")]
        public async Task<ActionResult> Get(string CodigoProducto)
        {
            if (CodigoProducto != null)
            {
                var response = await _Servicio.RecuperarPorCodigoProducto(CodigoProducto);
                if (response.Estado) return Ok(response);
                ModelState.AddModelError("Error", string.Join(",", response));
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoEditarCrearViewModel producto)
        {
            if (producto != null)
            {
                var validador = new ValidacionesProducto();
                ValidationResult resultado = validador.Validate(producto);
                if (!resultado.IsValid)
                {
                    foreach (var errors in resultado.Errors)
                    {
                        ModelState.AddModelError($"Error en ", string.Join(",", $" {errors.PropertyName} {errors.ErrorMessage}"));
                    }
                    return BadRequest(ModelState);
                }
                var response = await _Servicio.InsertarProducto(producto);
                if (response.Estado) return Ok(response);
                ModelState.AddModelError("Error", string.Join(",", response));
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{CodigoProducto}")]
        public async Task<ActionResult> Put(string CodigoProducto, [FromBody] ProductoEditarCrearViewModel producto)
        {
            if (producto != null)
            {
                var validador = new ValidacionesProducto();
                ValidationResult resultado = validador.Validate(producto);
                if (!resultado.IsValid)
                {
                    foreach (var errors in resultado.Errors)
                    {
                        ModelState.AddModelError($"Error en ", string.Join(",", $" {errors.PropertyName} {errors.ErrorMessage}"));
                    }
                    return BadRequest(ModelState);
                }
                var response = await _Servicio.EditarProducto(producto, CodigoProducto);
                if (response.Estado) return Ok(response);
                ModelState.AddModelError("Error", string.Join(",", response));
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{CodigoProducto}")]
        public async Task<ActionResult> Delete(string CodigoProducto)
        {
            if (CodigoProducto != null)
            {
                var response = await _Servicio.EliminarProducto(CodigoProducto);
                if (response.Estado) return Ok(response);
                ModelState.AddModelError("Error", string.Join(",", response));
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
    }
}
