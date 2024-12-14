using GestionEmpleados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.DTO
{
    public class CivilStateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public CivilStateDto(Domain.Entities.CivilStatus civilStatus)
        {
            Id = civilStatus.Id;
            Nombre = civilStatus.Nombre;
        }
    }
}
