using GestionEmpleados.Application.Common.Models;
using GestionEmpleados.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Commands.Create
{
    public record CreateEmployeeCommand(
       string Nombre,
       string ApellidoPaterno,
       string ApellidoMaterno,
       int Edad,
       DateTime FechaNacimiento,
       int GeneroId,
       int EstadoCivilId,
       string Rfc,
       string Direccion,
       string Email,
       string Telefono,
       string Puesto,
       DateTime FechaAlta,
       DateTime? FechaBaja
       ): IRequest<ServiceResult<EmployeeDto>>;
}
