using BookApplication.Data.Entity;
using BookApplication.Data.Models;

namespace BookApplication.Data.Repository.BookCategoryRepository
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly IGenericRepository<BookCategory> _bookCategoryRepository;

        public BookCategoryRepository(IGenericRepository<BookCategory> bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<BookCategory> CreateAsync(BookCategory entity)
        {
            return await (_bookCategoryRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await (_bookCategoryRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<BookCategory>> GetAllAsync()
        {
            return await (_bookCategoryRepository.GetAllAsync());
        }

        public Task<(IEnumerable<BookCategory> T, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel)
        {
            throw new NotImplementedException();
        }

        public async Task<BookCategory> GetByIdAsync(int id)
        {
            return await (_bookCategoryRepository.GetByIdAsync(id));
        }

        public async Task SaveAsync()
        {
            await (_bookCategoryRepository.SaveAsync());
        }

        public async Task<BookCategory> UpdateAsync(BookCategory entity)
        {
            return await (_bookCategoryRepository.UpdateAsync(entity));
        }
    }
}
