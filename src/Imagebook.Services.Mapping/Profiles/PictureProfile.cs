using AutoMapper;
using Imagebook.Data.Models;
using Imagebook.Data.ViewModels.Pictures;
using Imagebook.Services.Mapping.Extensions;

namespace Imagebook.Services.Mapping.Profiles
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            this.CreateMap<Picture, PictureViewModel>()
                .ForMember(dest => dest.Src, from => from.MapFrom(src => src.ImageArray.GetBase64()))
                .ReverseMap();
        }
    }
}
