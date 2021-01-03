using System.Collections.Generic;
using System.Threading.Tasks;
using EvalTask.Domain.Entities;
using EvalTask.Product.SQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EvalTask.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ILoggerFactory logger) : base(logger)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts() => 
            Ok(await Mediator.Send(new GetAllProductsQuery()));
    }
}