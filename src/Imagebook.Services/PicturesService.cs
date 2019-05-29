using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Imagebook.Data.Models;
using Imagebook.Data.UnitOfWork.Contracts;
using Imagebook.Data.ViewModels.Pictures;
using Imagebook.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace Imagebook.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PicturesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PictureViewModel> GetByIdAsync(string id)
        {
            var picture = await this._unitOfWork.Pictures.GetByIdAsync(id);
            var pictureViewModel = this._mapper.Map<Picture, PictureViewModel>(picture);

            return pictureViewModel;
        }

        public async Task UploadAsync(string id, IFormFile file)
        {
            long size = file.Length;

            var picture = new Picture();

            if (size > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    picture.ImageArray = stream.ToArray();
                    picture.Name = file.FileName;
                    picture.AlbumId = id;
                }
            }

            await this._unitOfWork.Pictures.AddAsync(picture);
            await this._unitOfWork.SaveChangesAsync();
        }
    }
}
