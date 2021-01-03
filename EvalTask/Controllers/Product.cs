using System.Threading.Tasks;
using EvalTask.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EvalTask.API.Controllers
{
    public class Product : BaseController
    {
        private readonly UserManager<User> _userManager;

        public Product(UserManager<User> userManager, ILoggerFactory logger) : base(logger)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<string> Get()
        {
            return "Hello world";
        }
    }
}