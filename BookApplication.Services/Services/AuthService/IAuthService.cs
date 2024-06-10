using BookApplication.Data.Entity;

namespace BookApplication.Services.Services.AuthService
{
    public interface IAuthService
    {
        Task<User> UserLoginAsync(User user);
        Task<string> PasswordHashAsync(string password);
        Task<string> GenerateJwtTokenAsync(string email, string roleName);
        Task SaveAsync();
    }
}
