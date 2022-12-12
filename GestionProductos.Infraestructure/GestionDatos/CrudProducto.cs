using GestionProductos.Infraestructure.Context;
using GestionProductos.Infraestructure.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProductos.Infraestructure.GestionDatos
{
    public class CrudProducto : ICrudProductos
    {
        private readonly ApplicationDbContext _context;

        public CrudProducto(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Producto> RecuperarPorCodigoProducto(string CodigoProducto)
        {
            var producto = new Producto();
            try
            {
                producto = _context.Producto.Where(d => d.CodigoProducto == CodigoProducto).AsNoTracking().First();
                return producto;
            }
            catch (System.Exception e)
            {
                producto.Id = 0;
                return producto;
            }
        }

        public async Task<List<Producto>> ListaRegistrosProductos()
        {
            var producto = new List<Producto>();
            try
            {
                producto = await _context.Producto.Where(x => x.EstadoProducto == "Activo").ToListAsync();
                return producto;
            }
            catch (System.Exception e)
            {
                return producto;
            }
        }

        public async Task<bool> InsertarProducto(Producto producto, string CodigoProducto)
        {
            producto.CodigoProducto = CodigoProducto;
            producto.EstadoProducto = "Activo";
            try
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public async Task<bool> EditarProducto(Producto producto, int Id, string CodigoProducto)
        {
            producto.CodigoProducto = CodigoProducto;
            producto.EstadoProducto = "Activo";
            producto.Id = Id;
            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public async Task<bool> EliminarProducto(Producto producto)
        {
            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public async Task<string> RecuperarUltimoCodigoProducto()
        {
            try
            {
                var lastRecord = await _context.Producto.OrderByDescending(x => x.CodigoProducto).FirstOrDefaultAsync();
                return lastRecord.CodigoProducto;
            }
            catch (System.Exception e)
            {
                return string.Empty;
            }
        }
    }
}
