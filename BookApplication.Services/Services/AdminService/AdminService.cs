using BookApplication.Data.Entity;
using BookApplication.Data.Repository.AdminRepository;
using BookApplication.Data.Repository.UserRepository;
using BookApplication.Services.NLog;

namespace BookApplication.Services.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ILoggerService _loggerService;

        public AdminService(IAdminRepository adminRepository, ILoggerService loggerService)
        {
            _adminRepository = adminRepository;
            _loggerService = loggerService;
        }

        public async Task<Admin> CreateAsync(Admin entity)
        {
            return await (_adminRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await (_adminRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await (_adminRepository.GetAllAsync());
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await (_adminRepository.GetByIdAsync(id));
        }

        public async Task<Admin> GetByTokenAsync(string token)
        {
            return await (_adminRepository.GetByTokenAsync(token));
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
