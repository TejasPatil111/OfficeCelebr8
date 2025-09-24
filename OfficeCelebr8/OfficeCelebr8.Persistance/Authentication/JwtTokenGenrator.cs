using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OfficeCelebr8.Domain.Entities;
using OfficeCelebr8.Domain.Interfaces;

namespace OfficeCelebr8.Persistance.Authentication
{
    public class JwtTokenGenrator : IJwtTokenGenrator
    {
        private readonly IConfiguration _config;

        //di method in short using lamda expression
        public JwtTokenGenrator(IConfiguration config) => _config = config;

        public string GenrateToken(User user)
        {
            var key = _config["JwtSettings:Key"] ?? throw new Exception("Jwt Key is Missing");
            var issuer = _config["JwtSettings:isssuer"];
            var audienance = _config["JwtSettings:Audience"];
            var expiryMin = int.Parse(_config["JwtSettings:DurationInMinutes"] ?? "60");

            var claim = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? ""),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Role, user.Role ??  "User"),
            };

            var  securityToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityToken, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audienance,
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(expiryMin),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
    }
}
