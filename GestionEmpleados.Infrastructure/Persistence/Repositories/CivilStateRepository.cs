using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Infrastructure.Persistence.Repositories
{
    public  class CivilStateRepository: ICivilStateRepository
    {
        private readonly ApplicationDbContext _db;

        public CivilStateRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<CivilStatus>> FindAll()
        {
            return await _db.CivilStatus
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
