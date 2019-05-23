using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imagebook.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Imagebook.Data.Repositories
{
    public class ImagebookDbRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ImagebookDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public ImagebookDbRepository(ImagebookDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await this._dbSet.ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetPageAsync(int skip, int take)
        {
            return await this._dbSet.Skip(skip).Take(take).ToListAsync();
        }


        public virtual async Task AddAsync(TEntity entity)
        {
            await this._dbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this._dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync(params object[] id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> CountAsync()
        {
            return await this._dbSet.CountAsync();
        }

        public virtual async Task<bool> EntityExists(string id)
        {
            return await this._dbSet.FindAsync(id) != null;
        }
    }
}
