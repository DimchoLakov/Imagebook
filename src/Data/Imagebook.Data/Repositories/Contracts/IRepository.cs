using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imagebook.Data.Repositories.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<IQueryable<TEntity>> AllAsync();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task Delete(string id);

        Task Delete(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetByIdAsync(params object[] id);
        
        Task<int> CountAsync();

        Task<bool> EntityExistsAsync(string id);
    }
}
