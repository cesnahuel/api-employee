using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<int>
    {   public int Id { get; set; }
    }
    
}
