using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;

namespace OpenMusic.API.Repositories
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<List<AlbumReadOnlyDto>> GetAllReadOnlyAsync();
        Task<AlbumDetailsDto> GetDetailsAsync(int id);
    }
}
