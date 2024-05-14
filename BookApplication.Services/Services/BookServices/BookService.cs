using BookApplication.Data.Entity;
using BookApplication.Data.Repository.BookRepository;
using BookApplication.Services.NLog;
using BookApplication.Services.SlugHelper;

namespace BookApplication.Services.Service.BookServices
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILoggerService _loggerService;

        public BookService(IBookRepository bookRepository, ILoggerService loggerService)
        {
            _bookRepository = bookRepository;
            _loggerService = loggerService;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            var slugName = entity.Name + " " + entity.Author;
            var slugifiedName = slugName.GenerateSlugName();
            entity.SlugName = slugifiedName;
            //var slugifiedImagePath = entity.ImagePath.GenerateSlugForImages();
            //entity.ImagePath = slugifiedImagePath;

            string message = $"New Book created, information:{entity.Name}";
            await (_loggerService.LogInfo(message));

            return await (_bookRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string message = $"Adnmin delete Book, ID information:{id}";
            await (_loggerService.LogWarning(message));

            return await (_bookRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await (_bookRepository.GetAllAsync());
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId)
        {
            return await (_bookRepository.GetBooksByCategoryIdAsync(categoryId));
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await (_bookRepository.GetByIdAsync(id));
        }

        public async Task SaveAsync()
        {
            await (_bookRepository.SaveAsync());
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            var slugName = entity.Name + " " + entity.Author;
            var slugifiedName = slugName.GenerateSlugName();
            entity.SlugName = slugifiedName;

            //var slugifiedImagePath = entity.ImagePath.GenerateSlugForImages();
            //entity.ImagePath = slugifiedImagePath;

            return await (_bookRepository.UpdateAsync(entity));
        }
    }
}
