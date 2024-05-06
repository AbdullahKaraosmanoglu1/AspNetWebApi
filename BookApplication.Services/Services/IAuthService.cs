using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Services.Services
{
    public interface IAuthService
    {
        Task<string> PasswordHashAsync(string password);
        Task<string> GenerateJwtTokenAsync(string email, string roleName);
        Task SaveAsync();
    }
}
