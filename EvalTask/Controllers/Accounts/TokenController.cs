using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using EvalTask.Data;
using EvalTask.Domain.Entities;
using EvalTask.Dto.Accounts;
using EvalTask.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EvalTask.API.Controllers.Accounts
{
    
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        
        private readonly JwtGenerator _tokenGenerator;
        private readonly EvalTaskContext _context;
        private readonly SignInManager<User> _signInManager;

        public TokenController(SignInManager<User> signInManager, 
            JwtGenerator tokenGenerator, 
            EvalTaskContext context, 
            ILoggerFactory logger 
            ) 
        {
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
            _context = context;
        }
        

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto payload)
        {
            var user = await _context.Set<User>()
                .SingleOrDefaultAsync(x => x.Email == payload.Email);

            if (user == null)
                return NotFound();

            var result = await _signInManager.CheckPasswordSignInAsync(user, payload.Password, false);
            if (result.Succeeded == false)
                return BadRequest();

            return Ok(GenerateToken(user));
        }

        private TokenDto GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email), 
            };
            
            return new TokenDto
            {
                AccessToken = _tokenGenerator.Create(claims),
            };
        }

    }
}