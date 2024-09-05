using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenMusic.API.Data;
using OpenMusic.API.Helpers;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Genre;
using OpenMusic.API.Models.Playlist;
using OpenMusic.API.Models.Song;
using OpenMusic.API.Models.User;

namespace OpenMusic.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {

            CreateMap<ApplicationUser, UserDto>().ReverseMap();

            CreateMap<string, DateOnly>().ConvertUsing<Helpers.DateOnlyToStringConverter>();

            CreateMap<ArtistDetailsDto, Artist>().ReverseMap();
            CreateMap<ArtistReadOnlyDto, Artist>().ReverseMap();
            CreateMap<ArtistCreateDto, Artist>()
                //.ForMember(d => d.Albums, opt => opt.MapFrom(s => s.Albums))
                .ReverseMap();
            CreateMap<ArtistUpdateDto, Artist>().ReverseMap();
            CreateMap<ArtistDetailsDto, ArtistReadOnlyDto>().ReverseMap();

            CreateMap<AlbumDetailsDto, Album>()
                .ForMember(d => d.AlbumGenres, opt => opt.MapFrom(a => a.Genres))
                .ReverseMap();
            CreateMap<AlbumReadOnlyDto, Album>().ReverseMap();
            CreateMap<AlbumCreateDto, Album>()
                .ForMember(d => d.AlbumGenres, opt => opt.MapFrom(a => a.Genres))
                .ForMember(d => d.Songs, opt => opt.MapFrom(s => s.Songs))
                .AfterMap((dto, album) =>
                {
                    // Set AlbumId for each Song
                    foreach (var song in album.Songs)
                    {
                        song.ArtistId = album.Id;
                    }
                })
                .ReverseMap();
            CreateMap<AlbumUpdateDto, Album>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .AfterMap((dto, album) =>
                {
                    // Set AlbumId for each Song
                    foreach (var song in album.Songs)
                    {
                        song.AlbumId = album.Id;
                    }
                })
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });

            CreateMap<Album, AlbumUpdateDto>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<AlbumInArtistDto, Album>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ReverseMap();

            CreateMap<SongInAlbumDto, Song>().ReverseMap();
            CreateMap<SongPlaybackDto, Song>().ReverseMap();
            CreateMap<SongDetailsDto, Song>().ReverseMap();
            CreateMap<SongUpdateDto, Song>()
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId))
                .ReverseMap();

            CreateMap<SongDetailsDto, Song>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<SongCreateDto, Song>()
                .ForMember(d => d.SongGenres, opt => opt.MapFrom(s => s.Genres))
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId))
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.AlbumId))
                .ReverseMap();

            CreateMap<GenreReadOnlyDto, Genre>().ReverseMap();
            CreateMap<SongGenre, Genre>().ReverseMap();
            CreateMap<AlbumGenre, Genre>().ReverseMap();
            CreateMap<GenreReadOnlyDto, SongGenre>().ReverseMap();
            CreateMap<GenreReadOnlyDto, AlbumGenre>().ReverseMap();

            CreateMap<Playlist, PlaylistPlaybackDto>().ReverseMap();
            CreateMap<Playlist, PlaylistCreateDto>().ReverseMap();

        }
    }
}
