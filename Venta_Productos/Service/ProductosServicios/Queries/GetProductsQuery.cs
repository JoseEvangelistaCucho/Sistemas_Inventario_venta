using MediatR;
using System.Collections.Generic;
using Venta_Productos.Models;

namespace Venta_Productos.Service.ProductosServicios.Queries
{
	public class GetProductsQuery : IRequest<List<ProductoServicio>>
	{
	}
}
