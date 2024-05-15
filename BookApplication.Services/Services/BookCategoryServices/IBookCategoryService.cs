using BookApplication.Data.Entity;
using BookApplication.Data.Models;

namespace BookApplication.Services.Service.BookCategoryServices
{
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategory>> GetAllAsync();
        Task<BookCategory> GetByIdAsync(int id);
        Task<BookCategory> CreateAsync(BookCategory entity);
        Task<BookCategory> UpdateAsync(BookCategory entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();

        Task<(IEnumerable<BookCategory> BookCategories, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel);
    }
}
