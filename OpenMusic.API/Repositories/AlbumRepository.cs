using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;

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

        public async Task<List<AlbumDetailsDto>> GetAlbumDetailsAsync(int id)
        {
            return await _dbContext.Albums.Include(a => a.Artist).ProjectTo<AlbumDetailsDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public Task<List<AlbumReadOnlyDto>> GetAllReadOnlyAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AlbumDetailsDto> GetDetailsAsync(int id)
        {
            return await _dbContext.Albums.Include(b => b.Artist).ProjectTo<AlbumDetailsDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(b => b.Id == id);
        }
    }
}
