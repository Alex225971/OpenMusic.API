﻿using AutoMapper;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;

namespace OpenMusic.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<AlbumDetailsDto, Album>().ReverseMap();
            CreateMap<AlbumReadOnlyDto, Album>().ReverseMap();
            CreateMap<AlbumCreateDto, Album>().ReverseMap();
            CreateMap<Album, AlbumReadOnlyDto>()
                .ForMember(a => a.ArtistName, a => a.MapFrom(map => $"{map.Artist.Name}"))
                .ReverseMap();
            CreateMap<Album, AlbumDetailsDto>()
                .ForMember(a => a.ArtistName, a => a.MapFrom(map => $"{map.Artist.Name}"))
                .ReverseMap();
        }
    }
}
