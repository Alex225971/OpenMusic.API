using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Configurations;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Song;
using System.Linq;

namespace OpenMusic.API.Repositories
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        private readonly OpenMusicDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArtistRepository(OpenMusicDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ArtistDetailsDto> GetArtistDetailsAsync(int id)
        {
            var artist = await _dbContext.Artists
                    .Include(a => a.Albums)
                    .ThenInclude(al => al.Songs)
                    .ProjectTo<ArtistDetailsDto>(_mapper.ConfigurationProvider)
                    .FirstAsync(a => a.Id == id);
            return artist;
        }

        public async Task<ArtistReadOnlyDto> GetArtistReadOnlyAsync(int id)
        {
            var artist = await _dbContext.Artists
                    .Include(a => a.Albums)
                    .ProjectTo<ArtistDetailsDto>(_mapper.ConfigurationProvider)
                    .FirstAsync(a => a.Id == id);
            return _mapper.Map<ArtistReadOnlyDto>(artist);
        }

        public async Task<List<ArtistSelectDto>> GetArtistsForSelectAsync()
        {
            return await _dbContext.Artists
                    .ProjectTo<ArtistSelectDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<ArtistDetailsDto>> SearchForArtistAsync(QueryParams queryParams)
        {
            return await _dbContext.Artists
                .Where(s => s.Name.Contains(queryParams.queryString))
                .Include(a => a.Albums.Where(al => al.Title == queryParams.queryString))
                .Include(a => a.Songs)
                .Skip(queryParams.PageSize * (queryParams.PageNumber - 1))
                .Take(queryParams.PageSize)
                .ProjectTo<ArtistDetailsDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
