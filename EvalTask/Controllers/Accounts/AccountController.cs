using System;
using System.Threading.Tasks;
using EvalTask.Domain.Entities;
using EvalTask.Dto.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EvalTask.API.Controllers.Accounts
{
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        public AccountController(UserManager<User> userManager, ILoggerFactory logger) : base(logger)

        {
            _userManager = userManager;
        }

        
        /// <summary>
        /// Create new user account
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterDto payload)
        {
            var user = new User
            {
                Email = payload.Email,
                UserName = payload.Email,
            };

            var result = await _userManager.CreateAsync(user, payload.Password);
            if (false == result.Succeeded)
                return BadRequest();
            return Ok();
        }
    }

}