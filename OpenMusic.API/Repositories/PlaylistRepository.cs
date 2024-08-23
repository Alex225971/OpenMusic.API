using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Playlist;

namespace OpenMusic.API.Repositories
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        private readonly OpenMusicDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlaylistRepository(OpenMusicDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PlaylistPlaybackDto> GetPlaylistForPlaybackAsync(int id)
        {
            var playlist = await _dbContext.Playlists.FindAsync(id);
            return _mapper.Map<PlaylistPlaybackDto>(playlist);
        }

        public async Task<List<PlaylistPlaybackDto>> GetUserPlaylistsAsync(string creatorId)
        {
            return await _dbContext.Playlists
                .Where(pl => pl.CreatorId == creatorId)
                .Include(pl => pl.Songs)
                .ProjectTo<PlaylistPlaybackDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public Task UpdateAsync(Playlist entity)
        {
            throw new NotImplementedException();
        }
    }
}
