using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitectureWebAPI.Application.Interfaces.Repositories;
using OnionArchitectureWebAPI.Application.Interfaces.UnitofWorks;
using OnionArchitectureWebAPI.Persistance.Context;
using OnionArchitectureWebAPI.Persistance.Repositories;
using OnionArchitectureWebAPI.Persistance.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureWebAPI.Persistance
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitofWork, UnitofWork>();
        }
    }
}
