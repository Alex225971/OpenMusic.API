using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Models.Album
{
    public class AlbumDetailsDto : BaseDto
    {
        public int Title { get; set; }
        public string Year { get; set; }
        public string? Genre { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public List<SongDetailsDto>? Songs { get; set; }
    }
}
