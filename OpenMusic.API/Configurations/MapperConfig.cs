using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenMusic.API.Data;
using OpenMusic.API.Helpers;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Song;
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
            CreateMap<ArtistDetailsDto, ArtistReadOnlyDto>().ReverseMap();

            CreateMap<ApplicationUser, UserDto>().ReverseMap();

            CreateMap<string, DateOnly>().ConvertUsing<DateTimeConverter>();

            CreateMap<SongPlaybackDto, Song>().ReverseMap();
            CreateMap<SongDetailsDto, Song>().ReverseMap();
            CreateMap<SongCreateDto, Song>()
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId));
            CreateMap<Song, SongCreateDto>()
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId));
        }
    }
}
