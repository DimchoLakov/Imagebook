using System;

namespace Imagebook.Data.Models
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Heading { get; set; }

        public string Content { get; set; }

        public string AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public string PictureId { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
