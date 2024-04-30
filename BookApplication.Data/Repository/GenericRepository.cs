using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
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
            T entity = await _table.Where(x => x.Id == id && x.IsDeleted != true).FirstOrDefaultAsync();

            if (entity == null)
            {
                return false;
            }

            entity.IsDeleted = true;
            _dbContext.Entry(entity).State = EntityState.Modified;

            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.Where(x => x.IsDeleted == false && x.IsActive != false).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
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
    }
}
