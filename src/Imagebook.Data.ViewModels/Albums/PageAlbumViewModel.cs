using System.Collections.Generic;

namespace Imagebook.Data.ViewModels.Albums
{
    public class PageAlbumViewModel
    {
        public PageAlbumViewModel()
        {
            this.IndexAlbumViewModels = new List<IndexAlbumViewModel>();
        }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public ICollection<IndexAlbumViewModel> IndexAlbumViewModels { get; set; }
    }
}
