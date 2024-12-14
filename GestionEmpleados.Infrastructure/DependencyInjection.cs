using GestionEmpleados.Application.Abstractions;
using GestionEmpleados.Infrastructure.Persistence;
using GestionEmpleados.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            //var provider = configuration.GetValue()

            var assembly = typeof(DependencyInjection).Assembly;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    m =>
                    {
                        m.MigrationsAssembly("GestionEmpleados.Infrastructure");
                    })
                );

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ICivilStateRepository, CivilStateRepository>();

            return services;

        }

    }
}
