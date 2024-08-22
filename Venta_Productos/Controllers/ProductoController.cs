using MediatR;
using Microsoft.AspNetCore.Mvc;
using Venta_Productos.Models;
using Venta_Productos.Service.ProductosServicios.Command;
using Venta_Productos.Service.ProductosServicios.Queries;

namespace Venta_Productos.Controllers
{

    public class ProductoController : Controller
    {

		private readonly IMediator _mediator;

		public ProductoController(IMediator mediator)
		{
			_mediator = mediator;
		}


		public async Task<IActionResult> Index()
		{
			var consulta = new GetProductsQuery(); 
			var productos = await _mediator.Send(consulta); 
			return View(productos);
		}

		[HttpPost]
		public async Task<IActionResult> Crear(ProductoServicio producto)
		{
			if (ModelState.IsValid)
			{
                CrearProductoCommand request = new CrearProductoCommand();

                Response<bool> result = await _mediator.Send(request);

				if (result.Data)
				{
					return RedirectToAction(nameof(Index));
				}
			}
			return View ("");
		}
       
    }
}
