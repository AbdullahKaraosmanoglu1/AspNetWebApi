using BookApplication.Data.Entity;

namespace BookApplication.Services.Service.UserBookServices
{
    public interface IUserBookSevice
    {
        Task<IEnumerable<UserBook>> GetAllAsync();
        Task<UserBook> GetByIdAsync(int id);
        Task<UserBook> CreateAsync(UserBook entity);
        Task<UserBook> UpdateAsync(UserBook entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
