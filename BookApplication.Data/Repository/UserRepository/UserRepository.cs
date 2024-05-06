using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Data.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly BookAppDataBaseContext _bookAppDataBaseContext;

        public UserRepository(IGenericRepository<User> userRepository, BookAppDataBaseContext bookAppDataBaseContext)
        {
            _userRepository = userRepository;
            _bookAppDataBaseContext = bookAppDataBaseContext;
        }

        public async Task<User> CreateAsync(User entity)
        {
            var test = await _bookAppDataBaseContext.Users.AddAsync(entity);
            var test1 = _bookAppDataBaseContext.Users.Include(x => x.Role);
            entity.IsDeleted = false;

            return entity;
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
