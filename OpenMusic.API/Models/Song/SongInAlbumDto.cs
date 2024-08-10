using OpenMusic.API.Models.Artist;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMusic.API.Models.Song
{
    public class SongInAlbumDto
    {
        public required string Title { get; set; }
        public string? ReleaseDate { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumTitle { get; set; }
    }
}
