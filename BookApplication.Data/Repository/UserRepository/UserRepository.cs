using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Data.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserRepository(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User entity)
        {
            return await _userRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
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
