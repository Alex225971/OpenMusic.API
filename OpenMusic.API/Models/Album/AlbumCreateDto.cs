using OpenMusic.API.Models.Genre;
using OpenMusic.API.Models.Song;
using System.ComponentModel.DataAnnotations;

namespace OpenMusic.API.Models.Album
{
    public class AlbumCreateDto : BaseDto
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int Year { get; set; }
        public string? Image { get; set; }
        public int? ArtistId { get; set; }
        public List<SongInAlbumCreateDto>? Songs { get; set; }
        public List<GenreReadOnlyDto>? Genres { get; set; }
    }
}
