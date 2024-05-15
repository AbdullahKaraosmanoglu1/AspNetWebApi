using BookApplication.Data.Entity;
using BookApplication.Data.Models;
using BookApplication.Data.Repository.RoleRepository;
using BookApplication.Services.NLog;

namespace BookApplication.Services.Service.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly ILoggerService _loggerService;

        public RoleService(IRoleRepository RoleRepository, ILoggerService loggerService)
        {
            _RoleRepository = RoleRepository;
            _loggerService = loggerService;
        }

        public async Task<Role> CreateAsync(Role entity)
        {

            return await (_RoleRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string message = $"Role wanted to delete account ID, information:{id}";
            await (_loggerService.LogWarning(message));

            return await (_RoleRepository.DeleteAsync(id));
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await (_RoleRepository.GetAllAsync());
        }

        public async Task<(IEnumerable<Role> T, int TotalCount)> GetAllWithPagenationAsync(PaginationModel pagenationModel)
        {
            return await _RoleRepository.GetAllWithPaginationAsync(pagenationModel);
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await (_RoleRepository.GetByIdAsync(id));
        }

        public async Task SaveAsync()
        {
            await (_RoleRepository.SaveAsync());
        }

        public async Task<Role> UpdateAsync(Role entity)
        {
            return await (_RoleRepository.UpdateAsync(entity));
        }
    }
}
