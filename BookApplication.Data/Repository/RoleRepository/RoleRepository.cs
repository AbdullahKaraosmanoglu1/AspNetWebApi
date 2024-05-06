using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Data.Repository.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IGenericRepository<Role> _RoleRepository;
        private readonly BookAppDataBaseContext _context;
        public RoleRepository(IGenericRepository<Role> RoleRepository, BookAppDataBaseContext context)
        {
            _RoleRepository = RoleRepository;
            _context = context;
        }

        public async Task<Role> CreateAsync(Role entity)
        {
            var Role = await _RoleRepository.CreateAsync(entity);
            return Role;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _RoleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _RoleRepository.GetAllAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _RoleRepository.GetByIdAsync(id);
        }


        public async Task SaveAsync()
        {
            await _RoleRepository.SaveAsync();
        }

        public async Task<Role> UpdateAsync(Role entity)
        {
            return await _RoleRepository.UpdateAsync(entity);
        }
    }
}
