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
            var allPictures = await this.AllAsync();
            return allPictures.Where(p => p.AlbumId == albumId);
        }
    }
}
