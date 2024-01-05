using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Ecommerce.Application.Product.Commands;
using Ecommerce.Application.Product.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Ecommerce.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppAndInfraDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
