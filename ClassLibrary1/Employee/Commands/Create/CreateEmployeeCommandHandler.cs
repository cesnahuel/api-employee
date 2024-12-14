using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Application.Common.Models;
using GestionEmpleados.Application.DTO;
using GestionEmpleados.Application.Employee.Queries.Get;
using GestionEmpleados.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Commands.Create
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ServiceResult<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<ServiceResult<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Employee entity = new Domain.Entities.Employee
            {
                Nombre = request.Nombre,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                Edad = request.Edad,
                FechaNacimiento = request.FechaNacimiento,
                GeneroId = request.GeneroId,
                EstadoCivilId = request.EstadoCivilId,
                Rfc = request.Rfc,
                Direccion = request.Direccion,
                Email = request.Email,
                Telefono = request.Telefono,
                Puesto = request.Puesto,
                FechaAlta = request.FechaAlta,
                FechaBaja = request.FechaBaja,
                EstadoId = (int)EStatus.Alta
            };

            await _employeeRepository.Add(entity, cancellationToken);

            var result = new EmployeeDto(entity);

            return ServiceResult.Success(result);
        }
    }
}
