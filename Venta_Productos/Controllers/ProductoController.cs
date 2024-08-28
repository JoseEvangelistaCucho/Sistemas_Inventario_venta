using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using Venta_Productos.Models;
using Venta_Productos.Service.ProductosServicios;
using Venta_Productos.Service.ProductosServicios.Command;
using Venta_Productos.Service.ProductosServicios.Queries;

namespace Venta_Productos.Controllers
{

    public class ProductoController : Controller
    {

        private readonly IMediator _mediator;
        private readonly ProductoSC _productoSC;
        private readonly IConfiguration _configuration;

        public ProductoController(IMediator mediator, ProductoSC productoSC, IConfiguration config)
        {
            _mediator = mediator;
            _productoSC = productoSC;
            _configuration = config;
        }


        public async Task<IActionResult> Index()
        {
            //var consulta = new GetProductsQuery(); 
            //var productos = await _mediator.Send(consulta); 
            //return View(productos);
            return View();
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
            return View("");
        }


        [HttpGet]
        public ActionResult<List<ProductoServicio>> ConsultarProductos([FromHeader] string id)
        {
            Response<List<ProductoServicio>> productos = _productoSC.ConsultarProducto(id);

            string apiKey = _configuration["rutaImgen"];

            if (productos.Code==0)
            {
                foreach (var product in productos.Data)
                {
                    product.Ruta = ConvertImageToBase64(apiKey+product.Ruta);
                }

                return Ok(productos.Data);
            }
            return Ok(null);
        }

            public string ConvertImageToBase64(string imagePath)
            {
                // Verifica si el archivo existe
                if (!System.IO.File.Exists(imagePath))
                {
                    throw new FileNotFoundException("La imagen no fue encontrada.", imagePath);
                }

                // Lee la imagen en un arreglo de bytes
                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

                // Convierte el arreglo de bytes a Base64
                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }

    }
}
