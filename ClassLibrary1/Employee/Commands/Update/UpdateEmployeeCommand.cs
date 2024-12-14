using GestionEmpleados.Application.Common.Models;
using GestionEmpleados.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Employee.Commands.Update
{
    public class UpdateEmployeeCommand : IRequest<ServiceResult<EmployeeDto>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int GeneroId { get; set; }
        public int EstadoCivilId { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
    } 
    
}
