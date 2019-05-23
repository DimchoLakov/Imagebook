using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Imagebook.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Albums = new List<Album>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PictureId { get; set; }
        public virtual Picture Picture { get; set; }

        public override string UserName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
