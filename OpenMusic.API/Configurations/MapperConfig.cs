using AutoMapper;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.User;

namespace OpenMusic.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<AlbumDetailsDto, Album>().ReverseMap();
            CreateMap<AlbumReadOnlyDto, Album>().ReverseMap();
            CreateMap<AlbumCreateDto, Album>().ReverseMap();
            CreateMap<AlbumUpdateDto, Album>().ReverseMap();


            CreateMap<ArtistDetailsDto, Artist>().ReverseMap();
            CreateMap<ArtistReadOnlyDto, Artist>().ReverseMap();
            CreateMap<ArtistCreateDto, Artist>().ReverseMap();
            CreateMap<ArtistUpdateDto, Artist>().ReverseMap();

            CreateMap<ApplicationUser, UserDto>().ReverseMap();
        }
    }
}
