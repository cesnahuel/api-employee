using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Commands.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(v => v.Nombre)
                .NotEmpty().WithMessage("Nombre es requerido.")
                .MaximumLength(100).WithMessage("Nombre no debe exceder de 100 caracteres.");

            RuleFor(v => v.ApellidoPaterno)
                .NotEmpty().WithMessage("Apellido Paterno es requerido.")
                .MaximumLength(100).WithMessage("Apellido Paterno no debe exceder de 100 caracteres.");

            RuleFor(v => v.ApellidoMaterno)
                .NotEmpty().WithMessage("Apellido Materno es requerido.")
                .MaximumLength(100).WithMessage("Apellido Materno no debe exceder de 100 caracteres.");

            RuleFor(v => v.Edad)
                .NotNull().WithMessage("Edad es requerido.")
                .GreaterThan(0).WithMessage("Edad debe ser mayor a 0.");

            RuleFor(v => v.FechaNacimiento)
                .NotEmpty().WithMessage("Fecha Nacimiento es requerido")
                .LessThan(p => DateTime.Now).WithMessage("Fecha Naciemiento no debe ser mayor a la fecha actual");

            RuleFor(v => v.GeneroId)
                .NotEmpty().WithMessage("GeneroId es requerido.")
                .GreaterThan(0).WithMessage("GeneroId debe ser mayor a 0.");

            RuleFor(v => v.EstadoCivilId)
                .NotEmpty().WithMessage("EstadoCivilId es requerido.")
                .GreaterThan(0).WithMessage("EstadoCivilId debe ser mayor a 0.");

            RuleFor(v => v.Rfc)
               .NotEmpty().WithMessage("Rfc es requerido.")
               .MaximumLength(100).WithMessage("Rfc no debe exceder de 100 caracteres.");

            RuleFor(v => v.Direccion)
               .NotEmpty().WithMessage("Direccion es requerido.")
               .MaximumLength(100).WithMessage("Direccion no debe exceder de 100 caracteres.");

            RuleFor(v => v.Email)
               .NotEmpty().WithMessage("EMail es requerido.")
               .EmailAddress().WithMessage("EMail debe ser valido");

            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("Telefono es requerido.")
                .NotNull().WithMessage("Telefono es requerido.")
                .MinimumLength(6).WithMessage("Telefono debe tener mas de 6 caracteres.")
                .MaximumLength(15).WithMessage("Telefono debe tener menos de 15 caracteres.");

            RuleFor(v => v.Puesto)
              .NotEmpty().WithMessage("Puesto es requerido.")
              .MaximumLength(100).WithMessage("Puesto no debe exceder de 100 caracteres.");

            RuleFor(v => v.FechaAlta)
                .NotEmpty().WithMessage("Fecha de Alta es requerido");


        }


    }
}
