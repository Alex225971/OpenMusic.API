﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Configurations;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Repositories
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        private readonly OpenMusicDbContext _dbContext;
        private readonly IMapper _mapper;

        public SongRepository(OpenMusicDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SongDetailsDto> GetSongDetailsAsync(int id)
        {
            return await _dbContext.Songs
                .ProjectTo<SongDetailsDto>(_mapper.ConfigurationProvider).FirstAsync(s => s.Id == id);
        }

        public async Task<SongPlaybackDto> GetForPlaybackAsync(int id)
        {
            return await _dbContext.Songs
                .Include(s => s.Artist)
                .Include(s => s.Album)
                .Include(s => s.SongGenres)
                .ProjectTo<SongPlaybackDto>(_mapper.ConfigurationProvider).FirstAsync(s => s.Id == id);
        }

        public async Task<SongDetailsDto> GetSongForUpdateAsync(int id)
        {
            return await _dbContext.Songs
                .ProjectTo<SongDetailsDto>(_mapper.ConfigurationProvider).FirstAsync(s => s.Id == id);
        }

        public async Task<List<SongSearchDto>> SearchForSongAsync(QueryParams queryParams)
        {
            return await _dbContext.Songs
                .Include(s => s.Artist)
                .Include(s => s.Album)
                .Where(s => s.Title.Contains(queryParams.queryString) || s.Album.Title.Contains(queryParams.queryString) || s.Artist.Name.Contains(queryParams.queryString))
                .Skip(queryParams.PageSize * (queryParams.PageNumber -1))
                .Take(queryParams.PageSize)
                .ProjectTo<SongSearchDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<SongDetailsDto>> GetAllSongDetailsAsync()
        {
            return await _dbContext.Songs
                .Include(s => s.Artist)
                .Include(s => s.Album)
                .ProjectTo<SongDetailsDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<SongPlaybackDto>> GetSongsFromArtistAsync(int id)
        {
            return await _dbContext.Songs
                .Include(s => s.Artist)
                .Include(s => s.Album)
                .Include(s => s.SongGenres)
                .ProjectTo<SongPlaybackDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
