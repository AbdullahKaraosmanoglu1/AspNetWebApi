using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Data.Repository.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IGenericRepository<Admin> _adminRepository;

        private readonly BookAppDataBaseContext _bookAppDataBaseContext;

        public AdminRepository(IGenericRepository<Admin> adminRepository, BookAppDataBaseContext bookAppDataBaseContext)
        {
            _adminRepository = adminRepository;
            _bookAppDataBaseContext = bookAppDataBaseContext;
        }

        public async Task<Admin> CreateAsync(Admin entity)
        {
            return await _adminRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _adminRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _adminRepository.GetAllAsync();
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await _adminRepository.GetByIdAsync(id);
        }

        public async Task<Admin> GetByTokenAsync(string token)
        {
            return await _bookAppDataBaseContext.Admins.FirstOrDefaultAsync(x => x.AccessToken == token && x.IsDeleted == false);
        }

        public async Task SaveAsync()
        {
            await (_adminRepository.SaveAsync());
        }

        public async Task<Admin> UpdateAsync(Admin entity)
        {
            return await (_adminRepository.UpdateAsync(entity));
        }
    }
}
