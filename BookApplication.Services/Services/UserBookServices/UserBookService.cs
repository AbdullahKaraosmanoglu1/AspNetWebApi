using BookApplication.Data.Entity;
using BookApplication.Data.Repository.UserBookRepository;
using BookApplication.Services.NLog;

namespace BookApplication.Services.Service.UserBookServices
{
    public class UserBookService : IUserBookService
    {
        private readonly IUserBookRepository _userBookRepository;
        private readonly ILoggerService _loggerService;

        public UserBookService(IUserBookRepository userBookRepository, ILoggerService loggerService)
        {
            _userBookRepository = userBookRepository;
            _loggerService = loggerService;
        }

        public async Task<UserBook> CreateAsync(UserBook entity)
        {
            string message = $"User claimed Book, information: UserId = {entity.UserId} and BookId = {entity.BookId} ";
            await _loggerService.LogInfo(message);

            return await _userBookRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string message = $"Adnmin delete UserBook, ID information:{id}";
            await _loggerService.LogWarning(message);

            return await (_userBookRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<UserBook>> GetAllAsync()
        {
            return await _userBookRepository.GetAllAsync();
        }

        public async Task<UserBook> GetByIdAsync(int id)
        {
            return await _userBookRepository.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _userBookRepository.SaveAsync();
        }

        public async Task<UserBook> UpdateAsync(UserBook entity)
        {
            return await _userBookRepository.UpdateAsync(entity);
        }
    }
}
