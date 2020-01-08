using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LibraCoffee.Entities.Seed;

namespace LibraCoffee.Core.Extensions
{
    public static class DbContextSetup
    {
        public static void AddDbContextSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<LibraCoffeeDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("LibraCoffeeDbContext"));
            });
        }
    }
}