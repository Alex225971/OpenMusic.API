using OpenMusic.API.Models.Artist;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMusic.API.Models.Song
{
    public class SongSearchDto : BaseDto
    {
        public required string Title { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string SongUrl { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumTitle { get; set; }
    }
}
