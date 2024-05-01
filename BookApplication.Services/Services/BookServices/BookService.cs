using BookApplication.Data.Entity;
using BookApplication.Data.Repository.BookRepository;
using BookApplication.Services.SlugHelper;

namespace BookApplication.Services.Service.BookServices
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
            var slugName = entity.Name + " " + entity.Author;
            var slugifiedName = slugName.GenerateSlugName();
            entity.SlugName = slugifiedName;

            //var slugifiedImagePath = entity.ImagePath.GenerateSlugForImages();
            //entity.ImagePath = slugifiedImagePath;

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
