using BookApplication.Data.Entity;
using System.Linq.Expressions;

namespace BookApplication.Data.Repository.BookCategoryRepository
{
    public class BookCategoryRespository : IBookCategoryRepository
    {
        private readonly IGenericRepository<BookCategory> _bookCategoryRepository;

        public BookCategoryRespository(IGenericRepository<BookCategory> bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<BookCategory> CreateAsync(BookCategory entity)
        {
            return await _bookCategoryRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookCategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookCategory>> GetAllAsync()
        {
            return await _bookCategoryRepository.GetAllAsync();
        }

        public async Task<BookCategory> GetByIdAsync(int id)
        {
            return await _bookCategoryRepository.GetByIdAsync(id);
        }

        public Task<BookCategory> GetByIdAsync(Expression<Func<BookCategory, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _bookCategoryRepository.SaveAsync();
        }

        public async Task<BookCategory> UpdateAsync(BookCategory entity)
        {
            return await _bookCategoryRepository.UpdateAsync(entity);
        }
    }
}
