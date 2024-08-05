using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Artist
{
    public class ArtistUpdateDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Ended { get; set; }
    }
}
