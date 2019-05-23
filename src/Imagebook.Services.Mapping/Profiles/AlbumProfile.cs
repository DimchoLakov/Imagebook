using AutoMapper;
using Imagebook.Data.Models;
using Imagebook.Data.ViewModels.Albums;
using Imagebook.Data.ViewModels.Constants;

namespace Imagebook.Services.Mapping.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            this.CreateMap<Album, IndexAlbumViewModel>()
                .ForMember(dest => dest.CreatedOn, from => from.MapFrom(
                        src => src.CreatedOn.ToString(AlbumConstants.DateTimeFormat)))
                .ForMember(dest => dest.PicturesCount, from => from.MapFrom(
                    src => src.Pictures.Count))
                .ForMember(dest => dest.CommentsCount, from => from.MapFrom(
                    src => src.Comments.Count))
                .ForMember(dest => dest.TagsCount, from => from.MapFrom(
                    src => src.AlbumTags.Count))
                .ForMember(dest => dest.Location, from => from.MapFrom(src => src.Location.Name))
                .ReverseMap();

            this.CreateMap<Album, AlbumEditDeleteDetailsViewModel>()
                .ForMember(dest => dest.CreatedOn,
                    from => from.MapFrom(src => src.CreatedOn.ToString(AlbumConstants.DateTimeFormat)))
                .ForMember(dest => dest.Location, from => from.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.Username, from => from.MapFrom(src => src.User.UserName))
                .ReverseMap();

            this.CreateMap<Album, PageAlbumViewModel>()
                .ReverseMap();
        }
    }
}
