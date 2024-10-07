using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenMusic.API.Configurations;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Song;
using OpenMusic.API.Services;

namespace OpenMusic.API.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly OpenMusicDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISongService _songService;

        public AlbumRepository(OpenMusicDbContext dbContext, IMapper mapper, ISongService songService) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _songService = songService;
        }

        public async Task<AlbumDetailsDto> GetAlbumDetailsAsync(int id)
        {
            return await _dbContext.Albums
                .Include(a => a.Songs)
                .Include(a => a.Artist)
                .Include(a => a.AlbumGenres)
                .ProjectTo<AlbumDetailsDto>(_mapper.ConfigurationProvider)
                .FirstAsync(a => a.Id == id);
        }

        public async Task<List<AlbumSelectDto>> GetAlbumsFromArtist(int id)
        {
            return await _dbContext.Albums.ProjectTo<AlbumSelectDto>(_mapper.ConfigurationProvider).Where(a => a.ArtistId == id).ToListAsync();
        }

        public async Task<List<AlbumReadOnlyDto>> GetAllReadOnlyAsync()
        {
            return await _dbContext.Albums.Include(b => b.Artist).ProjectTo<AlbumReadOnlyDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<AlbumDetailsDto> GetDetailsAsync(int id)
        {
            return await _dbContext.Albums.Include(b => b.Artist).ProjectTo<AlbumDetailsDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<AlbumSearchDto>> SearchForAlbumAsync(QueryParams queryParams)
        {
            return await _dbContext.Albums
                .Include(s => s.Songs)
                .Where(a => a.Title.Contains(queryParams.queryString))
                .Skip(queryParams.PageSize * (queryParams.PageNumber - 1))
                .Take(queryParams.PageSize)
                .ProjectTo<AlbumSearchDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task UpdateAlbumWithSongs(int id, AlbumUpdateDto albumDto)
        {
            //First check the album exists
            var existingAlbum = await _dbContext.Albums
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.Id == id);

            //Throw an error if album isn't found
            if (existingAlbum == null)
            {
                throw new ArgumentException("Album not found.");
            }

            //Update the album properties
            existingAlbum.Title = albumDto.Title;
            existingAlbum.Year = (int)albumDto.Year;
            existingAlbum.ArtistId = albumDto.ArtistId;

            //Update or remove existing songs
            foreach (var existingSong in existingAlbum.Songs.ToList())
            {
                var updatedSong = albumDto.Songs.FirstOrDefault(s => s.Id == existingSong.Id);
                if (updatedSong != null)
                {
                    existingSong.ArtistId = albumDto.ArtistId;
                    //Update existing song properties
                    existingSong.Title = updatedSong.Title;
                    existingSong.ReleaseDate = DateOnly.Parse(updatedSong.ReleaseDate);
                }
                else
                {
                    //Remove song if not present in the updated album
                    existingAlbum.Songs.Remove(existingSong);
                    _dbContext.Songs.Remove(existingSong); // Mark the song for deletion
                }
            }

            //TODO - run a similar logic to song create as we need a public id and songUrl to be generated before inserting will work
            if (albumDto.Songs != null)
            {
                foreach (var newSong in albumDto.Songs.Where(s => s.Id == 0))
                {
                    var mappedNewSong = _mapper.Map<Song>(newSong);
                    mappedNewSong.AlbumId = id;
                    mappedNewSong.ArtistId = albumDto.ArtistId;

                    if (newSong.SongFile != null)
                    {
                        var result = await _songService.AddSongAsync(newSong.SongFile);
                        if (result.Error != null) throw new Exception();

                        mappedNewSong.SongUrl = result.SecureUrl.AbsoluteUri;
                        mappedNewSong.SongPublicId = result.PublicId;
                    }

                    existingAlbum.Songs.Add(mappedNewSong);
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
