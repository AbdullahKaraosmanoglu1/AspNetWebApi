using BookApplication.Data.Entity;
using BookApplication.Data.Models;

namespace BookApplication.Services.Service.RoleService
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role entity);
        Task<Role> UpdateAsync(Role entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();

        Task<(IEnumerable<Role> T, int TotalCount)> GetAllWithPagenationAsync(PaginationModel pagenationModel);
    }
}
