using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Domain.Common;
using GestionEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        { 
            _db = db;
        }

        public async Task<List<Employee>> FindAll()
        {
            return await _db.Employees
                .Include(a=>a.Genero)
                .Include(a => a.EstadoCivil)
                .Include(a => a.Estado)
                .AsNoTracking()
                .ToListAsync();            
        }

        public async Task Add(Employee entity, CancellationToken cancellationToken)
        {
            await _db.AddAsync(entity, cancellationToken);
            await _db.SaveChangesAsync();
        }

        public async Task<Employee> Find(int id)
        {
            return await _db.Employees
                .Where(a => a.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task Update(Employee entity, CancellationToken cancellationToken)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Employee entity, CancellationToken cancellationToken)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Employee>> FindAll(Expression<Func<Employee, bool>> filter = null, Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderby = null, string includeProperties = "")
        {
            IQueryable<Employee> query = _db.Employees;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            return await query?.ToListAsync();
        }

    }
}
 