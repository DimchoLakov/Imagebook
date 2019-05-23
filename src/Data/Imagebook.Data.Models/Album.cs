using System;
using System.Collections.Generic;

namespace Imagebook.Data.Models
{
    public class Album : BaseEntity
    {
        public Album()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pictures = new List<Picture>();
            this.Comments = new List<Comment>();
            this.AlbumTags = new List<TagAlbum>();
        }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<TagAlbum> AlbumTags { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
