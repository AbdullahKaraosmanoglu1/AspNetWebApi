using BookApplication.Data.Entity;
using BookApplication.Data.Repository.UserBookRepository;

namespace BookApplication.Services.Service.UserBookServices
{
    public class UserBookService : IUserBookService
    {
        private readonly IUserBookRepository _userBookRepository;

        public UserBookService(IUserBookRepository userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<UserBook> CreateAsync(UserBook entity)
        {
            return await _userBookRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
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
