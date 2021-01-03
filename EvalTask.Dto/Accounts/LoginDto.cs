using System.ComponentModel.DataAnnotations;

namespace EvalTask.Dto.Accounts
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}