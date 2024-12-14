using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Application.Common.Exceptions;
using GestionEmpleados.Application.Common.Models;
using GestionEmpleados.Application.DTO;
using GestionEmpleados.Application.Employee.Commands.Create;
using GestionEmpleados.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Commands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ServiceResult<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<ServiceResult<EmployeeDto>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _employeeRepository.Find(request.Id);

            if (entity is null)
                throw new NotFoundException(nameof(Domain.Entities.Employee), request.Id);


            entity.Nombre = request.Nombre;
            entity.ApellidoPaterno = request.ApellidoPaterno;
            entity.ApellidoMaterno = request.ApellidoMaterno;
            entity.Edad = request.Edad;
            entity.FechaNacimiento = request.FechaNacimiento;
            entity.GeneroId = request.GeneroId;
            entity.EstadoCivilId = request.EstadoCivilId;
            entity.Rfc = request.Rfc;
            entity.Direccion = request.Direccion;
            entity.Email = request.Email;
            entity.Telefono = request.Telefono;
            entity.Puesto = request.Puesto;

            await _employeeRepository.Update(entity, cancellationToken);

            var result = new EmployeeDto(entity);

            return ServiceResult.Success(result);
        }
    }
}
