using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Venta_Productos.Infrastructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup));

            return services;
        }
    }
}
