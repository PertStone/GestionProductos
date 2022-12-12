using GestionProductos.Infraestructure.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionProductos.Infraestructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Producto { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
