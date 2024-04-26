using BookApplication.Data.BookApplicationDbContext;
using BookApplication.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookApplication.Data.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        /*private*/
        protected BookAppDataBaseContext _dbContext;
        private DbSet<T> _table;

        public GenericRepository(BookAppDataBaseContext dbContext, DbSet<T> table)
        {
            _dbContext = dbContext;
            _table = table;
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
            return await _table.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression,
            bool trackChanges) =>
             !trackChanges ?
            _dbContext.Set<T>().Where(expression).AsNoTracking() :
            _dbContext.Set<T>().Where(expression);



        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            _table.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
