using Microsoft.AspNetCore.Mvc;

namespace Venta_Productos.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
