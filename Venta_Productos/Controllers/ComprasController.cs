using Microsoft.AspNetCore.Mvc;

namespace Venta_Productos.Controllers
{
    public class ComprasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
