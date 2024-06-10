using BookApplication.Data.Entity;
using BookApplication.Data.Models;

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

        Task<User> GetByTokenAsync(string token);
        Task<(IEnumerable<User> Users, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel);
    }
}
