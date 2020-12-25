using System;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Spells.Extensions;

namespace EvalTask.Identity
{
    public static class JwtExtensions
    {

        public static SecurityKey GetSecurityKey(this JwtOptions options)
        {
            if (options.SecretPhrase.HasValue())
                return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretPhrase));
            
            throw new NotImplementedException();
        }

        public static Guid GetIdentifier(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            if (Guid.TryParse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var identifier))
                return identifier;

            throw new ArgumentException("No identifier");
        }

        
    }
}