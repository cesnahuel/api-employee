using GestionEmpleados.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Domain.Entities
{
    public class Employee : BaseEntity
    {
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
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int EstadoId { get; set; }
        
        public virtual Gender Genero { get; set; }
        public virtual CivilStatus EstadoCivil { get; set; }
        public virtual Status Estado { get; set; }

    }
}
