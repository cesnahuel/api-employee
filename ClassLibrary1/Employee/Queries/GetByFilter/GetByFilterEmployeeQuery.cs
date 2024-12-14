using GestionEmpleados.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Queries.GetByFilter
{
    public class GetByFilterEmployeeQuery : IRequest<List<EmployeeDto>>
    {
        public string? Nombre { get; set; }
        public string? Rfc { get; set; }
        public int? EstadoId { get; set; }
    }     
}
