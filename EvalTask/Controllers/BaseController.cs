using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EvalTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected ILogger Logger { get; }
        
        private IMediator _mediator;
           
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected BaseController(ILoggerFactory logger)
        {
            Logger = logger.CreateLogger(GetType());
        }
        
        
    }
}