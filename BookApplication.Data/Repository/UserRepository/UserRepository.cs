using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using BookApplication.Data.Models;
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

        public async Task<(IEnumerable<User> T, int TotalCount)> GetAllWithPaginationAsync(PaginationModel paginationModel)
        {
            var startIndex = (paginationModel.PageNumber - 1) * paginationModel.PageSize;

            var query = _bookAppDataBaseContext.Users
                .Where(x => x.IsDeleted == false && x.IsActive != true);

            if (!string.IsNullOrWhiteSpace(paginationModel.SearchTerm))
            {
                var searchTermLower = paginationModel.SearchTerm.ToLower();
                query = query.Where(x => (x.FirstName + " " + x.LastName).ToLower().Contains(searchTermLower));
            }

            var usersOnPage = await query
                .Skip(startIndex)
                .Take(paginationModel.PageSize)
                .ToListAsync();

            var totalCount = await query.CountAsync();

            return (usersOnPage, totalCount);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetByTokenAsync(string token)
        {
            return await _bookAppDataBaseContext.Users.FirstOrDefaultAsync(x => x.AccessToken == token && x.IsDeleted == false);
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
