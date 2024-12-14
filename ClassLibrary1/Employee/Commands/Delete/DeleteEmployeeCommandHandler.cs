using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Application.Common.Exceptions;
using GestionEmpleados.Application.DTO;
using GestionEmpleados.Application.Employee.Commands.Create;
using GestionEmpleados.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Commands.Delete
{
    
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _employeeRepository.Find(request.Id);

            if (entity is null)
                throw new NotFoundException(nameof(Domain.Entities.Employee), request.Id);

            entity.EstadoId = (int)EStatus.Baja;
            entity.FechaBaja = DateTime.Now;

            await _employeeRepository.Update(entity, cancellationToken);

            return request.Id;
        }
    }
}
