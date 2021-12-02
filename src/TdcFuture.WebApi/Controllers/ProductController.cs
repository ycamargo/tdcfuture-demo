using TdcFuture.Domain.Entities;
using MediatR;
using Liquid.WebApi.Http.Extensions.Crud.Controllers;

namespace TdcFuture.WebApi.Controllers
{
    public class ProductController : GenericCrudController<Product, int>
    {
        public ProductController(IMediator mediator) : base(mediator) { }
    }
}
