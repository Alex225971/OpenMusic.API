using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Models.Album
{
    public class AlbumReadOnlyDto : BaseDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string? Genre { get; set; }
        public string Image { get; set; }
        public string ArtistName { get; set; }
        public int ArtistId { get; set; }
        public List<SongPlaybackDto>? Songs { get; set; }
    }
}
