using GestionProductos.Infraestructure.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionProductos.Infraestructure.GestionDatos
{
    public interface ICrudProductos
    {
        public Task<Producto> RecuperarPorCodigoProducto(string CodigoProducto);
        public Task<List<Producto>> ListaRegistrosProductos();
        public Task<bool> InsertarProducto(Producto producto, string CodigoProducto);
        public Task<bool> EditarProducto(Producto producto, int Id, string CodigoProducto);
        public Task<bool> EliminarProducto(Producto producto);
        public Task<string> RecuperarUltimoCodigoProducto();
    }
}
