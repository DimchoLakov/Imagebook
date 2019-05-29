using System.Threading.Tasks;
using Imagebook.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imagebook.Web.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IPicturesService _picturesService;

        public PicturesController(IPicturesService picturesService)
        {
            this._picturesService = picturesService;
        }

        public async Task<IActionResult> Show(string id)
        {
            var picture = await this._picturesService.GetByIdAsync(id);
            
            return this.View(picture);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(string id, IFormFile file)
        {
            await this._picturesService.UploadAsync(id, file);

            return await Task.Run(() => this.RedirectToAction("Details", "Albums", new { id }));
        }
    }
}