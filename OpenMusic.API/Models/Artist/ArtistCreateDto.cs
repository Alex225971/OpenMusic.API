using OpenMusic.API.Models.Album;
using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Artist
{
    public class ArtistCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string? Bio { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Ended { get; set; }
        public List<AlbumCreateDto>? Albums { get; set; }
    }
}
