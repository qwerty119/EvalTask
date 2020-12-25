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

    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly ILoggerFactory _logger;

        public AccountController(UserManager<User> userManager, 
            ILoggerFactory logger)

        {
            _userManager = userManager;
            _logger = logger;
        }

        // /// <summary>
        // /// Current user information
        // /// </summary>
        // [HttpGet]
        // [Authorize]
        // public IActionResult Get() => Ok(User.GetIdentifier());
        
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

        // /// <summary>
        // /// Confirm email address 
        // /// </summary>
        // [HttpPost("confirm/email")]
        // public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto payload)
        // {
        //     var user = await _userManager.Users.SingleAsync(x => x.Id == payload.Id);
        //
        //     if (user.EmailConfirmed)
        //         return BadRequest("Your email already confirmed");
        //     
        //     var valid = await _userManager.ValidateTokenAsync(user, payload.Code, "EmailConfirmation");
        //     if (valid == false)
        //         return BadRequest();
        //     
        //     var userDeviceDto = new CreateUserDeviceDto(user.Id)
        //     {
        //         IsConfirmed = true
        //     };
        //
        //     var deviceId = await _createUserDeviceCommand.Handle(userDeviceDto, DeviceContext);
        //
        //     // TODO: Bad trick for using short token codes
        //     var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //     var result = await _userManager.ConfirmEmailAsync(user, token);
        //     
        //     return Ok(deviceId);
        // }
        //
        // /// <summary>
        // /// Request email confirmation code
        // /// </summary>
        // [HttpGet("confirm/email")]
        // public async Task ConfirmEmail(Guid id)
        // {
        //     var user = await _userManager.Users.SingleAsync(x => x.Id == id);
        //     
        //     await EmailConfirmCodeSent(user);
        //     
        //     // TODO: Add validation messages
        // }
        //
        // private async Task EmailConfirmCodeSent(User user)
        // {
        //     var code = await _userManager.GenerateTokenAsync(user, "EmailConfirmation");
        //     var codeSent = await _confirmEmailAddressMessage.Send(user.Email, code);
        //     if (codeSent == false)
        //         throw new ArgumentException("Code not sent");
        // }
        //
        // /// <summary>
        // /// Email change method
        // /// </summary>
        // [HttpPut("email")]
        // [Authorize]
        // public async Task ChangeEmail(string email)
        // {
        //     var user = await _userManager.Users.SingleAsync(x => x.Id == UserContext.Id);
        //     
        //     var code = await _userManager.GenerateTokenAsync(user, "Change Email", email);
        //     var codeSent = await _changeEmailAddressMessage.Send(email, code);
        //     if (codeSent == false)
        //         throw new ArgumentException("Code not sent");
        // }
        //              
        // /// <summary>
        // /// Confirm email on change 
        // /// </summary>
        // [HttpPost("email/confirm")]
        // [Authorize]
        // public async Task ConfirmChangedEmail(string code, string newEmail)
        // {
        //     var user = await _userManager.Users.SingleAsync(x => x.Id == UserContext.Id);
        //     
        //     var valid = await _userManager.ValidateTokenAsync(user, code, "Change Email", newEmail);
        //     if (valid == false)
        //         throw new Exception("token is wrong");
        //     
        //     // TODO: Bad trick for using short token codes
        //     var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        //     // TODO: Add validation through Result.
        //     await _userManager.ChangeEmailAsync(user, newEmail, token);
        // }
        //
        // /// <summary>
        // /// Password change method
        // /// </summary>
        // [HttpPut("password")]
        // [Authorize]
        // public async Task<IdentityResult> ChangePassword([FromBody] ChangePasswordDto payload)
        // {
        //     var user = await _userManager.Users.SingleAsync(x => x.Id == UserContext.Id);
        //
        //     return await _userManager.ChangePasswordAsync(user, payload.OldPassword, payload.NewPassword);
        // }
        //
        // [HttpGet("recovery")]
        // public async Task<IActionResult> Recovery(string email)
        // {
        //     var user = await _userManager.Users.SingleAsync(x => x.Email == email);
        //     if(user == null)
        //         throw new ArgumentException("User not found");
        //     
        //     var code = await _userManager.GenerateTokenAsync(user, "ResetPassword");
        //     
        //     var codeSent = await _resetPasswordEmailMessage.Send(user.Email, code);
        //     if (codeSent == false)
        //         throw new ArgumentException("Token not sent");
        //
        //     return Ok();
        // }
        //
        // [HttpPost("recovery")]
        // public async Task<IActionResult> Recovery(string email, string code, string newPassword)
        // {
        //     var user = await _userManager.Users.SingleAsync(x => x.Email == email);
        //     if (user == null)
        //         return BadRequest("User not found");
        //     
        //     var isCorrectToken = await _userManager.ValidateTokenAsync(user, code, "ResetPassword");
        //     
        //     if (false == isCorrectToken)
        //         return BadRequest("Token is incorrect!");
        //     
        //     // TODO: Bad trick for using short token codes, need to rewrite basic logic of change pass
        //     var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //     var test = await _userManager.ResetPasswordAsync(user, token, newPassword);
        //     
        //     return Ok();
        // }

    }

}