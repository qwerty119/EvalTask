using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace EvalTask.Identity
{
    public class JwtGenerator
    {
        private readonly JwtOptions _options;
        private readonly JwtHeader _header;

        public JwtGenerator(JwtOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            
            _header = new JwtHeader(new SigningCredentials(_options.GetSecurityKey(), SecurityAlgorithms.HmacSha256));
        }

        public string Create(IEnumerable<Claim> claims)
        {
            var payload = new JwtPayload(
                _options.Issuer,
                _options.Audience,
                claims, null, DateTime.UtcNow.Add(TimeSpan.FromMinutes(1000))
            );
            
            return new JwtSecurityTokenHandler()
                .WriteToken(new JwtSecurityToken(_header, payload));
        }
        
    }
}