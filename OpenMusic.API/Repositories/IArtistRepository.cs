using OpenMusic.API.Data;
using OpenMusic.API.Models.Artist;

namespace OpenMusic.API.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<ArtistDetailsDto> GetArtistDetailsAsync(int id);
        Task<ArtistReadOnlyDto> GetArtistReadOnlyAsync(int id);
    }
}
