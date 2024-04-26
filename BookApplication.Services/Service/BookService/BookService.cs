using BookApplication.Data.Entity;
using BookApplication.Data.Repository.BookRepository;

namespace BookApplication.Services.Service.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            return await _bookRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await (_bookRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _bookRepository.SaveAsync();
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            return await _bookRepository.UpdateAsync(entity);
        }
    }
}
