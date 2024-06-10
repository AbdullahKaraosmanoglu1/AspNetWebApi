using BookApplication.Data.Entity;
using BookApplication.Data.Models;

namespace BookApplication.Data.Repository.BookRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId);
        Task<(IEnumerable<Book> Books, int TotalCount)> GetBooksIsHomePageWithPaginationAsync(PaginationModel paginationModel);
    }
}
