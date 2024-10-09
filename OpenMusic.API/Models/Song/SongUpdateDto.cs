using OpenMusic.API.Models.Genre;
using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Song
{
    public class SongUpdateDto
    {
        [Required]
        public string Title { get; set; }
        public string? Year { get; set; }
        public int? ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumtName { get; set; }
        public List<GenreReadOnlyDto>? Genres { get; set; }
    }
}
