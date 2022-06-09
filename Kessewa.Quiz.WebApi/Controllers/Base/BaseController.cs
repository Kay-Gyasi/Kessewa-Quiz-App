using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kessewa.Quiz.WebApi.Controllers.Base
{
    // TODO:: Implement versioning properly
    
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Produces("application/json", "application/problem+json")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}