using BookApplication.Data.Entity;

namespace BookApplication.Services.Service.UserBookServices
{
    public interface IUserBookService
    {
        Task<IEnumerable<UserBook>> GetAllAsync();
        Task<UserBook> GetByIdAsync(int id);
        Task<UserBook> CreateAsync(UserBook entity);
        Task<UserBook> UpdateAsync(UserBook entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
