using BookApplication.Data.Entity;

namespace BookApplication.Data.Repository.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetByTokenAsync(string token);
    }
}
