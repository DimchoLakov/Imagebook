using System.Collections.Generic;
using System.Threading.Tasks;
using Imagebook.Data.ViewModels.Albums;

namespace Imagebook.Services.Contracts
{
    public interface IAlbumsService
    {
        Task<ICollection<IndexAlbumViewModel>> GetAllAsync();

        Task<AlbumEditDeleteDetailsViewModel> GetByIdAsync(string id);

        Task<PageAlbumViewModel> GetPageAsync(int? currentPage);

        Task CreateAsync(CreateAlbumViewModel viewModel);

        Task EditByIdAsync(string id);

        Task DeleteByIdAsync(string id);
    }
}
