using MediatR;
using Venta_Productos.Models;

namespace Venta_Productos.Service.Users.Queries
{
    public class GetUserQuery : IRequest<Response<User>>
    {
        public string UserName { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<User>>
    {
        public async Task<Response<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            List<User> listaUsuarios = new List<User>(){
                new User()
                {
                    Id = 1,
                    Name = "test"
                },
                new User()
                {
                    Id = 2,
                    Name = "test1"
                }

            };

            Response<User> response = new Response<User>();
            try
            {
                //5297321 gas

                User usuarioIguales = listaUsuarios.Where(x => x.Name.Equals(request.UserName)).Select(x => x).FirstOrDefault();
                response = new Response<User>
                {
                    Message = "",
                    Code = 0,
                    Data = new User()
                };

                response.Data = usuarioIguales;
            }
            catch (Exception ex)
            {
                response = new Response<User>
                {
                    Message = ex.Message,
                    Code = -1
                };
            }
            return response;
        }
    }
}
