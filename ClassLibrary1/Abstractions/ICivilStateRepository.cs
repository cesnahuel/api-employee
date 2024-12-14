using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Application.Abstractions
{
    public interface ICivilStateRepository
    {
        Task<List<Domain.Entities.CivilStatus>> FindAll();
    }
}
