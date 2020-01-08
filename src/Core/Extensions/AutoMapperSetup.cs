using System;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using LibraCoffee.Core.AutoMapper;

namespace LibraCoffee.Core.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DtoProfile));
        }
    }
}