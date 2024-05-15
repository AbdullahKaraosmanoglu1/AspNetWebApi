using BookApplication.Data.Entity;
using BookApplication.Data.Models;

namespace BookApplication.Services.Service.BookServices
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book entity);
        Task<Book> UpdateAsync(Book entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();

        Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId);
        Task<(IEnumerable<Book> Books, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel);
    }
}
