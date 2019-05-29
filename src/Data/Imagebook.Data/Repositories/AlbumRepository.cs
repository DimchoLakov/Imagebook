using Imagebook.Data.Models;
using Imagebook.Data.Repositories.Contracts;

namespace Imagebook.Data.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ImagebookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
