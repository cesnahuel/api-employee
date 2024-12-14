using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Queries.Get
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeDto>> 
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken) 
        {
            List<GestionEmpleados.Domain.Entities.Employee> employee = await _employeeRepository.FindAll();
            List<EmployeeDto> result = new List<EmployeeDto>();

            employee.ForEach(tempEmployee => result.Add(new EmployeeDto(tempEmployee)));

            return result;
        }
    }
}
