using OpenMusic.API.Configurations;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<ArtistDetailsDto> GetArtistDetailsAsync(int id);
        Task<ArtistReadOnlyDto> GetArtistReadOnlyAsync(int id);
        Task<List<ArtistDetailsDto>> SearchForArtistAsync(QueryParams queryParams);
    }
}
