using Microsoft.AspNetCore.Mvc;

namespace Venta_Productos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
