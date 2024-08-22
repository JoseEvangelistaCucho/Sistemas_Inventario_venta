using MediatR;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace Venta_Productos.Service.ProductosServicios.Queries.Preprocessors
{
	public class GetProductsQueryPreProcessor : IRequestPreProcessor<GetProductsQuery>
	{
		public Task Process(GetProductsQuery request, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
