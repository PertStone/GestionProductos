using AutoMapper;
using GestionProductos.Domain.Models;
using GestionProductos.Infraestructure.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionProductos.Domain.Perfiles
{
    public class ProductoPerfil : Profile
    {
        public ProductoPerfil()
        {
            CreateMap<Producto, ProductoViewModel>();
            CreateMap<ProductoViewModel, Producto>();
            CreateMap<ProductoEditarCrearViewModel, Producto>();

        }
    }
}
