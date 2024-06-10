using BookApplication.Data.Entity;
using BookApplication.Data.Models;
using BookApplication.Data.Repository.BookCategoryRepository;
using BookApplication.Services.NLog;
using BookApplication.Services.SlugHelper;

namespace BookApplication.Services.Service.BookCategoryServices
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        private readonly ILoggerService _loggerService;


        public BookCategoryService(IBookCategoryRepository bookCategoryRepository, ILoggerService loggerService)
        {
            _bookCategoryRepository = bookCategoryRepository;
            _loggerService = loggerService;
        }

        public async Task<BookCategory> CreateAsync(BookCategory entity)
        {
            var slugName = entity.Name;
            var slugifiedName = slugName.GenerateSlugName();
            entity.SlugName = slugifiedName;
            //var slugifiedImagePath = entity.ImagePath.GenerateSlugForImages();
            //entity.ImagePath = slugifiedImagePath;

            string message = $"New BookCategory created, information:{entity.Name}";
            await (_loggerService.LogInfo(message));

            return await (_bookCategoryRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string message = $"Adnmin delete BookCategory, ID information:{id}";
            await (_loggerService.LogWarning(message));

            return await (_bookCategoryRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<BookCategory>> GetAllAsync()
        {
            return await (_bookCategoryRepository.GetAllAsync());
        }

        public async Task<(IEnumerable<BookCategory> BookCategories, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel)
        {
            return await _bookCategoryRepository.GetAllWithPaginationAsync(pagenationModel);
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
            var slugName = entity.Name;
            var slugifiedName = slugName.GenerateSlugName();
            entity.SlugName = slugifiedName;

            //var slugifiedImagePath = entity.ImagePath.GenerateSlugForImages();
            //entity.ImagePath = slugifiedImagePath;

            return await (_bookCategoryRepository.UpdateAsync(entity));
        }
    }
}
