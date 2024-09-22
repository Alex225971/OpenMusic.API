using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Configurations;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Playlist;
using OpenMusic.API.Models.Song;

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
            //TODO - once this is working fully it needs optimising, there's a lot of waste because i used existing dtos instead of making more fit for purpose dtos
            var playlist = await _dbContext.Playlists
                .Include(p => p.PlaylistSongs)
                .ThenInclude(ps => ps.Song)
                .ProjectTo<PlaylistPlaybackDto>(_mapper.ConfigurationProvider).FirstAsync(p => p.Id == id);

            if(playlist == null)
            {
                return null;
            }

            return new PlaylistPlaybackDto
            {
                CreatorId = playlist.CreatorId,
                Id = playlist.Id,
                Name = playlist.Name,
                ImageUrl = playlist.ImageUrl,
                ImagePublicId = playlist.ImagePublicId,
                Description = playlist.Description,
                Songs = playlist.PlaylistSongs.Select(ps => new SongPlaybackDto
                {
                    Id = ps.Song.Id,
                    Title = ps.Song.Title,
                    SongUrl = ps.Song.SongUrl,
                    //AlbumId = ps.Song.AlbumId,
                    //ArtistId = ps.Song.ArtistId,
                    //AlbumTitle = ps.Song.Album.Title,
                    //ArtistName = ps.Song.Artist.Name
                    Album = _dbContext.Albums.Where(a => a.Id == ps.Song.AlbumId).ProjectTo<AlbumReadOnlyDto>(_mapper.ConfigurationProvider).FirstOrDefault(),
                    Artist = _dbContext.Artists.Where(a => a.Id == ps.Song.ArtistId).ProjectTo<ArtistReadOnlyDto>(_mapper.ConfigurationProvider).FirstOrDefault(),

                }).ToList()
            };
        }

        public async Task<List<PlaylistPlaybackDto>> GetUserPlaylistsAsync(string creatorId)
        {
            return await _dbContext.Playlists
                .Where(pl => pl.CreatorId == creatorId)
                .Include(pl => pl.PlaylistSongs)
                .Where(pls => pls.CreatorId == creatorId)
                .ProjectTo<PlaylistPlaybackDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<PlaylistPlaybackDto>> SearchForPlaylistsAsync(QueryParams queryParams)
        {
            return await _dbContext.Playlists
                .Where(s => s.Name.Contains(queryParams.queryString))
                .Skip(queryParams.PageSize * (queryParams.PageNumber - 1))
                .Take(queryParams.PageSize)
                .ProjectTo<PlaylistPlaybackDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
