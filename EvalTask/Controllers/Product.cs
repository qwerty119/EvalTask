using System.Threading.Tasks;
using EvalTask.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EvalTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Product : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public Product(UserManager<User> userManager)
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