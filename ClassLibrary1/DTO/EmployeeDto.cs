using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int GeneroId { get; set; }
        public string Genero { get; set; }
        public int EstadoCivilId { get; set; }
        public string EstadoCivil { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string Estado { get; set; }
        public int EstadoId { get; set; }

        public EmployeeDto(Domain.Entities.Employee employee)
        {
            Id=employee.Id;
            Nombre = employee.Nombre;
            ApellidoPaterno = employee.ApellidoPaterno;
            ApellidoMaterno = employee.ApellidoMaterno;
            Edad = employee.Edad;
            FechaNacimiento = employee.FechaNacimiento;
            GeneroId = employee.GeneroId;
            Genero = employee.Genero?.Nombre;
            EstadoCivilId = employee.EstadoCivilId;
            EstadoCivil = employee.EstadoCivil?.Nombre;
            Rfc = employee.Rfc;
            Direccion = employee.Direccion;
            Email = employee.Email;
            Telefono = employee.Telefono;
            Puesto = employee.Puesto;
            FechaAlta = employee.FechaAlta;
            FechaBaja = employee.FechaBaja;
            Estado = employee.Estado?.Nombre;
            EstadoId = employee.EstadoId;
        }
    }

   

}
