using System.Linq;
using System.Threading.Tasks;
using Imagebook.Data.Models;
using Imagebook.Data.Repositories.Contracts;

namespace Imagebook.Data.Repositories
{
    public class PictureRepository : GenericRepository<Picture>, IPictureRepository
    {
        public PictureRepository(ImagebookDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IQueryable<Picture>> AllByAlbumId(string albumId)
        {
            return await this.AllAsync(x => x.AlbumId == albumId);
        }
    }
}
