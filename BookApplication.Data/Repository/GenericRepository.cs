using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using BookApplication.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        /*private*/
        private BookAppDataBaseContext _dbContext;
        private DbSet<T> _table;

        public GenericRepository(BookAppDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            _table = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
            entity.IsDeleted = false;


            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await _table.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

            if (entity != null)
            {
                entity.IsDeleted = true;
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.Where(x => x.IsDeleted == false && x.IsActive != false).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {

            _table.Update(entity);

            return entity;
        }
        public async Task<(IEnumerable<T> T, int TotalCount)> GetAllWithPagenationAsync(PaginationModel paginationModel)
        {
            var startIndex = (paginationModel.PageNumber - 1) * paginationModel.PageSize;
            var tablesOnPage = _table
            .Where(x => x.IsDeleted == false && x.IsActive != false)
            .Skip(startIndex)
            .Take(paginationModel.PageSize);

            var totalCount = await _table
                  .Where(x => x.IsDeleted == false && x.IsActive != false)
                  .CountAsync();

            return (tablesOnPage, totalCount);
        }
    }
}
