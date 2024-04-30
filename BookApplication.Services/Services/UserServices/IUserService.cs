using BookApplication.Data.Entity;

namespace BookApplication.Services.Service.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User entity);
        Task<User> UpdateAsync(User entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
