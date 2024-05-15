using BookApplication.Data.Entity;
using BookApplication.Data.Models;

namespace BookApplication.Data.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
        Task<(IEnumerable<T> T, int TotalCount)> GetAllWithPagenationAsync(PaginationModel pagenationModel);
    }
}
