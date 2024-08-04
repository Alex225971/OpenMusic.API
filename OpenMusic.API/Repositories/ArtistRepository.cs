using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Artist;

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
                    .ProjectTo<ArtistDetailsDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(a => a.Id == id);
            return artist;
        }
    }
}
