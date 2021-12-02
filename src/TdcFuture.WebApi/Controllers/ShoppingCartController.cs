using TdcFuture.Domain.Entities;
using MediatR;
using Liquid.WebApi.Http.Extensions.Crud.Controllers;

namespace TdcFuture.WebApi.Controllers
{
    public class ShoppingCartController : GenericCrudController<ShoppingCart, int>
    {
        public ShoppingCartController(IMediator mediator) : base(mediator) { }
    }
}
