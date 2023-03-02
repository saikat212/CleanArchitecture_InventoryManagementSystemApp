using InventoryManagementSystemInfrastructure.DataContext;
using InventoryManagementSystemInfrastructure.IService;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryManagementSystemInfrastructure.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext context;
        public BaseService(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        // Implementing IBaseRepository


        #region Searching
        public async Task<TEntity> Get(int Id)
        {
            return await context.Set<TEntity>().FindAsync(Id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }
        public async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        #endregion

        #region Saving
        public async Task Save(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task SaveAll(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Deleting
        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
        public void RemoveAll(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
        }
        #endregion
        #region Updating
        public async Task Update(TEntity entity)
        {
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
