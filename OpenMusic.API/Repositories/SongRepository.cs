using OpenMusic.API.Data;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Repositories
{
    public class SongRepository : ISongRepository
    {
        public Task<Song> AddAsync(Song entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Song>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Song> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<SongDetailsDto> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SongPlaybackDto>> GetForPlaybackAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Song entity)
        {
            throw new NotImplementedException();
        }
    }
}
