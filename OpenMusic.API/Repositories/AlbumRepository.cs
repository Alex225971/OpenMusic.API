﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;

namespace OpenMusic.API.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly OpenMusicDbContext _dbContext;
        private readonly IMapper _mapper;

        public AlbumRepository(OpenMusicDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AlbumDetailsDto> GetAlbumDetailsAsync(int id)
        {
            return await _dbContext.Albums
                .Include(a => a.Songs)
                .ProjectTo<AlbumDetailsDto>(_mapper.ConfigurationProvider)
                .FirstAsync(a => a.Id == id);
        }

        public async Task<List<AlbumReadOnlyDto>> GetAllReadOnlyAsync()
        {
            return await _dbContext.Albums.Include(b => b.Artist).ProjectTo<AlbumReadOnlyDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<AlbumDetailsDto> GetDetailsAsync(int id)
        {
            return await _dbContext.Albums.Include(b => b.Artist).ProjectTo<AlbumDetailsDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(b => b.Id == id);
        }
    }
}
