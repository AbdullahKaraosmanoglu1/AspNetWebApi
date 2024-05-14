using BookApplication.Data.Entity;

namespace BookApplication.Data.Repository.BookRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId);
    }
}
