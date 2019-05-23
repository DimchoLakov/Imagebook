using System.Threading.Tasks;
using Imagebook.Services.Contracts;
using Imagebook.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Imagebook.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this._albumsService = albumsService;
        }

        [Authorize(Roles = UserRoleConstants.AdminUser)]
        [HttpGet]
        public async Task<IActionResult> All(int? currentPage = 1)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.LocalRedirect("/Identity/Account/Login");
            }

            var albums = await this._albumsService.GetPageAsync(currentPage);

            return this.View(albums);
        }

        [Authorize(Roles = UserRoleConstants.AdminUser)]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var album = await this._albumsService.GetByIdAsync(id);

            return this.View(album);
        }
    }
}
