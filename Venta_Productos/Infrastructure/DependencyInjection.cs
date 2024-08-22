using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Venta_Productos.Service.ProductosServicios.Command;

namespace Venta_Productos.Infrastructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup));
            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(CrearProductoCommand));

            ; return services;
        }
    }
}
