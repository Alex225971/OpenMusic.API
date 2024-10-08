﻿using OpenMusic.API.Configurations;
using OpenMusic.API.Data;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Playlist;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Repositories
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        Task<PlaylistPlaybackDto> GetPlaylistForPlaybackAsync(int id);
        Task<List<PlaylistPlaybackDto>> GetUserPlaylistsAsync(string id);
        Task<List<PlaylistPlaybackDto>> SearchForPlaylistsAsync(QueryParams queryParams);
    }
}
