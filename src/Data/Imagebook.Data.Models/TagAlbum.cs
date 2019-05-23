namespace Imagebook.Data.Models
{
    public class TagAlbum
    {
        public string TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public string AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}
