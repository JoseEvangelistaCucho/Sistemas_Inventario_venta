using Microsoft.AspNetCore.Mvc;

namespace Venta_Productos.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
