using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imagebook.Data.Repositories.Contracts
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<ICollection<TEntity>> GetAllAsync();

        Task<ICollection<TEntity>> GetPageAsync(int skip, int take);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<TEntity> GetByIdAsync(params object[] id);

        Task<int> SaveChangesAsync();

        Task<int> CountAsync();

        Task<bool> EntityExists(string id);
    }
}
