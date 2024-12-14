using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GestionEmpleados.Application.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<List<Domain.Entities.Employee>> FindAll();
        Task Add(Domain.Entities.Employee entity, CancellationToken cancellationToken);
        Task<Domain.Entities.Employee> Find(int id);
        Task Update(Domain.Entities.Employee entity, CancellationToken cancellationToken);
        Task Delete(Domain.Entities.Employee entity, CancellationToken cancellationToken);
        Task<List<Domain.Entities.Employee>> FindAll(Expression<Func<Domain.Entities.Employee, bool>> filter = null, Func<IQueryable<Domain.Entities.Employee>, IOrderedQueryable<Domain.Entities.Employee>> orderby = null, string includeProperties = "");
    }
}
