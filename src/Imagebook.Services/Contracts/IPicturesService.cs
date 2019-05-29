using System.Threading.Tasks;
using Imagebook.Data.ViewModels.Pictures;
using Microsoft.AspNetCore.Http;

namespace Imagebook.Services.Contracts
{
    public interface IPicturesService
    {
        Task<PictureViewModel> GetByIdAsync(string id);

        Task UploadAsync(string id, IFormFile file);
    }
}
