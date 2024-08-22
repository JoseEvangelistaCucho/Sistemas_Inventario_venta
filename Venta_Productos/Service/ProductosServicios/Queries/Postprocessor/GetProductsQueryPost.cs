using Venta_Productos.Models;

namespace Venta_Productos.Service.ProductosServicios.Queries.Postprocessor
{
	public class GetProductsQueryPost
	{
		public Task Process(GetProductsQuery request, List<ProductoServicio> response, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
