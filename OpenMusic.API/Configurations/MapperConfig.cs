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

            CreateMap<ApplicationUser, UserDto>().ReverseMap();

            CreateMap<string, DateOnly>().ConvertUsing<DateTimeConverter>();

            CreateMap<ArtistDetailsDto, Artist>().ReverseMap();
            CreateMap<ArtistReadOnlyDto, Artist>().ReverseMap();
            CreateMap<ArtistCreateDto, Artist>()
                //.ForMember(d => d.Albums, opt => opt.MapFrom(s => s.Albums))
                .ReverseMap();
            CreateMap<ArtistUpdateDto, Artist>().ReverseMap();
            CreateMap<ArtistDetailsDto, ArtistReadOnlyDto>().ReverseMap();

            CreateMap<AlbumDetailsDto, Album>().ReverseMap();
            CreateMap<AlbumReadOnlyDto, Album>().ReverseMap();
            CreateMap<AlbumCreateDto, Album>()
                //.ForMember(d => d.Songs, opt => opt.MapFrom(s => s.Songs))
                .ReverseMap();
            CreateMap<AlbumUpdateDto, Album>().ReverseMap();

            CreateMap<SongPlaybackDto, Song>().ReverseMap();
            CreateMap<SongDetailsDto, Song>().ReverseMap();
            CreateMap<SongCreateDto, Song>()
                //.ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId))
                //.ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId))
                .ReverseMap();
        }
    }
}
