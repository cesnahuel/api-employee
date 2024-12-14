using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Application.Common.Exceptions;
using GestionEmpleados.Application.DTO;
using GestionEmpleados.Application.Employee.Commands.Update;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Queries.GetByFilter
{
    public class GetByFilterEmployeeQueryHandler : IRequestHandler<GetByFilterEmployeeQuery, List<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetByFilterEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeDto>> Handle(GetByFilterEmployeeQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Employee> employee = await _employeeRepository.FindAll(c 
                =>  ((!string.IsNullOrEmpty(request.Nombre) && c.Nombre.ToLower() == request.Nombre.ToLower()) || (string.IsNullOrEmpty(request.Nombre))) &&
                    ((!string.IsNullOrEmpty(request.Rfc) && c.Rfc.ToLower() == request.Rfc.ToLower()) || (string.IsNullOrEmpty(request.Rfc))) &&
                    ((request.EstadoId.HasValue && request.EstadoId != 0 && c.EstadoId == request.EstadoId) || (!request.EstadoId.HasValue || request.EstadoId == 0)));

            List<EmployeeDto> result = new List<EmployeeDto>();

            employee.ForEach(tempEmployee => result.Add(new EmployeeDto(tempEmployee)));

            return result;
        }
    }
}
