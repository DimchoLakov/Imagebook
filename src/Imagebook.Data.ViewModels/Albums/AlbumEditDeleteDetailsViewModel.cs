using System.ComponentModel.DataAnnotations;
using Imagebook.Data.ViewModels.Constants;

namespace Imagebook.Data.ViewModels.Albums
{
    public class AlbumEditDeleteDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name = AlbumConstants.Name)]
        [Required]
        public string Name { get; set; }

        [Display(Name = AlbumConstants.CreatedOn)]
        public string CreatedOn { get; set; }

        [Display(Name = AlbumConstants.Description)]
        [Required]
        public string Description { get; set; }

        [Display(Name = AlbumConstants.Username)]
        [Required]
        public string Username { get; set; }
        
        [Display(Name = AlbumConstants.Location)]
        public string Location { get; set; }
    }
}
