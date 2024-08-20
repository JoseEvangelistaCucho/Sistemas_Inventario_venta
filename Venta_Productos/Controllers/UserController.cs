using Microsoft.AspNetCore.Mvc;
using Venta_Productos.Infrastructure;
using Venta_Productos.Models;
using Venta_Productos.Service.Users.Queries;

namespace Venta_Productos.Controllers
{
    public class UserController : UserControllerApiBase
    {
        public async Task<IActionResult> Index()
        {
            var data = await Mediator.Send(new GetUserQuery()
            {
                UserName="test"
            });

            ViewData["Apellido"] = "EnvioFormulario";
            ViewData["usuarioNuevo"] = new User()
            {
                Id = 10,
                Name = "victor"
            };


            ViewBag.Monto = 10;

            return View(data.Data);
        }
    }
}
