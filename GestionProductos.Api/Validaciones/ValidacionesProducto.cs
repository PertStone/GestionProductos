using FluentValidation;
using GestionProductos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProductos.Api.Validaciones
{
    public class ValidacionesProducto : AbstractValidator<ProductoEditarCrearViewModel>
    {
        public ValidacionesProducto()
        {

            RuleFor(x => x.DescripcionProducto).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(x => x.FechaValidez).GreaterThan(x => x.FechaFabricacion);
            RuleFor(x => x.DescripcionProveedor).MaximumLength(200);
            RuleFor(x => x.TelefonoProveedor).Matches("^[0-9]+$").Length(7,12).WithMessage("Solo se permiten numero y entre 7 y 12 digitos");

            //var conditions = new List<string>() { "Activo", "Inactivo" };
            //RuleFor(x => x.EstadoProducto).Must(x => conditions.Contains(x)).WithMessage("Por favor use solo: " + String.Join(",", conditions));
        }
    }
}
