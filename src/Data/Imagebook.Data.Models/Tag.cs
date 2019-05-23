using System;
using System.Collections.Generic;

namespace Imagebook.Data.Models
{
    public class Tag : BaseEntity
    {
        public Tag()
        {
            this.Id = Guid.NewGuid().ToString();
            this.TagAlbums = new List<TagAlbum>();
        }

        public string Name { get; set; }

        public virtual ICollection<TagAlbum> TagAlbums { get; set; }
    }
}
