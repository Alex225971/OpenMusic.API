using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Song
{
    public class SongDetailsDto : BaseDto
    {
        [Required]
        public string? Title { get; set; }
        public string? ReleaseDate { get; set; }
        public int TotalListeners { get; set; }
        public string SongUrl { get; set; }
        public int? ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumtName { get; set; }

    }
}
