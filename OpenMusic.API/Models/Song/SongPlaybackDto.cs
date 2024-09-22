using OpenMusic.API.Data;
using OpenMusic.API.Models.Album;
using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Genre;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace OpenMusic.API.Models.Song
{
    public class SongPlaybackDto : BaseDto
    {
        public string Title { get; set; }
        public string SongUrl { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string? ArtistName { get; set; }
        public int? ArtistId { get; set; }
        public string? AlbumTitle { get; set; }
        public int? AlbumId { get; set; }
        public AlbumReadOnlyDto Album { get; set; }
        public ArtistReadOnlyDto Artist { get; set; }
        public List<SongGenre>? SongGenres { get; set; }
    }
}
