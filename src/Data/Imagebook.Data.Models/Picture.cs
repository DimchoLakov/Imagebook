using System;
using System.Collections.Generic;

namespace Imagebook.Data.Models
{
    public class Picture : BaseEntity
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new List<Comment>();
        }

        public string Name { get; set; }

        public byte[] ImageArray { get; set; }

        public string AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public string LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
