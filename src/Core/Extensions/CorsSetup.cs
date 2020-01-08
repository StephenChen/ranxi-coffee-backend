using System;
using Microsoft.Extensions.DependencyInjection;

namespace LibraCoffee.Core.Extensions
{
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddCors(option =>
            {
                option.AddPolicy("CorsSample", policy => policy.WithOrigins("http://localhost:8080")
                    .AllowAnyMethod().AllowAnyHeader());
                option.AddPolicy("mytest", policy =>
                {
                    policy.WithOrigins("http://localhost:8081").AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
    }
}
