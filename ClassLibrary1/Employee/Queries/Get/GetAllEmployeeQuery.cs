using GestionEmpleados.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Queries.Get
{
    public class GetAllEmployeeQuery: IRequest<List<EmployeeDto>>
    { }
}
