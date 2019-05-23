namespace Imagebook.Data.ViewModels.Albums
{
    public class IndexAlbumViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public string Description { get; set; }

        public int PicturesCount { get; set; }

        public int CommentsCount { get; set; }

        public int TagsCount { get; set; }

        public string Location { get; set; }
    }
}
