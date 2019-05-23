using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Imagebook.Data.Models;
using Imagebook.Data.Repositories;
using Imagebook.Data.Repositories.Contracts;
using Imagebook.Data.ViewModels.Albums;
using Imagebook.Services.Constants;
using Imagebook.Services.Contracts;

namespace Imagebook.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IRepository<Album> _repository;
        private readonly IMapper _mapper;

        public AlbumsService(IRepository<Album> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<IndexAlbumViewModel>> GetAllAsync()
        {
            var allAlbums = await this._repository.GetAllAsync();
            var albumsViewModels = this._mapper.Map<IEnumerable<Album>, IEnumerable<IndexAlbumViewModel>>(allAlbums).ToList();

            return albumsViewModels;
        }

        public async Task<AlbumEditDeleteDetailsViewModel> GetByIdAsync(string id)
        {
            var album = await this._repository.GetByIdAsync(id);
            var albumViewModel = this._mapper.Map<Album, AlbumEditDeleteDetailsViewModel>(album);

            return albumViewModel;
        }

        public async Task<PageAlbumViewModel> GetPageAsync(int? currentPage = PageConstants.DefaultPageIndex)
        {
            var pageSize = PageConstants.PageSize;
            var skip = Convert.ToInt32(currentPage - 1) * pageSize;
            var take = pageSize;

            var albums = await this._repository.GetPageAsync(skip, take);
            var albumViewModels = this._mapper.Map<IEnumerable<Album>, IEnumerable<IndexAlbumViewModel>>(albums).ToList();

            var albumsCount = await this._repository.CountAsync();
            var totalPages = (int)Math.Ceiling(decimal.Divide(albumsCount, pageSize));

            var pageAlbumViewModel = new PageAlbumViewModel()
            {
                CurrentPage = currentPage.GetValueOrDefault(),
                TotalPages = totalPages,
                IndexAlbumViewModels = albumViewModels
            };

            return pageAlbumViewModel;
        }

        public Task CreateAsync(CreateAlbumViewModel viewModel)
        {
            return this._repository.SaveChangesAsync();
        }

        public Task EditByIdAsync(string id)
        {
            return this._repository.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(string id)
        {
            return this._repository.SaveChangesAsync();
        }
    }
}
