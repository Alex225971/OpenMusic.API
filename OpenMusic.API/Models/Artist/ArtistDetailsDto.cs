using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Artist
{
    public class ArtistDetailsDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
        public string? Bio { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Ended { get; set; }
        public int? TotalListeners { get; set; }
    }
}
