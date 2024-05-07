using BookApplication.Data.Entity;

namespace BookApplication.Data.Repository.AdminRepository
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        public Task<Admin> GetByToken(string token);
    }
}
