using BookApplication.Data.Entity;

namespace BookApplication.Data.Repository.AuthRepository
{
    public interface IAuthRepository : IGenericRepository<User>
    {
        Task<User> UserLoginAsync(User user);
    }
}
