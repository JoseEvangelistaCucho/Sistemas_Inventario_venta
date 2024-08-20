using Microsoft.AspNetCore.Mvc;

namespace Venta_Productos.Controllers
{
    public class ProformasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
