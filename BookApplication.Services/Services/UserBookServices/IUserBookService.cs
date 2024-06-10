using BookApplication.Data.Entity;
using BookApplication.Data.Models;

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

        Task<(IEnumerable<UserBook> UserBooks, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel);
    }
}
