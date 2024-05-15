using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using BookApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Data.Repository.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IGenericRepository<User> _authRepository;

        private readonly BookAppDataBaseContext _bookAppDataBaseContext;

        public AuthRepository(IGenericRepository<User> authRepository, BookAppDataBaseContext bookAppDataBaseContext)
        {
            _authRepository = authRepository;
            _bookAppDataBaseContext = bookAppDataBaseContext;
        }

        public Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<User> T, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
           await _authRepository.SaveAsync();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UserLoginAsync(User user)
        {
            return await (_bookAppDataBaseContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password && x.IsDeleted == false && x.IsActive != false));
        }
    }
}
