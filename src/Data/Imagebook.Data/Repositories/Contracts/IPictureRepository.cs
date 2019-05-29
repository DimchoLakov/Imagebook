using System.Linq;
using System.Threading.Tasks;
using Imagebook.Data.Models;

namespace Imagebook.Data.Repositories.Contracts
{
    public interface IPictureRepository : IRepository<Picture>
    {
        Task<IQueryable<Picture>> AllByAlbumId(string albumId);
    }
}
