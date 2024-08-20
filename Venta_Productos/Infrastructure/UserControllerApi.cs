using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Venta_Productos.Infrastructure
{
    public class UserControllerApiBase : Controller
    {

        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    }
}
