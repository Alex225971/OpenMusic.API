using OpenMusic.API.Models.Artist;
using OpenMusic.API.Models.Genre;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMusic.API.Models.Song
{
    public class SongCreateDto
    {
        public required string Title { get; set; }
        public required string SongUrl { get; set; }
        [JsonConverter(typeof(DateOnlyConverter))]
        public string? ReleaseDate { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumTitle { get; set; }
        public int? ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public List<GenreReadOnlyDto>? Genres { get; set; }
    }
}
