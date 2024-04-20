using BookApplication.Data.Entity;

namespace BookApplication.Data.Repository.BookRepository
{
    public class BookRespository : IBookRepository
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BookRespository(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            return await _bookRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookRepository.DeleteAsync(id);
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
