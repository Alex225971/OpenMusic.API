﻿using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Repositories
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        Task<SongPlaybackDto> GetForPlaybackAsync(int id);
        Task<SongDetailsDto> GetSongDetailsAsync(int id);
    }
}
