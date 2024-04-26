using BookApplication.Data.Entity;
using BookApplication.Data.Repository.UserRepository;

namespace BookApplication.Services.Service.UserServices
{
    public class UserSevice : IUserSevice
    {
        private readonly UserRepository _userRepository;

        public UserSevice(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User entity)
        {
            return await _userRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await (_userRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _userRepository.SaveAsync();
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }
    }
}
