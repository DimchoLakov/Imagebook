using System.Collections.Generic;
using System.Threading.Tasks;
using Imagebook.Data.ViewModels.Albums;

namespace Imagebook.Services.Contracts
{
    public interface IAlbumsService
    {
        Task<ICollection<IndexAlbumViewModel>> GetAllAsync();

        Task<AlbumEditDeleteDetailsViewModel> GetByIdAsync(string id);

        Task<PageAlbumViewModel> GetPageAsync(string search, string sortOrder, int? currentPage);

        Task CreateAsync(CreateAlbumViewModel viewModel);

        Task EditAsync(AlbumEditDeleteDetailsViewModel viewModel);

        Task DeleteAsync(string id);

        Task DeleteAsync(AlbumEditDeleteDetailsViewModel viewModel);
    }
}
