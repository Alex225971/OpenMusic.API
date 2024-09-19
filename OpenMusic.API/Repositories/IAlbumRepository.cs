using Microsoft.AspNetCore.Mvc;
using OpenMusic.API.Configurations;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Repositories
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<List<AlbumReadOnlyDto>> GetAllReadOnlyAsync();
        Task<AlbumDetailsDto> GetDetailsAsync(int id);
        Task<AlbumDetailsDto> GetAlbumDetailsAsync(int id);
        Task<List<AlbumDetailsDto>> GetAlbumsFromArtist(int id);
        Task<List<AlbumReadOnlyDto>> SearchForAlbumAsync(QueryParams queryParams);
        Task UpdateAlbumWithSongs(int id, AlbumUpdateDto albumDto);
    }
}
