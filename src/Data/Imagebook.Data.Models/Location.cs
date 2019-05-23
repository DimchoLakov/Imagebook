using System;
using System.Collections.Generic;

namespace Imagebook.Data.Models
{
    public class Location : BaseEntity
    {
        public Location()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Albums = new List<Album>();
            this.Pictures = new List<Picture>();
        }

        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
