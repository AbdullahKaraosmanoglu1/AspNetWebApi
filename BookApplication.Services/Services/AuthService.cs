using BookApplication.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtTokenAsync(string email, string roleName)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role,roleName),
                new Claim("JWTID", Guid.NewGuid().ToString()),
            };         

            string signingKey = _configuration["JWT:Key"];
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var tokenObject = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.UtcNow.AddDays(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return accessToken;
        }

        public async Task<string> PasswordHashAsync(string password)
        {
            //todo: twofactor authentication
            string secretKey = "Lazkopat_53";
            string combinedPassword = password + secretKey;

            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPassword));
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hashedBytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            string hashedPassword = stringBuilder.ToString();

            return hashedPassword;
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
