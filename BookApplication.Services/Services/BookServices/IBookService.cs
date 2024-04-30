using BookApplication.Data.Entity;

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
    }
}
