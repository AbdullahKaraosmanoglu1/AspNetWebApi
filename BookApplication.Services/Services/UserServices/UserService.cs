using BookApplication.Data.Entity;
using BookApplication.Data.Models;
using BookApplication.Data.Repository.UserRepository;
using BookApplication.Services.NLog;

namespace BookApplication.Services.Service.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoggerService _loggerService;

        public UserService(IUserRepository userRepository, ILoggerService loggerService)
        {
            _userRepository = userRepository;
            _loggerService = loggerService;
        }

        public async Task<User> CreateAsync(User entity)
        {
            string message = $"New User registered E-Mail, information:{entity.Email}";
            await (_loggerService.LogInfo(message));

            return await (_userRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string message = $"User wanted to delete account ID, information:{id}";
            await (_loggerService.LogWarning(message));

            return await (_userRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await (_userRepository.GetAllAsync());
        }

        public async Task<(IEnumerable<User> Users, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel)
        {
            return await _userRepository.GetAllWithPaginationAsync(pagenationModel);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await (_userRepository.GetByIdAsync(id));
        }

        public async Task<User> GetByTokenAsync(string token)
        {
            return await (_userRepository.GetByTokenAsync(token));
        }

        public async Task SaveAsync()
        {
            await (_userRepository.SaveAsync());
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return await (_userRepository.UpdateAsync(entity));
        }
    }
}
