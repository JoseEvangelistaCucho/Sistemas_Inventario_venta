using Microsoft.AspNetCore.Mvc;

namespace Venta_Productos.Controllers
{
    public class FacturacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
