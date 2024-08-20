using Microsoft.AspNetCore.Mvc;

namespace Venta_Productos.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
