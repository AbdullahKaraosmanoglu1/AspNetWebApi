using BookApplication.Data.Entity;
using BookApplication.Data.Models;

namespace BookApplication.Services.Services.AdminService
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> GetByIdAsync(int id);
        Task<Admin> CreateAsync(Admin entity);
        Task<Admin> UpdateAsync(Admin entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();

        Task<Admin> GetByTokenAsync(string token);
        Task<(IEnumerable<Admin> Admins, int TotalCount)> GetAllWithPaginationAsync(PaginationModel pagenationModel);
    }
}
