using Venta_Productos.Models;
using MediatR;
using Venta_Productos.Infrastructure.Data;

namespace Venta_Productos.Service.ProductosServicios.Command
{
    public class CrearProductoCommand : IRequest<Response<bool>>
    {
      public ProductoServicio productoDetalle { get; set; }
    }
    public class CrearProductoCommandHandler : IRequestHandler<CrearProductoCommand, Response<bool>>
    {
        public CrearProductoCommandHandler()
        {
        }

        public Task<Response<bool>> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {


            throw new NotImplementedException();
        }
    }
}
