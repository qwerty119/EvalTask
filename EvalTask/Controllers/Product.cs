using Microsoft.AspNetCore.Mvc;

namespace EvalTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Product : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world";
        }
    }
}