using Microsoft.Extensions.DependencyInjection;
using OrderManagementSystem.Application.Mapping;
using OrderManagementSystem.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // ServiceManager يجمع كل الـ services في واجهة واحدة
            services.AddScoped<IServiceManager, ServiceManager>();

            return services;
        }
    }
}
