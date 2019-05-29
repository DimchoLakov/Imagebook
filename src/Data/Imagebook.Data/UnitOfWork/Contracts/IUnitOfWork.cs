using System.Threading.Tasks;
using Imagebook.Data.Repositories.Contracts;

namespace Imagebook.Data.UnitOfWork.Contracts
{
    public interface IUnitOfWork
    {
        IAlbumRepository Albums { get; }

        IPictureRepository Pictures { get; }

        Task<int> SaveChangesAsync();
    }
}
