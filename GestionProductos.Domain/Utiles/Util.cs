using GestionProductos.Domain.Models;
using GestionProductos.Infraestructure.GestionDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos.Domain.Utiles
{
    public class Util
    {
        
        public Paginador<ProductoViewModel> GeneradorPaginador(BusquedaViewModel busqueda, List<ProductoViewModel> Producto)
        {
            if (!string.IsNullOrEmpty(busqueda.buscar))
            {
                foreach (var item in busqueda.buscar.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    Producto = Producto.Where(x => x.CodigoProducto.Contains(item) ||
                                                  x.DescripcionProducto.Contains(item) ||
                                                  x.DescripcionProveedor.Contains(item) ||
                                                  x.DescripcionProveedor.Contains(item))
                                                  .ToList();
                }
            }

            switch (busqueda.orden)
            {
                case "CodigoProducto":
                    if (busqueda.tipo_orden.ToLower() == "desc")
                        Producto = Producto.OrderByDescending(x => x.CodigoProducto).ToList();
                    else if (busqueda.tipo_orden.ToLower() == "asc")
                        Producto = Producto.OrderBy(x => x.CodigoProducto).ToList();
                    break;

                case "DescripcionProducto":
                    if (busqueda.tipo_orden.ToLower() == "desc")
                        Producto = Producto.OrderByDescending(x => x.DescripcionProducto).ToList();
                    else if (busqueda.tipo_orden.ToLower() == "asc")
                        Producto = Producto.OrderBy(x => x.DescripcionProducto).ToList();
                    break;

                case "FechaFabricacion":
                    if (busqueda.tipo_orden.ToLower() == "desc")
                        Producto = Producto.OrderByDescending(x => x.FechaFabricacion).ToList();
                    else if (busqueda.tipo_orden.ToLower() == "asc")
                        Producto = Producto.OrderBy(x => x.FechaFabricacion).ToList();
                    break;

                case "FechaValidez":
                    if (busqueda.tipo_orden.ToLower() == "desc")
                        Producto = Producto.OrderByDescending(x => x.FechaValidez).ToList();
                    else if (busqueda.tipo_orden.ToLower() == "asc")
                        Producto = Producto.OrderBy(x => x.FechaValidez).ToList();
                    break;

                case "CodigoProveedor":
                    if (busqueda.tipo_orden.ToLower() == "desc")
                        Producto = Producto.OrderByDescending(x => x.CodigoProveedor).ToList();
                    else if (busqueda.tipo_orden.ToLower() == "asc")
                        Producto = Producto.OrderBy(x => x.CodigoProveedor).ToList();
                    break;

                case "DescripcionProveedor":
                    if (busqueda.tipo_orden.ToLower() == "desc")
                        Producto = Producto.OrderByDescending(x => x.DescripcionProveedor).ToList();
                    else if (busqueda.tipo_orden.ToLower() == "asc")
                        Producto = Producto.OrderBy(x => x.DescripcionProveedor).ToList();
                    break;

                case "TelefonoProveedor":
                    if (busqueda.tipo_orden.ToLower() == "desc")
                        Producto = Producto.OrderByDescending(x => x.TelefonoProveedor).ToList();
                    else if (busqueda.tipo_orden.ToLower() == "asc")
                        Producto = Producto.OrderBy(x => x.TelefonoProveedor).ToList();
                    break;

                default:
                    if (busqueda.tipo_orden.ToLower() == "desc")
                        Producto = Producto.OrderByDescending(x => x.CodigoProducto).ToList();
                    else if (busqueda.tipo_orden.ToLower() == "asc")
                        Producto = Producto.OrderBy(x => x.CodigoProducto).ToList();
                    break;
            }

            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            _TotalRegistros = Producto.Count();
            Producto = Producto.Skip((busqueda.pagina - 1) * busqueda.registros_por_pagina)
                                             .Take(busqueda.registros_por_pagina)
                                             .ToList();
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / busqueda.registros_por_pagina);


            var _PaginadorProductos = new Paginador<ProductoViewModel>()
            {
                RegistrosPorPagina = busqueda.registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = busqueda.pagina,
                BusquedaActual = busqueda.buscar,
                OrdenActual = busqueda.orden,
                TipoOrdenActual = busqueda.tipo_orden,
                Resultado = Producto
            };

            return _PaginadorProductos;
        }

        public string GenerarNuevoCodigo(string codigo)
        {
            string NuevoCodigo = string.Empty;
            if (!string.IsNullOrEmpty(codigo))
            {
                string[] subs = codigo.Split('T');
                int Codigo = int.Parse(subs[1]);
                Codigo++;

                if (Codigo < 10)
                {
                    NuevoCodigo = "PDT000" + Convert.ToString(Codigo);
                }
                else if (Codigo < 100)
                {
                    NuevoCodigo = "PDT00" + Convert.ToString(Codigo);
                }
                else if (Codigo >= 100 && Codigo < 1000)
                {
                    NuevoCodigo = "PDT0" + Convert.ToString(Codigo);
                }
                else
                {
                    NuevoCodigo = "PDT" + Convert.ToString(Codigo);
                }
            }
            else
            {
                NuevoCodigo = "PDT0001";
            }
            return NuevoCodigo;
        }
    }
}
