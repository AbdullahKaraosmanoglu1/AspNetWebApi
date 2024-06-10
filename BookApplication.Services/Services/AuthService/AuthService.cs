using BookApplication.Data.Entity;
using BookApplication.Data.Repository.AuthRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookApplication.Services.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
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
            string secretKey = _configuration["Hash:Key"];
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

        public async Task SaveAsync()
        {
           await _authRepository.SaveAsync();
        }

        public async Task<User> UserLoginAsync(User user)
        {
            user.Password = await PasswordHashAsync(user.Password);
            var userLogin = await _authRepository.UserLoginAsync(user);

            if (userLogin != null )
            {
                var accessToken = await GenerateJwtTokenAsync(user.Email, userLogin.Role.RoleName);

                userLogin.AccessToken = accessToken;
                userLogin.AccessTokenCreatedDate = DateTime.UtcNow;

                await _authRepository.SaveAsync();
                return userLogin;
            }

            return null;
        }        

    }
}
