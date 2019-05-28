using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Imagebook.Data.Models;
using Imagebook.Data.Repositories.Contracts;
using Imagebook.Data.ViewModels.Albums;
using Imagebook.Services.Constants;
using Imagebook.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Imagebook.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsRepository _repository;
        private readonly IMapper _mapper;

        public AlbumsService(IAlbumsRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<IndexAlbumViewModel>> GetAllAsync()
        {
            var allAlbums = await this._repository.AllAsync();
            var albumsViewModels = this._mapper.Map<IEnumerable<Album>, IEnumerable<IndexAlbumViewModel>>(allAlbums).ToList();

            return albumsViewModels;
        }

        public async Task<AlbumEditDeleteDetailsViewModel> GetByIdAsync(string id)
        {
            var album = await this._repository.GetByIdAsync(id);
            var albumViewModel = this._mapper.Map<Album, AlbumEditDeleteDetailsViewModel>(album);

            return albumViewModel;
        }

        public async Task<PageAlbumViewModel> GetPageAsync(string search, string sortOrder, int? currentPage = PageConstants.DefaultPageIndex)
        {
            var pageSize = PageConstants.PageSize;
            var skip = Convert.ToInt32(currentPage - 1) * pageSize;
            var take = pageSize;

            // Get all albums as IQueryable
            var allAlbums = await this._repository.AllAsync();

            // Sort all ablums
            switch (sortOrder)
            {
                case AlbumServiceConstants.OrderByNameInDescending:
                    allAlbums = allAlbums.OrderByDescending(a => a.Name);
                    break;
                case AlbumServiceConstants.OrderByDateInDescending:
                    allAlbums = allAlbums.OrderByDescending(a => a.CreatedOn);
                    break;
                case AlbumServiceConstants.OrderByDateInAscending:
                    allAlbums = allAlbums.OrderBy(a => a.CreatedOn);
                    break;
                case AlbumServiceConstants.OrderByLocationInDescending:
                    allAlbums = allAlbums.OrderByDescending(a => a.Location.Name);
                    break;
                case AlbumServiceConstants.OrderByLocationInAscending:
                    allAlbums = allAlbums.OrderBy(a => a.Location.Name);
                    break;
                default:
                    allAlbums = allAlbums.OrderBy(a => a.Name);
                    break;
            }

            // Get albums for single page
            var albums = await allAlbums.Skip(skip).Take(take).ToListAsync();
            var totalPages = (int)Math.Ceiling(decimal.Divide(await allAlbums.CountAsync(), pageSize));
            
            // If Search string is not null, get filtered albums for single page
            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchToLower = search.ToLower();
            
                //filter
                Expression<Func<Album, bool>> filter = a =>
                    a.Name.ToLower().Contains(searchToLower) ||
                    a.Location.Name.ToLower().Contains(searchToLower) ||
                    a.Description.ToLower().Contains(searchToLower);

                albums = await allAlbums.Where(filter).Skip(skip).Take(take).ToListAsync();
                totalPages = (int)Math.Ceiling(decimal.Divide(await allAlbums.Where(filter).CountAsync(), pageSize));
            }

            var albumViewModels = this._mapper.Map<IEnumerable<Album>, IEnumerable<IndexAlbumViewModel>>(albums).ToList();
            var pageAlbumViewModel = new PageAlbumViewModel
            {
                CurrentPage = currentPage.GetValueOrDefault(),
                TotalPages = totalPages,
                IndexAlbumViewModels = albumViewModels,
                NameSortParam =
                    string.IsNullOrWhiteSpace(sortOrder) ? AlbumServiceConstants.OrderByNameInDescending : AlbumServiceConstants.OrderByNameInAscending,
                DateSortParam =
                    sortOrder == AlbumServiceConstants.OrderByDateInAscending ? AlbumServiceConstants.OrderByDateInDescending : AlbumServiceConstants.OrderByDateInAscending,
                LocationSortParam =
                    sortOrder == AlbumServiceConstants.OrderByLocationInAscending ? AlbumServiceConstants.OrderByLocationInDescending : AlbumServiceConstants.OrderByLocationInAscending,
                Search = search
            };

            return pageAlbumViewModel;
        }

        public async Task CreateAsync(CreateAlbumViewModel viewModel)
        {
            var album = this._mapper.Map<Album>(viewModel);

            await this._repository.AddAsync(album);

            await this._repository.SaveChangesAsync();
        }

        public async Task EditAsync(AlbumEditDeleteDetailsViewModel viewModel)
        {
            var album = this._mapper.Map<Album>(viewModel);
            this._repository.Update(album);

            await this._repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await this._repository.Delete(id);

            await this._repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(AlbumEditDeleteDetailsViewModel viewModel)
        {
            var album = this._mapper.Map<Album>(viewModel);

            this._repository.Delete(album);

            await this._repository.SaveChangesAsync();
        }
    }
}
