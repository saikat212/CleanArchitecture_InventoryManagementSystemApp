using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemInfrastructure.IService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        // Searching Objects
        Task<TEntity> GetById(int Id);
        Task<TEntity> GetByName(string name);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        // Saving objects
        Task Save(TEntity entity);
        Task SaveAll(IEnumerable<TEntity> entities);

        // Removing objects
        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);

        // Updating
        Task Update(TEntity entity);
    }
}
