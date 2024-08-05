using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Album
{
    public class AlbumUpdateDto : BaseDto
    {
        [StringLength(50)]
        public string? Title { get; set; }
        public int? Year { get; set; }
        public string? Image { get; set; }
        public string? Genre { get; set; }
        public int ArtistId { get; set; }
    }
}
