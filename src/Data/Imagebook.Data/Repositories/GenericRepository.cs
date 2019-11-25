using Imagebook.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imagebook.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ImagebookDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ImagebookDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> AllAsync()
        {
            return await Task.Run(() => this._dbSet.AsQueryable());
        }

        public async Task AddAsync(TEntity entity)
        {
            await this._dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            this._dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public async Task Delete(string id)
        {
            var entity = await this.GetByIdAsync(id);

            if (entity != null)
            {
                this._dbSet.Remove(entity);
            }
        }

        public async Task Delete(Expression<Func<TEntity, bool>> filter)
        {
            var entities = await this.AllAsync(filter);
            this._dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> GetByIdAsync(params object[] id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public async Task<int> CountAsync()
        {
            return await this._dbSet.CountAsync();
        }

        public async Task<bool> EntityExistsAsync(string id)
        {
            var entity = await this.GetByIdAsync(id);

            return entity != null;
        }

        public async Task<IQueryable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Task.Run(() => this._dbSet.Where(filter).AsQueryable());
        }
    }
}