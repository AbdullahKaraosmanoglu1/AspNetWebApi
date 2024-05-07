using BookApplication.Data.Entity;

namespace BookApplication.Data.Repository.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetByToken(string token);
    }
}
