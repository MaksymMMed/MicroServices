using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Apllication.Common.Interfaces;

namespace Infrastructure.Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddScoped<IEmployeeContext>(provider => provider.GetService<EmployeeContext>());
            return services;
        }
    }
}
