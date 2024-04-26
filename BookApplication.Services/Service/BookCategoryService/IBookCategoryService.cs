using BookApplication.Data.Entity;

namespace BookApplication.Services.Service.BookCategoryService
{
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategory>> GetAllAsync();
        Task<BookCategory> GetByIdAsync(int id);
        Task<BookCategory> CreateAsync(BookCategory entity);
        Task<BookCategory> UpdateAsync(BookCategory entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
