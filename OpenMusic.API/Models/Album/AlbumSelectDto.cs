using OpenMusic.API.Data;
using OpenMusic.API.Models.Genre;
using OpenMusic.API.Models.Song;

namespace OpenMusic.API.Models.Album
{
    public class AlbumSelectDto : BaseDto
    {
        public string Title { get; set; }
        public int? ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
}
