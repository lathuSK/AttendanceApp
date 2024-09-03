using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using API.Entities;
using API.Interfaces;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _tokenKey;

        public TokenService(IConfiguration configuration)
        {
            _tokenKey = configuration["TokenKey"] ?? throw new Exception("Cannot access tokenKey from appsettings");
            if (_tokenKey.Length < 64) throw new Exception("Your tokenKey needs to be longer");
        }

        public string GenerateToken(User user)
        {
            if (user.Username == null) throw new Exception("No username for user");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Name", user.Name),
                new Claim("Department", user.Department),
                new Claim("JobId", user.JobId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
