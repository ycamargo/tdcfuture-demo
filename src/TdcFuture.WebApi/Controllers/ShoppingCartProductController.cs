using TdcFuture.Domain.Entities;
using MediatR;
using Liquid.WebApi.Http.Extensions.Crud.Controllers;

namespace TdcFuture.WebApi.Controllers
{
    public class ShoppingCartProductController : GenericCrudController<ShoppingCartProduct, int>
    {
        public ShoppingCartProductController(IMediator mediator) : base(mediator) { }
    }
}
