using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Song
{
    public class SongCreateDto
    {
        public required string Title { get; set; }
        public required string SongUrl { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public int? ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumtName { get; set; }
    }
}
