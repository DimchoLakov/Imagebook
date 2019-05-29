using System.Collections.Generic;
using System.Threading.Tasks;
using Imagebook.Data.Repositories;
using Imagebook.Data.Repositories.Contracts;
using Imagebook.Data.UnitOfWork.Contracts;

namespace Imagebook.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImagebookDbContext _dbContext;

        public UnitOfWork(ImagebookDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.Albums = new AlbumRepository(dbContext);
            this.Pictures = new PictureRepository(dbContext);
        }

        public IAlbumRepository Albums { get; }

        public IPictureRepository Pictures { get; }

        public Task<int> SaveChangesAsync()
        {
            return this._dbContext.SaveChangesAsync();
        }
    }
}
